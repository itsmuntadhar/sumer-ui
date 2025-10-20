using SumerUI.Elements;
using SumerUI.Extensions;
using static SumerUI.Extensions.Elements;

namespace SumerUI.BasicGeneratorExample.Dashboard;

public sealed class TypographyExamplesView : Element
{
    public TypographyExamplesView() : base("div")
    {
        this.Padding(2.Rem())
            .BackgroundColor("#f3f4f6")
            .Content(
                // Header
                H1().Text("Typography Extensions")
                    .TextColor("#111827")
                    .MarginBottom(2.Rem()),

                // Font Weights Section
                Section("Font Weights"),
                new Div()
                    .Grid()
                    .GridCols(2)
                    .Gap(1.Rem())
                    .MarginBottom(4.Rem())
                    .Content(
                        Card("Weight Scale",
                            new Div().Content(
                                P().Text("Thin (100)").FontThin().MarginBottom(0.5.Rem()),
                                P().Text("Light (300)").FontLight().MarginBottom(0.5.Rem()),
                                P().Text("Normal (400)").FontNormal().MarginBottom(0.5.Rem()),
                                P().Text("Medium (500)").FontMedium().MarginBottom(0.5.Rem()),
                                P().Text("Semibold (600)").FontSemibold().MarginBottom(0.5.Rem()),
                                P().Text("Bold (700)").FontBold().MarginBottom(0.5.Rem()),
                                P().Text("Extra Bold (800)").FontExtraBold().MarginBottom(0.5.Rem()),
                                P().Text("Black (900)").FontBlack()
                            )
                        ),
                        Card("Custom & Styles",
                            new Div().Content(
                                P().Text("Custom Weight (550)").FontWeight(550).MarginBottom(0.5.Rem()),
                                P().Text("Italic Text").Italic().MarginBottom(0.5.Rem()),
                                P().Text("Small Caps Text").SmallCaps().MarginBottom(0.5.Rem()),
                                P().Text("Tabular Nums: 1234567890").TabularNums()
                            )
                        )
                    ),

                // Letter Spacing Section
                Section("Letter Spacing"),
                new Div()
                    .Grid()
                    .GridCols(2)
                    .Gap(1.Rem())
                    .MarginBottom(4.Rem())
                    .Content(
                        Card("Tracking",
                            new Div().Content(
                                P().Text("Tighter (-0.05em)").TrackingTighter().MarginBottom(0.5.Rem()),
                                P().Text("Tight (-0.025em)").TrackingTight().MarginBottom(0.5.Rem()),
                                P().Text("Normal (0)").TrackingNormal().MarginBottom(0.5.Rem()),
                                P().Text("Wide (0.025em)").TrackingWide().MarginBottom(0.5.Rem()),
                                P().Text("Wider (0.05em)").TrackingWider().MarginBottom(0.5.Rem()),
                                P().Text("Widest (0.1em)").TrackingWidest()
                            )
                        ),
                        Card("Custom Example",
                            new Div().Content(
                                P().Text("WIDELY SPACED TEXT")
                                    .LetterSpacing("0.15em")
                                    .Uppercase()
                                    .FontWeight(600)
                                    .TextColor("#3b82f6")
                                    .TextXl()
                            )
                        )
                    ),

                // Line Height Section
                Section("Line Height"),
                new Div()
                    .Grid()
                    .GridCols(2)
                    .Gap(1.Rem())
                    .MarginBottom(4.Rem())
                    .Content(
                        Card("Leading Tight",
                            P().Text("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.")
                                .LeadingTight()
                                .Padding(0.5.Rem())
                                .BackgroundColor("#ddd6fe")
                                .BorderRadius("0.5rem")
                        ),
                        Card("Leading Loose",
                            P().Text("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.")
                                .LeadingLoose()
                                .Padding(0.5.Rem())
                                .BackgroundColor("#bbf7d0")
                                .BorderRadius("0.5rem")
                        )
                    ),

                // Font Families Section
                Section("Font Families"),
                new Div()
                    .Grid()
                    .GridCols(3)
                    .Gap(1.Rem())
                    .MarginBottom(4.Rem())
                    .Content(
                        Card("Sans Serif",
                            P().Text("The quick brown fox jumps over the lazy dog. 0123456789")
                                .FontSans()
                                .FontSize("1.125rem")
                        ),
                        Card("Serif",
                            P().Text("The quick brown fox jumps over the lazy dog. 0123456789")
                                .FontSerif()
                                .FontSize("1.125rem")
                        ),
                        Card("Monospace",
                            P().Text("The quick brown fox jumps over the lazy dog. 0123456789")
                                .FontMono()
                                .FontSize("1rem")
                        )
                    ),

                // Text Decoration Section
                Section("Text Decoration"),
                new Div()
                    .Grid()
                    .GridCols(2)
                    .Gap(1.Rem())
                    .MarginBottom(4.Rem())
                    .Content(
                        Card("Decoration Lines",
                            new Div().Content(
                                P().Text("Underline Text").Underline().MarginBottom(0.5.Rem()),
                                P().Text("Line Through Text").LineThrough().MarginBottom(0.5.Rem()),
                                P().Text("Overline Text").Overline()
                            )
                        ),
                        Card("Decoration Styles",
                            new Div().Content(
                                P().Text("Wavy Underline").Underline().DecorationWavy().TextColor("#3b82f6").MarginBottom(0.5.Rem()),
                                P().Text("Dashed Underline").Underline().DecorationDashed().TextColor("#10b981").MarginBottom(0.5.Rem()),
                                P().Text("Dotted Underline").Underline().DecorationDotted().TextColor("#f59e0b")
                            )
                        )
                    ),

                // Text Overflow Section
                Section("Text Overflow & Utilities"),
                new Div()
                    .Grid()
                    .GridCols(2)
                    .Gap(1.Rem())
                    .MarginBottom(4.Rem())
                    .Content(
                        Card("Truncate",
                            new Div()
                                .Width(250.Px())
                                .Content(
                                    P().Text("This is a very long text that will be truncated with an ellipsis when it exceeds the container width")
                                        .Truncate()
                                        .Padding(0.5.Rem())
                                        .BackgroundColor("#e0e7ff")
                                        .BorderRadius("0.375rem")
                                )
                        ),
                        Card("Break Words",
                            new Div()
                                .Width(200.Px())
                                .Content(
                                    P().Text("ThisIsAVeryLongWordThatNeedsToBreakToFitTheContainer")
                                        .BreakWords()
                                        .Padding(0.5.Rem())
                                        .BackgroundColor("#fce7f3")
                                        .BorderRadius("0.375rem")
                                )
                        )
                    ),

                // Complex Example
                Section("Complex Typography Example"),
                new Div()
                    .Padding(2.Rem())
                    .BackgroundColor("white")
                    .BorderRadius("0.75rem")
                    .BoxShadow("0 4px 6px rgba(0,0,0,0.1)")
                    .Content(
                        H2().Text("Elegant Typography")
                            .FontSerif()
                            .FontWeight(700)
                            .Text3Xl()
                            .TrackingTight()
                            .TextColor("#1f2937")
                            .MarginBottom(0.5.Rem()),
                        P().Text("Beautiful, carefully crafted text using modern font stacks and spacing")
                            .FontSans()
                            .TextLg()
                            .TrackingWide()
                            .TextColor("#6b7280")
                            .LeadingRelaxed()
                            .MarginBottom(1.5.Rem()),
                        new Div()
                            .Padding(1.Rem())
                            .BackgroundColor("#3b82f6")
                            .BorderRadius("0.5rem")
                            .Flex()
                            .JustifyContent("center")
                            .Content(
                                Span().Text("GET STARTED")
                                    .FontWeight(700)
                                    .LetterSpacing("0.1em")
                                    .Uppercase()
                                    .TextColor("white")
                                    .TextSm()
                            )
                    )
            );
    }

    private static Element Section(string title)
    {
        return new Div()
            .MarginBottom(1.5.Rem())
            .Content(
                H2().Text(title)
                    .TextColor("#111827")
                    .FontSize("1.5rem")
                    .FontWeight(700)
                    .MarginBottom(0.5.Rem()),
                new Div()
                    .Width(4.Rem())
                    .Height(0.25.Rem())
                    .BackgroundColor("#3b82f6")
                    .BorderRadius("9999px")
            );
    }

    private static Element Card(string title, params Element[] content)
    {
        return new Div()
            .Padding(1.5.Rem())
            .BackgroundColor("white")
            .BorderRadius("0.5rem")
            .BoxShadow("0 1px 3px rgba(0,0,0,0.1)")
            .Content(
                H3().Text(title)
                    .FontWeight(600)
                    .TextColor("#374151")
                    .MarginBottom(1.Rem())
                    .FontSize("1.125rem"),
                new Div().Content(content)
            );
    }
}
