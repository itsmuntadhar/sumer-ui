using SumerUI.Elements;

namespace SumerUI.Extensions;

public static class GridExtensions
{
    // Grid Display (Grid() is in LayoutExtensions)
    public static Element InlineGrid(this Element element)
    {
        return element.Style("display", "inline-grid");
    }

    // Grid Template Columns (GridCols(int) is in LayoutExtensions)
    public static Element GridCols(this Element element, string template)
    {
        return element.Style("grid-template-columns", template);
    }

    public static Element GridColsNone(this Element element)
    {
        return element.Style("grid-template-columns", "none");
    }

    // Grid Template Rows (GridRows(int) is in LayoutExtensions)
    public static Element GridRows(this Element element, string template)
    {
        return element.Style("grid-template-rows", template);
    }

    public static Element GridRowsNone(this Element element)
    {
        return element.Style("grid-template-rows", "none");
    }

    // Grid Column Start / End
    public static Element GridColStart(this Element element, int start)
    {
        return element.Style("grid-column-start", start.ToString());
    }

    public static Element GridColStart(this Element element, string start)
    {
        return element.Style("grid-column-start", start);
    }

    public static Element GridColEnd(this Element element, int end)
    {
        return element.Style("grid-column-end", end.ToString());
    }

    public static Element GridColEnd(this Element element, string end)
    {
        return element.Style("grid-column-end", end);
    }

    // Grid Column Span
    public static Element GridColSpan(this Element element, int span)
    {
        return element.Style("grid-column", $"span {span} / span {span}");
    }

    public static Element GridColSpanFull(this Element element)
    {
        return element.Style("grid-column", "1 / -1");
    }

    // Grid Row Start / End
    public static Element GridRowStart(this Element element, int start)
    {
        return element.Style("grid-row-start", start.ToString());
    }

    public static Element GridRowStart(this Element element, string start)
    {
        return element.Style("grid-row-start", start);
    }

    public static Element GridRowEnd(this Element element, int end)
    {
        return element.Style("grid-row-end", end.ToString());
    }

    public static Element GridRowEnd(this Element element, string end)
    {
        return element.Style("grid-row-end", end);
    }

    // Grid Row Span
    public static Element GridRowSpan(this Element element, int span)
    {
        return element.Style("grid-row", $"span {span} / span {span}");
    }

    public static Element GridRowSpanFull(this Element element)
    {
        return element.Style("grid-row", "1 / -1");
    }

    // Grid Auto Flow (GridFlowRow/Col are in LayoutExtensions)
    public static Element GridFlowRowDense(this Element element)
    {
        return element.Style("grid-auto-flow", "row dense");
    }

    public static Element GridFlowColDense(this Element element)
    {
        return element.Style("grid-auto-flow", "column dense");
    }

    // Grid Auto Columns
    public static Element GridAutoColsAuto(this Element element)
    {
        return element.Style("grid-auto-columns", "auto");
    }

    public static Element GridAutoColsMin(this Element element)
    {
        return element.Style("grid-auto-columns", "min-content");
    }

    public static Element GridAutoColsMax(this Element element)
    {
        return element.Style("grid-auto-columns", "max-content");
    }

    public static Element GridAutoColsFr(this Element element)
    {
        return element.Style("grid-auto-columns", "minmax(0, 1fr)");
    }

    public static Element GridAutoCols(this Element element, string value)
    {
        return element.Style("grid-auto-columns", value);
    }

    // Grid Auto Rows
    public static Element GridAutoRowsAuto(this Element element)
    {
        return element.Style("grid-auto-rows", "auto");
    }

    public static Element GridAutoRowsMin(this Element element)
    {
        return element.Style("grid-auto-rows", "min-content");
    }

    public static Element GridAutoRowsMax(this Element element)
    {
        return element.Style("grid-auto-rows", "max-content");
    }

    public static Element GridAutoRowsFr(this Element element)
    {
        return element.Style("grid-auto-rows", "minmax(0, 1fr)");
    }

    public static Element GridAutoRows(this Element element, string value)
    {
        return element.Style("grid-auto-rows", value);
    }

    // Gap (already in LayoutExtensions, but grid-specific versions)
    public static Element GapX(this Element element, string gap)
    {
        return element.Style("column-gap", gap);
    }

