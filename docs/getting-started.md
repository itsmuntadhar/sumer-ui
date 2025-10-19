# Getting Started with SumerUI

SumerUI is a type-safe, fluent C# library for generating static HTML with Tailwind-inspired utilities.

## Installation

### Using .NET CLI

```bash
dotnet new console -n MyStaticSite
cd MyStaticSite
dotnet add package SumerUI
dotnet add package SumerUI.Renderers
dotnet add package SumerUI.Generators
```

### Using Package Manager

```bash
Install-Package SumerUI
Install-Package SumerUI.Renderers
Install-Package SumerUI.Generators
```

## Your First Page

Create a simple HTML page with SumerUI:

```csharp
using SumerUI.Elements;
using SumerUI.Generators;
using static SumerUI.Elements.HtmlElements;

var page = Html()
    .Content(
        Head().Content(
            Meta().Attr("charset", "UTF-8"),
            Meta().Attr("name", "viewport").Attr("content", "width=device-width, initial-scale=1.0"),
            Title().Text("My First SumerUI Page")
        ),
        Body()
            .Padding(2.Rem())
            .BackgroundColor("#f3f4f6")
            .Content(
                H1()
                    .Text("Welcome to SumerUI!")
                    .FontBold()
                    .Text3Xl()
                    .TextCenter(),
                P()
                    .Text("A type-safe way to build HTML in C#")
                    .TextCenter()
                    .TextLg()
            )
    );

var generator = new StaticSiteGenerator("./out");
await generator.GeneratePageAsync("/", page);

Console.WriteLine("✨ Site generated! Check ./out/index.html");
```

Run your program:

```bash
dotnet run
```

Open `./out/index.html` in your browser to see your page!

## Building a Multi-Page Site

Use the `PageBuilder` helper to create multiple pages:

```csharp
using SumerUI.Elements;
using SumerUI.Generators;
using static SumerUI.Elements.HtmlElements;

// Create a reusable layout
Element CreateLayout(string title, params Element[] content)
{
    return Html().Content(
        Head().Content(
            Meta().Attr("charset", "UTF-8"),
            Title().Text(title)
        ),
        Body()
            .Padding(2.Rem())
            .Content(content)
    );
}

// Define your pages
var pages = new Dictionary<string, Element>
{
    ["/"] = CreateLayout("Home",
        H1().Text("Home Page").FontBold().Text3Xl(),
        P().Text("Welcome to my site!")
    ),
    
    ["/about"] = CreateLayout("About",
        H1().Text("About").FontBold().Text3Xl(),
        P().Text("This is the about page")
    ),
    
    ["/contact"] = CreateLayout("Contact",
        H1().Text("Contact").FontBold().Text3Xl(),
        P().Text("Get in touch!")
    )
};

// Generate the site
var generator = new StaticSiteGenerator("./out");
await generator.GenerateSiteAsync(pages);
```

## Using Tailwind-Inspired Utilities

SumerUI provides extension methods that mirror Tailwind CSS utilities:

```csharp
var card = Div()
    .Padding(2.Rem())
    .BackgroundColor("#ffffff")
    .Rounded(0.5.Rem())
    .Shadow()
    .MaxWidth(24.Rem())
    .Content(
        H2()
            .Text("Card Title")
            .FontBold()
            .TextXl()
            .MarginBottom(1.Rem()),
        P()
            .Text("Card content goes here")
            .TextBase()
    );
```

### Available Utilities

- **Layout**: `Padding()`, `Margin()`, `Width()`, `Height()`, `Display()`, `Position()`
- **Flexbox**: `Flex()`, `FlexRow()`, `FlexCol()`, `ItemsCenter()`, `JustifyBetween()`, `Gap()`
- **Typography**: `FontBold()`, `TextXl()`, `TextCenter()`, `Uppercase()`
- **Colors**: `BackgroundColor()`, `TextColor()`, `BorderColor()`
- **Spacing**: Use unit extensions like `1.Rem()`, `16.Px()`, `100.Percent()`

See the [API Reference](api-reference.md) for a complete list.

## Unit System

SumerUI provides type-safe unit extensions:

```csharp
// Rem units
.Padding(1.Rem())      // padding: 1rem
.Margin(2.Rem())       // margin: 2rem

// Pixel units
.Width(320.Px())       // width: 320px
.Height(200.Px())      // height: 200px

// Percentage
.Width(100.Percent())  // width: 100%

// Viewport units
.Width(50.Vw())        // width: 50vw
.Height(100.Vh())      // height: 100vh
```

## Generator Options

Customize the static site generator:

```csharp
var options = new StaticSiteOptions
{
    CleanOutput = true,    // Clean output directory before generation
    MinifyHtml = false,    // Minify HTML output
    PrettyUrls = true,     // Use /about/index.html instead of /about.html
    Verbose = true         // Print generation progress
};

var generator = new StaticSiteGenerator("./out", options);
```

## Deployment

### Deploy to Vercel

```bash
cd out
npx vercel --prod
```

### Deploy to Netlify

```bash
cd out
npx netlify deploy --prod --dir=.
```

### Deploy to GitHub Pages

```bash
cd out
git init
git add .
git commit -m "Deploy site"
git branch -M gh-pages
git remote add origin https://github.com/yourusername/yourrepo.git
git push -u origin gh-pages
```

## Next Steps

- Check out the [API Reference](api-reference.md) for all available utilities
- Browse the [examples](../examples/) for more complex use cases
- Learn about [creating reusable components](components.md) _(coming soon)_
- Join the discussion on [GitHub](https://github.com/itsmuntadhar/sumer-ui)

## Examples

Complete working examples are available in the [`examples/`](../examples/) directory:

- [`basic/`](../examples/basic/) - ASP.NET server-side rendering example
- [`basic-generator/`](../examples/basic-generator/) - Static site generation example

Happy building! 🚀
