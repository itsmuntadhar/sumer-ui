using SumerUI.Elements;

namespace SumerUI.Extensions;

public static class BreakpointExtensions
{
    // Standard Tailwind breakpoints
    private const string SmBreakpoint = "640px";   // @media (min-width: 640px)
    private const string MdBreakpoint = "768px";   // @media (min-width: 768px)
    private const string LgBreakpoint = "1024px";  // @media (min-width: 1024px)
    private const string XlBreakpoint = "1280px";  // @media (min-width: 1280px)
    private const string XxlBreakpoint = "1536px"; // @media (min-width: 1536px)

    /// <summary>
    /// Apply styles at the 'sm' breakpoint (min-width: 640px).
    /// Mobile-first approach: styles apply at 640px and above.
    /// </summary>
    public static Element Sm(this Element element, Action<Element> configure)
    {
        return ApplyResponsiveStyles(element, SmBreakpoint, configure);
    }

    /// <summary>
    /// Apply styles at the 'md' breakpoint (min-width: 768px).
    /// Mobile-first approach: styles apply at 768px and above.
    /// </summary>
    public static Element Md(this Element element, Action<Element> configure)
    {
        return ApplyResponsiveStyles(element, MdBreakpoint, configure);
    }

    /// <summary>
    /// Apply styles at the 'lg' breakpoint (min-width: 1024px).
    /// Mobile-first approach: styles apply at 1024px and above.
    /// </summary>
    public static Element Lg(this Element element, Action<Element> configure)
    {
        return ApplyResponsiveStyles(element, LgBreakpoint, configure);
    }

    /// <summary>
    /// Apply styles at the 'xl' breakpoint (min-width: 1280px).
    /// Mobile-first approach: styles apply at 1280px and above.
    /// </summary>
    public static Element Xl(this Element element, Action<Element> configure)
    {
        return ApplyResponsiveStyles(element, XlBreakpoint, configure);
    }

    /// <summary>
    /// Apply styles at the '2xl' breakpoint (min-width: 1536px).
    /// Mobile-first approach: styles apply at 1536px and above.
    /// </summary>
    public static Element TwoXl(this Element element, Action<Element> configure)
    {
        return ApplyResponsiveStyles(element, XxlBreakpoint, configure);
    }

    /// <summary>
    /// Apply styles with a custom media query.
    /// </summary>
    public static Element MediaQuery(this Element element, string query, Action<Element> configure)
    {
        return ApplyResponsiveStyles(element, query, configure);
    }

    private static Element ApplyResponsiveStyles(Element element, string breakpoint, Action<Element> configure)
    {
        element.EnsureResponsiveId();

        var tempElement = new Element(element.Tag);
        configure(tempElement);

        var mediaQueryKey = $"(min-width: {breakpoint})";

        if (!element.ResponsiveStyles.TryGetValue(mediaQueryKey, out Dictionary<string, string>? value))
        {
            value = [];
            element.ResponsiveStyles[mediaQueryKey] = value;
        }

        foreach (var style in tempElement.Styles)
        {
            value[style.Key] = style.Value;

            if (element.Styles.ContainsKey(style.Key))
            {
                if (!element.ResponsiveStyles.TryGetValue("base", out Dictionary<string, string>? baseStyles))
                {
                    baseStyles = [];
                    element.ResponsiveStyles["base"] = baseStyles;
                }

                // Only add to base if not already there
                if (!baseStyles.ContainsKey(style.Key))
                {
                    baseStyles[style.Key] = element.Styles[style.Key];
                }

                // Remove from inline styles
                element.Styles.Remove(style.Key);
            }
        }

        return element;
    }
}
