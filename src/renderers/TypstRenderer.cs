using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using SumerUI.Elements;

namespace SumerUI.Renderers;

public sealed class TypstRenderer : IRenderer
{
    private const string UnsupportedAttributeCode = "TYPST001";
    private const string OmittedElementCode = "TYPST002";
    private const string TransparentElementCode = "TYPST003";
    private const string UnsupportedStyleCode = "TYPST004";
    private const string ResponsiveStyleCode = "TYPST005";

    private static readonly HashSet<string> TransparentElements =
        new(StringComparer.OrdinalIgnoreCase) { "form", "button", "label", "select", "option", "textarea" };
    private static readonly HashSet<string> OmittedElements =
        new(StringComparer.OrdinalIgnoreCase) { "meta", "link", "script", "input", "style" };
    private static readonly Regex LengthPattern =
        new(@"^\s*(-?\d+(?:\.\d+)?)\s*(px|rem|pt|em|%|cm|mm|in)\s*$", RegexOptions.IgnoreCase);
    private static readonly Regex NumberPattern =
        new(@"^\s*(-?\d+(?:\.\d+)?)\s*$", RegexOptions.IgnoreCase);
    private static readonly Regex FunctionPattern =
        new(@"^\s*([a-zA-Z]+)\((.*)\)\s*$", RegexOptions.IgnoreCase);
    private static readonly Regex GridRepeatPattern =
        new(@"^\s*repeat\(\s*(\d+)\s*,", RegexOptions.IgnoreCase);

    private readonly TypstRendererOptions _options;
    private readonly List<TypstDiagnostic> _diagnostics = [];

