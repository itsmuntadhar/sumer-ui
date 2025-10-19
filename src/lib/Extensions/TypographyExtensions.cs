using SumerUI.Elements;

namespace SumerUI.Extensions;

public static class TypographyExtensions
{
    // Font Sizes
    public static Element FontSize(this Element element, string fontSize) => element.Style("font-size", fontSize);
    public static Element TextXs(this Element element) => element.Style("font-size", "0.75rem").Style("line-height", "1rem");
    public static Element TextSm(this Element element) => element.Style("font-size", "0.875rem").Style("line-height", "1.25rem");
    public static Element TextBase(this Element element) => element.Style("font-size", "1rem").Style("line-height", "1.5rem");
    public static Element TextLg(this Element element) => element.Style("font-size", "1.125rem").Style("line-height", "1.75rem");
    public static Element TextXl(this Element element) => element.Style("font-size", "1.25rem").Style("line-height", "1.75rem");
    public static Element Text2Xl(this Element element) => element.Style("font-size", "1.5rem").Style("line-height", "2rem");
    public static Element Text3Xl(this Element element) => element.Style("font-size", "1.875rem").Style("line-height", "2.25rem");

    // Font Weights
    public static Element FontThin(this Element element) => element.Style("font-weight", "100");
    public static Element FontLight(this Element element) => element.Style("font-weight", "300");
    public static Element FontNormal(this Element element) => element.Style("font-weight", "400");
    public static Element FontMedium(this Element element) => element.Style("font-weight", "500");
    public static Element FontSemibold(this Element element) => element.Style("font-weight", "600");
    public static Element FontBold(this Element element) => element.Style("font-weight", "700");

    // Text Alignment
    public static Element TextLeft(this Element element) => element.Style("text-align", "left");
    public static Element TextCenter(this Element element) => element.Style("text-align", "center");
    public static Element TextRight(this Element element) => element.Style("text-align", "right");

    // Text Transform
    public static Element Uppercase(this Element element) => element.Style("text-transform", "uppercase");
    public static Element Lowercase(this Element element) => element.Style("text-transform", "lowercase");
    public static Element Capitalize(this Element element) => element.Style("text-transform", "capitalize");

    // Line Height
    public static Element LeadingNone(this Element element) => element.Style("line-height", "1");
    public static Element LeadingTight(this Element element) => element.Style("line-height", "1.25");
    public static Element LeadingNormal(this Element element) => element.Style("line-height", "1.5");
    public static Element LeadingRelaxed(this Element element) => element.Style("line-height", "1.625");
}
