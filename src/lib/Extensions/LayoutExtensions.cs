using SumerUI.Elements;

namespace SumerUI.Extensions;

public static class LayoutExtensions
{
    public static Element Margin(this Element element, string margin)
    {
        return element.Style("margin", margin);
    }

    public static Element Margin(this Element element, string vertical, string horizontal)
    {
        return element.Style("margin", $"{vertical} {horizontal}");
    }

    public static Element Margin(this Element element, string left, string top, string right, string bottom)
    {
        return element.Style("margin", $"{top} {right} {bottom} {left}");
    }

    public static Element MarginTop(this Element element, string top)
    {
        return element.Style("margin-top", top);
    }

    public static Element MarginBottom(this Element element, string bottom)
    {
        return element.Style("margin-bottom", bottom);
    }

    public static Element MarginLeft(this Element element, string left)
    {
        return element.Style("margin-left", left);
    }

    public static Element MarginRight(this Element element, string right)
    {
        return element.Style("margin-right", right);
    }

    public static Element Padding(this Element element, string padding)
    {
        return element.Style("padding", padding);
    }

    public static Element Padding(this Element element, string vertical, string horizontal)
    {
        return element.Style("padding", $"{vertical} {horizontal}");
    }

    public static Element Padding(this Element element, string left, string top, string right, string bottom)
    {
        return element.Style("padding", $"{top} {right} {bottom} {left}");
    }

    public static Element Width(this Element element, string width)
    {
        return element.Style("width", width);
    }

    public static Element Height(this Element element, string height)
    {
        return element.Style("height", height);
    }

    public static Element MaxWidth(this Element element, string maxWidth)
    {
        return element.Style("max-width", maxWidth);
    }

    public static Element MaxHeight(this Element element, string maxHeight)
    {
        return element.Style("max-height", maxHeight);
    }

    public static Element MinWidth(this Element element, string minWidth)
    {
        return element.Style("min-width", minWidth);
    }

    public static Element MinHeight(this Element element, string minHeight)
    {
        return element.Style("min-height", minHeight);
    }

    public static Element Display(this Element element, string display)
    {
        return element.Style("display", display);
    }

    public static Element Position(this Element element, string position)
    {
        return element.Style("position", position);
    }

    public static Element Top(this Element element, string top)
    {
        return element.Style("top", top);
    }

    public static Element Bottom(this Element element, string bottom)
    {
        return element.Style("bottom", bottom);
    }

    public static Element Left(this Element element, string left)
    {
        return element.Style("left", left);
    }

    public static Element Right(this Element element, string right)
    {
        return element.Style("right", right);
    }

    public static Element Overflow(this Element element, string overflow)
    {
        return element.Style("overflow", overflow);
    }

    public static Element OverflowX(this Element element, string overflowX)
    {
        return element.Style("overflow-x", overflowX);
    }

    public static Element OverflowY(this Element element, string overflowY)
    {
        return element.Style("overflow-y", overflowY);
    }

    public static Element Cursor(this Element element, string cursor)
    {
        return element.Style("cursor", cursor);
    }

    public static Element ZIndex(this Element element, int zIndex)
    {
        return element.Style("z-index", zIndex.ToString());
    }

    public static Element FlexDirection(this Element element, string direction)
    {
        return element.Style("flex-direction", direction);
    }

    public static Element Flex(this Element element)
    {
        return element.Display("flex");
    }

    public static Element FlexColumn(this Element element)
    {
        return element.Style("flex-direction", "column");
    }

    public static Element FlexRow(this Element element)
    {
        return element.Style("flex-direction", "row");
    }

    public static Element JustifyContent(this Element element, string justifyContent)
    {
        return element.Style("justify-content", justifyContent);
    }

    public static Element AlignItems(this Element element, string alignItems)
    {
        return element.Style("align-items", alignItems);
    }

    public static Element Gap(this Element element, string gap)
    {
        return element.Style("gap", gap);
    }

    public static Element FlexWrap(this Element element, string flexWrap)
    {
        return element.Style("flex-wrap", flexWrap);
    }

