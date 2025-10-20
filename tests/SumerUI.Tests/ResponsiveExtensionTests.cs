using SumerUI.Elements;
using SumerUI.Extensions;
using SumerUI.Renderers;

namespace SumerUI.Tests;

public class ResponsiveExtensionTests
{
    private readonly HtmlRenderer _renderer = new();

    [Fact]
    public void Md_AppliesMediaQuery()
    {
        var element = new Div()
            .Width("100%")
            .Md(el => el.Width("50%"));

        var html = _renderer.RenderToString(element);

        // Should have inline style for mobile
        Assert.Contains("width:100%", html);

        // Should have media query for md breakpoint
        Assert.Contains("@media (min-width: 768px)", html);
        Assert.Contains("width:50%", html);

        // Should have a responsive class
        Assert.Contains("class=\"sui-", html);
    }

    [Fact]
    public void Lg_AppliesMediaQuery()
    {
        var element = new Div()
            .Padding("1rem")
            .Lg(el => el.Padding("2rem"));

        var html = _renderer.RenderToString(element);

        Assert.Contains("padding:1rem", html);
        Assert.Contains("@media (min-width: 1024px)", html);
        Assert.Contains("padding:2rem", html);
    }

    [Fact]
    public void Sm_AppliesMediaQuery()
    {
        var element = new Div()
            .Display("block")
            .Sm(el => el.Display("flex"));

        var html = _renderer.RenderToString(element);

        Assert.Contains("display:block", html);
        Assert.Contains("@media (min-width: 640px)", html);
        Assert.Contains("display:flex", html);
    }

    [Fact]
    public void Xl_AppliesMediaQuery()
    {
        var element = new Div()
            .MaxWidth("800px")
            .Xl(el => el.MaxWidth("1200px"));

        var html = _renderer.RenderToString(element);

        Assert.Contains("max-width:800px", html);
        Assert.Contains("@media (min-width: 1280px)", html);
        Assert.Contains("max-width:1200px", html);
    }

    [Fact]
    public void TwoXl_AppliesMediaQuery()
    {
        var element = new Div()
            .GridCols(2)
            .TwoXl(el => el.GridCols(4));

        var html = _renderer.RenderToString(element);

        Assert.Contains("grid-template-columns:repeat(2, minmax(0, 1fr))", html);
        Assert.Contains("@media (min-width: 1536px)", html);
        Assert.Contains("grid-template-columns:repeat(4, minmax(0, 1fr))", html);
    }

    [Fact]
    public void MultipleBreakpoints_CascadeCorrectly()
    {
        var element = new Div()
            .Width("100%")
            .Sm(el => el.Width("640px"))
            .Md(el => el.Width("768px"))
            .Lg(el => el.Width("1024px"));

        var html = _renderer.RenderToString(element);

        // Base style
        Assert.Contains("width:100%", html);

        // All breakpoints present
        Assert.Contains("@media (min-width: 640px)", html);
        Assert.Contains("@media (min-width: 768px)", html);
        Assert.Contains("@media (min-width: 1024px)", html);

        // All widths present
        Assert.Contains("width:640px", html);
        Assert.Contains("width:768px", html);
        Assert.Contains("width:1024px", html);
    }

    [Fact]
    public void ResponsiveGrid_WorksCorrectly()
    {
        var element = new Div()
            .Grid()
            .GridCols(1)
            .Md(el => el.GridCols(2))
            .Lg(el => el.GridCols(3))
            .Xl(el => el.GridCols(4));

        var html = _renderer.RenderToString(element);

        Assert.Contains("display:grid", html);
        Assert.Contains("grid-template-columns:repeat(1, minmax(0, 1fr))", html);
        Assert.Contains("@media (min-width: 768px)", html);
        Assert.Contains("grid-template-columns:repeat(2, minmax(0, 1fr))", html);
        Assert.Contains("grid-template-columns:repeat(3, minmax(0, 1fr))", html);
        Assert.Contains("grid-template-columns:repeat(4, minmax(0, 1fr))", html);
    }