    public TypstRenderer(TypstRendererOptions? options = null)
    {
        _options = options ?? new TypstRendererOptions();
        if (_options.RootFontSizeInPoints <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(options), "Root font size must be greater than zero.");
        }
    }

    public IReadOnlyList<TypstDiagnostic> Diagnostics => _diagnostics;

    public Stream RenderToStream(Element element)
    {
        return new MemoryStream(Encoding.UTF8.GetBytes(RenderToString(element)));
    }

    public string RenderToString(Element element)
    {
        ArgumentNullException.ThrowIfNull(element);
        _diagnostics.Clear();
        return RenderElement(element, $"/{PathName(element)}");
    }

    private string RenderElement(Element element, string path)
    {
        WarnResponsiveStyles(element, path);

        var tag = element.Tag.ToLowerInvariant();
        WarnAttributes(element, tag, path);

        if (OmittedElements.Contains(tag))
        {
            WarnStylesOnOmittedElement(element, path);
            AddDiagnostic(
                OmittedElementCode,
                $"Element '{element.Tag}' has no Typst document equivalent and was omitted.",
                path);
            return "";
        }

        if (tag == "head")
        {
            return RenderHead(element, path);
        }

        if (tag == "title")
        {
            WarnStylesOnOmittedElement(element, path);
            AddDiagnostic(
                OmittedElementCode,
                "A title is only translated when it appears within a head element.",
                path);
            return "";
        }

        if (tag.Length > 0 && TransparentElements.Contains(tag))
        {
            AddDiagnostic(
                TransparentElementCode,
                $"Element '{element.Tag}' was rendered as transparent document content.",
                path);
        }

        var consumed = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var core = RenderCore(element, tag, path, consumed);
        return ApplyStyles(element, core, path, consumed);
    }

    private string RenderCore(Element element, string tag, string path, HashSet<string> consumed)
    {
        if (tag == "div" && IsGrid(element))
        {
            return RenderGrid(element, path, consumed);
        }

        if (tag == "div" && IsFlex(element))
        {
            return RenderStack(element, path, consumed);
        }

        var content = RenderContent(element, path);

        return tag switch
        {
            "" or "html" or "body" => content,
            "div" => $"#block[{content}]",
            "span" => content,
            "p" => $"#par()[{content}]",
            "h1" => $"#heading(level: 1)[{content}]",
            "h2" => $"#heading(level: 2)[{content}]",
            "h3" => $"#heading(level: 3)[{content}]",
            "h4" => $"#heading(level: 4)[{content}]",
            "h5" => $"#heading(level: 5)[{content}]",
            "h6" => $"#heading(level: 6)[{content}]",
            "a" => RenderLink(element, content),
            "ul" => RenderList(element, path),
            "li" => content,
            _ when TransparentElements.Contains(tag) => content,
            _ => RenderUnknownElement(element, content, path)
        };
    }

    private string RenderHead(Element element, string path)
    {
        WarnStylesOnOmittedElement(element, path);

        var output = new List<string>();
        for (var i = 0; i < element.Children.Count; i++)
        {
            var child = element.Children[i];
            var childPath = ChildPath(path, child, i);
            if (child.Tag.Equals("title", StringComparison.OrdinalIgnoreCase))
            {
                WarnResponsiveStyles(child, childPath);
                WarnAttributes(child, "title", childPath);
                WarnStylesOnOmittedElement(child, childPath);
                output.Add($"#set document(title: [{EscapeContent(GetPlainText(child))}])");
            }
            else
            {
                var ignored = RenderElement(child, childPath);
                if (!OmittedElements.Contains(child.Tag) && ignored.Length > 0)
                {
                    AddDiagnostic(
                        OmittedElementCode,
                        $"Element '{child.Tag}' inside head does not produce Typst document content and was omitted.",
                        childPath);
                }
            }
        }

        return string.Join("\n", output);
    }

    private string RenderUnknownElement(Element element, string content, string path)
    {
        AddDiagnostic(
            TransparentElementCode,
            $"Unknown element '{element.Tag}' was rendered as transparent document content.",
            path);
        return content;
    }

    private string RenderLink(Element element, string content)
    {
        if (!element.Attributes.TryGetValue("href", out var href))
        {
            return content;
        }

        return $"#link(\"{EscapeString(href)}\")[{content}]";
    }

    private string RenderList(Element element, string path)
    {
        var items = new List<string>();
        for (var i = 0; i < element.Children.Count; i++)
        {
            var child = element.Children[i];
            var rendered = RenderElement(child, ChildPath(path, child, i));
            items.Add($"  [{rendered}]");
        }

        if (!string.IsNullOrEmpty(element.TextContent))
        {
            items.Insert(0, $"  [{EscapeContent(element.TextContent)}]");
        }

        return items.Count == 0 ? "" : $"#list(\n{string.Join(",\n", items)}\n)";
    }

    private string RenderGrid(Element element, string path, HashSet<string> consumed)
    {
        consumed.Add("display");
        var args = new List<string>();

        if (TryGetStyle(element, "grid-template-columns", out var columns))
        {
            consumed.Add("grid-template-columns");
            var match = GridRepeatPattern.Match(columns);
            if (match.Success)
            {
                args.Add($"columns: {match.Groups[1].Value}");
            }
            else
            {
                WarnUnsupportedStyle(path, "grid-template-columns", columns);
            }
        }

        if (TryGetStyle(element, "grid-template-rows", out var rows))
        {
            consumed.Add("grid-template-rows");
            var match = GridRepeatPattern.Match(rows);
            if (match.Success)
            {
                args.Add($"rows: {match.Groups[1].Value}");
            }
            else
            {
                WarnUnsupportedStyle(path, "grid-template-rows", rows);
            }
        }

        if (TryGetStyle(element, "gap", out var gap))
        {
            consumed.Add("gap");
            if (TryLength(gap, out var length))
            {
                args.Add($"gutter: {length}");
            }
            else
            {
                WarnUnsupportedStyle(path, "gap", gap);
            }
        }

        var cells = RenderCells(element, path);
        var arguments = args.Concat(cells).ToList();
        return $"#grid({string.Join(", ", arguments)})";
    }

    private string RenderStack(Element element, string path, HashSet<string> consumed)
    {
        consumed.Add("display");
        var args = new List<string>();
        if (TryGetStyle(element, "flex-direction", out var direction))
        {
            consumed.Add("flex-direction");
            args.Add(direction.Equals("row", StringComparison.OrdinalIgnoreCase) ? "dir: ltr" : "dir: ttb");
            if (!direction.Equals("row", StringComparison.OrdinalIgnoreCase) &&
                !direction.Equals("column", StringComparison.OrdinalIgnoreCase))
            {
                WarnUnsupportedStyle(path, "flex-direction", direction);
            }
        }

        if (TryGetStyle(element, "gap", out var gap))
        {
            consumed.Add("gap");
            if (TryLength(gap, out var length))
            {
                args.Add($"spacing: {length}");
            }
            else
            {
                WarnUnsupportedStyle(path, "gap", gap);
            }
        }

        args.AddRange(RenderCells(element, path));
        return $"#stack({string.Join(", ", args)})";
    }

    private List<string> RenderCells(Element element, string path)
    {
        var cells = new List<string>();
        if (!string.IsNullOrEmpty(element.TextContent))
        {
            cells.Add($"[{EscapeContent(element.TextContent)}]");
        }

        for (var i = 0; i < element.Children.Count; i++)
        {
            cells.Add($"[{RenderElement(element.Children[i], ChildPath(path, element.Children[i], i))}]");
        }

        return cells;
    }

    private string RenderContent(Element element, string path)
    {
        var fragments = new List<string>();
        if (!string.IsNullOrEmpty(element.TextContent))
        {
            fragments.Add(EscapeContent(element.TextContent));
        }

        for (var i = 0; i < element.Children.Count; i++)
        {
            var rendered = RenderElement(element.Children[i], ChildPath(path, element.Children[i], i));
            if (rendered.Length > 0)
            {
                fragments.Add(rendered);
            }
        }

        var separator = element.Tag is "html" or "body" or "div" ? "\n" : "";
        return string.Join(separator, fragments);
    }

    private string ApplyStyles(Element element, string core, string path, HashSet<string> consumed)
    {
        var hidden = false;
        if (TryGetStyle(element, "display", out var display))
        {
            consumed.Add("display");
            if (display.Equals("none", StringComparison.OrdinalIgnoreCase))
            {
                hidden = true;
            }
            else if (!display.Equals("block", StringComparison.OrdinalIgnoreCase) &&
                !display.Equals("inline", StringComparison.OrdinalIgnoreCase) &&
                !display.Equals("inline-block", StringComparison.OrdinalIgnoreCase) &&
                !display.Equals("grid", StringComparison.OrdinalIgnoreCase) &&
                !display.Equals("flex", StringComparison.OrdinalIgnoreCase))
            {
                WarnUnsupportedStyle(path, "display", display);
            }
            else if ((display.Equals("grid", StringComparison.OrdinalIgnoreCase) ||
                      display.Equals("flex", StringComparison.OrdinalIgnoreCase)) &&
                     !element.Tag.Equals("div", StringComparison.OrdinalIgnoreCase))
            {
                WarnUnsupportedStyle(path, "display", display);
            }
        }

        core = ApplyTextStyles(element, core, path, consumed);
        core = ApplyDecorationStyles(element, core, path, consumed);
        core = ApplyContainerStyles(element, core, path, consumed);
        core = ApplyAlignment(element, core, path, consumed);
        core = ApplyTransform(element, core, path, consumed);

        foreach (var style in element.Styles.OrderBy(pair => pair.Key, StringComparer.Ordinal))
        {
            if (!consumed.Contains(style.Key))
            {
                WarnUnsupportedStyle(path, style.Key, style.Value);
            }
        }

        return hidden ? "" : core;
    }

    private string ApplyTextStyles(Element element, string core, string path, HashSet<string> consumed)
    {
        var args = new List<string>();
        AddLengthArgument(element, "font-size", "size", args, consumed, path);
        AddLengthArgument(element, "letter-spacing", "tracking", args, consumed, path);

        if (TryGetStyle(element, "font-family", out var family))
        {
            consumed.Add("font-family");
            var primary = family.Split(',')[0].Trim().Trim('"', '\'');
            args.Add($"font: \"{EscapeString(primary)}\"");
        }

        if (TryGetStyle(element, "font-weight", out var weight))
        {
            consumed.Add("font-weight");
            args.Add(NumberPattern.IsMatch(weight)
                ? $"weight: {weight.Trim()}"
                : $"weight: \"{EscapeString(weight)}\"");
        }

        if (TryGetStyle(element, "font-style", out var fontStyle))
        {
            consumed.Add("font-style");
            if (fontStyle is "italic" or "normal")
            {
                args.Add($"style: \"{fontStyle}\"");
            }
            else
            {
                WarnUnsupportedStyle(path, "font-style", fontStyle);
            }
        }

        if (TryGetStyle(element, "color", out var color))
        {
            consumed.Add("color");
            if (TryColor(color, out var converted))
            {
                args.Add($"fill: {converted}");
            }
            else
            {
                WarnUnsupportedStyle(path, "color", color);
            }
        }

        if (TryGetStyle(element, "font-variant-numeric", out var numeric))
        {
            consumed.Add("font-variant-numeric");
            if (numeric == "oldstyle-nums")
            {
                args.Add("number-type: \"old-style\"");
            }
            else if (numeric == "tabular-nums")
            {
                args.Add("number-width: \"tabular\"");
            }
            else if (numeric != "normal")
            {
                WarnUnsupportedStyle(path, "font-variant-numeric", numeric);
            }
        }

        if (TryGetStyle(element, "font-variant", out var variant))
        {
            consumed.Add("font-variant");
            if (variant == "small-caps")
            {
                core = $"#smallcaps[{core}]";
            }
            else
            {
                WarnUnsupportedStyle(path, "font-variant", variant);
            }
        }

        if (TryGetStyle(element, "line-height", out var leading))
        {
            consumed.Add("line-height");
            if (TryLengthOrUnitlessEm(leading, out var converted))
            {
                core = $"#par(leading: {converted})[{core}]";
            }
            else
            {
                WarnUnsupportedStyle(path, "line-height", leading);
            }
        }

        return args.Count > 0 ? $"#text({string.Join(", ", args)})[{core}]" : core;
    }

    private string ApplyDecorationStyles(Element element, string core, string path, HashSet<string> consumed)
    {
        if (TryGetStyle(element, "text-decoration-line", out var line))
        {
            consumed.Add("text-decoration-line");
            core = line switch
            {
                "underline" => $"#underline[{core}]",
                "overline" => $"#overline[{core}]",
                "line-through" => $"#strike[{core}]",
                "none" => core,
                _ => WarnAndKeepStyle(core, path, "text-decoration-line", line)
            };
        }

        if (TryGetStyle(element, "text-decoration-style", out var style))
        {
            consumed.Add("text-decoration-style");
            if (style != "solid")
            {
                WarnUnsupportedStyle(path, "text-decoration-style", style);
            }
        }

        return core;
    }

    private string ApplyContainerStyles(Element element, string core, string path, HashSet<string> consumed)
    {
        var blockArgs = new List<string>();
        AddLengthArgument(element, "width", "width", blockArgs, consumed, path);
        AddLengthArgument(element, "height", "height", blockArgs, consumed, path);
        AddLengthArgument(element, "border-radius", "radius", blockArgs, consumed, path);

        if (TryGetStyle(element, "background-color", out var background))
        {
            consumed.Add("background-color");
            if (TryColor(background, out var converted))
            {
                blockArgs.Add($"fill: {converted}");
            }
            else
            {
                WarnUnsupportedStyle(path, "background-color", background);
            }
        }

        var stroke = RenderStroke(element, path, consumed);
        if (stroke != null)
        {
            blockArgs.Add($"stroke: {stroke}");
        }

        if (TryGetStyle(element, "overflow", out var overflow))
        {
            consumed.Add("overflow");
            if (overflow == "hidden")
            {
                blockArgs.Add("clip: true");
            }
            else
            {
                WarnUnsupportedStyle(path, "overflow", overflow);
            }
        }

        AddVerticalSpacing(element, blockArgs, path, consumed);
        if (blockArgs.Count > 0)
        {
            core = $"#block({string.Join(", ", blockArgs)})[{core}]";
        }

        if (TryGetStyle(element, "padding", out var padding))
        {
            consumed.Add("padding");
            if (TryInsets(padding, out var insetArgs))
            {
                core = $"#pad({insetArgs})[{core}]";
            }
            else
            {
                WarnUnsupportedStyle(path, "padding", padding);
            }
        }

        if (TryGetStyle(element, "opacity", out var opacity))
        {
            consumed.Add("opacity");
            if (TryOpacity(opacity, out var percentage))
            {
                core = $"#opacity({percentage})[{core}]";
            }
            else
            {
                WarnUnsupportedStyle(path, "opacity", opacity);
            }
        }

        return core;
    }

    private string? RenderStroke(Element element, string path, HashSet<string> consumed)
    {
        var arguments = new List<string>();
        if (TryGetStyle(element, "border-width", out var width))
        {
            consumed.Add("border-width");
            if (TryLength(width, out var converted))
            {
                arguments.Add($"thickness: {converted}");
            }
            else
            {
                WarnUnsupportedStyle(path, "border-width", width);
            }
        }

        if (TryGetStyle(element, "border-color", out var color))
        {
            consumed.Add("border-color");
            if (TryColor(color, out var converted))
            {
                arguments.Add($"paint: {converted}");
            }
            else
            {
                WarnUnsupportedStyle(path, "border-color", color);
            }
        }

        if (TryGetStyle(element, "border-style", out var style))
        {
            consumed.Add("border-style");
            if (!style.Equals("solid", StringComparison.OrdinalIgnoreCase))
            {
                WarnUnsupportedStyle(path, "border-style", style);
            }
        }

        return arguments.Count == 0 ? null : $"({string.Join(", ", arguments)})";
    }

    private void AddVerticalSpacing(Element element, List<string> args, string path, HashSet<string> consumed)
    {
        AddLengthArgument(element, "margin-top", "above", args, consumed, path);
        AddLengthArgument(element, "margin-bottom", "below", args, consumed, path);

        if (!TryGetStyle(element, "margin", out var margin))
        {
            return;
        }

        consumed.Add("margin");
        var parts = margin.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 1 && TryLength(parts[0], out var all))
        {
            args.Add($"above: {all}");
            args.Add($"below: {all}");
            return;
        }
        if (parts.Length >= 2 &&
            TryLength(parts[0], out var vertical) &&
            IsZeroLength(parts[1]))
        {
            args.Add($"above: {vertical}");
            args.Add($"below: {vertical}");
            return;
        }

        WarnUnsupportedStyle(path, "margin", margin);
    }

    private string ApplyAlignment(Element element, string core, string path, HashSet<string> consumed)
    {
        if (!TryGetStyle(element, "text-align", out var alignment))
        {
            return core;
        }

        consumed.Add("text-align");
        return alignment switch
        {
            "left" => $"#align(left)[{core}]",
            "center" => $"#align(center)[{core}]",
            "right" => $"#align(right)[{core}]",
            _ => WarnAndKeepStyle(core, path, "text-align", alignment)
        };
    }

    private string ApplyTransform(Element element, string core, string path, HashSet<string> consumed)
    {
        if (!TryGetStyle(element, "transform", out var transform))
        {
            return core;
        }

        consumed.Add("transform");
        var match = FunctionPattern.Match(transform);
        if (!match.Success)
        {
            WarnUnsupportedStyle(path, "transform", transform);
            return core;
        }

        var values = match.Groups[2].Value.Split(',', StringSplitOptions.TrimEntries);
        switch (match.Groups[1].Value.ToLowerInvariant())
        {
            case "rotate" when values.Length == 1 && TryAngle(values[0], out var angle):
                return $"#rotate({angle})[{core}]";
            case "scale" when values.Length is 1 or 2 &&
                                   TryScale(values[0], out var x) &&
                                   TryScale(values.Length == 1 ? values[0] : values[1], out var y):
                return $"#scale(x: {x}, y: {y})[{core}]";
            case "translate" when values.Length == 2 &&
                                       TryLength(values[0], out var dx) &&
                                       TryLength(values[1], out var dy):
                return $"#move(dx: {dx}, dy: {dy})[{core}]";
            case "translatex" when values.Length == 1 && TryLength(values[0], out var onlyX):
                return $"#move(dx: {onlyX})[{core}]";
            case "translatey" when values.Length == 1 && TryLength(values[0], out var onlyY):
                return $"#move(dy: {onlyY})[{core}]";
            case "skew" when values.Length == 2 &&
                                  TryAngle(values[0], out var ax) &&
                                  TryAngle(values[1], out var ay):
                return $"#skew(ax: {ax}, ay: {ay})[{core}]";
            case "skewx" when values.Length == 1 && TryAngle(values[0], out var onlyAx):
                return $"#skew(ax: {onlyAx})[{core}]";
            case "skewy" when values.Length == 1 && TryAngle(values[0], out var onlyAy):
                return $"#skew(ay: {onlyAy})[{core}]";
            default:
                WarnUnsupportedStyle(path, "transform", transform);
                return core;
        }
    }

    private void WarnAttributes(Element element, string tag, string path)
    {
        foreach (var attribute in element.Attributes.OrderBy(pair => pair.Key, StringComparer.Ordinal))
        {
            if (tag == "a" && attribute.Key.Equals("href", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            AddDiagnostic(
                UnsupportedAttributeCode,
                $"Attribute '{attribute.Key}' is not translated to Typst.",
                path,
                attribute.Key,
                attribute.Value);
        }
    }

    private void WarnResponsiveStyles(Element element, string path)
    {
        foreach (var responsiveStyle in element.ResponsiveStyles.OrderBy(pair => pair.Key, StringComparer.Ordinal))
        {
            AddDiagnostic(
                ResponsiveStyleCode,
                "Responsive styles do not have a static Typst equivalent and were omitted.",
                path,
                "responsive",
                responsiveStyle.Key);
        }
    }

    private void WarnStylesOnOmittedElement(Element element, string path)
    {
        foreach (var style in element.Styles.OrderBy(pair => pair.Key, StringComparer.Ordinal))
        {
            WarnUnsupportedStyle(path, style.Key, style.Value);
        }
    }

    private void AddLengthArgument(
        Element element,
        string property,
        string argument,
        List<string> args,
        HashSet<string> consumed,
        string path)
    {
        if (!TryGetStyle(element, property, out var value))
        {
            return;
        }

        consumed.Add(property);
        if (TryLength(value, out var converted))
        {
            args.Add($"{argument}: {converted}");
        }
        else
        {
            WarnUnsupportedStyle(path, property, value);
        }
    }

    private void WarnUnsupportedStyle(string path, string property, string value)
    {
        AddDiagnostic(
            UnsupportedStyleCode,
            $"Style '{property}' cannot be faithfully translated to Typst and was omitted.",
            path,
            property,
            value);
    }

    private string WarnAndKeepStyle(string core, string path, string property, string value)
    {
        WarnUnsupportedStyle(path, property, value);
        return core;
    }

    private void AddDiagnostic(string code, string message, string path, string? property = null, string? value = null)
    {
        _diagnostics.Add(new TypstDiagnostic(code, message, path, property, value));
    }

    private bool TryLength(string value, out string converted)
    {
        if (Regex.IsMatch(value.Trim(), @"^0(?:\.0+)?$"))
        {
            converted = "0pt";
            return true;
        }

        var match = LengthPattern.Match(value);
        if (!match.Success)
        {
            converted = "";
            return false;
        }

        var number = double.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
        var unit = match.Groups[2].Value.ToLowerInvariant();
        converted = unit switch
        {
            "px" => $"{FormatNumber(number * 0.75)}pt",
            "rem" => $"{FormatNumber(number * _options.RootFontSizeInPoints)}pt",
            _ => $"{FormatNumber(number)}{unit}"
        };
        return true;
    }

    private bool TryLengthOrUnitlessEm(string value, out string converted)
    {
        if (TryLength(value, out converted))
        {
            return true;
        }

        var match = NumberPattern.Match(value);
        if (match.Success)
        {
            converted = $"{match.Groups[1].Value}em";
            return true;
        }

        converted = "";
        return false;
    }

    private bool TryInsets(string value, out string arguments)
    {
        var parts = value.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var converted = new List<string>();
        foreach (var part in parts)
        {
            if (!TryLength(part, out var length))
            {
                arguments = "";
                return false;
            }
            converted.Add(length);
        }

        arguments = converted.Count switch
        {
            1 => $"rest: {converted[0]}",
            2 => $"y: {converted[0]}, x: {converted[1]}",
            4 => $"top: {converted[0]}, right: {converted[1]}, bottom: {converted[2]}, left: {converted[3]}",
            _ => ""
        };
        return arguments.Length > 0;
    }

    private static bool TryColor(string value, out string converted)
    {
        var trimmed = value.Trim();
        if (Regex.IsMatch(trimmed, @"^#[0-9a-fA-F]{3,8}$"))
        {
            converted = $"rgb(\"{trimmed}\")";
            return true;
        }

        var rgba = Regex.Match(
            trimmed,
            @"^rgba\(\s*(\d+)\s*,\s*(\d+)\s*,\s*(\d+)\s*,\s*(\d+(?:\.\d+)?%?)\s*\)$",
            RegexOptions.IgnoreCase);
        if (rgba.Success)
        {
            var alpha = rgba.Groups[4].Value;
            if (!alpha.EndsWith('%') &&
                double.TryParse(alpha, NumberStyles.Float, CultureInfo.InvariantCulture, out var ratio))
            {
                alpha = $"{FormatNumber(ratio * 100)}%";
            }
            converted = $"rgb({rgba.Groups[1].Value}, {rgba.Groups[2].Value}, {rgba.Groups[3].Value}, {alpha})";
            return true;
        }

        if (Regex.IsMatch(trimmed, @"^rgb\([\d\s.,%]+\)$", RegexOptions.IgnoreCase))
        {
            converted = trimmed.ToLowerInvariant();
            return true;
        }

        converted = "";
        return false;
    }

    private static bool TryOpacity(string value, out string converted)
    {
        var match = NumberPattern.Match(value);
        if (match.Success &&
            double.TryParse(match.Groups[1].Value, NumberStyles.Float, CultureInfo.InvariantCulture, out var opacity) &&
            opacity >= 0 &&
            opacity <= 1)
        {
            converted = $"{FormatNumber(opacity * 100)}%";
            return true;
        }

        converted = "";
        return false;
    }

    private static bool TryAngle(string value, out string converted)
    {
        var match = Regex.Match(value.Trim(), @"^(-?\d+(?:\.\d+)?)\s*(deg|rad)$", RegexOptions.IgnoreCase);
        if (match.Success)
        {
            converted = $"{match.Groups[1].Value}{match.Groups[2].Value.ToLowerInvariant()}";
            return true;
        }

        converted = "";
        return false;
    }

    private static bool TryScale(string value, out string converted)
    {
        if (double.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out var scale))
        {
            converted = $"{FormatNumber(scale * 100)}%";
            return true;
        }

        converted = "";
        return false;
    }

    private static bool TryGetStyle(Element element, string property, out string value)
    {
        return element.Styles.TryGetValue(property, out value!);
    }

    private static bool IsGrid(Element element)
    {
        return TryGetStyle(element, "display", out var display) &&
               display.Equals("grid", StringComparison.OrdinalIgnoreCase);
    }

    private static bool IsFlex(Element element)
    {
        return TryGetStyle(element, "display", out var display) &&
               display.Equals("flex", StringComparison.OrdinalIgnoreCase);
    }

    private static bool IsZeroLength(string value)
    {
        return Regex.IsMatch(value.Trim(), @"^0(?:\.0+)?(?:px|rem|pt|em|%|cm|mm|in)?$", RegexOptions.IgnoreCase);
    }

    private static string GetPlainText(Element element)
    {
        var text = new StringBuilder(element.TextContent);
        foreach (var child in element.Children)
        {
            text.Append(GetPlainText(child));
        }
        return text.ToString();
    }

    private static string PathName(Element element)
    {
        return string.IsNullOrEmpty(element.Tag) ? "content" : element.Tag.ToLowerInvariant();
    }

    private static string ChildPath(string parentPath, Element child, int index)
    {
        return $"{parentPath}/{PathName(child)}[{index}]";
    }

    private static string EscapeString(string value)
    {
        return value
            .Replace("\\", "\\\\")
            .Replace("\"", "\\\"")
            .Replace("\r", "")
            .Replace("\n", "\\n");
    }

    private static string EscapeContent(string value)
    {
        var sb = new StringBuilder();
        foreach (var character in value)
        {
            if ("\\#[]$*_`<>@".Contains(character))
            {
                sb.Append('\\');
            }
            sb.Append(character);
        }
        return sb.ToString();
    }

    private static string FormatNumber(double value)
    {
        return value.ToString("0.###", CultureInfo.InvariantCulture);
    }
}