    public static Element BorderRadius(this Element element, string borderRadius)
    {
        return element.Style("border-radius", borderRadius);
    }

    public static Element BorderWidth(this Element element, string borderWidth)
    {
        return element.Style("border-width", borderWidth);
    }

    public static Element BorderStyle(this Element element, string borderStyle)
    {
        return element.Style("border-style", borderStyle);
    }

    public static Element BoxShadow(this Element element, string boxShadow)
    {
        return element.Style("box-shadow", boxShadow);
    }

    public static Element Grid(this Element element)
    {
        return element.Display("grid");
    }

    public static Element GridCols(this Element element, int count)
    {
        return element.Style("grid-template-columns", $"repeat({count}, minmax(0, 1fr))");
    }

    public static Element GridRows(this Element element, int count)
    {
        return element.Style("grid-template-rows", $"repeat({count}, minmax(0, 1fr))");
    }

    public static Element ColSpan(this Element element, int span)
    {
        return element.Style("grid-column", $"span {span} / span {span}");
    }

    public static Element RowSpan(this Element element, int span)
    {
        return element.Style("grid-row", $"span {span} / span {span}");
    }

    public static Element GridFlow(this Element element, string flow)
    {
        return element.Style("grid-auto-flow", flow);
    }

    public static Element GridFlowRow(this Element element)
    {
        return element.GridFlow("row");
    }

    public static Element GridFlowCol(this Element element)
    {
        return element.GridFlow("column");
    }


    public static Element Hidden(this Element element)
    {
        return element.Display("none");
    }

    public static Element Block(this Element element)
    {
        return element.Display("block");
    }

    public static Element Inline(this Element element)
    {
        return element.Display("inline");
    }

    public static Element InlineBlock(this Element element)
    {
        return element.Display("inline-block");
    }

    public static Element Border(this Element element, string v)
    {
        return element.Style("border-width", v);
    }

    public static Element BorderTop(this Element element, string v)
    {
        return element.Style("border-top-width", v);
    }

    public static Element BorderRight(this Element element, string v)
    {
        return element.Style("border-right-width", v);
    }

    public static Element BorderBottom(this Element element, string v)
    {
        return element.Style("border-bottom-width", v);
    }

    public static Element BorderLeft(this Element element, string v)
    {
        return element.Style("border-left-width", v);
    }

    public static Element ShadowSm(this Element element)
    {
        return element.Style("box-shadow", "0 1px 2px 0 rgb(0 0 0 / 0.05)");
    }

    public static Element Shadow(this Element element)
    {
        return element.Style("box-shadow", "0 1px 3px 0 rgb(0 0 0 / 0.1), 0 1px 2px -1px rgb(0 0 0 / 0.1)");
    }

    public static Element ShadowMd(this Element element)
    {
        return element.Style("box-shadow", "0 4px 6px -1px rgb(0 0 0 / 0.1), 0 2px 4px -2px rgb(0 0 0 / 0.1)");
    }

    public static Element ShadowLg(this Element element)
    {
        return element.Style("box-shadow", "0 10px 15px -3px rgb(0 0 0 / 0.1), 0 4px 6px -4px rgb(0 0 0 / 0.1)");
    }

    public static Element ShadowXl(this Element element)
    {
        return element.Style("box-shadow", "0 20px 25px -5px rgb(0 0 0 / 0.1), 0 10px 10px -5px rgb(0 0 0 / 0.04)");
    }

    public static Element Shadow2Xl(this Element element)
    {
        return element.Style("box-shadow", "0 25px 50px -12px rgb(0 0 0 / 0.25)");
    }

    public static Element Relative(this Element element)
    {
        return element.Position("relative");
    }

    public static Element Absolute(this Element element)
    {
        return element.Position("absolute");
    }

    public static Element Fixed(this Element element)
    {
        return element.Position("fixed");
    }

    public static Element Sticky(this Element element)
    {
        return element.Position("sticky");
    }
}
