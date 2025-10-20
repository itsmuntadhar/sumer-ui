using SumerUI.Elements;
using SumerUI.Extensions;
using SumerUI.Renderers;
using static SumerUI.Extensions.Elements;

namespace SumerUI.Tests.Typography;

public class TypographyExtensionTests
{
    private readonly HtmlRenderer _renderer = new();

    // Font Weight Tests
    [Fact]
    public void FontWeight_WithCustomValue_ShouldApplyCorrectStyle()
    {
        var element = Div().FontWeight(600);
        var html = _renderer.RenderToString(element);
        Assert.Contains("font-weight:600", html);
    }

    [Fact]
    public void FontThin_ShouldApply100Weight()
    {
        var element = Div().FontThin();
        var html = _renderer.RenderToString(element);
        Assert.Contains("font-weight:100", html);
    }

    [Fact]
    public void FontExtraLight_ShouldApply200Weight()
    {
        var element = Div().FontExtraLight();
        var html = _renderer.RenderToString(element);
        Assert.Contains("font-weight:200", html);
    }

    [Fact]
    public void FontExtraBold_ShouldApply800Weight()
    {
        var element = Div().FontExtraBold();
        var html = _renderer.RenderToString(element);
        Assert.Contains("font-weight:800", html);
    }

    [Fact]
    public void FontBlack_ShouldApply900Weight()
    {
        var element = Div().FontBlack();
        var html = _renderer.RenderToString(element);
        Assert.Contains("font-weight:900", html);
    }

    // Line Height Tests
    [Fact]
    public void LineHeight_WithCustomValue_ShouldApplyCorrectStyle()
    {
        var element = Div().LineHeight("2.5");
        var html = _renderer.RenderToString(element);
        Assert.Contains("line-height:2.5", html);
    }

    [Fact]
    public void LeadingSnug_ShouldApplyCorrectLineHeight()
    {
        var element = Div().LeadingSnug();
        var html = _renderer.RenderToString(element);
        Assert.Contains("line-height:1.375", html);
    }

    [Fact]
    public void LeadingLoose_ShouldApplyCorrectLineHeight()
    {
        var element = Div().LeadingLoose();
        var html = _renderer.RenderToString(element);
        Assert.Contains("line-height:2", html);
    }

    // Letter Spacing Tests
    [Fact]
    public void LetterSpacing_WithCustomValue_ShouldApplyCorrectStyle()
    {
        var element = Div().LetterSpacing("0.2em");
        var html = _renderer.RenderToString(element);
        Assert.Contains("letter-spacing:0.2em", html);
    }

    [Fact]
    public void TrackingTighter_ShouldApplyCorrectSpacing()
    {
        var element = Div().TrackingTighter();
        var html = _renderer.RenderToString(element);
        Assert.Contains("letter-spacing:-0.05em", html);
    }

    [Fact]
    public void TrackingWidest_ShouldApplyCorrectSpacing()
    {
        var element = Div().TrackingWidest();
        var html = _renderer.RenderToString(element);
        Assert.Contains("letter-spacing:0.1em", html);
    }

    // Font Family Tests
    [Fact]
    public void FontFamily_WithCustomValue_ShouldApplyCorrectStyle()
    {
        var element = Div().FontFamily("'Comic Sans MS', cursive");
        var html = _renderer.RenderToString(element);
        Assert.Contains("font-family:'Comic Sans MS', cursive", html);
    }

    [Fact]
    public void FontSans_ShouldApplySystemSans()
    {
        var element = Div().FontSans();
        var html = _renderer.RenderToString(element);
        Assert.Contains("font-family:ui-sans-serif, system-ui, sans-serif", html);
    }

    [Fact]
    public void FontSerif_ShouldApplySystemSerif()
    {
        var element = Div().FontSerif();
        var html = _renderer.RenderToString(element);
        Assert.Contains("font-family:ui-serif, Georgia, serif", html);
    }

    [Fact]
    public void FontMono_ShouldApplySystemMono()
    {
        var element = Div().FontMono();
        var html = _renderer.RenderToString(element);
        Assert.Contains("font-family:ui-monospace, monospace", html);
    }

    // Text Decoration Tests
    [Fact]
    public void Underline_ShouldApplyCorrectDecoration()
    {
        var element = Div().Underline();
        var html = _renderer.RenderToString(element);
        Assert.Contains("text-decoration-line:underline", html);
    }

    [Fact]
    public void LineThrough_ShouldApplyCorrectDecoration()
    {
        var element = Div().LineThrough();
        var html = _renderer.RenderToString(element);
        Assert.Contains("text-decoration-line:line-through", html);
    }

