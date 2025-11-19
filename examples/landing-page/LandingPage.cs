using SumerUI.Elements;
using SumerUI.Extensions;
using static SumerUI.Extensions.Elements;

namespace SumerUI.LandingPage;

public sealed class LandingPage : Element
{
    public LandingPage() : base("")
    {
        Content(Html()
            .Attr("lang", "en")
            .Content(
                BuildHead(),
                BuildBody()
            )
        );
    }

    private static Element BuildHead()
    {
        return Head().Content(
            Meta().Attr("charset", "UTF-8"),
            Meta().Attr("name", "viewport").Attr("content", "width=device-width, initial-scale=1.0"),
            Meta().Attr("name", "description").Attr("content", "SumerUI - A type-safe, fluent C# library for generating static HTML with Tailwind-inspired utilities."),
            Title().Text("SumerUI - Type-Safe HTML Generation for C#"),
            Script("https://cdn.jsdelivr.net/npm/@tailwindcss/browser@4")
        );
    }

    private static Element BuildBody()
    {
        return Body()
            .MinHeight("100vh")
            .BackgroundColor("#f9fafb")
            .Content(
                BuildHero(),
                BuildFeatures(),
                BuildCodeExample(),
                BuildQuickStart(),
                BuildFooter()
            );
    }

    private static Element BuildHero()
    {
        return Div()
            .Flex()
            .FlexColumn()
            .AlignItems("center")
            .JustifyContent("center")
            .MinHeight("100vh")
            .Padding("2rem")
            .Style("background", "linear-gradient(135deg, #667eea 0%, #764ba2 100%)")
            .TextColor("#ffffff")
            .Content(
                Div()
                    .MaxWidth("56rem")
                    .TextCenter()
                    .Content(
                        // Logo/Title
                        H1()
                            .Text("SumerUI")
                            .FontBold()
                            .FontSize("4rem")
                            .MarginBottom("1rem")
                            .LetterSpacing("-0.05em"),

                        // Tagline
                        P()
                            .Text("Type-safe, fluent C# library for generating static HTML")
                            .FontSize("1.5rem")
                            .MarginBottom("2rem")
                            .Style("opacity", "0.9"),

                        // Features badges
                        Div()
                            .Flex()
                            .FlexWrap("wrap")
                            .Gap("1rem")
                            .JustifyContent("center")
                            .MarginBottom("3rem")
                            .Content(
                                Badge("🎨 Fluent API"),
                                Badge("🔒 Type-Safe"),
                                Badge("🎯 Tailwind-Inspired"),
                                Badge("📦 Static Site Gen"),
                                Badge("🚀 Zero JavaScript")
                            ),

                        // CTA Buttons
                        Div()
                            .Flex()
                            .Gap("1rem")
                            .JustifyContent("center")
                            .FlexWrap("wrap")
                            .Content(
                                A("https://github.com/itsmuntadhar/sumer-ui")
                                    .Attr("target", "_blank")
                                    .Padding("1rem", "2rem")
                                    .BackgroundColor("#ffffff")
                                    .TextColor("#667eea")
                                    .FontBold()
                                    .BorderRadius("0.5rem")
                                    .Text("View on GitHub")
                                    .Style("text-decoration", "none")
                                    .Style("transition", "transform 0.2s"),

                                A("#quick-start")
                                    .Padding("1rem", "2rem")
                                    .BackgroundColor("rgba(255, 255, 255, 0.2)")
                                    .TextColor("#ffffff")
                                    .FontBold()
                                    .BorderRadius("0.5rem")
                                    .Border("2px solid white")
                                    .Text("Get Started")
                                    .Style("text-decoration", "none")
                                    .Style("transition", "transform 0.2s")
                            )
                    )
            );
    }

