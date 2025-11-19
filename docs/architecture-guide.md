# Architecture Guide

Learn how to structure and organize large SumerUI projects for maintainability and scalability.

## Table of Contents

- [Project Structure](#project-structure)
- [Separation of Concerns](#separation-of-concerns)
- [State Management](#state-management)
- [Routing and Navigation](#routing-and-navigation)
- [Asset Management](#asset-management)
- [Testing Strategy](#testing-strategy)
- [Performance Optimization](#performance-optimization)

---

## Project Structure

### Small Projects

For simple static sites with a few pages:

```
MyStaticSite/
├── Program.cs              # Entry point and page generation
├── Layout.cs               # Shared layout
├── Pages/
│   ├── HomePage.cs
│   ├── AboutPage.cs
│   └── ContactPage.cs
├── Components/
│   ├── Header.cs
│   ├── Footer.cs
│   └── Card.cs
├── assets/
│   ├── styles.css
│   └── images/
└── out/                    # Generated output
```

**Program.cs:**
```csharp
using SumerUI.Generators;

var generator = new StaticSiteGenerator("./out", new StaticSiteOptions
{
    CleanOutput = true,
    PrettyUrls = true,
    Verbose = true
});

var pages = new PageBuilder()
    .AddPage("/", () => new HomePage())
    .AddPage("/about", () => new AboutPage())
    .AddPage("/contact", () => new ContactPage())
    .Build();

await generator.GenerateSiteAsync(pages);
await generator.CopyStaticAssetsAsync("./assets");
```

### Medium Projects

For multi-section sites with more features:

```
MyWebsite/
├── Program.cs
├── Features/
│   ├── Blog/
│   │   ├── BlogLayout.cs
│   │   ├── BlogListPage.cs
│   │   ├── BlogPostPage.cs
│   │   └── Components/
│   │       ├── BlogCard.cs
│   │       └── BlogHeader.cs
│   ├── Products/
│   │   ├── ProductListPage.cs
│   │   ├── ProductDetailPage.cs
│   │   └── Components/
│   │       ├── ProductCard.cs
│   │       └── ProductFilter.cs
│   └── About/
│       ├── AboutPage.cs
│       └── TeamPage.cs
├── Shared/
│   ├── Layout.cs
│   ├── Components/
│   │   ├── Header.cs
│   │   ├── Footer.cs
│   │   ├── Navigation.cs
│   │   └── Button.cs
│   └── Models/
│       ├── BlogPost.cs
│       ├── Product.cs
│       └── TeamMember.cs
├── Services/
│   ├── DataService.cs
│   └── ImageService.cs
├── assets/
│   ├── css/
│   ├── js/
│   └── images/
└── out/
```

### Large Projects

For complex applications with many features:

```
LargeApp/
├── src/
│   ├── LargeApp.csproj
│   ├── Program.cs
│   ├── Core/
│   │   ├── Configuration/
│   │   │   ├── SiteConfig.cs
│   │   │   └── RouteConfig.cs
│   │   ├── Extensions/
│   │   │   └── ElementExtensions.cs
│   │   └── Abstractions/
│   │       ├── IPage.cs
│   │       ├── ILayout.cs
│   │       └── IDataProvider.cs
│   ├── Features/
│   │   ├── Home/
│   │   │   ├── HomePage.cs
│   │   │   ├── Components/
│   │   │   │   ├── Hero.cs
│   │   │   │   ├── Features.cs
│   │   │   │   └── Testimonials.cs
│   │   │   └── Models/
│   │   │       └── Feature.cs
│   │   ├── Blog/
│   │   │   ├── BlogLayout.cs
│   │   │   ├── Pages/
│   │   │   ├── Components/
│   │   │   ├── Models/
│   │   │   └── Services/
│   │   │       └── BlogService.cs
│   │   └── Shop/
│   │       ├── Pages/
│   │       ├── Components/
│   │       ├── Models/
│   │       └── Services/
│   ├── Shared/
│   │   ├── Layouts/
│   │   │   ├── MainLayout.cs
│   │   │   ├── BlogLayout.cs
│   │   │   └── AdminLayout.cs
│   │   ├── Components/
│   │   │   ├── UI/
│   │   │   │   ├── Button.cs
│   │   │   │   ├── Card.cs
│   │   │   │   ├── Modal.cs
│   │   │   │   └── Alert.cs
│   │   │   ├── Navigation/
│   │   │   │   ├── Header.cs
│   │   │   │   ├── Footer.cs
│   │   │   │   ├── Sidebar.cs
│   │   │   │   └── Breadcrumb.cs
│   │   │   └── Forms/
│   │   │       ├── Input.cs
│   │   │       ├── Select.cs
│   │   │       └── Checkbox.cs
│   │   └── Constants/
│   │       ├── Colors.cs
│   │       ├── Spacing.cs
│   │       └── Routes.cs
│   ├── Data/
│   │   ├── Providers/
│   │   │   ├── JsonDataProvider.cs
│   │   │   ├── ApiDataProvider.cs
│   │   │   └── MarkdownDataProvider.cs
│   │   ├── Repositories/
│   │   │   ├── BlogRepository.cs
│   │   │   └── ProductRepository.cs
│   │   └── content/
│   │       ├── blog/
│   │       └── products/
│   └── Services/
│       ├── SiteGenerator.cs
│       ├── ImageOptimizer.cs
│       └── SitemapGenerator.cs
├── tests/
│   ├── ComponentTests/
│   ├── PageTests/
│   └── IntegrationTests/
├── assets/
│   ├── css/
│   ├── js/
│   └── images/
└── out/
```

---

## Separation of Concerns

### Layer Architecture

Organize code into logical layers:

#### 1. Presentation Layer (Components & Pages)

```csharp
// Pages/BlogPostPage.cs
public class BlogPostPage : Element
{
    public BlogPostPage(BlogPost post) : base("")
    {
        Content(
            new MainLayout().Content(
                new BlogHeader(post.Title, post.Date, post.Author),
                new BlogContent(post.Body),
                new BlogComments(post.Comments)
            )
        );
    }
}
```

#### 2. Domain Layer (Models & Business Logic)

```csharp
// Models/BlogPost.cs
public record BlogPost(
    Guid Id,
    string Title,
    string Slug,
    string Body,
    DateTime Date,
    Author Author,
    List<string> Tags,
    List<Comment> Comments
);

// Models/Comment.cs
public record Comment(
    string Author,
    DateTime Date,
    string Content
);
```

#### 3. Data Layer (Repositories & Data Access)

```csharp
// Data/Repositories/BlogRepository.cs
public class BlogRepository
{
    private readonly IDataProvider _dataProvider;

    public BlogRepository(IDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    public async Task<List<BlogPost>> GetAllPostsAsync()
    {
        var data = await _dataProvider.ReadAsync("blog/posts.json");
        return JsonSerializer.Deserialize<List<BlogPost>>(data)!;
    }

    public async Task<BlogPost?> GetPostBySlugAsync(string slug)
    {
        var posts = await GetAllPostsAsync();
        return posts.FirstOrDefault(p => p.Slug == slug);
    }

    public async Task<List<BlogPost>> GetPostsByTagAsync(string tag)
    {
        var posts = await GetAllPostsAsync();
        return posts.Where(p => p.Tags.Contains(tag)).ToList();
    }
}
```

#### 4. Service Layer (Application Logic)

```csharp
// Services/SiteGenerator.cs
public class SiteGenerator
{
    private readonly StaticSiteGenerator _generator;
    private readonly BlogRepository _blogRepo;
    private readonly ProductRepository _productRepo;

    public SiteGenerator(
        StaticSiteGenerator generator,
        BlogRepository blogRepo,
        ProductRepository productRepo)
    {
        _generator = generator;
        _blogRepo = blogRepo;
        _productRepo = productRepo;
    }

    public async Task GenerateAsync()
    {
        var pages = new Dictionary<string, Element>();

        // Home page
        pages["/"] = new HomePage();

        // Blog pages
        var posts = await _blogRepo.GetAllPostsAsync();
        pages["/blog"] = new BlogListPage(posts);
        
        foreach (var post in posts)
        {
            pages[$"/blog/{post.Slug}"] = new BlogPostPage(post);
        }

        // Product pages
        var products = await _productRepo.GetAllAsync();
        pages["/products"] = new ProductListPage(products);
        
        foreach (var product in products)
        {
            pages[$"/products/{product.Slug}"] = new ProductDetailPage(product);
        }

        await _generator.GenerateSiteAsync(pages);
    }
}
```

---

## State Management

### Configuration State

Centralize site configuration:

```csharp
// Core/Configuration/SiteConfig.cs
public class SiteConfig
{
    public string SiteName { get; set; } = "My Site";
    public string BaseUrl { get; set; } = "https://example.com";
    public string Description { get; set; } = "";
    public string Author { get; set; } = "";
    public SocialLinks Social { get; set; } = new();
    public NavigationConfig Navigation { get; set; } = new();
}

public class SocialLinks
{
    public string? Twitter { get; set; }
    public string? GitHub { get; set; }
    public string? LinkedIn { get; set; }
}

public class NavigationConfig
{
    public List<NavItem> Items { get; set; } = new();
}

public record NavItem(string Label, string Href);

// Usage in components
public class Header : Element
{
    private readonly SiteConfig _config;

    public Header(SiteConfig config) : base("header")
    {
        _config = config;
        
        this.BackgroundColor("#1f2937")
            .Padding(1.Rem())
            .Content(
                Div()
                    .Flex()
                    .ItemsCenter()
                    .JustifyBetween()
                    .Content(
                        H1().Text(_config.SiteName).TextWhite(),
                        new Navigation(_config.Navigation)
                    )
            );
    }
}
```

### Page Context

Pass context through components:

```csharp
// Core/PageContext.cs
public class PageContext
{
    public SiteConfig Config { get; init; } = new();
    public string CurrentPath { get; init; } = "/";
    public Dictionary<string, object> Metadata { get; init; } = new();
}

// Layouts/MainLayout.cs
public class MainLayout : Element
{
    private readonly PageContext _context;

    public MainLayout(PageContext context) : base("")
    {
        _context = context;
    }

    public Element WithContent(params Element[] children)
    {
        return Html().Content(
            Head().Content(
                Meta().Attr("charset", "UTF-8"),
                Title().Text(_context.Config.SiteName),
                Meta().Attr("name", "description")
                    .Attr("content", _context.Config.Description),
                Link().Attr("rel", "stylesheet")
                    .Attr("href", "/assets/styles.css")
            ),
            Body().Content(
                new Header(_context.Config),
                Html.Main().Content(children),
                new Footer(_context.Config)
            )
        );
    }
}

// Usage
var context = new PageContext
{
    Config = siteConfig,
    CurrentPath = "/about"
};

var page = new MainLayout(context).WithContent(
    H1().Text("About Us"),
    P().Text("Welcome to our site")
);
```

---

## Routing and Navigation

### Route Configuration

Centralize route definitions:

```csharp
// Core/Configuration/RouteConfig.cs
public static class Routes
{
    public const string Home = "/";
    public const string About = "/about";
    public const string Contact = "/contact";
    
    public static class Blog
    {
        public const string List = "/blog";
        public static string Post(string slug) => $"/blog/{slug}";
        public static string Tag(string tag) => $"/blog/tag/{tag}";
    }
    
    public static class Products
    {
        public const string List = "/products";
        public static string Detail(string slug) => $"/products/{slug}";
        public static string Category(string category) => $"/products/category/{category}";
    }
}

// Usage in components
var link = A()
    .Attr("href", Routes.Blog.Post("my-first-post"))
    .Text("Read More");
```

### Active Link Helper

Highlight active navigation items:

```csharp
// Shared/Components/Navigation/NavLink.cs
public class NavLink : Element
{
    public NavLink(string label, string href, string currentPath) : base("a")
    {
        var isActive = currentPath == href || 
                       currentPath.StartsWith(href + "/");

        this.Attr("href", href)
            .Text(label)
            .Padding(0.5.Rem(), 1.Rem())
            .TextColor(isActive ? "#3b82f6" : "#6b7280")
            .FontWeight(isActive ? 600 : 400)
            .TransitionColors()
            .Duration300();
    }
}

// Usage
public class Navigation : Element
{
    public Navigation(NavigationConfig config, string currentPath) : base("nav")
    {
        this.Content(
            config.Items.Select(item =>
                new NavLink(item.Label, item.Href, currentPath)
            )
        );
    }
}
```

### Breadcrumb Component

```csharp
// Shared/Components/Navigation/Breadcrumb.cs
public class Breadcrumb : Element
{
    public Breadcrumb(string currentPath) : base("nav")
    {
        var segments = currentPath.Split('/', StringSplitOptions.RemoveEmptyEntries);
        var breadcrumbs = new List<Element> { HomeLink() };

        var path = "";
        foreach (var segment in segments)
        {
            path += "/" + segment;
            breadcrumbs.Add(Separator());
            breadcrumbs.Add(PathLink(segment, path));
        }

        this.Attr("aria-label", "Breadcrumb")
            .Flex()
            .ItemsCenter()
            .Gap(0.5.Rem())
            .Padding(1.Rem())
            .Content(breadcrumbs);
    }

    private static Element HomeLink() =>
        A().Attr("href", "/")
           .Text("Home")
           .TextColor("#3b82f6");

    private static Element Separator() =>
        Span().Text("/").TextColor("#9ca3af");

    private static Element PathLink(string label, string href) =>
        A().Attr("href", href)
           .Text(FormatLabel(label))
           .TextColor("#3b82f6");

    private static string FormatLabel(string segment) =>
        string.Join(" ", segment.Split('-'))
              .Transform(s => char.ToUpper(s[0]) + s.Substring(1));
}
```

---

## Asset Management

### Organizing Assets

```
assets/
├── css/
│   ├── main.css
│   ├── components.css
│   └── utilities.css
├── js/
│   ├── main.js
│   └── analytics.js
├── images/
│   ├── logo.svg
│   ├── hero/
│   └── products/
├── fonts/
│   └── custom-font.woff2
└── data/
    ├── blog-posts.json
    └── products.json
```

### Asset Helper Service

```csharp
// Services/AssetService.cs
public class AssetService
{
    private readonly string _basePath;

    public AssetService(string basePath = "/assets")
    {
        _basePath = basePath;
    }

    public string Css(string filename) => $"{_basePath}/css/{filename}";
    public string Js(string filename) => $"{_basePath}/js/{filename}";
    public string Image(string path) => $"{_basePath}/images/{path}";
    public string Font(string filename) => $"{_basePath}/fonts/{filename}";

    public string ImageOptimized(string path, int? width = null, int? height = null)
    {
        // Could implement image optimization logic
        var query = new List<string>();
        if (width.HasValue) query.Add($"w={width}");
        if (height.HasValue) query.Add($"h={height}");
        
        var queryString = query.Any() ? "?" + string.Join("&", query) : "";
        return $"{_basePath}/images/{path}{queryString}";
    }
}

// Usage in components
var assets = new AssetService();

var img = Html.Img()
    .Attr("src", assets.ImageOptimized("hero/banner.jpg", width: 1200))
    .Attr("alt", "Hero banner");
```

---

## Testing Strategy

### Unit Testing Components

```csharp
// tests/ComponentTests/ButtonTests.cs
public class ButtonTests
{
    private readonly HtmlRenderer _renderer = new();

    [Fact]
    public void Button_RendersWithCorrectText()
    {
        var button = new Button("Click Me");
        var html = _renderer.RenderToString(button);

        Assert.Contains("Click Me", html);
    }

    [Fact]
    public void Button_AppliesPrimaryVariantStyles()
    {
        var button = new Button("Submit", variant: "primary");
        var html = _renderer.RenderToString(button);

        Assert.Contains("background-color: #3b82f6", html);
    }

    [Theory]
    [InlineData("small", "0.5rem 1rem")]
    [InlineData("medium", "0.75rem 1.5rem")]
    [InlineData("large", "1rem 2rem")]
    public void Button_AppliesCorrectSizePadding(string size, string expectedPadding)
    {
        var button = new Button("Test", size: size);
        var html = _renderer.RenderToString(button);

        Assert.Contains($"padding: {expectedPadding}", html);
    }
}
```

### Integration Testing

```csharp
// tests/IntegrationTests/PageGenerationTests.cs
public class PageGenerationTests
{
    [Fact]
    public async Task GenerateSite_CreatesAllPages()
    {
        var outputDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        var generator = new StaticSiteGenerator(outputDir);

        var pages = new Dictionary<string, Element>
        {
            ["/"] = new HomePage(),
            ["/about"] = new AboutPage()
        };

        await generator.GenerateSiteAsync(pages);

        Assert.True(File.Exists(Path.Combine(outputDir, "index.html")));
        Assert.True(File.Exists(Path.Combine(outputDir, "about", "index.html")));

        Directory.Delete(outputDir, true);
    }
}
```

---

## Performance Optimization

### 1. Lazy Page Generation

Generate pages only when needed:

```csharp
var pages = new PageBuilder()
    .AddPage("/", () => new HomePage())  // Lazy factory
    .AddPage("/about", () => new AboutPage())
    .Build();
```

### 2. Parallel Generation

Generate multiple pages concurrently (already built into `StaticSiteGenerator`):

```csharp
public async Task GenerateSiteAsync(Dictionary<string, Element> pages)
{
    var tasks = pages.Select(kvp => GeneratePageAsync(kvp.Key, kvp.Value));
    await Task.WhenAll(tasks);  // Parallel execution
}
```

### 3. Component Caching

Cache expensive component renders:

```csharp
public class CachedComponentFactory
{
    private readonly Dictionary<string, Element> _cache = new();

    public Element GetOrCreate(string key, Func<Element> factory)
    {
        if (!_cache.TryGetValue(key, out var element))
        {
            element = factory();
            _cache[key] = element;
        }
        return element;
    }
}

// Usage
var factory = new CachedComponentFactory();
var header = factory.GetOrCreate("header", () => new Header(config));
```

### 4. Minimize Inline Styles

Use CSS classes for repeated styles:

```csharp
// Instead of inline styles everywhere
var card = Div()
    .Padding(2.Rem())
    .BackgroundColor("#ffffff")
    .Rounded(0.5.Rem())
    .Shadow();

// Use CSS classes
var card = Div().Class("card");

// In your CSS file:
// .card { padding: 2rem; background-color: #fff; border-radius: 0.5rem; box-shadow: ...; }
```

---

## Next Steps

- Review the [Components Guide](components-guide.md) for reusable patterns
- Check the [API Reference](api-reference.md) for all utilities
- Explore [Examples](../examples/) for complete projects

Happy architecting!
