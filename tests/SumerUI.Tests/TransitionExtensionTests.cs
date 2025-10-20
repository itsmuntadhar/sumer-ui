using SumerUI.Elements;
using SumerUI.Extensions;
using SumerUI.Renderers;
using static SumerUI.Extensions.Elements;

namespace SumerUI.Tests.Transition;

public class TransitionExtensionTests
{
    private readonly HtmlRenderer _renderer = new();

    // Transition Property Tests
    [Fact]
    public void Transition_WithCustomValue_ShouldApplyCorrectStyle()
    {
        var element = Div().Transition("all 0.3s ease-in-out");
        var html = _renderer.RenderToString(element);
        Assert.Contains("transition:all 0.3s ease-in-out", html);
    }

    [Fact]
    public void TransitionProperty_ShouldApplyCorrectProperty()
    {
        var element = Div().TransitionProperty("opacity");
        var html = _renderer.RenderToString(element);
        Assert.Contains("transition-property:opacity", html);
    }

    [Fact]
    public void TransitionDuration_ShouldApplyCorrectDuration()
    {
        var element = Div().TransitionDuration("500ms");
        var html = _renderer.RenderToString(element);
        Assert.Contains("transition-duration:500ms", html);
    }

    [Fact]
    public void TransitionTimingFunction_ShouldApplyCorrectFunction()
    {
        var element = Div().TransitionTimingFunction("ease-in");
        var html = _renderer.RenderToString(element);
        Assert.Contains("transition-timing-function:ease-in", html);
    }

    [Fact]
    public void TransitionDelay_ShouldApplyCorrectDelay()
    {
        var element = Div().TransitionDelay("100ms");
        var html = _renderer.RenderToString(element);
        Assert.Contains("transition-delay:100ms", html);
    }

    // Predefined Properties Tests
    [Fact]
    public void TransitionAll_ShouldApplyAllProperty()
    {
        var element = Div().TransitionAll();
        var html = _renderer.RenderToString(element);
        Assert.Contains("transition-property:all", html);
    }

    [Fact]
    public void TransitionColors_ShouldApplyColorProperties()
    {
        var element = Div().TransitionColors();
        var html = _renderer.RenderToString(element);
        Assert.Contains("transition-property:color, background-color, border-color", html);
    }

    [Fact]
    public void TransitionOpacity_ShouldApplyOpacityProperty()
    {
        var element = Div().TransitionOpacity();
        var html = _renderer.RenderToString(element);
        Assert.Contains("transition-property:opacity", html);
    }

    [Fact]
    public void TransitionTransform_ShouldApplyTransformProperty()
    {
        var element = Div().TransitionTransform();
        var html = _renderer.RenderToString(element);
        Assert.Contains("transition-property:transform", html);
    }

    // Duration Tests
    [Fact]
    public void Duration150_ShouldApply150ms()
    {
        var element = Div().Duration150();
        var html = _renderer.RenderToString(element);
        Assert.Contains("transition-duration:150ms", html);
    }

    [Fact]
    public void Duration300_ShouldApply300ms()
    {
        var element = Div().Duration300();
        var html = _renderer.RenderToString(element);
        Assert.Contains("transition-duration:300ms", html);
    }

    [Fact]
    public void Duration1000_ShouldApply1000ms()
    {
        var element = Div().Duration1000();
        var html = _renderer.RenderToString(element);
        Assert.Contains("transition-duration:1000ms", html);
    }

    // Timing Function Tests
    [Fact]
    public void EaseLinear_ShouldApplyLinearTiming()
    {
        var element = Div().EaseLinear();
        var html = _renderer.RenderToString(element);
        Assert.Contains("transition-timing-function:linear", html);
    }

    [Fact]
    public void EaseIn_ShouldApplyEaseInTiming()
    {
        var element = Div().EaseIn();
        var html = _renderer.RenderToString(element);
        Assert.Contains("transition-timing-function:cubic-bezier(0.4, 0, 1, 1)", html);
    }

