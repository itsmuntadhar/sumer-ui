using SumerUI.Elements;

namespace SumerUI.Extensions;

public static class TransformExtensions
{
    // Transform Origin
    public static Element TransformOrigin(this Element element, string origin) => element.Style("transform-origin", origin);
    public static Element OriginCenter(this Element element) => element.Style("transform-origin", "center");
    public static Element OriginTop(this Element element) => element.Style("transform-origin", "top");
    public static Element OriginTopRight(this Element element) => element.Style("transform-origin", "top right");
    public static Element OriginRight(this Element element) => element.Style("transform-origin", "right");
    public static Element OriginBottomRight(this Element element) => element.Style("transform-origin", "bottom right");
    public static Element OriginBottom(this Element element) => element.Style("transform-origin", "bottom");
    public static Element OriginBottomLeft(this Element element) => element.Style("transform-origin", "bottom left");
    public static Element OriginLeft(this Element element) => element.Style("transform-origin", "left");
    public static Element OriginTopLeft(this Element element) => element.Style("transform-origin", "top left");

    // Scale
    public static Element Scale(this Element element, double scale) => element.Style("transform", $"scale({scale})");
    public static Element ScaleX(this Element element, double scale) => element.Style("transform", $"scaleX({scale})");
    public static Element ScaleY(this Element element, double scale) => element.Style("transform", $"scaleY({scale})");
    public static Element Scale(this Element element, double scaleX, double scaleY) => element.Style("transform", $"scale({scaleX}, {scaleY})");

    // Predefined scales
    public static Element Scale0(this Element element) => element.Style("transform", "scale(0)");
    public static Element Scale50(this Element element) => element.Style("transform", "scale(0.5)");
    public static Element Scale75(this Element element) => element.Style("transform", "scale(0.75)");
    public static Element Scale90(this Element element) => element.Style("transform", "scale(0.9)");
    public static Element Scale95(this Element element) => element.Style("transform", "scale(0.95)");
    public static Element Scale100(this Element element) => element.Style("transform", "scale(1)");
    public static Element Scale105(this Element element) => element.Style("transform", "scale(1.05)");
    public static Element Scale110(this Element element) => element.Style("transform", "scale(1.1)");
    public static Element Scale125(this Element element) => element.Style("transform", "scale(1.25)");
    public static Element Scale150(this Element element) => element.Style("transform", "scale(1.5)");

    // Rotate
    public static Element Rotate(this Element element, int degrees) => element.Style("transform", $"rotate({degrees}deg)");
    public static Element Rotate(this Element element, string value) => element.Style("transform", $"rotate({value})");

    // Predefined rotations
    public static Element Rotate0(this Element element) => element.Style("transform", "rotate(0deg)");
    public static Element Rotate1(this Element element) => element.Style("transform", "rotate(1deg)");
    public static Element Rotate2(this Element element) => element.Style("transform", "rotate(2deg)");
    public static Element Rotate3(this Element element) => element.Style("transform", "rotate(3deg)");
    public static Element Rotate6(this Element element) => element.Style("transform", "rotate(6deg)");
    public static Element Rotate12(this Element element) => element.Style("transform", "rotate(12deg)");
    public static Element Rotate45(this Element element) => element.Style("transform", "rotate(45deg)");
    public static Element Rotate90(this Element element) => element.Style("transform", "rotate(90deg)");
    public static Element Rotate180(this Element element) => element.Style("transform", "rotate(180deg)");
    public static Element RotateNeg1(this Element element) => element.Style("transform", "rotate(-1deg)");
    public static Element RotateNeg2(this Element element) => element.Style("transform", "rotate(-2deg)");
    public static Element RotateNeg3(this Element element) => element.Style("transform", "rotate(-3deg)");
    public static Element RotateNeg6(this Element element) => element.Style("transform", "rotate(-6deg)");
    public static Element RotateNeg12(this Element element) => element.Style("transform", "rotate(-12deg)");
    public static Element RotateNeg45(this Element element) => element.Style("transform", "rotate(-45deg)");
    public static Element RotateNeg90(this Element element) => element.Style("transform", "rotate(-90deg)");
    public static Element RotateNeg180(this Element element) => element.Style("transform", "rotate(-180deg)");

