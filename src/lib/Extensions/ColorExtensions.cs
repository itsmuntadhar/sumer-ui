using SumerUI.Elements;

namespace SumerUI.Extensions;

public static class ColorExtensions
{
    public static Element BackgroundColor(this Element element, string color)
    {
        return element.Style("background-color", color);
    }

    public static Element BackgroundColor(this Element element, string color, double opacity)
    {
        return element.Style("background-color", color).Style("background-opacity", opacity.ToString());
    }

    public static Element TextColor(this Element element, string color)
    {
        return element.Style("color", color);
    }

    public static Element BorderColor(this Element element, string color)
    {
        return element.Style("border-color", color);
    }

    public static Element BorderColor(this Element element, string color, double opacity)
    {
        return element.Style("border-color", color).Style("border-opacity", opacity.ToString());
    }

    public static Element PlaceholderColor(this Element element, string color, float opacity)
    {
        return element.Style("::placeholder", $"color: {color}; opacity: {opacity.ToString()};");
    }

    public static Element TextColor(this Element element, string color, double opacity)
    {
        return element.Style("color", color).Style("color-opacity", opacity.ToString());
    }

    public static Element PlaceholderColor(this Element element, string color)
    {
        return element.Style("::placeholder", $"color: {color};");
    }

    public static Element PlaceholderColor(this Element element, string color, double opacity)
    {
        return element.Style("::placeholder", $"color: {color}; opacity: {opacity.ToString()};");
    }

    public static Element Opacity(this Element element, double opacity)
    {
        return element.Style("opacity", opacity.ToString());
    }

    public static Element HoverBackgroundColor(this Element element, string color)
    {
        return element.Style(":hover", $"background-color: {color};");
    }

    public static Element HoverTextColor(this Element element, string color)
    {
        return element.Style(":hover", $"color: {color};");
    }

    public static Element HoverBorderColor(this Element element, string color)
    {
        return element.Style(":hover", $"border-color: {color};");
    }
}

public static class Color
{
    public static string WithOpacity(string color, double opacity)
    {
        if (opacity < 0 || opacity > 1)
        {
            throw new ArgumentException("Opacity must be between 0 and 1");
        }

        var rgb = color.TrimStart('#');
        var r = Convert.ToInt32(rgb.Substring(0, 2), 16);
        var g = Convert.ToInt32(rgb.Substring(2, 2), 16);
        var b = Convert.ToInt32(rgb.Substring(4, 2), 16);

        return $"rgba({r}, {g}, {b}, {opacity})";
    }

    public static string LinearGradient(string direction, params string[] colors)
    {
        var colorStops = string.Join(", ", colors);
        return $"linear-gradient({direction}, {colorStops})";
    }

    public static string Black => "#000000";
    public static string White => "#FFFFFF";

    public static string Rose50 => "#FFF1F2";
    public static string Rose100 => "#FFE4E6";
    public static string Rose200 => "#FECDD3";
    public static string Rose300 => "#FDA4AF";
    public static string Rose400 => "#FB7185";
    public static string Rose500 => "#F43F5E";
    public static string Rose600 => "#E11D48";
    public static string Rose700 => "#BE123C";
    public static string Rose800 => "#9F1239";
    public static string Rose900 => "#881337";

    public static string Pink50 => "#FDF2F8";
    public static string Pink100 => "#FCE7F3";
    public static string Pink200 => "#FBCFE8";
    public static string Pink300 => "#F9A8D4";
    public static string Pink400 => "#F472B6";
    public static string Pink500 => "#EC4899";
    public static string Pink600 => "#DB2777";
    public static string Pink700 => "#BE185D";
    public static string Pink800 => "#9D174D";
    public static string Pink900 => "#831843";

    public static string Purple50 => "#FAF5FF";
    public static string Purple100 => "#F3E8FF";
    public static string Purple200 => "#E9D5FF";
    public static string Purple300 => "#D8B4FE";
    public static string Purple400 => "#C084FC";
    public static string Purple500 => "#A855F7";
    public static string Purple600 => "#9333EA";
    public static string Purple700 => "#7E22CE";
    public static string Purple800 => "#6B21A8";
    public static string Purple900 => "#581C87";

    public static string Indigo50 => "#EEF2FF";
    public static string Indigo100 => "#E0E7FF";
    public static string Indigo200 => "#C7D2FE";
    public static string Indigo300 => "#A5B4FC";
    public static string Indigo400 => "#818CF8";
    public static string Indigo500 => "#6366F1";
    public static string Indigo600 => "#4F46E5";
    public static string Indigo700 => "#4338CA";
    public static string Indigo800 => "#3730A3";
    public static string Indigo900 => "#312E81";