    [Fact]
    public void EaseOut_ShouldApplyEaseOutTiming()
    {
        var element = Div().EaseOut();
        var html = _renderer.RenderToString(element);
        Assert.Contains("transition-timing-function:cubic-bezier(0, 0, 0.2, 1)", html);
    }

    [Fact]
    public void EaseInOut_ShouldApplyEaseInOutTiming()
    {
        var element = Div().EaseInOut();
        var html = _renderer.RenderToString(element);
        Assert.Contains("transition-timing-function:cubic-bezier(0.4, 0, 0.2, 1)", html);
    }

    // Delay Tests
    [Fact]
    public void Delay100_ShouldApply100msDelay()
    {
        var element = Div().Delay100();
        var html = _renderer.RenderToString(element);
        Assert.Contains("transition-delay:100ms", html);
    }

    [Fact]
    public void Delay500_ShouldApply500msDelay()
    {
        var element = Div().Delay500();
        var html = _renderer.RenderToString(element);
        Assert.Contains("transition-delay:500ms", html);
    }

    // Animation Tests
    [Fact]
    public void Animation_WithCustomValue_ShouldApplyCorrectAnimation()
    {
        var element = Div().Animation("fadeIn 1s ease-in");
        var html = _renderer.RenderToString(element);
        Assert.Contains("animation:fadeIn 1s ease-in", html);
    }

    [Fact]
    public void AnimationName_ShouldApplyCorrectName()
    {
        var element = Div().AnimationName("bounce");
        var html = _renderer.RenderToString(element);
        Assert.Contains("animation-name:bounce", html);
    }

    [Fact]
    public void AnimateSpin_ShouldApplySpinAnimation()
    {
        var element = Div().AnimateSpin();
        var html = _renderer.RenderToString(element);
        Assert.Contains("animation:spin 1s linear infinite", html);
    }

    [Fact]
    public void AnimatePulse_ShouldApplyPulseAnimation()
    {
        var element = Div().AnimatePulse();
        var html = _renderer.RenderToString(element);
        Assert.Contains("animation:pulse 2s cubic-bezier(0.4, 0, 0.6, 1) infinite", html);
    }

    [Fact]
    public void AnimateBounce_ShouldApplyBounceAnimation()
    {
        var element = Div().AnimateBounce();
        var html = _renderer.RenderToString(element);
        Assert.Contains("animation:bounce 1s infinite", html);
    }

    // Will-change Tests
    [Fact]
    public void WillChange_WithCustomValue_ShouldApplyCorrectProperty()
    {
        var element = Div().WillChange("transform, opacity");
        var html = _renderer.RenderToString(element);
        Assert.Contains("will-change:transform, opacity", html);
    }

    [Fact]
    public void WillChangeTransform_ShouldApplyTransformProperty()
    {
        var element = Div().WillChangeTransform();
        var html = _renderer.RenderToString(element);
        Assert.Contains("will-change:transform", html);
    }

    [Fact]
    public void WillChangeOpacity_ShouldApplyOpacityProperty()
    {
        var element = Div().WillChangeOpacity();
        var html = _renderer.RenderToString(element);
        Assert.Contains("will-change:opacity", html);
    }

    // Chaining Tests
    [Fact]
    public void CompleteTransition_ShouldChainAllProperties()
    {
        var element = Div()
            .TransitionAll()
            .Duration300()
            .EaseInOut()
            .Delay100();

        var html = _renderer.RenderToString(element);
        Assert.Contains("transition-property:all", html);
        Assert.Contains("transition-duration:300ms", html);
        Assert.Contains("transition-timing-function:cubic-bezier(0.4, 0, 0.2, 1)", html);
        Assert.Contains("transition-delay:100ms", html);
    }

    [Fact]
    public void TransformWithTransition_ShouldWorkTogether()
    {
        var element = Div()
            .Scale(1.1)
            .TransitionTransform()
            .Duration300()
            .EaseOut();

        var html = _renderer.RenderToString(element);
        Assert.Contains("transform:scale(1.1)", html);
        Assert.Contains("transition-property:transform", html);
        Assert.Contains("transition-duration:300ms", html);
    }
}