    private static Element BuildFeatures()
    {
        return Div()
            .Padding("4rem", "2rem")
            .MaxWidth("80rem")
            .Margin("0", "auto")
            .Content(
                H2()
                    .Text("Why SumerUI?")
                    .FontBold()
                    .FontSize("3rem")
                    .TextCenter()
                    .MarginBottom("3rem")
                    .TextColor("#1f2937"),

                Div()
                    .Grid()
                    .GridCols(1)
                    .Md(e => e.GridCols(2))
                    .Lg(e => e.GridCols(3))
                    .Gap("2rem")
                    .Content(
                        FeatureCard(
                            "🎨",
                            "Fluent API",
                            "Chainable methods make building HTML intuitive and readable. Write code that looks like the structure you're creating."
                        ),
                        FeatureCard(
                            "🔒",
                            "Type-Safe",
                            "Full IntelliSense support with no magic strings. Catch errors at compile time, not runtime."
                        ),
                        FeatureCard(
                            "🎯",
                            "Tailwind-Inspired",
                            "Familiar utility-first approach with type-safe methods. All the power of Tailwind in pure C#."
                        ),
                        FeatureCard(
                            "📦",
                            "Static Site Generation",
                            "Export to HTML files ready for CDN deployment. Perfect for blogs, documentation, and marketing sites."
                        ),
                        FeatureCard(
                            "🚀",
                            "Zero JavaScript",
                            "Pure server-side rendering with no client-side dependencies. Fast, SEO-friendly, and accessible."
                        ),
                        FeatureCard(
                            "🔧",
                            "Reusable Components",
                            "Build component libraries with C# classes. Share and reuse UI patterns across projects."
                        )
                    )
            );
    }