    public static Element GapY(this Element element, string gap)
    {
        return element.Style("row-gap", gap);
    }

    // Place Content
    public static Element PlaceContentCenter(this Element element)
    {
        return element.Style("place-content", "center");
    }

    public static Element PlaceContentStart(this Element element)
    {
        return element.Style("place-content", "start");
    }

    public static Element PlaceContentEnd(this Element element)
    {
        return element.Style("place-content", "end");
    }

    public static Element PlaceContentBetween(this Element element)
    {
        return element.Style("place-content", "space-between");
    }

    public static Element PlaceContentAround(this Element element)
    {
        return element.Style("place-content", "space-around");
    }

    public static Element PlaceContentEvenly(this Element element)
    {
        return element.Style("place-content", "space-evenly");
    }

    public static Element PlaceContentStretch(this Element element)
    {
        return element.Style("place-content", "stretch");
    }

    // Place Items
    public static Element PlaceItemsStart(this Element element)
    {
        return element.Style("place-items", "start");
    }

    public static Element PlaceItemsEnd(this Element element)
    {
        return element.Style("place-items", "end");
    }

    public static Element PlaceItemsCenter(this Element element)
    {
        return element.Style("place-items", "center");
    }

    public static Element PlaceItemsStretch(this Element element)
    {
        return element.Style("place-items", "stretch");
    }

    // Place Self
    public static Element PlaceSelfAuto(this Element element)
    {
        return element.Style("place-self", "auto");
    }

    public static Element PlaceSelfStart(this Element element)
    {
        return element.Style("place-self", "start");
    }

    public static Element PlaceSelfEnd(this Element element)
    {
        return element.Style("place-self", "end");
    }

    public static Element PlaceSelfCenter(this Element element)
    {
        return element.Style("place-self", "center");
    }

    public static Element PlaceSelfStretch(this Element element)
    {
        return element.Style("place-self", "stretch");
    }

    // Justify Items
    public static Element JustifyItemsStart(this Element element)
    {
        return element.Style("justify-items", "start");
    }

    public static Element JustifyItemsEnd(this Element element)
    {
        return element.Style("justify-items", "end");
    }

    public static Element JustifyItemsCenter(this Element element)
    {
        return element.Style("justify-items", "center");
    }

    public static Element JustifyItemsStretch(this Element element)
    {
        return element.Style("justify-items", "stretch");
    }

    // Justify Self
    public static Element JustifySelfAuto(this Element element)
    {
        return element.Style("justify-self", "auto");
    }

    public static Element JustifySelfStart(this Element element)
    {
        return element.Style("justify-self", "start");
    }

    public static Element JustifySelfEnd(this Element element)
    {
        return element.Style("justify-self", "end");
    }

    public static Element JustifySelfCenter(this Element element)
    {
        return element.Style("justify-self", "center");
    }

    public static Element JustifySelfStretch(this Element element)
    {
        return element.Style("justify-self", "stretch");
    }

    // Align Items
    public static Element AlignItemsStart(this Element element)
    {
        return element.Style("align-items", "start");
    }

    public static Element AlignItemsEnd(this Element element)
    {
        return element.Style("align-items", "end");
    }

    public static Element AlignItemsCenter(this Element element)
    {
        return element.Style("align-items", "center");
    }

    public static Element AlignItemsStretch(this Element element)
    {
        return element.Style("align-items", "stretch");
    }

    public static Element AlignItemsBaseline(this Element element)
    {
        return element.Style("align-items", "baseline");
    }

    // Align Self
    public static Element AlignSelfAuto(this Element element)
    {
        return element.Style("align-self", "auto");
    }

    public static Element AlignSelfStart(this Element element)
    {
        return element.Style("align-self", "start");
    }

    public static Element AlignSelfEnd(this Element element)
    {
        return element.Style("align-self", "end");
    }

    public static Element AlignSelfCenter(this Element element)
    {
        return element.Style("align-self", "center");
    }

    public static Element AlignSelfStretch(this Element element)
    {
        return element.Style("align-self", "stretch");
    }

    public static Element AlignSelfBaseline(this Element element)
    {
        return element.Style("align-self", "baseline");
    }
}
