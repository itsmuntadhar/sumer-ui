using System.Text;
using SumerUI.Elements;

namespace SumerUI.Renderers;

public partial class HtmlRenderer : IRenderer
{
    private readonly bool _minify;
    private readonly Dictionary<string, Dictionary<string, Dictionary<string, string>>> _mediaQueries = new();

    public HtmlRenderer(bool minify = false)
    {
        _minify = minify;
    }

    public Stream RenderToStream(Element element)
    {
        var html = RenderToString(element);
        var bytes = Encoding.UTF8.GetBytes(html);
        return new MemoryStream(bytes);
    }

    public string RenderToString(Element element)
    {
        _mediaQueries.Clear(); // Reset for each render

        var sb = new StringBuilder();
        RenderElement(element, sb);

        var result = sb.ToString();

        // Inject responsive styles if any media queries were collected
        if (_mediaQueries.Count > 0)
        {
            result = InjectResponsiveStyles(result);
        }

        if (_minify)
        {
            result = MinifyHtml(result);
        }

        return result;
    }

    private static string MinifyHtml(string html)
    {
        html = RemoveSpaceRegex().Replace(html, " ");
        html = RemoveSpaceBetweenTagsRegex().Replace(html, "><");
        return html.Trim();
    }

    private string InjectResponsiveStyles(string html)
    {
        var styleTag = GenerateResponsiveStylesTag();

        var headEndIndex = html.IndexOf("</head>", StringComparison.OrdinalIgnoreCase);
        if (headEndIndex >= 0)
        {
            return html.Insert(headEndIndex, styleTag);
        }

        var htmlStartIndex = html.IndexOf("<html", StringComparison.OrdinalIgnoreCase);
        if (htmlStartIndex >= 0)
        {
            var tagEndIndex = html.IndexOf('>', htmlStartIndex);
            if (tagEndIndex >= 0)
            {
                return html.Insert(tagEndIndex + 1, styleTag);
            }
        }

        return styleTag + html;
    }

    private string GenerateResponsiveStylesTag()
    {
        var sb = new StringBuilder();
        sb.Append("<style>");

        if (_mediaQueries.TryGetValue("base", out var baseStyles))
        {
            foreach (var selector in baseStyles)
            {
                sb.Append('.').Append(selector.Key).Append('{');

                foreach (var style in selector.Value)
                {
                    sb.Append(style.Key).Append(':').Append(style.Value).Append(';');
                }

                sb.Append('}');
            }
        }

        var orderedMediaQueries = _mediaQueries
            .Where(mq => mq.Key != "base")
            .OrderBy(mq => ExtractBreakpointValue(mq.Key));

        foreach (var mediaQuery in orderedMediaQueries)
        {
            sb.Append("@media ").Append(mediaQuery.Key).Append('{');

            foreach (var selector in mediaQuery.Value)
            {
                sb.Append('.').Append(selector.Key).Append('{');

                foreach (var style in selector.Value)
                {
                    sb.Append(style.Key).Append(':').Append(style.Value).Append(';');
                }

                sb.Append('}');
            }

            sb.Append('}');
        }

        sb.Append("</style>");
        return sb.ToString();
    }

    private static int ExtractBreakpointValue(string mediaQuery)
    {
        var match = MediaQueryRegex().Match(mediaQuery);
        return match.Success ? int.Parse(match.Groups[1].Value) : 0;
    }

    private void RenderElement(Element element, StringBuilder sb)
    {
        if (string.IsNullOrWhiteSpace(element.Tag))
        {
            if (!string.IsNullOrEmpty(element.TextContent))
            {
                sb.Append(EscapeText(element.TextContent));
            }

            foreach (var c in element.Children)
            {
                RenderElement(c, sb);
            }

            return;
        }

        sb.Append('<').Append(element.Tag);

        // Collect responsive styles if present
        if (element.ResponsiveStyles.Count > 0 && !string.IsNullOrEmpty(element.ResponsiveId))
        {
            foreach (var mediaQuery in element.ResponsiveStyles)
            {
                if (!_mediaQueries.TryGetValue(mediaQuery.Key, out Dictionary<string, Dictionary<string, string>>? value1))
                {
                    value1 = new Dictionary<string, Dictionary<string, string>>();
                    _mediaQueries[mediaQuery.Key] = value1;
                }

                value1[element.ResponsiveId] = mediaQuery.Value;
            }

            if (!element.Attributes.TryGetValue("class", out string? value))
            {
                element.Attributes["class"] = element.ResponsiveId;
            }
            else if (!value.Contains(element.ResponsiveId))
            {
                element.Attributes["class"] += " " + element.ResponsiveId;
            }
        }

        if (element.Attributes.Count > 0)
        {
            foreach (var kv in element.Attributes)
            {
                sb.Append(' ').Append(kv.Key).Append("=\"").Append(EscapeAttr(kv.Value)).Append('"');
            }
        }

        if (element.Styles.Count > 0)
        {
            sb.Append(" style=\"");
            foreach (var kv in element.Styles)
            {
                sb.Append(kv.Key).Append(':').Append(EscapeAttr(kv.Value)).Append(';');
            }
            sb.Append('"');
        }

        if (IsSelfClosing(element.Tag) && element.Children.Count == 0 && string.IsNullOrEmpty(element.TextContent))
        {
            sb.Append(" />");
            return;
        }

        sb.Append('>');

        if (!string.IsNullOrEmpty(element.TextContent))
        {
            sb.Append(EscapeText(element.TextContent));
        }

        foreach (var c in element.Children)
        {
            RenderElement(c, sb);
        }

        sb.Append("</").Append(element.Tag).Append('>');
    }

    private static string EscapeAttr(string s) => s.Replace("\"", "&quot;").Replace("<", "&lt;").Replace(">", "&gt;");
    private static string EscapeText(string s) => s.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");

    private static bool IsSelfClosing(string tag)
    {
        var set = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "img", "input", "br", "hr", "meta", "link" };
        return set.Contains(tag);
    }

    [System.Text.RegularExpressions.GeneratedRegex(@"\s+")]
    private static partial System.Text.RegularExpressions.Regex RemoveSpaceRegex();

    [System.Text.RegularExpressions.GeneratedRegex(@">\s+<")]
    private static partial System.Text.RegularExpressions.Regex RemoveSpaceBetweenTagsRegex();

    [System.Text.RegularExpressions.GeneratedRegex(@"(\d+)px")]
    private static partial System.Text.RegularExpressions.Regex MediaQueryRegex();
}
