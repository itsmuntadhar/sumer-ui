using SumerUI.Elements;
using SumerUI.Extensions;
using SumerUI.Renderers;
using static SumerUI.Extensions.Elements;

namespace SumerUI.Tests.Transform;

public class TransformExtensionTests
{
    private readonly HtmlRenderer _renderer = new();

    // Transform Origin Tests
    [Fact]
    public void TransformOrigin_WithCustomValue_ShouldApplyCorrectStyle()
    {
        var element = Div().TransformOrigin("10px 20px");
        var html = _renderer.RenderToString(element);
        Assert.Contains("transform-origin:10px 20px", html);
    }

    [Fact]
    public void OriginCenter_ShouldApplyCorrectOrigin()
    {
        var element = Div().OriginCenter();
        var html = _renderer.RenderToString(element);
        Assert.Contains("transform-origin:center", html);
    }

    [Fact]
    public void OriginTopRight_ShouldApplyCorrectOrigin()
    {
        var element = Div().OriginTopRight();
        var html = _renderer.RenderToString(element);
        Assert.Contains("transform-origin:top right", html);
    }

    // Scale Tests
    [Fact]
    public void Scale_WithCustomValue_ShouldApplyCorrectTransform()
    {
        var element = Div().Scale(1.5);
        var html = _renderer.RenderToString(element);
        Assert.Contains("transform:scale(1.5)", html);
    }

    [Fact]
    public void ScaleX_ShouldApplyCorrectTransform()
    {
        var element = Div().ScaleX(2.0);
        var html = _renderer.RenderToString(element);
        Assert.Contains("transform:scaleX(2)", html);
    }

    [Fact]
    public void Scale_WithXAndY_ShouldApplyCorrectTransform()
    {
        var element = Div().Scale(1.5, 0.5);
        var html = _renderer.RenderToString(element);
        Assert.Contains("transform:scale(1.5, 0.5)", html);
    }

    [Fact]
    public void Scale105_ShouldApplyCorrectScale()
    {
        var element = Div().Scale105();
        var html = _renderer.RenderToString(element);
        Assert.Contains("transform:scale(1.05)", html);
    }

    [Fact]
    public void Scale0_ShouldApplyZeroScale()
    {
        var element = Div().Scale0();
        var html = _renderer.RenderToString(element);
        Assert.Contains("transform:scale(0)", html);
    }

    // Rotate Tests
    [Fact]
    public void Rotate_WithDegrees_ShouldApplyCorrectRotation()
    {
        var element = Div().Rotate(45);
        var html = _renderer.RenderToString(element);
        Assert.Contains("transform:rotate(45deg)", html);
    }

    [Fact]
    public void Rotate_WithString_ShouldApplyCorrectRotation()
    {
        var element = Div().Rotate("0.5turn");
        var html = _renderer.RenderToString(element);
        Assert.Contains("transform:rotate(0.5turn)", html);
    }

    [Fact]
    public void Rotate90_ShouldApply90Degrees()
    {
        var element = Div().Rotate90();
        var html = _renderer.RenderToString(element);
        Assert.Contains("transform:rotate(90deg)", html);
    }

    [Fact]
    public void RotateNeg45_ShouldApplyNegativeRotation()
    {
        var element = Div().RotateNeg45();
        var html = _renderer.RenderToString(element);
        Assert.Contains("transform:rotate(-45deg)", html);
    }

    // Translate Tests
    [Fact]
    public void Translate_WithXAndY_ShouldApplyCorrectTransform()
    {
        var element = Div().Translate("10px", "20px");
        var html = _renderer.RenderToString(element);
        Assert.Contains("transform:translate(10px, 20px)", html);
    }

    [Fact]
    public void TranslateX_ShouldApplyCorrectTransform()
    {
        var element = Div().TranslateX("50%");
        var html = _renderer.RenderToString(element);
        Assert.Contains("transform:translateX(50%)", html);
    }

    [Fact]
    public void TranslateYHalf_ShouldApply50Percent()
    {
        var element = Div().TranslateYHalf();
        var html = _renderer.RenderToString(element);
        Assert.Contains("transform:translateY(50%)", html);
    }

    [Fact]
    public void TranslateXNegFull_ShouldApplyNegative100Percent()
    {
        var element = Div().TranslateXNegFull();
        var html = _renderer.RenderToString(element);
        Assert.Contains("transform:translateX(-100%)", html);
    }

    // Skew Tests
    [Fact]
    public void Skew_WithXAndY_ShouldApplyCorrectTransform()
    {
        var element = Div().Skew(10, 5);
        var html = _renderer.RenderToString(element);
        Assert.Contains("transform:skew(10deg, 5deg)", html);
    }

    [Fact]
    public void SkewX_ShouldApplyCorrectTransform()
    {
        var element = Div().SkewX(12);
        var html = _renderer.RenderToString(element);
        Assert.Contains("transform:skewX(12deg)", html);
    }

    [Fact]
    public void SkewX6_ShouldApply6Degrees()
    {
        var element = Div().SkewX6();
        var html = _renderer.RenderToString(element);
        Assert.Contains("transform:skewX(6deg)", html);
    }

    [Fact]
    public void SkewYNeg3_ShouldApplyNegativeSkew()
    {
        var element = Div().SkewYNeg3();
        var html = _renderer.RenderToString(element);
        Assert.Contains("transform:skewY(-3deg)", html);
    }

    // Custom Transform Test
    [Fact]
    public void Transform_WithMultipleTransforms_ShouldApplyCorrectly()
    {
        var element = Div().Transform("scale(1.1) rotate(45deg) translateX(10px)");
        var html = _renderer.RenderToString(element);
        Assert.Contains("transform:scale(1.1) rotate(45deg) translateX(10px)", html);
    }

    // Chaining Test
    [Fact]
    public void TransformWithOrigin_ShouldChainCorrectly()
    {
        var element = Div()
            .OriginCenter()
            .Scale(1.5);

        var html = _renderer.RenderToString(element);
        Assert.Contains("transform-origin:center", html);
        Assert.Contains("transform:scale(1.5)", html);
    }
}
