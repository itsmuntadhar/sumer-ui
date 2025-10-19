using SumerUI.Elements;
using SumerUI.Renderers;
using static SumerUI.Extensions.Elements;

namespace SumerUI.Tests.Elements;

public class ElementTests
{
    private readonly HtmlRenderer _renderer = new();

    [Fact]
    public void Div_ShouldRender_WithTag()
    {
        var element = Div();
        var html = _renderer.RenderToString(element);

        Assert.Contains("<div", html);
        Assert.Contains("</div>", html);
    }

    [Fact]
    public void Div_ShouldRender_WithAttributes()
    {
        var element = Div()
            .Attr("id", "test")
            .Attr("data-value", "123");

        var html = _renderer.RenderToString(element);

        Assert.Contains("id=\"test\"", html);
        Assert.Contains("data-value=\"123\"", html);
    }

    [Fact]
    public void Div_ShouldRender_WithClass()
    {
        var element = Div()
            .Class("container")
            .Class("active");

        var html = _renderer.RenderToString(element);

        Assert.Contains("class=\"container active\"", html);
    }

    [Fact]
    public void Div_ShouldRender_WithStyles()
    {
        var element = Div()
            .Style("padding", "1rem")
            .Style("background-color", "#f0fdf4");

        var html = _renderer.RenderToString(element);

        Assert.Contains("padding:1rem", html);
        Assert.Contains("background-color:#f0fdf4", html);
    }

    [Fact]
    public void Div_ShouldRender_WithTextContent()
    {
        var element = Div().Text("Hello World");
        var html = _renderer.RenderToString(element);

        Assert.Contains(">Hello World<", html);
    }

    [Fact]
    public void Div_ShouldRender_WithChildren()
    {
        var element = Div().Content(
            H1().Text("Title"),
            P().Text("Content")
        );

        var html = _renderer.RenderToString(element);

        Assert.Contains("<h1>Title</h1>", html);
        Assert.Contains("<p>Content</p>", html);
    }

    [Fact]
    public void Div_ShouldRender_WithNestedChildren()
    {
        var element = Div().Content(
            Div().Content(
                Div().Text("Nested")
            )
        );

        var html = _renderer.RenderToString(element);

        Assert.Contains("<div><div><div>Nested</div></div></div>", html);
    }

    [Fact]
    public void Html_ShouldRender_CompleteDocument()
    {
        var page = Html().Content(
            Head().Content(
                Title().Text("Test Page")
            ),
            Body().Content(
                H1().Text("Hello")
            )
        );

        var html = _renderer.RenderToString(page);

        Assert.Contains("<html>", html);
        Assert.Contains("<head>", html);
        Assert.Contains("<title>Test Page</title>", html);
        Assert.Contains("<body>", html);
        Assert.Contains("<h1>Hello</h1>", html);
        Assert.Contains("</html>", html);
    }

    [Fact]
    public void Element_ShouldChain_FluentMethods()
    {
        var element = Div()
            .Attr("id", "test")
            .Class("container")
            .Style("padding", "1rem")
            .Text("Content");

        var html = _renderer.RenderToString(element);

        Assert.Contains("id=\"test\"", html);
        Assert.Contains("class=\"container\"", html);
        Assert.Contains("padding:1rem", html);
        Assert.Contains(">Content<", html);
    }
}
