using SumerUI.Elements;

namespace SumerUI.Extensions;

public static class TransitionExtensions
{
    // Transition Property
    public static Element Transition(this Element element, string transition) => element.Style("transition", transition);
    public static Element TransitionProperty(this Element element, string property) => element.Style("transition-property", property);
    public static Element TransitionDuration(this Element element, string duration) => element.Style("transition-duration", duration);
    public static Element TransitionTimingFunction(this Element element, string timingFunction) => element.Style("transition-timing-function", timingFunction);
    public static Element TransitionDelay(this Element element, string delay) => element.Style("transition-delay", delay);

    // Predefined transition properties
    public static Element TransitionNone(this Element element) => element.Style("transition-property", "none");
    public static Element TransitionAll(this Element element) => element.Style("transition-property", "all");
    public static Element TransitionColors(this Element element) => element.Style("transition-property", "color, background-color, border-color, text-decoration-color, fill, stroke");
    public static Element TransitionOpacity(this Element element) => element.Style("transition-property", "opacity");
    public static Element TransitionShadow(this Element element) => element.Style("transition-property", "box-shadow");
    public static Element TransitionTransform(this Element element) => element.Style("transition-property", "transform");

    // Predefined durations
    public static Element Duration75(this Element element) => element.Style("transition-duration", "75ms");
    public static Element Duration100(this Element element) => element.Style("transition-duration", "100ms");
    public static Element Duration150(this Element element) => element.Style("transition-duration", "150ms");
    public static Element Duration200(this Element element) => element.Style("transition-duration", "200ms");
    public static Element Duration300(this Element element) => element.Style("transition-duration", "300ms");
    public static Element Duration500(this Element element) => element.Style("transition-duration", "500ms");
    public static Element Duration700(this Element element) => element.Style("transition-duration", "700ms");
    public static Element Duration1000(this Element element) => element.Style("transition-duration", "1000ms");

    // Predefined timing functions
    public static Element EaseLinear(this Element element) => element.Style("transition-timing-function", "linear");
    public static Element EaseIn(this Element element) => element.Style("transition-timing-function", "cubic-bezier(0.4, 0, 1, 1)");
    public static Element EaseOut(this Element element) => element.Style("transition-timing-function", "cubic-bezier(0, 0, 0.2, 1)");
    public static Element EaseInOut(this Element element) => element.Style("transition-timing-function", "cubic-bezier(0.4, 0, 0.2, 1)");

    // Predefined delays
    public static Element Delay75(this Element element) => element.Style("transition-delay", "75ms");
    public static Element Delay100(this Element element) => element.Style("transition-delay", "100ms");
    public static Element Delay150(this Element element) => element.Style("transition-delay", "150ms");
    public static Element Delay200(this Element element) => element.Style("transition-delay", "200ms");
    public static Element Delay300(this Element element) => element.Style("transition-delay", "300ms");
    public static Element Delay500(this Element element) => element.Style("transition-delay", "500ms");
    public static Element Delay700(this Element element) => element.Style("transition-delay", "700ms");
    public static Element Delay1000(this Element element) => element.Style("transition-delay", "1000ms");

    // Animation
    public static Element Animation(this Element element, string animation) => element.Style("animation", animation);
    public static Element AnimationName(this Element element, string name) => element.Style("animation-name", name);
    public static Element AnimationDuration(this Element element, string duration) => element.Style("animation-duration", duration);
    public static Element AnimationTimingFunction(this Element element, string timingFunction) => element.Style("animation-timing-function", timingFunction);
    public static Element AnimationDelay(this Element element, string delay) => element.Style("animation-delay", delay);
    public static Element AnimationIterationCount(this Element element, string count) => element.Style("animation-iteration-count", count);
    public static Element AnimationDirection(this Element element, string direction) => element.Style("animation-direction", direction);
    public static Element AnimationFillMode(this Element element, string fillMode) => element.Style("animation-fill-mode", fillMode);
    public static Element AnimationPlayState(this Element element, string playState) => element.Style("animation-play-state", playState);

    // Predefined animations
    public static Element AnimateNone(this Element element) => element.Style("animation", "none");
    public static Element AnimateSpin(this Element element) => element.Style("animation", "spin 1s linear infinite");
    public static Element AnimatePing(this Element element) => element.Style("animation", "ping 1s cubic-bezier(0, 0, 0.2, 1) infinite");
    public static Element AnimatePulse(this Element element) => element.Style("animation", "pulse 2s cubic-bezier(0.4, 0, 0.6, 1) infinite");
    public static Element AnimateBounce(this Element element) => element.Style("animation", "bounce 1s infinite");

    // Will-change for performance
    public static Element WillChange(this Element element, string property) => element.Style("will-change", property);
    public static Element WillChangeAuto(this Element element) => element.Style("will-change", "auto");
    public static Element WillChangeTransform(this Element element) => element.Style("will-change", "transform");
    public static Element WillChangeOpacity(this Element element) => element.Style("will-change", "opacity");
    public static Element WillChangeScroll(this Element element) => element.Style("will-change", "scroll-position");
}
