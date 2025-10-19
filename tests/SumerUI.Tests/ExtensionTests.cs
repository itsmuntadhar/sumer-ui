using SumerUI.Elements;
using SumerUI.Extensions;
using SumerUI.Renderers;
using static SumerUI.Extensions.Elements;

namespace SumerUI.Tests.Extensions;

public class ExtensionTests
{
    private readonly HtmlRenderer _renderer = new();

    [Fact]
    public void Padding_ShouldApply_CorrectStyle()
    {
        var element = Div().Padding(1.Rem());
        var html = _renderer.RenderToString(element);

        Assert.Contains("padding:1rem", html);
    }

    [Fact]
    public void Margin_ShouldApply_CorrectStyle()
    {
        var element = Div().Margin(2.Rem());
        var html = _renderer.RenderToString(element);

        Assert.Contains("margin:2rem", html);
    }

    [Fact]
    public void BackgroundColor_ShouldApply_CorrectStyle()
    {
        var element = Div().BackgroundColor("#f0fdf4");
        var html = _renderer.RenderToString(element);

        Assert.Contains("background-color:#f0fdf4", html);
    }

    [Fact]
    public void TextColor_ShouldApply_CorrectStyle()
    {
        var element = Div().TextColor("#000000");
        var html = _renderer.RenderToString(element);

        Assert.Contains("color:#000000", html);
    }

    [Fact]
    public void Flex_ShouldApply_DisplayFlex()
    {
        var element = Div().Flex();
        var html = _renderer.RenderToString(element);

        Assert.Contains("display:flex", html);
    }

    [Fact]
    public void FlexDirection_ShouldApply_CorrectStyle()
    {
        var element = Div().FlexColumn();
        var html = _renderer.RenderToString(element);

        Assert.Contains("flex-direction:column", html);
    }

    [Fact]
    public void AlignItems_ShouldApply_CorrectStyle()
    {
        var element = Div().AlignItems("center");
        var html = _renderer.RenderToString(element);

        Assert.Contains("align-items:center", html);
    }

    [Fact]
    public void JustifyContent_ShouldApply_CorrectStyle()
    {
        var element = Div().JustifyContent("space-between");
        var html = _renderer.RenderToString(element);

        Assert.Contains("justify-content:space-between", html);
    }

    [Fact]
    public void Gap_ShouldApply_CorrectStyle()
    {
        var element = Div().Gap(1.Rem());
        var html = _renderer.RenderToString(element);

        Assert.Contains("gap:1rem", html);
    }

    [Fact]
    public void BorderRadius_ShouldApply_CorrectStyle()
    {
        var element = Div().BorderRadius(0.5.Rem());
        var html = _renderer.RenderToString(element);

        Assert.Contains("border-radius:0.5rem", html);
    }

    [Fact]
    public void FontBold_ShouldApply_CorrectStyle()
    {
        var element = H1().FontBold();
        var html = _renderer.RenderToString(element);

        Assert.Contains("font-weight:700", html);
    }

    [Fact]
    public void Text2Xl_ShouldApply_CorrectStyle()
    {
        var element = H1().Text2Xl();
        var html = _renderer.RenderToString(element);

        Assert.Contains("font-size:1.5rem", html);
        Assert.Contains("line-height:2rem", html);
    }

    [Fact]
    public void TextCenter_ShouldApply_CorrectStyle()
    {
        var element = P().TextCenter();
        var html = _renderer.RenderToString(element);

        Assert.Contains("text-align:center", html);
    }

    [Fact]
    public void MultipleExtensions_ShouldChain_Correctly()
    {
        var element = Div()
            .Flex()
            .FlexRow()
            .AlignItems("center")
            .JustifyContent("space-between")
            .Gap(1.Rem())
            .Padding(2.Rem())
            .BackgroundColor("#ffffff")
            .BorderRadius(0.5.Rem());

        var html = _renderer.RenderToString(element);

        Assert.Contains("display:flex", html);
        Assert.Contains("flex-direction:row", html);
        Assert.Contains("align-items:center", html);
        Assert.Contains("justify-content:space-between", html);
        Assert.Contains("gap:1rem", html);
        Assert.Contains("padding:2rem", html);
        Assert.Contains("background-color:#ffffff", html);
        Assert.Contains("border-radius:0.5rem", html);
    }
}
