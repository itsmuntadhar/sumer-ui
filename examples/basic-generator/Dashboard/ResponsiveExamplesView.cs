using SumerUI.Elements;
using SumerUI.Extensions;
using static SumerUI.Extensions.Elements;

namespace SumerUI.BasicGeneratorExample.Dashboard;

public sealed class ResponsiveExamplesView : Element
{
    public ResponsiveExamplesView() : base("div")
    {
        this.Padding("2rem")
            .BackgroundColor("#f3f4f6")
            .Content(
                // Title
                H1().Text("Responsive Design Examples")
                    .TextColor("#111827")
                    .MarginBottom("0.5rem"),

                P().Text("Resize your browser window to see the responsive layouts in action!")
                    .TextColor("#6b7280")
                    .MarginBottom("3rem"),

                // Example 1: Responsive Grid
                Section("Responsive Grid Layout",
                    "1 column on mobile, 2 on tablet, 3 on desktop, 4 on large screens",
                    new Div()
                        .Grid()
                        .GridCols(1)
                        .Gap("1rem")
                        .Sm(el => el.GridCols(2))
                        .Md(el => el.GridCols(3))
                        .Lg(el => el.GridCols(4))
                        .Content(
                            Card("📱 Mobile", "#3b82f6"),
                            Card("💻 Tablet", "#10b981"),
                            Card("🖥️ Desktop", "#f59e0b"),
                            Card("📺 Large", "#ef4444"),
                            Card("🎨 Design", "#8b5cf6"),
                            Card("🚀 Deploy", "#ec4899"),
                            Card("⚡ Fast", "#14b8a6"),
                            Card("✨ Modern", "#f97316")
                        )
                ),

                // Example 2: Responsive Flex Direction
                Section("Responsive Flex Direction",
                    "Column on mobile, row on tablet and up",
                    new Div()
                        .Flex()
                        .FlexColumn()
                        .Gap("1rem")
                        .Md(el => el.FlexRow())
                        .Content(
                            new Div()
                                .Padding("2rem")
                                .BackgroundColor("#3b82f6")
                                .TextColor("white")
                                .BorderRadius("0.5rem")
                                .Style("flex", "1")
                                .Text("First Item"),
                            new Div()
                                .Padding("2rem")
                                .BackgroundColor("#10b981")
                                .TextColor("white")
                                .BorderRadius("0.5rem")
                                .Style("flex", "1")
                                .Text("Second Item"),
                            new Div()
                                .Padding("2rem")
                                .BackgroundColor("#f59e0b")
                                .TextColor("white")
                                .BorderRadius("0.5rem")
                                .Style("flex", "1")
                                .Text("Third Item")
                        )
                ),

                // Example 3: Responsive Spacing
                Section("Responsive Spacing",
                    "Padding and gap increase with screen size",
                    new Div()
                        .Grid()
                        .GridCols(2)
                        .Gap("0.5rem")
                        .Sm(el => el.Gap("1rem"))
                        .Md(el => el.Gap("1.5rem"))
                        .Lg(el => el.Gap("2rem"))
                        .Content(
                            new Div()
                                .Padding("1rem")
                                .Sm(el => el.Padding("1.5rem"))
                                .Md(el => el.Padding("2rem"))
                                .Lg(el => el.Padding("2.5rem"))
                                .BackgroundColor("#ddd6fe")
                                .BorderRadius("0.5rem")
                                .Text("Responsive Padding"),
                            new Div()
                                .Padding("1rem")
                                .Sm(el => el.Padding("1.5rem"))
                                .Md(el => el.Padding("2rem"))
                                .Lg(el => el.Padding("2.5rem"))
                                .BackgroundColor("#bfdbfe")
                                .BorderRadius("0.5rem")
                                .Text("Grows with screen"),
                            new Div()
                                .Padding("1rem")
                                .Sm(el => el.Padding("1.5rem"))
                                .Md(el => el.Padding("2rem"))
                                .Lg(el => el.Padding("2.5rem"))
                                .BackgroundColor("#fecaca")
                                .BorderRadius("0.5rem")
                                .Text("Notice the gap"),
                            new Div()
                                .Padding("1rem")
                                .Sm(el => el.Padding("1.5rem"))
                                .Md(el => el.Padding("2rem"))
                                .Lg(el => el.Padding("2.5rem"))
                                .BackgroundColor("#fed7aa")
                                .BorderRadius("0.5rem")
                                .Text("Between items")
                        )
                ),

                // Example 4: Responsive Typography
                Section("Responsive Typography",
                    "Font sizes adapt to screen size",
                    new Div()
                        .Content(
                            H2().Text("Heading scales up")
                                .FontSize("1.5rem")
                                .Sm(el => el.FontSize("2rem"))
                                .Md(el => el.FontSize("2.5rem"))
                                .Lg(el => el.FontSize("3rem"))
                                .MarginBottom("1rem"),
                            P().Text("Body text also responds to screen size for better readability.")
                                .FontSize("0.875rem")
                                .Sm(el => el.FontSize("1rem"))
                                .Md(el => el.FontSize("1.125rem"))
                                .TextColor("#4b5563")
                        )
                ),

                // Example 5: Responsive Visibility/Width
                Section("Responsive Width",
                    "Container width adjusts for each breakpoint",
                    new Div()
                        .Width("100%")
                        .Sm(el => el.Width("640px"))
                        .Md(el => el.Width("768px"))
                        .Lg(el => el.Width("1024px"))
                        .Xl(el => el.Width("1280px"))
                        .Padding("2rem")
                        .BackgroundColor("#e0e7ff")
                        .BorderRadius("0.5rem")
                        .Margin("0 auto")
                        .Content(
                            P().Text("This container has maximum widths defined for each breakpoint:")
                                .MarginBottom("0.5rem")
                                .FontSize("1.125rem")
                                .FontBold(),
                            new Ul()
                                .Content(
                                    Li().Text("📱 Mobile: 100% width"),
                                    Li().Text("📱 SM (640px+): 640px max-width"),
                                    Li().Text("💻 MD (768px+): 768px max-width"),
                                    Li().Text("🖥️ LG (1024px+): 1024px max-width"),
                                    Li().Text("📺 XL (1280px+): 1280px max-width")
                                )
                        )
                ),

                // Example 6: Complex Dashboard Layout
                Section("Responsive Dashboard",
                    "Sidebar stacks on mobile, side-by-side on desktop",
                    new Div()
                        .Grid()
                        .GridCols(1)
                        .Lg(el => el.GridCols(4))
                        .Gap("1rem")
                        .Height("400px")
                        .Content(
                            // Sidebar
                            new Div()
                                .Lg(el => el.GridColSpan(1))
                                .BackgroundColor("#374151")
                                .TextColor("white")
                                .Padding("1.5rem")
                                .BorderRadius("0.5rem")
                                .Content(
                                    H3().Text("Sidebar").MarginBottom("0.5rem"),
                                    P().Text("Stacks on mobile").FontSize("0.875rem")
                                ),

                            // Main content
                            new Div()
                                .Lg(el => el.GridColSpan(3))
                                .BackgroundColor("#3b82f6")
                                .TextColor("white")
                                .Padding("1.5rem")
                                .BorderRadius("0.5rem")
                                .Flex()
                                .AlignItems("center")
                                .JustifyContent("center")
                                .Content(
                                    new Div().Content(
                                        H3().Text("Main Content").MarginBottom("0.5rem"),
                                        P().Text("Full width on mobile, 3/4 width on desktop")
                                            .FontSize("0.875rem")
                                    )
                                )
                        )
                )
            );
    }

    private static Element Section(string title, string description, Element content)
    {
        return new Div()
            .MarginBottom("4rem")
            .Content(
                H2().Text(title)
                    .TextColor("#111827")
                    .FontSize("1.5rem")
                    .FontBold()
                    .MarginBottom("0.5rem"),
                P().Text(description)
                    .TextColor("#6b7280")
                    .MarginBottom("1.5rem"),
                content
            );
    }

    private static Element Card(string text, string bgColor)
    {
        return new Div()
            .BackgroundColor(bgColor)
            .TextColor("white")
            .Padding("2rem")
            .BorderRadius("0.5rem")
            .FontSize("1.125rem")
            .Text(text);
    }
}
