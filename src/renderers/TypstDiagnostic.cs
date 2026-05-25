namespace SumerUI.Renderers;

public sealed record TypstDiagnostic(
    string Code,
    string Message,
    string ElementPath,
    string? Property = null,
    string? Value = null);

public sealed class TypstRendererOptions
{
    public double RootFontSizeInPoints { get; set; } = 12;
}
