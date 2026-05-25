using System.Text;
using SumerUI.Elements;
using SumerUI.Extensions;
using SumerUI.Renderers;
using static SumerUI.Extensions.Elements;

namespace SumerUI.Tests.Renderers;

public class TypstRendererTests
{
    private readonly TypstRenderer _renderer = new();

    [Fact]
    public void RenderToString_RendersDocumentStructure()
    {
        var page = Html().Content(
            Head().Content(Title().Text("Quarterly \"Report\"")),
            Body().Content(
                H1().Text("Overview"),
                P().Content(
                    Span().Text("See "),
                    A("https://example.test/?q=one").Text("details")
                ),
                Ul().Content(Li().Text("First"), Li().Text("Second"))
            )
        );

        var typst = _renderer.RenderToString(page);

        Assert.Contains("#set document(title: [Quarterly \"Report\"])", typst);
        Assert.Contains("#heading(level: 1)[Overview]", typst);
        Assert.Contains("#par()[See #link(\"https://example.test/?q=one\")[details]]", typst);
        Assert.Contains("#list(\n  [First],\n  [Second]\n)", typst);
        Assert.Empty(_renderer.Diagnostics);
    }

    [Fact]
    public void RenderToString_EscapesTypstMarkupCharacters()
    {
        var typst = _renderer.RenderToString(P().Text(@"Total #1: [x] *bold* $math$ \path"));

        Assert.Contains(@"Total \#1: \[x\] \*bold\* \$math\$ \\path", typst);
    }

    [Fact]
    public void RenderToStream_UsesUtf8TypstSource()
    {
        using var stream = _renderer.RenderToStream(H2().Text("Hello"));
        using var reader = new StreamReader(stream, Encoding.UTF8);

        Assert.Equal("#heading(level: 2)[Hello]", reader.ReadToEnd());
    }

    [Fact]
    public void RenderToString_MapsTypographyAndContainerStyles()
    {
        var element = Div()
            .Width("96px")
            .Height("2rem")
            .Padding("1rem")
            .BackgroundColor("#ffffff")
            .BorderWidth("2px")
            .BorderColor("#111827")
            .BorderRadius("4px")
            .Content(
                P().Text("Styled")
                    .Text2Xl()
                    .FontBold()
                    .TextColor("#10B981")
                    .TextCenter()
                    .Underline()
            );

        var typst = _renderer.RenderToString(element);

        Assert.Contains("width: 72pt", typst);
        Assert.Contains("height: 24pt", typst);
        Assert.Contains("#pad(rest: 12pt)", typst);
        Assert.Contains("fill: rgb(\"#ffffff\")", typst);
        Assert.Contains("stroke: (thickness: 1.5pt, paint: rgb(\"#111827\"))", typst);
        Assert.Contains("radius: 3pt", typst);
        Assert.Contains("size: 18pt", typst);
        Assert.Contains("weight: 700", typst);
        Assert.Contains("fill: rgb(\"#10B981\")", typst);
        Assert.Contains("#align(center)", typst);
        Assert.Contains("#underline", typst);
        Assert.Empty(_renderer.Diagnostics);
    }

    [Fact]
    public void RenderToString_UsesConfiguredRootFontSize()
    {
        var renderer = new TypstRenderer(new TypstRendererOptions { RootFontSizeInPoints = 10 });

        var typst = renderer.RenderToString(Div().Padding("1.5rem"));

        Assert.Contains("#pad(rest: 15pt)", typst);
    }

    [Fact]
    public void RenderToString_ConvertsCssAlphaColorToTypstRgb()
    {
        var typst = _renderer.RenderToString(Div().BackgroundColor("rgba(1, 2, 3, 0.5)"));

        Assert.Contains("fill: rgb(1, 2, 3, 50%)", typst);
        Assert.Empty(_renderer.Diagnostics);
    }

    [Fact]
    public void RenderToString_MapsGridStackVisibilityAndTransforms()
    {
        var grid = Div()
            .Grid()
            .GridCols(2)
            .Gap("8px")
            .Content(Div().Text("A"), Div().Text("B"));
        var row = Div()
            .Flex()
            .FlexRow()
            .Gap("1rem")
            .Rotate(45)
            .Content(Span().Text("X"), Span().Text("Y"));
        var hidden = Div().Hidden().Text("Secret");

        var typst = _renderer.RenderToString(Div().Content(grid, row, hidden));

        Assert.Contains("#grid(columns: 2, gutter: 6pt, [#block[A]], [#block[B]])", typst);
        Assert.Contains("#rotate(45deg)[#stack(dir: ltr, spacing: 12pt, [X], [Y])]", typst);
        Assert.DoesNotContain("Secret", typst);
        Assert.Empty(_renderer.Diagnostics);
    }

    [Fact]
    public void RenderToString_WarnsForUnsupportedSemanticsAndPreservesVisibleContent()
    {
        var page = Html().Attr("lang", "en").Content(
            Head().Content(Meta().Attr("charset", "UTF-8"), Script("/app.js")),
            Body().Content(
                Form("/submit").Content(Button().Text("Send")),
                Input("text"),
                new Element("custom").Text("Kept")
                    .Style("cursor", "pointer")
                    .Md(el => el.Width("50%"))
            )
        );

        var typst = _renderer.RenderToString(page);

        Assert.Contains("Send", typst);
        Assert.Contains("Kept", typst);
        Assert.DoesNotContain("/app.js", typst);
        Assert.Contains(_renderer.Diagnostics, diagnostic => diagnostic.Code == "TYPST001" && diagnostic.Property == "lang");
        Assert.Contains(_renderer.Diagnostics, diagnostic => diagnostic.Code == "TYPST002");
        Assert.Contains(_renderer.Diagnostics, diagnostic => diagnostic.Code == "TYPST003");
        Assert.Contains(_renderer.Diagnostics, diagnostic => diagnostic.Code == "TYPST004" && diagnostic.Property == "cursor");
        Assert.Contains(_renderer.Diagnostics, diagnostic => diagnostic.Code == "TYPST005");
    }

    [Fact]
    public void RenderToString_ResetsDiagnosticsForEveryRender()
    {
        _renderer.RenderToString(Div().Attr("class", "not-supported").Text("First"));
        Assert.NotEmpty(_renderer.Diagnostics);

        _renderer.RenderToString(P().Text("Second"));

        Assert.Empty(_renderer.Diagnostics);
    }

    [Fact]
    public void RenderToString_DoesNotMutateTheElementTree()
    {
        var element = Div()
            .Class("card")
            .Width("100%")
            .Md(item => item.Width("50%"))
            .Text("Content");
        var attributes = element.Attributes.ToDictionary();
        var styles = element.Styles.ToDictionary();
        var responsive = element.ResponsiveStyles.ToDictionary(
            pair => pair.Key,
            pair => pair.Value.ToDictionary());

        _renderer.RenderToString(element);

        Assert.Equal(attributes, element.Attributes);
        Assert.Equal(styles, element.Styles);
        Assert.Equal(responsive.Keys, element.ResponsiveStyles.Keys);
        foreach (var pair in responsive)
        {
            Assert.Equal(pair.Value, element.ResponsiveStyles[pair.Key]);
        }
    }
}
