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
    public static Element FontWeight(this Element element, int weight) => element.Style("font-weight", weight.ToString());
    public static Element FontThin(this Element element) => element.Style("font-weight", "100");
    public static Element FontExtraLight(this Element element) => element.Style("font-weight", "200");
    public static Element FontLight(this Element element) => element.Style("font-weight", "300");
    public static Element FontNormal(this Element element) => element.Style("font-weight", "400");
    public static Element FontMedium(this Element element) => element.Style("font-weight", "500");
    public static Element FontSemibold(this Element element) => element.Style("font-weight", "600");
    public static Element FontBold(this Element element) => element.Style("font-weight", "700");
    public static Element FontExtraBold(this Element element) => element.Style("font-weight", "800");
    public static Element FontBlack(this Element element) => element.Style("font-weight", "900");

    // Text Alignment
    public static Element TextLeft(this Element element) => element.Style("text-align", "left");
    public static Element TextCenter(this Element element) => element.Style("text-align", "center");
    public static Element TextRight(this Element element) => element.Style("text-align", "right");

    // Text Transform
    public static Element Uppercase(this Element element) => element.Style("text-transform", "uppercase");
    public static Element Lowercase(this Element element) => element.Style("text-transform", "lowercase");
    public static Element Capitalize(this Element element) => element.Style("text-transform", "capitalize");

    // Line Height
    public static Element LineHeight(this Element element, string lineHeight) => element.Style("line-height", lineHeight);
    public static Element LeadingNone(this Element element) => element.Style("line-height", "1");
    public static Element LeadingTight(this Element element) => element.Style("line-height", "1.25");
    public static Element LeadingSnug(this Element element) => element.Style("line-height", "1.375");
    public static Element LeadingNormal(this Element element) => element.Style("line-height", "1.5");
    public static Element LeadingRelaxed(this Element element) => element.Style("line-height", "1.625");
    public static Element LeadingLoose(this Element element) => element.Style("line-height", "2");

    // Letter Spacing
    public static Element LetterSpacing(this Element element, string spacing) => element.Style("letter-spacing", spacing);
    public static Element TrackingTighter(this Element element) => element.Style("letter-spacing", "-0.05em");
    public static Element TrackingTight(this Element element) => element.Style("letter-spacing", "-0.025em");
    public static Element TrackingNormal(this Element element) => element.Style("letter-spacing", "0");
    public static Element TrackingWide(this Element element) => element.Style("letter-spacing", "0.025em");
    public static Element TrackingWider(this Element element) => element.Style("letter-spacing", "0.05em");
    public static Element TrackingWidest(this Element element) => element.Style("letter-spacing", "0.1em");

    // Font Family
    public static Element FontFamily(this Element element, string family) => element.Style("font-family", family);
    public static Element FontSans(this Element element) => element.Style("font-family", "ui-sans-serif, system-ui, sans-serif");
    public static Element FontSerif(this Element element) => element.Style("font-family", "ui-serif, Georgia, serif");
    public static Element FontMono(this Element element) => element.Style("font-family", "ui-monospace, monospace");

    // Text Decoration
    public static Element Underline(this Element element) => element.Style("text-decoration-line", "underline");
    public static Element Overline(this Element element) => element.Style("text-decoration-line", "overline");
    public static Element LineThrough(this Element element) => element.Style("text-decoration-line", "line-through");
    public static Element NoUnderline(this Element element) => element.Style("text-decoration-line", "none");

    // Text Decoration Style
    public static Element DecorationSolid(this Element element) => element.Style("text-decoration-style", "solid");
    public static Element DecorationDouble(this Element element) => element.Style("text-decoration-style", "double");
    public static Element DecorationDotted(this Element element) => element.Style("text-decoration-style", "dotted");
    public static Element DecorationDashed(this Element element) => element.Style("text-decoration-style", "dashed");
    public static Element DecorationWavy(this Element element) => element.Style("text-decoration-style", "wavy");

    // Text Overflow
    public static Element TextOverflow(this Element element, string overflow) => element.Style("text-overflow", overflow);
    public static Element Truncate(this Element element) => element
        .Style("overflow", "hidden")
        .Style("text-overflow", "ellipsis")
        .Style("white-space", "nowrap");
    public static Element TextEllipsis(this Element element) => element.Style("text-overflow", "ellipsis");
    public static Element TextClip(this Element element) => element.Style("text-overflow", "clip");

    // White Space
    public static Element WhiteSpace(this Element element, string whiteSpace) => element.Style("white-space", whiteSpace);
    public static Element WhitespaceNormal(this Element element) => element.Style("white-space", "normal");
    public static Element WhitespaceNowrap(this Element element) => element.Style("white-space", "nowrap");
    public static Element WhitespacePre(this Element element) => element.Style("white-space", "pre");
    public static Element WhitespacePreLine(this Element element) => element.Style("white-space", "pre-line");
    public static Element WhitespacePreWrap(this Element element) => element.Style("white-space", "pre-wrap");

    // Word Break
    public static Element BreakNormal(this Element element) => element.Style("overflow-wrap", "normal").Style("word-break", "normal");
    public static Element BreakWords(this Element element) => element.Style("overflow-wrap", "break-word");
    public static Element BreakAll(this Element element) => element.Style("word-break", "break-all");

    // Text Style
    public static Element Italic(this Element element) => element.Style("font-style", "italic");
    public static Element NotItalic(this Element element) => element.Style("font-style", "normal");

    // Font Variant
    public static Element SmallCaps(this Element element) => element.Style("font-variant", "small-caps");
    public static Element NormalNums(this Element element) => element.Style("font-variant-numeric", "normal");
    public static Element OldstyleNums(this Element element) => element.Style("font-variant-numeric", "oldstyle-nums");
    public static Element TabularNums(this Element element) => element.Style("font-variant-numeric", "tabular-nums");
}