    // Translate
    public static Element Translate(this Element element, string x, string y) => element.Style("transform", $"translate({x}, {y})");
    public static Element TranslateX(this Element element, string x) => element.Style("transform", $"translateX({x})");
    public static Element TranslateY(this Element element, string y) => element.Style("transform", $"translateY({y})");

    // Predefined X translations
    public static Element TranslateXFull(this Element element) => element.Style("transform", "translateX(100%)");
    public static Element TranslateXHalf(this Element element) => element.Style("transform", "translateX(50%)");
    public static Element TranslateXNegFull(this Element element) => element.Style("transform", "translateX(-100%)");
    public static Element TranslateXNegHalf(this Element element) => element.Style("transform", "translateX(-50%)");

    // Predefined Y translations
    public static Element TranslateYFull(this Element element) => element.Style("transform", "translateY(100%)");
    public static Element TranslateYHalf(this Element element) => element.Style("transform", "translateY(50%)");
    public static Element TranslateYNegFull(this Element element) => element.Style("transform", "translateY(-100%)");
    public static Element TranslateYNegHalf(this Element element) => element.Style("transform", "translateY(-50%)");

    // Skew
    public static Element Skew(this Element element, int x, int y) => element.Style("transform", $"skew({x}deg, {y}deg)");
    public static Element SkewX(this Element element, int degrees) => element.Style("transform", $"skewX({degrees}deg)");
    public static Element SkewY(this Element element, int degrees) => element.Style("transform", $"skewY({degrees}deg)");

    // Predefined skews
    public static Element SkewX0(this Element element) => element.Style("transform", "skewX(0deg)");
    public static Element SkewX1(this Element element) => element.Style("transform", "skewX(1deg)");
    public static Element SkewX2(this Element element) => element.Style("transform", "skewX(2deg)");
    public static Element SkewX3(this Element element) => element.Style("transform", "skewX(3deg)");
    public static Element SkewX6(this Element element) => element.Style("transform", "skewX(6deg)");
    public static Element SkewX12(this Element element) => element.Style("transform", "skewX(12deg)");
    public static Element SkewXNeg1(this Element element) => element.Style("transform", "skewX(-1deg)");
    public static Element SkewXNeg2(this Element element) => element.Style("transform", "skewX(-2deg)");
    public static Element SkewXNeg3(this Element element) => element.Style("transform", "skewX(-3deg)");
    public static Element SkewXNeg6(this Element element) => element.Style("transform", "skewX(-6deg)");
    public static Element SkewXNeg12(this Element element) => element.Style("transform", "skewX(-12deg)");

    public static Element SkewY0(this Element element) => element.Style("transform", "skewY(0deg)");
    public static Element SkewY1(this Element element) => element.Style("transform", "skewY(1deg)");
    public static Element SkewY2(this Element element) => element.Style("transform", "skewY(2deg)");
    public static Element SkewY3(this Element element) => element.Style("transform", "skewY(3deg)");
    public static Element SkewY6(this Element element) => element.Style("transform", "skewY(6deg)");
    public static Element SkewY12(this Element element) => element.Style("transform", "skewY(12deg)");
    public static Element SkewYNeg1(this Element element) => element.Style("transform", "skewY(-1deg)");
    public static Element SkewYNeg2(this Element element) => element.Style("transform", "skewY(-2deg)");
    public static Element SkewYNeg3(this Element element) => element.Style("transform", "skewY(-3deg)");
    public static Element SkewYNeg6(this Element element) => element.Style("transform", "skewY(-6deg)");
    public static Element SkewYNeg12(this Element element) => element.Style("transform", "skewY(-12deg)");

    // Combined transforms (allows multiple transforms)
    public static Element Transform(this Element element, string transform) => element.Style("transform", transform);
}
