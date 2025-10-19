using System.Text;
using SumerUI.Elements;

namespace SumerUI.Renderers;

public partial class HtmlRenderer : IRenderer
{
    private readonly bool _minify;

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
        var sb = new StringBuilder();
        RenderElement(element, sb);

        var result = sb.ToString();
        if (_minify)
        {
            result = MinifyHtml(result);
        }

        return result;
    }

    private string MinifyHtml(string html)
    {
        html = RemoveSpaceRegex().Replace(html, " ");
        html = RemoveSpaceBetweenTagsRegex().Replace(html, "><");
        return html.Trim();
    }

    private static void RenderElement(Element element, StringBuilder sb)
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
}