    private static Element BuildCodeExample()
    {
        return Div()
            .Padding("4rem", "2rem")
            .BackgroundColor("#1f2937")
            .TextColor("#ffffff")
            .Content(
                Div()
                    .MaxWidth("80rem")
                    .Margin("0", "auto")
                    .Content(
                        H2()
                            .Text("See It In Action")
                            .FontBold()
                            .FontSize("3rem")
                            .TextCenter()
                            .MarginBottom("3rem"),

                        Div()
                            .Grid()
                            .GridCols(1)
                            .Lg(e => e.GridCols(2))
                            .Gap("2rem")
                            .AlignItems("center")
                            .Content(
                                // Code
                                Div()
                                    .Padding("1.5rem")
                                    .BackgroundColor("#1e293b")
                                    .BorderRadius("0.5rem")
                                    .Overflow("auto")
                                    .Content(
                                        Span()
                                            .TextColor("#e5e7eb")
                                            .FontMono()
                                            .FontSize("0.9rem")
                                            .LineHeight("1.6")
                                            .Style("white-space", "pre")
                                            .Text(@"var page = Div()
    .Flex()
    .AlignItems(""center"")
    .JustifyContent(""center"")
    .MinHeight(""100vh"")
    .Style(""background"",
        ""linear-gradient(135deg, 
         #667eea 0%, #764ba2 100%)"")
    .Content(
        H1()
            .Text(""Hello, SumerUI!"")
            .FontBold()
            .Text4Xl()
            .TextColor(""#fff"")
    );")
                                    ),

                                // Result
                                Div()
                                    .Padding("2rem")
                                    .BackgroundColor("#ffffff")
                                    .BorderRadius("0.5rem")
                                    .Content(
                                        Div()
                                            .Flex()
                                            .AlignItems("center")
                                            .JustifyContent("center")
                                            .MinHeight("20rem")
                                            .Style("background", "linear-gradient(135deg, #667eea 0%, #764ba2 100%)")
                                            .BorderRadius("0.5rem")
                                            .Content(
                                                H1()
                                                    .Text("Hello, SumerUI!")
                                                    .FontBold()
                                                    .FontSize("2.5rem")
                                                    .TextColor("#ffffff")
                                            )
                                    )
                            )
                    )
            );
    }

    private static Element BuildQuickStart()
    {
        return Div()
            .Attr("id", "quick-start")
            .Padding("4rem", "2rem")
            .BackgroundColor("#ffffff")
            .Content(
                Div()
                    .MaxWidth("56rem")
                    .Margin("0", "auto")
                    .Content(
                        H2()
                            .Text("Quick Start")
                            .FontBold()
                            .FontSize("3rem")
                            .TextCenter()
                            .MarginBottom("2rem")
                            .TextColor("#1f2937"),

                        // Installation
                        Div()
                            .MarginBottom("3rem")
                            .Content(
                                H3()
                                    .Text("1. Install")
                                    .FontBold()
                                    .FontSize("1.5rem")
                                    .MarginBottom("1rem")
                                    .TextColor("#374151"),

                                Div()
                                    .Padding("1.5rem")
                                    .BackgroundColor("#1e293b")
                                    .BorderRadius("0.5rem")
                                    .Content(
                                        Span()
                                            .TextColor("#e5e7eb")
                                            .FontMono()
                                            .Style("white-space", "pre")
                                            .Text(@"dotnet add package SumerUI
dotnet add package SumerUI.Renderers
dotnet add package SumerUI.Generators")
                                    )
                            ),

                        // Create
                        Div()
                            .MarginBottom("3.Rem")
                            .Content(
                                H3()
                                    .Text("2. Create")
                                    .FontBold()
                                    .FontSize("1.5rem")
                                    .MarginBottom("1rem")
                                    .TextColor("#374151"),

                                Div()
                                    .Padding("1.5rem")
                                    .BackgroundColor("#1e293b")
                                    .BorderRadius("0.5rem")
                                    .Overflow("auto")
                                    .Content(
                                        Span()
                                            .TextColor("#e5e7eb")
                                            .FontMono()
                                            .FontSize("0.9rem")
                                            .LineHeight("1.6")
                                            .Style("white-space", "pre")
                                            .Text(@"using SumerUI.Elements;
using SumerUI.Generators;
using static SumerUI.Extensions.Elements;

var page = Div()
    .Padding(""2rem"")
    .Content(
        H1().Text(""My Site"").FontBold()
    );

var generator = new StaticSiteGenerator(""./out"");
await generator.GeneratePageAsync(""/"", page);")
                                    )
                            ),

                        // Deploy
                        Div()
                            .Content(
                                H3()
                                    .Text("3. Deploy")
                                    .FontBold()
                                    .FontSize("1.5rem")
                                    .MarginBottom("1rem")
                                    .TextColor("#374151"),

                                P()
                                    .TextColor("#4b5563")
                                    .FontSize("1.1rem")
                                    .LineHeight("1.6")
                                    .Text("Upload the generated files to any static hosting service: Netlify, Vercel, GitHub Pages, AWS S3, or any CDN. No server required!")
                            )
                    )
            );
    }

    private static Element BuildFooter()
    {
        return Div()
            .Padding("3rem", "2rem")
            .BackgroundColor("#111827")
            .TextColor("#ffffff")
            .TextCenter()
            .Content(
                P()
                    .MarginBottom("1rem")
                    .Text("Built with ❤️ using SumerUI"),

                Div()
                    .Flex()
                    .Gap("2rem")
                    .JustifyContent("center")
                    .Content(
                        A("https://github.com/itsmuntadhar/sumer-ui")
                            .Attr("target", "_blank")
                            .TextColor("#9ca3af")
                            .Text("GitHub")
                            .Style("text-decoration", "none"),

                        A("https://github.com/itsmuntadhar/sumer-ui/blob/main/docs/getting-started.md")
                            .Attr("target", "_blank")
                            .TextColor("#9ca3af")
                            .Text("Documentation")
                            .Style("text-decoration", "none"),

                        A("https://github.com/itsmuntadhar/sumer-ui/blob/main/LICENSE")
                            .Attr("target", "_blank")
                            .TextColor("#9ca3af")
                            .Text("MIT License")
                            .Style("text-decoration", "none")
                    )
            );
    }

    private static Element Badge(string text)
    {
        return Span()
            .Padding("0.5rem", "1rem")
            .BackgroundColor("rgba(255, 255, 255, 0.2)")
            .BorderRadius("2rem")
            .FontSize("0.9rem")
            .Text(text);
    }

    private static Element FeatureCard(string icon, string title, string description)
    {
        return Div()
            .Padding("2rem")
            .BackgroundColor("#ffffff")
            .BorderRadius("0.5rem")
            .BoxShadow("0 4px 6px rgba(0, 0, 0, 0.1)")
            .Style("transition", "transform 0.2s")
            .Content(
                Div()
                    .FontSize("3rem")
                    .MarginBottom("1rem")
                    .Text(icon),

                H3()
                    .Text(title)
                    .FontBold()
                    .FontSize("1.5rem")
                    .MarginBottom("0.5rem")
                    .TextColor("#1f2937"),

                P()
                    .Text(description)
                    .TextColor("#4b5563")
                    .LineHeight("1.6")
            );
    }
}
