using SumerUI.Elements;
using SumerUI.Extensions;
using static SumerUI.Extensions.Elements;

namespace SumerUI.BasicGeneratorExample.Dashboard;

public sealed class TransformTransitionExamplesView : Element
{
    public TransformTransitionExamplesView() : base("div")
    {
        this.Padding(2.Rem())
            .BackgroundColor("#f3f4f6")
            .Content(
                // Add hover styles
                new Element("style")
                    .Text(@"
                        .hover-scale:hover { transform: scale(1.15); }
                        .hover-fade:hover { opacity: 0.5; }
                        .hover-color:hover { background-color: #ef4444 !important; }
                        .hover-button:hover { transform: scale(1.05); box-shadow: 0 10px 20px rgba(0,0,0,0.2); }
                        .hover-button-rounded:hover { transform: scale(1.05); }
                    "),

                // Header
                H1().Text("Transform & Transition Examples")
                    .TextColor("#111827")
                    .MarginBottom(2.Rem()),

                // Scale Section
                Section("Scale Transforms"),
                new Div()
                    .Grid()
                    .GridCols(3)
                    .Gap(1.Rem())
                    .MarginBottom(4.Rem())
                    .Content(
                        Card("Scale 50%",
                            new Div()
                                .Width(100.Px())
                                .Height(100.Px())
                                .BackgroundColor("#3b82f6")
                                .BorderRadius("0.5rem")
                                .Scale50()
                                .Margin("auto")
                        ),
                        Card("Scale 100%",
                            new Div()
                                .Width(100.Px())
                                .Height(100.Px())
                                .BackgroundColor("#10b981")
                                .BorderRadius("0.5rem")
                                .Scale100()
                                .Margin("auto")
                        ),
                        Card("Scale 150%",
                            new Div()
                                .Width(100.Px())
                                .Height(100.Px())
                                .BackgroundColor("#f59e0b")
                                .BorderRadius("0.5rem")
                                .Scale150()
                                .Margin("auto")
                        )
                    ),

                // Rotate Section
                Section("Rotate Transforms"),
                new Div()
                    .Grid()
                    .GridCols(4)
                    .Gap(1.Rem())
                    .MarginBottom(4.Rem())
                    .Content(
                        Card("0°",
                            new Div()
                                .Width(80.Px())
                                .Height(80.Px())
                                .BackgroundColor("#ef4444")
                                .Rotate0()
                                .Margin("auto")
                        ),
                        Card("45°",
                            new Div()
                                .Width(80.Px())
                                .Height(80.Px())
                                .BackgroundColor("#8b5cf6")
                                .Rotate45()
                                .Margin("auto")
                        ),
                        Card("90°",
                            new Div()
                                .Width(80.Px())
                                .Height(80.Px())
                                .BackgroundColor("#ec4899")
                                .Rotate90()
                                .Margin("auto")
                        ),
                        Card("180°",
                            new Div()
                                .Width(80.Px())
                                .Height(80.Px())
                                .BackgroundColor("#14b8a6")
                                .Rotate180()
                                .Margin("auto")
                        )
                    ),

                // Translate Section
                Section("Translate Transforms"),
                new Div()
                    .Grid()
                    .GridCols(2)
                    .Gap(1.Rem())
                    .MarginBottom(4.Rem())
                    .Content(
                        Card("Translate X (50%)",
                            new Div()
                                .Position("relative")
                                .Height(100.Px())
                                .BackgroundColor("#e0e7ff")
                                .BorderRadius("0.5rem")
                                .Content(
                                    new Div()
                                        .Width(50.Px())
                                        .Height(50.Px())
                                        .BackgroundColor("#3b82f6")
                                        .BorderRadius("0.375rem")
                                        .TranslateXHalf()
                                        .Position("absolute")
                                        .Top(25.Px())
                                )
                        ),
                        Card("Translate Y (50%)",
                            new Div()
                                .Position("relative")
                                .Height(100.Px())
                                .BackgroundColor("#fce7f3")
                                .BorderRadius("0.5rem")
                                .Content(
                                    new Div()
                                        .Width(50.Px())
                                        .Height(50.Px())
                                        .BackgroundColor("#ec4899")
                                        .BorderRadius("0.375rem")
                                        .TranslateYHalf()
                                        .Position("absolute")
                                        .Left(25.Px())
                                )
                        )
                    ),

                // Skew Section
                Section("Skew Transforms"),
                new Div()
                    .Grid()
                    .GridCols(3)
                    .Gap(1.Rem())
                    .MarginBottom(4.Rem())
                    .Content(
                        Card("Skew X (6°)",
                            new Div()
                                .Width(100.Px())
                                .Height(100.Px())
                                .BackgroundColor("#f59e0b")
                                .BorderRadius("0.5rem")
                                .SkewX6()
                                .Margin("auto")
                        ),
                        Card("Skew Y (6°)",
                            new Div()
                                .Width(100.Px())
                                .Height(100.Px())
                                .BackgroundColor("#10b981")
                                .BorderRadius("0.5rem")
                                .SkewY6()
                                .Margin("auto")
                        ),
                        Card("Skew (-3°, -3°)",
                            new Div()
                                .Width(100.Px())
                                .Height(100.Px())
                                .BackgroundColor("#8b5cf6")
                                .BorderRadius("0.5rem")
                                .Skew(-3, -3)
                                .Margin("auto")
                        )
                    ),

                // Transition Section
                Section("Transitions (Hover Effects)"),
                P().Text("Hover over the boxes to see the transitions in action!")
                    .TextColor("#6b7280")
                    .MarginBottom(1.Rem())
                    .FontSize("0.875rem"),
                new Div()
                    .Grid()
                    .GridCols(3)
                    .Gap(1.Rem())
                    .MarginBottom(4.Rem())
                    .Content(
                        Card("Scale on Hover",
                            new Div()
                                .Width(100.Px())
                                .Height(100.Px())
                                .BackgroundColor("#3b82f6")
                                .BorderRadius("0.5rem")
                                .TransitionTransform()
                                .Duration300()
                                .EaseInOut()
                                .Margin("auto")
                                .Cursor("pointer")
                                .Class("hover-scale")
                                .Content(
                                    P().Text("Hover").TextColor("white").Flex().AlignItems("center").JustifyContent("center").Height(100.Px())
                                )
                        ),
                        Card("Fade on Hover",
                            new Div()
                                .Width(100.Px())
                                .Height(100.Px())
                                .BackgroundColor("#10b981")
                                .BorderRadius("0.5rem")
                                .TransitionOpacity()
                                .Duration500()
                                .EaseOut()
                                .Margin("auto")
                                .Cursor("pointer")
                                .Class("hover-fade")
                                .Content(
                                    P().Text("Hover").TextColor("white").Flex().AlignItems("center").JustifyContent("center").Height(100.Px())
                                )
                        ),
                        Card("Color Change",
                            new Div()
                                .Width(100.Px())
                                .Height(100.Px())
                                .BackgroundColor("#f59e0b")
                                .BorderRadius("0.5rem")
                                .TransitionColors()
                                .Duration300()
                                .EaseIn()
                                .Margin("auto")
                                .Cursor("pointer")
                                .Class("hover-color")
                                .Content(
                                    P().Text("Hover").TextColor("white").Flex().AlignItems("center").JustifyContent("center").Height(100.Px())
                                )
                        )
                    ),

                // Timing Functions Section
                Section("Transition Timing Functions"),
                new Div()
                    .Grid()
                    .GridCols(4)
                    .Gap(1.Rem())
                    .MarginBottom(4.Rem())
                    .Content(
                        TimingCard("Linear", "linear", "#3b82f6"),
                        TimingCard("Ease In", "ease-in", "#10b981"),
                        TimingCard("Ease Out", "ease-out", "#f59e0b"),
                        TimingCard("Ease In-Out", "ease-in-out", "#ef4444")
                    ),

                // Complex Transform Section
                Section("Combined Transforms"),
                new Div()
                    .Grid()
                    .GridCols(2)
                    .Gap(1.Rem())
                    .MarginBottom(4.Rem())
                    .Content(
                        Card("Scale + Rotate",
                            new Div()
                                .Width(100.Px())
                                .Height(100.Px())
                                .BackgroundColor("#8b5cf6")
                                .BorderRadius("0.5rem")
                                .Transform("scale(1.2) rotate(15deg)")
                                .Margin("auto")
                        ),
                        Card("Rotate + Skew + Translate",
                            new Div()
                                .Width(100.Px())
                                .Height(100.Px())
                                .BackgroundColor("#ec4899")
                                .BorderRadius("0.5rem")
                                .Transform("rotate(10deg) skew(5deg, 5deg) translateX(10px)")
                                .Margin("auto")
                        )
                    ),

                // Transform Origin Section
                Section("Transform Origin"),
                new Div()
                    .Grid()
                    .GridCols(3)
                    .Gap(1.Rem())
                    .MarginBottom(4.Rem())
                    .Content(
                        Card("Origin: Top Left",
                            new Div()
                                .Width(100.Px())
                                .Height(100.Px())
                                .BackgroundColor("#3b82f6")
                                .BorderRadius("0.5rem")
                                .OriginTopLeft()
                                .Rotate45()
                                .Margin("auto")
                        ),
                        Card("Origin: Center",
                            new Div()
                                .Width(100.Px())
                                .Height(100.Px())
                                .BackgroundColor("#10b981")
                                .BorderRadius("0.5rem")
                                .OriginCenter()
                                .Rotate45()
                                .Margin("auto")
                        ),
                        Card("Origin: Bottom Right",
                            new Div()
                                .Width(100.Px())
                                .Height(100.Px())
                                .BackgroundColor("#f59e0b")
                                .BorderRadius("0.5rem")
                                .OriginBottomRight()
                                .Rotate45()
                                .Margin("auto")
                        )
                    ),

                // Interactive Button Example
                Section("Interactive Button Example"),
                new Div()
                    .Flex()
                    .JustifyContent("center")
                    .Gap(1.Rem())
                    .Content(
                        new Div()
                            .Padding("1rem", "2rem")
                            .BackgroundColor("#3b82f6")
                            .TextColor("white")
                            .BorderRadius("0.5rem")
                            .FontWeight(600)
                            .TransitionAll()
                            .Duration300()
                            .EaseInOut()
                            .BoxShadow("0 4px 6px rgba(0,0,0,0.1)")
                            .Cursor("pointer")
                            .Class("hover-button")
                            .Content(Span().Text("Hover Me!")),
                        new Div()
                            .Padding("1rem", "2rem")
                            .BackgroundColor("#10b981")
                            .TextColor("white")
                            .BorderRadius("9999px")
                            .FontWeight(600)
                            .TransitionTransform()
                            .Duration200()
                            .EaseOut()
                            .BoxShadow("0 4px 6px rgba(0,0,0,0.1)")
                            .Cursor("pointer")
                            .Class("hover-button-rounded")
                            .Content(Span().Text("Click Me!"))
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
                    .FontSize("0.875rem")
                    .TextCenter(),
                new Div().Content(content)
            );
    }

    private static Element TimingCard(string name, string timing, string color)
    {
        return Card(name,
            new Div()
                .Width(60.Px())
                .Height(60.Px())
                .BackgroundColor(color)
                .BorderRadius("0.375rem")
                .TransitionProperty("transform")
                .TransitionDuration("1s")
                .TransitionTimingFunction(timing)
                .Margin("auto")
        );
    }
}
