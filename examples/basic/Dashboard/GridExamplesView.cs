using SumerUI.Elements;
using SumerUI.Extensions;
using SumerUI.Generators;
using SumerUI.Renderers;

namespace SumerUI.Example.Dashboard;

public class GridExamplesView
{
    public static async Task GenerateAsync()
    {
        var renderer = new HtmlRenderer();
        var generator = new StaticSiteGenerator("./out", new StaticSiteOptions
        {
            CleanOutput = true,
            PrettyUrls = true,
            MinifyHtml = false,
            Verbose = true
        });

        var page = new Html()
            .Content(
                new Head()
                    .Content(
                        new Meta().Attr("charset", "UTF-8"),
                        new Meta().Attr("name", "viewport").Attr("content", "width=device-width, initial-scale=1.0"),
                        new Title().Text("SumerUI Grid Examples")
                    ),
                new Body()
                    .Margin("0")
                    .Padding("2rem")
                    .BackgroundColor("#f3f4f6")
                    .Content(
                        // Title
                        new H1()
                            .Text("CSS Grid Examples")
                            .TextColor("#111827")
                            .MarginBottom("2rem"),

                        // Example 1: Simple 3-column grid
                        new Div()
                            .Content(
                                new H2().Text("Simple Grid - 3 Columns").MarginBottom("1rem"),
                                new Div()
                                    .Grid()
                                    .GridCols(3)
                                    .Gap("1rem")
                                    .MarginBottom("3rem")
                                    .Content(
                                        GridCard("1", "#3b82f6"),
                                        GridCard("2", "#10b981"),
                                        GridCard("3", "#f59e0b"),
                                        GridCard("4", "#ef4444"),
                                        GridCard("5", "#8b5cf6"),
                                        GridCard("6", "#ec4899")
                                    )
                            ),

                        // Example 2: Column spanning
                        new Div()
                            .Content(
                                new H2().Text("Column Spanning").MarginBottom("1rem"),
                                new Div()
                                    .Grid()
                                    .GridCols(4)
                                    .Gap("1rem")
                                    .MarginBottom("3rem")
                                    .Content(
                                        GridCard("Span 2", "#3b82f6").GridColSpan(2),
                                        GridCard("1", "#10b981"),
                                        GridCard("1", "#f59e0b"),
                                        GridCard("1", "#ef4444"),
                                        GridCard("1", "#8b5cf6"),
                                        GridCard("Full Width", "#ec4899").GridColSpanFull()
                                    )
                            ),

                        // Example 3: Custom template
                        new Div()
                            .Content(
                                new H2().Text("Custom Grid Template").MarginBottom("1rem"),
                                new Div()
                                    .Grid()
                                    .GridCols("200px 1fr 2fr")
                                    .GridRows("100px auto")
                                    .Gap("1rem")
                                    .MarginBottom("3rem")
                                    .Content(
                                        GridCard("200px", "#3b82f6"),
                                        GridCard("1fr", "#10b981"),
                                        GridCard("2fr", "#f59e0b"),
                                        GridCard("Auto", "#ef4444").GridColSpan(3)
                                    )
                            ),

                        // Example 4: Dashboard layout
                        new Div()
                            .Content(
                                new H2().Text("Dashboard Layout").MarginBottom("1rem"),
                                new Div()
                                    .Grid()
                                    .GridCols(4)
                                    .GridRows(3)
                                    .Gap("1rem")
                                    .Height("600px")
                                    .MarginBottom("3rem")
                                    .Content(
                                        // Header
                                        GridCard("Header", "#111827")
                                            .GridColSpanFull()
                                            .PlaceItemsCenter(),

                                        // Sidebar
                                        GridCard("Sidebar", "#374151")
                                            .GridRowSpan(2)
                                            .PlaceItemsCenter(),

                                        // Main content
                                        GridCard("Main Content", "#3b82f6")
                                            .GridColSpan(3)
                                            .GridRowSpan(2)
                                            .PlaceItemsCenter()
                                    )
                            ),

                        // Example 5: Grid with place-items
                        new Div()
                            .Content(
                                new H2().Text("Alignment Examples").MarginBottom("1rem"),
                                new Div()
                                    .Grid()
                                    .GridCols(3)
                                    .Gap("1rem")
                                    .Content(
                                        new Div()
                                            .Height("150px")
                                            .BackgroundColor("#e5e7eb")
                                            .BorderRadius("0.5rem")
                                            .Grid()
                                            .PlaceItemsCenter()
                                            .Content(
                                                new Div()
                                                    .Padding("1rem")
                                                    .BackgroundColor("#3b82f6")
                                                    .TextColor("white")
                                                    .BorderRadius("0.25rem")
                                                    .Text("Center")
                                            ),
                                        new Div()
                                            .Height("150px")
                                            .BackgroundColor("#e5e7eb")
                                            .BorderRadius("0.5rem")
                                            .Grid()
                                            .PlaceItemsStart()
                                            .Content(
                                                new Div()
                                                    .Padding("1rem")
                                                    .BackgroundColor("#10b981")
                                                    .TextColor("white")
                                                    .BorderRadius("0.25rem")
                                                    .Text("Start")
                                            ),
                                        new Div()
                                            .Height("150px")
                                            .BackgroundColor("#e5e7eb")
                                            .BorderRadius("0.5rem")
                                            .Grid()
                                            .PlaceItemsEnd()
                                            .Content(
                                                new Div()
                                                    .Padding("1rem")
                                                    .BackgroundColor("#f59e0b")
                                                    .TextColor("white")
                                                    .BorderRadius("0.25rem")
                                                    .Text("End")
                                            )
                                    )
                            )
                    )
            );

        await generator.GeneratePageAsync("grid-examples", page);
        Console.WriteLine("✅ Grid examples generated at: grid-examples/grid-examples.html");
    }

    private static Element GridCard(string text, string bgColor)
    {
        return new Div()
            .BackgroundColor(bgColor)
            .TextColor("white")
            .Padding("2rem")
            .BorderRadius("0.5rem")
            .FontSize("1.125rem")
            .FontBold()
            .Text(text);
    }
}
