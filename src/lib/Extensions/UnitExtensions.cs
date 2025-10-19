namespace SumerUI.Extensions;

public static class UnitExtensions
{
    public static string Px<TNumber>(this TNumber v) where TNumber : struct, IFormattable
        => v.ToString(null, System.Globalization.CultureInfo.InvariantCulture) + "px";

    public static string Em<TNumber>(this TNumber v) where TNumber : struct, IFormattable
        => v.ToString(null, System.Globalization.CultureInfo.InvariantCulture) + "em";

    public static string Percent<TNumber>(this TNumber v) where TNumber : struct, IFormattable
        => v.ToString(null, System.Globalization.CultureInfo.InvariantCulture) + "%";

    public static string Vw<TNumber>(this TNumber v) where TNumber : struct, IFormattable
        => v.ToString(null, System.Globalization.CultureInfo.InvariantCulture) + "vw";

    public static string Vh<TNumber>(this TNumber v) where TNumber : struct, IFormattable
        => v.ToString(null, System.Globalization.CultureInfo.InvariantCulture) + "vh";

    public static string Rem<TNumber>(this TNumber v) where TNumber : struct, IFormattable
        => v.ToString(null, System.Globalization.CultureInfo.InvariantCulture) + "rem";
}
