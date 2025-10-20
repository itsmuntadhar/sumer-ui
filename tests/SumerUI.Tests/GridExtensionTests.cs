using SumerUI.Elements;
using SumerUI.Extensions;
using SumerUI.Renderers;
using Xunit;

namespace SumerUI.Tests;

public class GridExtensionTests
{
    private readonly HtmlRenderer _renderer = new();

    [Fact]
    public void InlineGrid_SetsDisplayInlineGrid()
    {
        var element = new Div().InlineGrid();
        var html = _renderer.RenderToString(element);
        Assert.Contains("display:inline-grid", html);
    }

    [Fact]
    public void GridCols_WithCustomTemplate_SetsTemplate()
    {
        var element = new Div().GridCols("200px 1fr 2fr");
        var html = _renderer.RenderToString(element);
        Assert.Contains("grid-template-columns:200px 1fr 2fr", html);
    }

    [Fact]
    public void GridRows_WithCustomTemplate_SetsTemplate()
    {
        var element = new Div().GridRows("100px auto 1fr");
        var html = _renderer.RenderToString(element);
        Assert.Contains("grid-template-rows:100px auto 1fr", html);
    }

    [Fact]
    public void GridColSpan_CreatesSpanValue()
    {
        var element = new Div().GridColSpan(2);
        var html = _renderer.RenderToString(element);
        Assert.Contains("grid-column:span 2 / span 2", html);
    }

    [Fact]
    public void GridColSpanFull_SpansAllColumns()
    {
        var element = new Div().GridColSpanFull();
        var html = _renderer.RenderToString(element);
        Assert.Contains("grid-column:1 / -1", html);
    }

    [Fact]
    public void GridRowSpan_CreatesSpanValue()
    {
        var element = new Div().GridRowSpan(3);
        var html = _renderer.RenderToString(element);
        Assert.Contains("grid-row:span 3 / span 3", html);
    }

    [Fact]
    public void GridRowSpanFull_SpansAllRows()
    {
        var element = new Div().GridRowSpanFull();
        var html = _renderer.RenderToString(element);
        Assert.Contains("grid-row:1 / -1", html);
    }

    [Fact]
    public void GridColStart_SetsColumnStart()
    {
        var element = new Div().GridColStart(2);
        var html = _renderer.RenderToString(element);
        Assert.Contains("grid-column-start:2", html);
    }

    [Fact]
    public void GridColEnd_SetsColumnEnd()
    {
        var element = new Div().GridColEnd(4);
        var html = _renderer.RenderToString(element);
        Assert.Contains("grid-column-end:4", html);
    }

    [Fact]
    public void GridRowStart_SetsRowStart()
    {
        var element = new Div().GridRowStart(1);
        var html = _renderer.RenderToString(element);
        Assert.Contains("grid-row-start:1", html);
    }

    [Fact]
    public void GridRowEnd_SetsRowEnd()
    {
        var element = new Div().GridRowEnd(3);
        var html = _renderer.RenderToString(element);
        Assert.Contains("grid-row-end:3", html);
    }

    [Fact]
    public void GridFlowRowDense_SetsAutoFlowRowDense()
    {
        var element = new Div().GridFlowRowDense();
        var html = _renderer.RenderToString(element);
        Assert.Contains("grid-auto-flow:row dense", html);
    }

    [Fact]
    public void GridAutoColsFr_SetsAutoColumns()
    {
        var element = new Div().GridAutoColsFr();
        var html = _renderer.RenderToString(element);
        Assert.Contains("grid-auto-columns:minmax(0, 1fr)", html);
    }

    [Fact]
    public void GridAutoRowsMax_SetsAutoRowsMaxContent()
    {
        var element = new Div().GridAutoRowsMax();
        var html = _renderer.RenderToString(element);
        Assert.Contains("grid-auto-rows:max-content", html);
    }

    [Fact]
    public void GapX_SetsColumnGap()
    {
        var element = new Div().GapX("1rem");
        var html = _renderer.RenderToString(element);
        Assert.Contains("column-gap:1rem", html);
    }

    [Fact]
    public void GapY_SetsRowGap()
    {
        var element = new Div().GapY("2rem");
        var html = _renderer.RenderToString(element);
        Assert.Contains("row-gap:2rem", html);
    }

    [Fact]
    public void PlaceItemsCenter_CentersItems()
    {
        var element = new Div().PlaceItemsCenter();
        var html = _renderer.RenderToString(element);
        Assert.Contains("place-items:center", html);
    }

    [Fact]
    public void PlaceContentBetween_SetsPlaceContentSpaceBetween()
    {
        var element = new Div().PlaceContentBetween();
        var html = _renderer.RenderToString(element);
        Assert.Contains("place-content:space-between", html);
    }

    [Fact]
    public void PlaceSelfCenter_CentersSelf()
    {
        var element = new Div().PlaceSelfCenter();
        var html = _renderer.RenderToString(element);
        Assert.Contains("place-self:center", html);
    }

    [Fact]
    public void JustifyItemsStart_SetsJustifyItems()
    {
        var element = new Div().JustifyItemsStart();
        var html = _renderer.RenderToString(element);
        Assert.Contains("justify-items:start", html);
    }

    [Fact]
    public void JustifySelfEnd_SetsJustifySelf()
    {
        var element = new Div().JustifySelfEnd();
        var html = _renderer.RenderToString(element);
        Assert.Contains("justify-self:end", html);
    }

    [Fact]
    public void AlignItemsCenter_SetsAlignItems()
    {
        var element = new Div().AlignItemsCenter();
        var html = _renderer.RenderToString(element);
        Assert.Contains("align-items:center", html);
    }

    [Fact]
    public void AlignSelfStretch_SetsAlignSelf()
    {
        var element = new Div().AlignSelfStretch();
        var html = _renderer.RenderToString(element);
        Assert.Contains("align-self:stretch", html);
    }

    [Fact]
    public void ComplexGrid_ChainsMultipleGridProperties()
    {
        var element = new Div()
            .Grid()
            .GridCols(3)
            .GridRows(2)
            .Gap("1rem")
            .PlaceItemsCenter();

        var html = _renderer.RenderToString(element);

        Assert.Contains("display:grid", html);
        Assert.Contains("grid-template-columns:repeat(3, minmax(0, 1fr))", html);
        Assert.Contains("grid-template-rows:repeat(2, minmax(0, 1fr))", html);
        Assert.Contains("gap:1rem", html);
        Assert.Contains("place-items:center", html);
    }

    [Fact]
    public void GridItem_WithSpanAndAlignment()
    {
        var element = new Div()
            .GridColSpan(2)
            .GridRowSpan(1)
            .JustifySelfCenter()
            .AlignSelfEnd();

        var html = _renderer.RenderToString(element);

        Assert.Contains("grid-column:span 2 / span 2", html);
        Assert.Contains("grid-row:span 1 / span 1", html);
        Assert.Contains("justify-self:center", html);
        Assert.Contains("align-self:end", html);
    }
}
