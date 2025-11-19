# Real-World Examples

Practical, production-ready examples showcasing SumerUI patterns and best practices.

## Table of Contents

- [Landing Page](#landing-page)
- [Blog System](#blog-system)
- [Dashboard Layout](#dashboard-layout)
- [E-commerce Product Page](#e-commerce-product-page)
- [Portfolio Site](#portfolio-site)

---

## Landing Page

A complete marketing landing page with hero, features, pricing, and CTA sections.

### Structure

```csharp
using SumerUI.Elements;
using SumerUI.Extensions;
using SumerUI.Generators;
using static SumerUI.Extensions.Elements;

// Hero Section
public class Hero : Element
{
    public Hero() : base("section")
    {
        this.Padding(6.Rem(), 1.Rem())
            .BackgroundColor("#0f172a")
            .TextCenter()
            .Md(e => e.Padding(8.Rem(), 2.Rem()))
            .Content(
                Div()
                    .MaxWidth(64.Rem())
                    .Margin("0 auto")
                    .Content(
                        H1()
                            .Text("Build Static Sites with Type Safety")
                            .TextWhite()
                            .Text3Xl()
                            .FontBold()
                            .MarginBottom(1.5.Rem())
                            .Md(e => e.FontSize(3.5.Rem())),
                        
                        P()
                            .Text("A fluent C# library for generating beautiful static HTML with Tailwind-inspired utilities")
                            .TextColor("#94a3b8")
                            .TextLg()
                            .MarginBottom(2.Rem())
                            .Md(e => e.TextXl()),
                        
                        Div()
                            .Flex()
                            .FlexCol()
                            .Gap(1.Rem())
                            .ItemsCenter()
                            .Md(e => e.FlexRow().JustifyCenter())
                            .Content(
                                Button()
                                    .Text("Get Started")
                                    .Padding(1.Rem(), 2.Rem())
                                    .BackgroundColor("#3b82f6")
                                    .TextWhite()
                                    .Rounded(0.5.Rem())
                                    .FontSemibold()
                                    .TransitionAll()
                                    .Duration300()
                                    .Cursor("pointer"),
                                
                                A()
                                    .Attr("href", "https://github.com/itsmuntadhar/sumer-ui")
                                    .Text("View on GitHub →")
                                    .TextColor("#94a3b8")
                                    .Padding(1.Rem(), 2.Rem())
                                    .TransitionColors()
                                    .Duration300()
                            )
                    )
            );
    }
}

// Feature Card
public class FeatureCard : Element
{
    public FeatureCard(string icon, string title, string description) : base("div")
    {
        this.Padding(2.Rem())
            .BackgroundColor("#ffffff")
            .Rounded(0.75.Rem())
            .Shadow("0 4px 6px -1px rgb(0 0 0 / 0.1)")
            .TransitionAll()
            .Duration300()
            .Content(
                Div()
                    .Text(icon)
                    .FontSize(2.5.Rem())
                    .MarginBottom(1.Rem()),
                
                H3()
                    .Text(title)
                    .FontBold()
                    .TextXl()
                    .MarginBottom(0.75.Rem())
                    .TextColor("#1e293b"),
                
                P()
                    .Text(description)
                    .TextColor("#64748b")
                    .LineHeight("1.625")
            );
    }
}

// Features Section
public class FeaturesSection : Element
{
    public FeaturesSection() : base("section")
    {
        this.Padding(6.Rem(), 1.Rem())
            .BackgroundColor("#f8fafc")
            .Content(
                Div()
                    .MaxWidth(80.Rem())
                    .Margin("0 auto")
                    .Content(
                        H2()
                            .Text("Why Choose SumerUI?")
                            .Text3Xl()
                            .FontBold()
                            .TextCenter()
                            .MarginBottom(3.Rem())
                            .TextColor("#1e293b"),
                        
                        Div()
                            .Grid()
                            .GridCols(1)
                            .Gap(2.Rem())
                            .Md(e => e.GridCols(2))
                            .Lg(e => e.GridCols(3))
                            .Content(
                                new FeatureCard(
                                    "🎨",
                                    "Fluent API",
                                    "Chainable methods make building UIs intuitive and enjoyable"
                                ),
                                new FeatureCard(
                                    "🔒",
                                    "Type-Safe",
                                    "Full IntelliSense support with compile-time checking"
                                ),
                                new FeatureCard(
                                    "⚡",
                                    "Fast",
                                    "Generate static HTML with zero JavaScript overhead"
                                ),
                                new FeatureCard(
                                    "📱",
                                    "Responsive",
                                    "Mobile-first breakpoint system built in"
                                ),
                                new FeatureCard(
                                    "🎯",
                                    "Tailwind-Inspired",
                                    "Familiar utility-first approach you already know"
                                ),
                                new FeatureCard(
                                    "🚀",
                                    "Deploy Anywhere",
                                    "CDN-ready static output works everywhere"
                                )
                            )
                    )
            );
    }
}

// Pricing Card
public class PricingCard : Element
{
    public PricingCard(
        string name,
        string price,
        string description,
        string[] features,
        bool highlighted = false) : base("div")
    {
        this.Padding(2.Rem())
            .BackgroundColor(highlighted ? "#3b82f6" : "#ffffff")
            .TextColor(highlighted ? "#ffffff" : "#1e293b")
            .Rounded(0.75.Rem())
            .Shadow("0 10px 15px -3px rgb(0 0 0 / 0.1)")
            .Position("relative")
            .Content(
                highlighted
                    ? Div()
                        .Text("POPULAR")
                        .Position("absolute")
                        .Top(-0.75.Rem())
                        .Right(1.5.Rem())
                        .BackgroundColor("#fbbf24")
                        .TextColor("#1e293b")
                        .Padding(0.25.Rem(), 1.Rem())
                        .Rounded(9999.Px())
                        .TextXs()
                        .FontBold()
                    : null,
                
                H3()
                    .Text(name)
                    .FontBold()
                    .TextXl()
                    .MarginBottom(0.5.Rem()),
                
                Div()
                    .Flex()
                    .ItemsBaseline()
                    .Gap(0.5.Rem())
                    .MarginBottom(1.Rem())
                    .Content(
                        Span()
                            .Text(price)
                            .FontBold()
                            .FontSize(3.Rem()),
                        Span()
                            .Text("/month")
                            .TextColor(highlighted ? "#cbd5e1" : "#64748b")
                    ),
                
                P()
                    .Text(description)
                    .TextColor(highlighted ? "#cbd5e1" : "#64748b")
                    .MarginBottom(1.5.Rem()),
                
                Ul()
                    .MarginBottom(2.Rem())
                    .Content(
                        features.Select(feature =>
                            Li()
                                .Flex()
                                .ItemsCenter()
                                .Gap(0.5.Rem())
                                .MarginBottom(0.75.Rem())
                                .Content(
                                    Span().Text("✓").FontBold(),
                                    Span().Text(feature)
                                )
                        )
                    ),
                
                Button()
                    .Text("Get Started")
                    .Width(100.Percent())
                    .Padding(0.75.Rem())
                    .BackgroundColor(highlighted ? "#ffffff" : "#3b82f6")
                    .TextColor(highlighted ? "#3b82f6" : "#ffffff")
                    .Rounded(0.5.Rem())
                    .FontSemibold()
                    .TransitionAll()
                    .Duration300()
                    .Cursor("pointer")
            ).Content();
    }
}

// Pricing Section
public class PricingSection : Element
{
    public PricingSection() : base("section")
    {
        this.Padding(6.Rem(), 1.Rem())
            .BackgroundColor("#ffffff")
            .Content(
                Div()
                    .MaxWidth(80.Rem())
                    .Margin("0 auto")
                    .Content(
                        H2()
                            .Text("Simple, Transparent Pricing")
                            .Text3Xl()
                            .FontBold()
                            .TextCenter()
                            .MarginBottom(3.Rem()),
                        
                        Div()
                            .Grid()
                            .GridCols(1)
                            .Gap(2.Rem())
                            .Md(e => e.GridCols(3))
                            .Content(
                                new PricingCard(
                                    "Starter",
                                    "$0",
                                    "Perfect for side projects",
                                    new[] {
                                        "Unlimited pages",
                                        "Basic components",
                                        "Community support",
                                        "MIT License"
                                    }
                                ),
                                new PricingCard(
                                    "Pro",
                                    "$29",
                                    "For professional developers",
                                    new[] {
                                        "Everything in Starter",
                                        "Premium components",
                                        "Priority support",
                                        "Advanced examples",
                                        "Custom themes"
                                    },
                                    highlighted: true
                                ),
                                new PricingCard(
                                    "Enterprise",
                                    "$99",
                                    "For large teams",
                                    new[] {
                                        "Everything in Pro",
                                        "Dedicated support",
                                        "Custom development",
                                        "Training & consulting",
                                        "SLA guarantee"
                                    }
                                )
                            )
                    )
            );
    }
}

// Complete Landing Page
public class LandingPage : Element
{
    public LandingPage() : base("")
    {
        Content(
            Html().Content(
                Head().Content(
                    Meta().Attr("charset", "UTF-8"),
                    Meta().Attr("name", "viewport")
                        .Attr("content", "width=device-width, initial-scale=1.0"),
                    Title().Text("SumerUI - Type-Safe Static Site Generation"),
                    Meta().Attr("name", "description")
                        .Attr("content", "Build beautiful static sites with C# and type safety")
                ),
                Body()
                    .Style("margin", "0")
                    .Style("font-family", "system-ui, -apple-system, sans-serif")
                    .Content(
                        new Hero(),
                        new FeaturesSection(),
                        new PricingSection()
                    )
            )
        );
    }
}

// Generate the site
var generator = new StaticSiteGenerator("./out");
await generator.GeneratePageAsync("/", new LandingPage());
```

---

## Blog System

A complete blog with list, detail pages, and categories.

### Blog Models

```csharp
public record BlogPost(
    string Slug,
    string Title,
    string Excerpt,
    string Content,
    DateTime PublishedDate,
    string Author,
    string[] Tags,
    string CoverImage
);

public record BlogAuthor(
    string Name,
    string Bio,
    string Avatar
);
```

### Blog Components

```csharp
// Blog Card for list view
public class BlogCard : Element
{
    public BlogCard(BlogPost post) : base("article")
    {
        this.BackgroundColor("#ffffff")
            .Rounded(0.75.Rem())
            .Shadow()
            .Overflow("hidden")
            .TransitionAll()
            .Duration300()
            .Content(
                // Cover image
                Div()
                    .Height(12.Rem())
                    .BackgroundColor("#e5e7eb")
                    .Style("background-image", $"url({post.CoverImage})")
                    .Style("background-size", "cover")
                    .Style("background-position", "center"),
                
                // Content
                Div()
                    .Padding(1.5.Rem())
                    .Content(
                        // Tags
                        Div()
                            .Flex()
                            .Gap(0.5.Rem())
                            .MarginBottom(1.Rem())
                            .Content(
                                post.Tags.Select(tag =>
                                    Span()
                                        .Text(tag)
                                        .BackgroundColor("#dbeafe")
                                        .TextColor("#1e40af")
                                        .Padding(0.25.Rem(), 0.75.Rem())
                                        .Rounded(9999.Px())
                                        .TextXs()
                                        .FontMedium()
                                )
                            ),
                        
                        // Title
                        H2()
                            .Content(
                                A()
                                    .Attr("href", $"/blog/{post.Slug}")
                                    .Text(post.Title)
                                    .TextColor("#1e293b")
                                    .FontBold()
                                    .TextXl()
                                    .Style("text-decoration", "none")
                                    .TransitionColors()
                                    .Duration300()
                            ),
                        
                        // Excerpt
                        P()
                            .Text(post.Excerpt)
                            .TextColor("#64748b")
                            .MarginTop(0.75.Rem())
                            .MarginBottom(1.Rem()),
                        
                        // Meta
                        Div()
                            .Flex()
                            .ItemsCenter()
                            .JustifyBetween()
                            .TextSm()
                            .TextColor("#94a3b8")
                            .Content(
                                Span().Text(post.Author),
                                Span().Text(post.PublishedDate.ToString("MMM dd, yyyy"))
                            )
                    )
            );
    }
}

// Blog Post Detail
public class BlogPostDetail : Element
{
    public BlogPostDetail(BlogPost post) : base("article")
    {
        this.MaxWidth(48.Rem())
            .Margin("0 auto")
            .Padding(2.Rem(), 1.Rem())
            .Content(
                // Header
                Html.Header()
                    .MarginBottom(3.Rem())
                    .Content(
                        H1()
                            .Text(post.Title)
                            .FontBold()
                            .FontSize(2.5.Rem())
                            .MarginBottom(1.Rem())
                            .Md(e => e.FontSize(3.Rem())),
                        
                        Div()
                            .Flex()
                            .ItemsCenter()
                            .Gap(1.Rem())
                            .TextColor("#64748b")
                            .MarginBottom(1.5.Rem())
                            .Content(
                                Span().Text(post.Author).FontSemibold(),
                                Span().Text("•"),
                                Span().Text(post.PublishedDate.ToString("MMMM dd, yyyy"))
                            ),
                        
                        // Cover image
                        Html.Img()
                            .Attr("src", post.CoverImage)
                            .Attr("alt", post.Title)
                            .Width(100.Percent())
                            .Rounded(0.75.Rem())
                    ),
                
                // Content
                Div()
                    .Style("line-height", "1.75")
                    .TextColor("#374151")
                    .Content(
                        // Parse markdown or HTML content here
                        P().Text(post.Content)
                    ),
                
                // Tags
                Div()
                    .MarginTop(3.Rem())
                    .PaddingTop(2.Rem())
                    .BorderTop("1px solid #e5e7eb")
                    .Content(
                        Div()
                            .Flex()
                            .Gap(0.5.Rem())
                            .Content(
                                post.Tags.Select(tag =>
                                    A()
                                        .Attr("href", $"/blog/tag/{tag}")
                                        .Text($"#{tag}")
                                        .TextColor("#3b82f6")
                                        .Style("text-decoration", "none")
                                )
                            )
                    )
            );
    }
}

// Blog List Page
public class BlogListPage : Element
{
    public BlogListPage(List<BlogPost> posts) : base("")
    {
        Content(
            Div()
                .MaxWidth(80.Rem())
                .Margin("0 auto")
                .Padding(3.Rem(), 1.Rem())
                .Content(
                    H1()
                        .Text("Blog")
                        .FontBold()
                        .Text3Xl()
                        .MarginBottom(3.Rem()),
                    
                    Div()
                        .Grid()
                        .GridCols(1)
                        .Gap(2.Rem())
                        .Md(e => e.GridCols(2))
                        .Lg(e => e.GridCols(3))
                        .Content(
                            posts.Select(post => new BlogCard(post))
                        )
                )
        );
    }
}
```

### Blog Generator

```csharp
public async Task GenerateBlogAsync()
{
    // Load posts from JSON, Markdown, or database
    var posts = await LoadBlogPostsAsync();
    
    var generator = new StaticSiteGenerator("./out");
    
    // Blog list page
    await generator.GeneratePageAsync("/blog", new BlogListPage(posts));
    
    // Individual blog posts
    foreach (var post in posts)
    {
        await generator.GeneratePageAsync(
            $"/blog/{post.Slug}",
            new BlogPostDetail(post)
        );
    }
    
    // Tag pages
    var tags = posts.SelectMany(p => p.Tags).Distinct();
    foreach (var tag in tags)
    {
        var tagPosts = posts.Where(p => p.Tags.Contains(tag)).ToList();
        await generator.GeneratePageAsync(
            $"/blog/tag/{tag}",
            new BlogListPage(tagPosts)
        );
    }
}
```

---

## Dashboard Layout

A responsive admin dashboard with sidebar navigation.

```csharp
// Sidebar Component
public class Sidebar : Element
{
    public Sidebar(string currentPath) : base("aside")
    {
        MenuItem[] menuItems = new[]
        {
            ("Dashboard", "/dashboard", "📊"),
            ("Users", "/dashboard/users", "👥"),
            ("Analytics", "/dashboard/analytics", "📈"),
            ("Settings", "/dashboard/settings", "⚙️")
        };

        this.Width(16.Rem())
            .Height(100.Vh())
            .BackgroundColor("#1e293b")
            .Padding(1.5.Rem())
            .Position("fixed")
            .Left(0.Px())
            .Top(0.Px())
            .Overflow("auto")
            .Content(
                // Logo
                H2()
                    .Text("Admin")
                    .TextWhite()
                    .FontBold()
                    .TextXl()
                    .MarginBottom(2.Rem()),
                
                // Menu
                Html.Nav().Content(
                    menuItems.Select(item =>
                    {
                        var isActive = currentPath.StartsWith(item.Item2);
                        return A()
                            .Attr("href", item.Item2)
                            .Flex()
                            .ItemsCenter()
                            .Gap(0.75.Rem())
                            .Padding(0.75.Rem())
                            .MarginBottom(0.5.Rem())
                            .Rounded(0.5.Rem())
                            .BackgroundColor(isActive ? "#334155" : "transparent")
                            .TextColor(isActive ? "#ffffff" : "#cbd5e1")
                            .Style("text-decoration", "none")
                            .TransitionAll()
                            .Duration300()
                            .Content(
                                Span().Text(item.Item3).FontSize(1.25.Rem()),
                                Span().Text(item.Item1).FontMedium()
                            );
                    })
                )
            );
    }
}

// Dashboard Layout
public class DashboardLayout : Element
{
    public DashboardLayout(string currentPath, params Element[] children) : base("")
    {
        Content(
            Html().Content(
                Head().Content(
                    Meta().Attr("charset", "UTF-8"),
                    Title().Text("Dashboard")
                ),
                Body()
                    .Style("margin", "0")
                    .Style("font-family", "system-ui, sans-serif")
                    .Content(
                        new Sidebar(currentPath),
                        
                        // Main content
                        Html.Main()
                            .MarginLeft(16.Rem())
                            .Padding(2.Rem())
                            .MinHeight(100.Vh())
                            .BackgroundColor("#f8fafc")
                            .Content(children)
                    )
            )
        );
    }
}

// Stats Card
public class StatsCard : Element
{
    public StatsCard(string label, string value, string trend) : base("div")
    {
        this.Padding(1.5.Rem())
            .BackgroundColor("#ffffff")
            .Rounded(0.75.Rem())
            .Shadow()
            .Content(
                P()
                    .Text(label)
                    .TextColor("#64748b")
                    .TextSm()
                    .MarginBottom(0.5.Rem()),
                
                P()
                    .Text(value)
                    .FontBold()
                    .FontSize(2.Rem())
                    .MarginBottom(0.5.Rem()),
                
                P()
                    .Text(trend)
                    .TextColor("#10b981")
                    .TextSm()
            );
    }
}

// Dashboard Page
public class DashboardPage : Element
{
    public DashboardPage() : base("")
    {
        Content(
            new DashboardLayout("/dashboard",
                H1()
                    .Text("Dashboard")
                    .FontBold()
                    .Text3Xl()
                    .MarginBottom(2.Rem()),
                
                // Stats grid
                Div()
                    .Grid()
                    .GridCols(1)
                    .Gap(1.5.Rem())
                    .Md(e => e.GridCols(2))
                    .Lg(e => e.GridCols(4))
                    .MarginBottom(3.Rem())
                    .Content(
                        new StatsCard("Total Users", "12,543", "+12.5% from last month"),
                        new StatsCard("Revenue", "$45,231", "+8.2% from last month"),
                        new StatsCard("Active Sessions", "2,543", "+3.1% from last week"),
                        new StatsCard("Conversion", "3.24%", "+0.4% from last month")
                    ),
                
                // Chart placeholder
                Div()
                    .Padding(2.Rem())
                    .BackgroundColor("#ffffff")
                    .Rounded(0.75.Rem())
                    .Shadow()
                    .Content(
                        H2()
                            .Text("Analytics")
                            .FontBold()
                            .TextXl()
                            .MarginBottom(1.Rem()),
                        
                        Div()
                            .Height(20.Rem())
                            .BackgroundColor("#f8fafc")
                            .Rounded(0.5.Rem())
                            .Flex()
                            .ItemsCenter()
                            .JustifyCenter()
                            .Content(
                                P().Text("Chart goes here").TextColor("#94a3b8")
                            )
                    )
            )
        );
    }
}
```

---

## Next Steps

- Explore the [Components Guide](components-guide.md) for more patterns
- Check the [Architecture Guide](architecture-guide.md) for large projects
- Review the [API Reference](api-reference.md) for all utilities

Build something amazing!