    [Fact]
    public void DecorationWavy_ShouldApplyCorrectStyle()
    {
        var element = Div().DecorationWavy();
        var html = _renderer.RenderToString(element);
        Assert.Contains("text-decoration-style:wavy", html);
    }

    [Fact]
    public void DecorationDashed_ShouldApplyCorrectStyle()
    {
        var element = Div().DecorationDashed();
        var html = _renderer.RenderToString(element);
        Assert.Contains("text-decoration-style:dashed", html);
    }

    // Text Overflow Tests
    [Fact]
    public void Truncate_ShouldApplyMultipleStyles()
    {
        var element = Div().Truncate();
        var html = _renderer.RenderToString(element);
        Assert.Contains("overflow:hidden", html);
        Assert.Contains("text-overflow:ellipsis", html);
        Assert.Contains("white-space:nowrap", html);
    }

    [Fact]
    public void TextEllipsis_ShouldApplyCorrectOverflow()
    {
        var element = Div().TextEllipsis();
        var html = _renderer.RenderToString(element);
        Assert.Contains("text-overflow:ellipsis", html);
    }

    // White Space Tests
    [Fact]
    public void WhiteSpace_WithCustomValue_ShouldApplyCorrectStyle()
    {
        var element = Div().WhiteSpace("break-spaces");
        var html = _renderer.RenderToString(element);
        Assert.Contains("white-space:break-spaces", html);
    }

    [Fact]
    public void WhitespacePre_ShouldApplyCorrectStyle()
    {
        var element = Div().WhitespacePre();
        var html = _renderer.RenderToString(element);
        Assert.Contains("white-space:pre", html);
    }

    [Fact]
    public void WhitespacePreWrap_ShouldApplyCorrectStyle()
    {
        var element = Div().WhitespacePreWrap();
        var html = _renderer.RenderToString(element);
        Assert.Contains("white-space:pre-wrap", html);
    }

    // Word Break Tests
    [Fact]
    public void BreakWords_ShouldApplyCorrectStyle()
    {
        var element = Div().BreakWords();
        var html = _renderer.RenderToString(element);
        Assert.Contains("overflow-wrap:break-word", html);
    }

    [Fact]
    public void BreakAll_ShouldApplyCorrectStyle()
    {
        var element = Div().BreakAll();
        var html = _renderer.RenderToString(element);
        Assert.Contains("word-break:break-all", html);
    }

    // Text Style Tests
    [Fact]
    public void Italic_ShouldApplyCorrectStyle()
    {
        var element = Div().Italic();
        var html = _renderer.RenderToString(element);
        Assert.Contains("font-style:italic", html);
    }

    [Fact]
    public void NotItalic_ShouldApplyCorrectStyle()
    {
        var element = Div().NotItalic();
        var html = _renderer.RenderToString(element);
        Assert.Contains("font-style:normal", html);
    }

    // Font Variant Tests
    [Fact]
    public void SmallCaps_ShouldApplyCorrectStyle()
    {
        var element = Div().SmallCaps();
        var html = _renderer.RenderToString(element);
        Assert.Contains("font-variant:small-caps", html);
    }

    [Fact]
    public void TabularNums_ShouldApplyCorrectStyle()
    {
        var element = Div().TabularNums();
        var html = _renderer.RenderToString(element);
        Assert.Contains("font-variant-numeric:tabular-nums", html);
    }

    // Chaining Tests
    [Fact]
    public void ChainedTypography_ShouldApplyAllStyles()
    {
        var element = Div()
            .FontWeight(600)
            .LetterSpacing("0.05em")
            .LineHeight("1.6")
            .Uppercase();

        var html = _renderer.RenderToString(element);
        Assert.Contains("font-weight:600", html);
        Assert.Contains("letter-spacing:0.05em", html);
        Assert.Contains("line-height:1.6", html);
        Assert.Contains("text-transform:uppercase", html);
    }

    [Fact]
    public void ComplexTypography_ShouldWorkWithOtherExtensions()
    {
        var element = Div()
            .FontSans()
            .FontWeight(700)
            .TrackingWide()
            .TextXl()
            .Underline()
            .DecorationWavy()
            .TextColor("#3b82f6");

        var html = _renderer.RenderToString(element);
        Assert.Contains("font-family:ui-sans-serif", html);
        Assert.Contains("font-weight:700", html);
        Assert.Contains("letter-spacing:0.025em", html);
        Assert.Contains("font-size:1.25rem", html);
        Assert.Contains("text-decoration-line:underline", html);
        Assert.Contains("text-decoration-style:wavy", html);
        Assert.Contains("color:#3b82f6", html);
    }
}