    public static string Blue50 => "#EFF6FF";
    public static string Blue100 => "#DBEAFE";
    public static string Blue200 => "#BFDBFE";
    public static string Blue300 => "#93C5FD";
    public static string Blue400 => "#60A5FA";
    public static string Blue500 => "#3B82F6";
    public static string Blue600 => "#2563EB";
    public static string Blue700 => "#1D4ED8";
    public static string Blue800 => "#1E40AF";
    public static string Blue900 => "#1E3A8A";

    public static string Emerald50 => "#ECFDF5";
    public static string Emerald100 => "#D1FAE5";
    public static string Emerald200 => "#A7F3D0";
    public static string Emerald300 => "#6EE7B7";
    public static string Emerald400 => "#34D399";
    public static string Emerald500 => "#10B981";
    public static string Emerald600 => "#059669";
    public static string Emerald700 => "#047857";
    public static string Emerald800 => "#065F46";
    public static string Emerald900 => "#064E3B";

    public static string Gray50 => "#F9FAFB";
    public static string Gray100 => "#F3F4F6";
    public static string Gray200 => "#E5E7EB";
    public static string Gray300 => "#D1D5DB";
    public static string Gray400 => "#9CA3AF";
    public static string Gray500 => "#6B7280";
    public static string Gray600 => "#4B5563";
    public static string Gray700 => "#374151";
    public static string Gray800 => "#1F2937";
    public static string Gray900 => "#111827";

    public static string Red50 => "#FEF2F2";
    public static string Red100 => "#FEE2E2";
    public static string Red200 => "#FECACA";
    public static string Red300 => "#FCA5A5";
    public static string Red400 => "#F87171";
    public static string Red500 => "#EF4444";
    public static string Red600 => "#DC2626";
    public static string Red700 => "#B91C1C";
    public static string Red800 => "#991B1B";
    public static string Red900 => "#7F1D1D";

    public static string Yellow50 => "#FFFBEB";
    public static string Yellow100 => "#FEF3C7";
    public static string Yellow200 => "#FDE68A";
    public static string Yellow300 => "#FCD34D";
    public static string Yellow400 => "#FBBF24";
    public static string Yellow500 => "#F59E0B";
    public static string Yellow600 => "#D97706";
    public static string Yellow700 => "#B45309";
    public static string Yellow800 => "#92400E";
    public static string Yellow900 => "#78350F";

    public static string Orange50 => "#FFF7ED";
    public static string Orange100 => "#FFEDD5";
    public static string Orange200 => "#FED7AA";
    public static string Orange300 => "#FDBA74";
    public static string Orange400 => "#FB923C";
    public static string Orange500 => "#F97316";
    public static string Orange600 => "#EA580C";
    public static string Orange700 => "#C2410C";
    public static string Orange800 => "#9A3412";
    public static string Orange900 => "#7C2D12";

    public static string Teal50 => "#F0FDFA";
    public static string Teal100 => "#CCFBF1";
    public static string Teal200 => "#99F6E4";
    public static string Teal300 => "#5EEAD4";
    public static string Teal400 => "#2DD4BF";
    public static string Teal500 => "#14B8A6";
    public static string Teal600 => "#0D9488";
    public static string Teal700 => "#0F766E";
    public static string Teal800 => "#115E59";
    public static string Teal900 => "#134E4A";

    public static string Cyan50 => "#ECFEFF";
    public static string Cyan100 => "#CFFAFE";
    public static string Cyan200 => "#A5F3FC";
    public static string Cyan300 => "#67E8F9";
    public static string Cyan400 => "#22D3EE";
    public static string Cyan500 => "#06B6D4";
    public static string Cyan600 => "#0891B2";
    public static string Cyan700 => "#0E7490";
    public static string Cyan800 => "#155E75";
    public static string Cyan900 => "#164E63";

    public static string Lime50 => "#F7FEE7";
    public static string Lime100 => "#ECFCCB";
    public static string Lime200 => "#D9F99D";
    public static string Lime300 => "#BEF264";
    public static string Lime400 => "#A3E635";
    public static string Lime500 => "#84CC16";
    public static string Lime600 => "#65A30D";
    public static string Lime700 => "#4D7C0F";
    public static string Lime800 => "#3F6212";
    public static string Lime900 => "#365314";

    public static string Amber50 => "#FFFBEB";
    public static string Amber100 => "#FEF3C7";
    public static string Amber200 => "#FDE68A";
    public static string Amber300 => "#FCD34D";
    public static string Amber400 => "#FBBF24";
    public static string Amber500 => "#F59E0B";
    public static string Amber600 => "#D97706";
    public static string Amber700 => "#B45309";
    public static string Amber800 => "#92400E";
    public static string Amber900 => "#78350F";
}
