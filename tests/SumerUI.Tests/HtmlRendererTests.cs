using SumerUI.Elements;
using SumerUI.Renderers;
using static SumerUI.Extensions.Elements;

namespace SumerUI.Tests.Renderers;

public class HtmlRendererTests
{
    private readonly HtmlRenderer _renderer = new();

    [Fact]
    public void RenderToString_ShouldRender_EmptyDiv()
    {
        var element = Div();
        var html = _renderer.RenderToString(element);

        Assert.Equal("<div></div>", html.Trim());
    }

    [Fact]
    public void RenderToString_ShouldRender_SelfClosingTag()
    {
        var element = Meta().Attr("charset", "UTF-8");
        var html = _renderer.RenderToString(element);

        Assert.Contains("<meta charset=\"UTF-8\" />", html);
    }

    [Fact]
    public void RenderToString_ShouldEscape_SpecialCharacters()
    {
        var element = Div().Text("<script>alert('xss')</script>");
        var html = _renderer.RenderToString(element);

        // Should escape the script tags
        Assert.DoesNotContain("<script>", html);
        Assert.Contains("&lt;script&gt;", html);
    }

    [Fact]
    public void RenderToString_ShouldRender_ComplexDocument()
    {
        var page = Html()
            .Attr("lang", "en")
            .Content(
                Head().Content(
                    Meta().Attr("charset", "UTF-8"),
                    Title().Text("Test")
                ),
                Body().Content(
                    Div()
                        .Class("container")
                        .Content(
                            H1().Text("Title"),
                            P().Text("Paragraph")
                        )
                )
            );

        var html = _renderer.RenderToString(page);

        Assert.Contains("<html lang=\"en\">", html);
        Assert.Contains("<head>", html);
        Assert.Contains("<meta charset=\"UTF-8\" />", html);
        Assert.Contains("<title>Test</title>", html);
        Assert.Contains("<body>", html);
        Assert.Contains("class=\"container\"", html);
        Assert.Contains("<h1>Title</h1>", html);
        Assert.Contains("<p>Paragraph</p>", html);
    }

    [Fact]
    public void RenderToString_ShouldRender_StylesCorrectly()
    {
        var element = Div()
            .Style("padding", "1rem")
            .Style("margin", "2rem")
            .Style("background-color", "#ffffff");

        var html = _renderer.RenderToString(element);

        Assert.Contains("style=\"", html);
        Assert.Contains("padding:1rem", html);
        Assert.Contains("margin:2rem", html);
        Assert.Contains("background-color:#ffffff", html);
    }

    [Fact]
    public void RenderToString_ShouldHandle_EmptyChildren()
    {
        var element = Div().Content(Array.Empty<Element>());
        var html = _renderer.RenderToString(element);

        Assert.Equal("<div></div>", html.Trim());
    }
}