    [Fact]
    public void ResponsiveFlexbox_WorksCorrectly()
    {
        var element = new Div()
            .Flex()
            .FlexColumn()
            .Md(el => el.FlexRow());

        var html = _renderer.RenderToString(element);

        Assert.Contains("display:flex", html);
        Assert.Contains("flex-direction:column", html);
        Assert.Contains("@media (min-width: 768px)", html);
        Assert.Contains("flex-direction:row", html);
    }

    [Fact]
    public void MediaQuery_CustomQuery_WorksCorrectly()
    {
        var element = new Div()
            .Width("100%")
            .MediaQuery("max-width: 600px", el => el.Width("90%"));

        var html = _renderer.RenderToString(element);

        Assert.Contains("width:100%", html);
        Assert.Contains("@media (min-width: max-width: 600px)", html);
        Assert.Contains("width:90%", html);
    }

    [Fact]
    public void MultipleProperties_InSameBreakpoint()
    {
        var element = new Div()
            .Width("100%")
            .Padding("1rem")
            .Md(el => el
                .Width("50%")
                .Padding("2rem")
                .BackgroundColor("#f0f0f0"));

        var html = _renderer.RenderToString(element);

        // Base styles
        Assert.Contains("width:100%", html);
        Assert.Contains("padding:1rem", html);

        // Responsive styles
        Assert.Contains("@media (min-width: 768px)", html);
        Assert.Contains("width:50%", html);
        Assert.Contains("padding:2rem", html);
        Assert.Contains("background-color:#f0f0f0", html);
    }

    [Fact]
    public void ResponsiveStyles_InjectedInHead()
    {
        var page = new Html()
            .Content(
                new Head().Content(new Title().Text("Test")),
                new Body().Content(
                    new Div()
                        .Width("100%")
                        .Md(el => el.Width("50%"))
                )
            );

        var html = _renderer.RenderToString(page);

        // Style tag should be injected before </head>
        var headEndIndex = html.IndexOf("</head>");
        var styleIndex = html.IndexOf("<style>");

        Assert.True(styleIndex < headEndIndex, "Style tag should be before </head>");
        Assert.Contains("@media (min-width: 768px)", html);
    }

    [Fact]
    public void NoResponsiveStyles_NoStyleTag()
    {
        var element = new Div()
            .Width("100%")
            .Padding("1rem");

        var html = _renderer.RenderToString(element);

        // Should not contain style tag or media queries
        Assert.DoesNotContain("<style>", html);
        Assert.DoesNotContain("@media", html);
    }

    [Fact]
    public void ExistingClass_PreservedWithResponsiveId()
    {
        var element = new Div()
            .Class("my-class")
            .Md(el => el.Width("50%"));

        var html = _renderer.RenderToString(element);

        // Should have both the existing class and responsive ID
        Assert.Contains("class=\"my-class sui-", html);
    }

    [Fact]
    public void ComplexResponsiveLayout()
    {
        var element = new Div()
            .Grid()
            .GridCols(1)
            .Gap("1rem")
            .Sm(el => el.GridCols(2).Gap("1.5rem"))
            .Md(el => el.GridCols(3).Gap("2rem"))
            .Lg(el => el.GridCols(4).Gap("2.5rem"))
            .Xl(el => el.GridCols(6).Gap("3rem"));

        var html = _renderer.RenderToString(element);

        // Should have all breakpoints
        Assert.Contains("@media (min-width: 640px)", html);
        Assert.Contains("@media (min-width: 768px)", html);
        Assert.Contains("@media (min-width: 1024px)", html);
        Assert.Contains("@media (min-width: 1280px)", html);

        // Should have all grid configurations
        Assert.Contains("grid-template-columns:repeat(1, minmax(0, 1fr))", html);
        Assert.Contains("grid-template-columns:repeat(2, minmax(0, 1fr))", html);
        Assert.Contains("grid-template-columns:repeat(3, minmax(0, 1fr))", html);
        Assert.Contains("grid-template-columns:repeat(4, minmax(0, 1fr))", html);
        Assert.Contains("grid-template-columns:repeat(6, minmax(0, 1fr))", html);
    }
}
