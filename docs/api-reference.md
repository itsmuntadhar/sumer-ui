# API Reference

Complete reference for all SumerUI APIs.

## Table of Contents

- [Core Elements](#core-elements)
- [Layout Utilities](#layout-utilities)
- [Flexbox Utilities](#flexbox-utilities)
- [Typography Utilities](#typography-utilities)
- [Color Utilities](#color-utilities)
- [Unit Extensions](#unit-extensions)
- [Static Site Generator](#static-site-generator)
- [HTML Renderer](#html-renderer)

---

## Core Elements

### Element Base Class

All HTML elements inherit from `Element`:

```csharp
public class Element
{
    public string Tag { get; }
    public List<Element> Children { get; }
    public Dictionary<string, string> Attributes { get; }
    public Dictionary<string, string> Styles { get; }
    public string? TextContent { get; set; }
    
    // Core methods
    public Element Attr(string name, string value)
    public Element Style(string name, string value)
    public Element Class(string className)
    public Element Content(params IEnumerable<Element> children)
    public Element Text(string text)
}
```

### HTML Elements

Import with: `using static SumerUI.Elements.HtmlElements;`

#### Structure
- `Html()` - `<html>` element
- `Head()` - `<head>` element
- `Body()` - `<body>` element
- `Div()` - `<div>` element

#### Typography
- `H1()` - `<h1>` element
- `H2()` - `<h2>` element
- `H3()` - `<h3>` element
- `H4()` - `<h4>` element
- `H5()` - `<h5>` element
- `H6()` - `<h6>` element
- `P()` - `<p>` element
- `Span()` - `<span>` element

#### Lists
- `Ul()` - `<ul>` element
- `Li()` - `<li>` element

#### Links & Media
- `A()` - `<a>` element
- `Link()` - `<link>` element

#### Forms
- `Form()` - `<form>` element
- `Input()` - `<input>` element
- `TextArea()` - `<textarea>` element
- `Select()` - `<select>` element
- `Option()` - `<option>` element
- `Label()` - `<label>` element
- `Button()` - `<button>` element

#### Meta
- `Meta()` - `<meta>` element
- `Title()` - `<title>` element

---

## Layout Utilities

Import with: `using SumerUI.Extensions;`

### Spacing

#### Margin

```csharp
.Margin(string margin)                    // margin: {margin}
.Margin(string vertical, string horizontal) // margin: {vertical} {horizontal}
.MarginTop(string top)                    // margin-top: {top}
.MarginBottom(string bottom)              // margin-bottom: {bottom}
.MarginLeft(string left)                  // margin-left: {left}
.MarginRight(string right)                // margin-right: {right}
```

**Example:**
```csharp
Div()
    .Margin(2.Rem())           // All sides
    .MarginTop(1.Rem())        // Specific side
```

#### Padding

```csharp
.Padding(string padding)                    // padding: {padding}
.Padding(string vertical, string horizontal) // padding: {vertical} {horizontal}
.PaddingTop(string top)                     // padding-top: {top}
.PaddingBottom(string bottom)               // padding-bottom: {bottom}
.PaddingLeft(string left)                   // padding-left: {left}
.PaddingRight(string right)                 // padding-right: {right}
```

**Example:**
```csharp
Div()
    .Padding(2.Rem(), 4.Rem()) // Vertical, Horizontal
```

### Sizing

```csharp
.Width(string width)          // width: {width}
.Height(string height)        // height: {height}
.MaxWidth(string maxWidth)    // max-width: {maxWidth}
.MaxHeight(string maxHeight)  // max-height: {maxHeight}
.MinWidth(string minWidth)    // min-width: {minWidth}
.MinHeight(string minHeight)  // min-height: {minHeight}
```

**Example:**
```csharp
Div()
    .Width(100.Percent())
    .MaxWidth(64.Rem())
    .Height(24.Rem())
```

### Display & Position

```csharp
.Display(string display)      // display: {display}
.Position(string position)    // position: {position}
.Top(string top)             // top: {top}
.Bottom(string bottom)       // bottom: {bottom}
.Left(string left)           // left: {left}
.Right(string right)         // right: {right}
.ZIndex(int zIndex)          // z-index: {zIndex}
```

**Example:**
```csharp
Div()
    .Position("absolute")
    .Top(0.Px())
    .Right(0.Px())
    .ZIndex(10)
```

### Overflow

```csharp
.Overflow(string overflow)    // overflow: {overflow}
.OverflowX(string overflowX)  // overflow-x: {overflowX}
.OverflowY(string overflowY)  // overflow-y: {overflowY}
```

### Cursor

```csharp
.Cursor(string cursor)        // cursor: {cursor}
```

### Border Radius

```csharp
.Rounded(string radius)                // border-radius: {radius}
.RoundedTop(string radius)             // border-top-left/right-radius: {radius}
.RoundedBottom(string radius)          // border-bottom-left/right-radius: {radius}
.RoundedLeft(string radius)            // border-top/bottom-left-radius: {radius}
.RoundedRight(string radius)           // border-top/bottom-right-radius: {radius}
.RoundedTopLeft(string radius)         // border-top-left-radius: {radius}
.RoundedTopRight(string radius)        // border-top-right-radius: {radius}
.RoundedBottomLeft(string radius)      // border-bottom-left-radius: {radius}
.RoundedBottomRight(string radius)     // border-bottom-right-radius: {radius}
```

**Example:**
```csharp
Div()
    .Rounded(0.5.Rem())        // Fully rounded
    .RoundedTop(0.25.Rem())    // Top corners only
```

---

## Flexbox Utilities

```csharp
.Flex()                       // display: flex
.FlexRow()                    // flex-direction: row
.FlexCol()                    // flex-direction: column
.FlexDirection(string dir)    // flex-direction: {dir}

// Alignment
.ItemsCenter()                // align-items: center
.ItemsStart()                 // align-items: flex-start
.ItemsEnd()                   // align-items: flex-end
.ItemsStretch()               // align-items: stretch

.JustifyCenter()              // justify-content: center
.JustifyStart()               // justify-content: flex-start
.JustifyEnd()                 // justify-content: flex-end
.JustifyBetween()             // justify-content: space-between
.JustifyAround()              // justify-content: space-around
.JustifyEvenly()              // justify-content: space-evenly

// Gap
.Gap(string gap)              // gap: {gap}
.RowGap(string gap)           // row-gap: {gap}
.ColumnGap(string gap)        // column-gap: {gap}

// Flex properties
.FlexWrap()                   // flex-wrap: wrap
.FlexGrow(int value)          // flex-grow: {value}
.FlexShrink(int value)        // flex-shrink: {value}
```

**Example:**
```csharp
Div()
    .Flex()
    .FlexRow()
    .ItemsCenter()
    .JustifyBetween()
    .Gap(1.Rem())
    .Content(
        Div().Text("Left"),
        Div().Text("Right")
    )
```

---

## Typography Utilities

### Font Size

```csharp
.FontSize(string size)        // font-size: {size}
.TextXs()                     // font-size: 0.75rem; line-height: 1rem
.TextSm()                     // font-size: 0.875rem; line-height: 1.25rem
.TextBase()                   // font-size: 1rem; line-height: 1.5rem
.TextLg()                     // font-size: 1.125rem; line-height: 1.75rem
.TextXl()                     // font-size: 1.25rem; line-height: 1.75rem
.Text2Xl()                    // font-size: 1.5rem; line-height: 2rem
.Text3Xl()                    // font-size: 1.875rem; line-height: 2.25rem
```

### Font Weight

```csharp
.FontThin()                   // font-weight: 100
.FontLight()                  // font-weight: 300
.FontNormal()                 // font-weight: 400
.FontMedium()                 // font-weight: 500
.FontSemibold()               // font-weight: 600
.FontBold()                   // font-weight: 700
```

### Text Alignment

```csharp
.TextLeft()                   // text-align: left
.TextCenter()                 // text-align: center
.TextRight()                  // text-align: right
```

### Text Transform

```csharp
.Uppercase()                  // text-transform: uppercase
.Lowercase()                  // text-transform: lowercase
.Capitalize()                 // text-transform: capitalize
```

### Line Height

```csharp
.LeadingNone()                // line-height: 1
.LeadingTight()               // line-height: 1.25
.LeadingNormal()              // line-height: 1.5
.LeadingRelaxed()             // line-height: 1.625
```

**Example:**
```csharp
H1()
    .Text("Welcome!")
    .Text3Xl()
    .FontBold()
    .TextCenter()
    .Uppercase()
```

---

## Color Utilities

### Background Color

```csharp
.BackgroundColor(string color)              // background-color: {color}
.BackgroundColor(string color, double opacity) // with opacity
```

### Text Color

```csharp
.TextColor(string color)                    // color: {color}
.TextColor(string color, double opacity)    // with opacity
```

### Border Color

```csharp
.BorderColor(string color)                  // border-color: {color}
.BorderColor(string color, double opacity)  // with opacity
```

**Example:**
```csharp
Div()
    .BackgroundColor("#3b82f6")
    .TextColor("#ffffff")
    .BorderColor("#2563eb")
```

### Built-in Color Palette

SumerUI includes Tailwind's color palette. Import with: `using SumerUI.Models;`

```csharp
// Usage
.BackgroundColor(Color.Blue500)
.TextColor(Color.Gray900)
.BorderColor(Color.Emerald50)
```

Available colors: Gray, Red, Orange, Yellow, Green, Emerald, Teal, Cyan, Blue, Indigo, Purple, Pink, Rose, Slate, Zinc, Neutral, Stone

Each with shades: 50, 100, 200, 300, 400, 500, 600, 700, 800, 900, 950

---

## Unit Extensions

Type-safe CSS unit extensions. Import with: `using SumerUI.Extensions;`

```csharp
1.Rem()        // "1rem"
16.Px()        // "16px"
2.5.Em()       // "2.5em"
100.Percent()  // "100%"
50.Vw()        // "50vw"
100.Vh()       // "100vh"
```

**Works with any numeric type:**

```csharp
int value = 10;
value.Px()           // "10px"

double decimal = 1.5;
decimal.Rem()        // "1.5rem"

float floating = 2.5f;
floating.Em()        // "2.5em"
```

---

## Static Site Generator

### StaticSiteGenerator

Generate static HTML files from SumerUI elements.

```csharp
using SumerUI.Generators;

var generator = new StaticSiteGenerator(
    outputDir: "./out",
    options: new StaticSiteOptions()
);
```

#### Methods

##### GeneratePageAsync

Generate a single page:

```csharp
await generator.GeneratePageAsync(
    route: "/about",
    page: Html().Content(...)
);
```

Routes are converted to file paths:
- `"/"` → `index.html`
- `"/about"` → `about/index.html` (with `PrettyUrls = true`)
- `"/about"` → `about.html` (with `PrettyUrls = false`)

##### GenerateSiteAsync

Generate multiple pages at once:

```csharp
var pages = new Dictionary<string, Element>
{
    ["/"] = homePage,
    ["/about"] = aboutPage,
    ["/contact"] = contactPage
};

await generator.GenerateSiteAsync(pages);
```

##### CopyStaticAssetsAsync

Copy static assets (CSS, JS, images) to the output directory:

```csharp
await generator.CopyStaticAssetsAsync("./assets");
```

Files are copied to `{outputDir}/assets/`.

### StaticSiteOptions

Configure the generator:

```csharp
var options = new StaticSiteOptions
{
    CleanOutput = true,    // Clean output directory before generation (default: true)
    MinifyHtml = false,    // Minify HTML output (default: false)
    PrettyUrls = true,     // Use /about/index.html instead of /about.html (default: true)
    Verbose = true         // Print generation progress to console (default: true)
};
```

### PageBuilder

Helper for building multi-page sites:

```csharp
using SumerUI.Generators;

var pages = new PageBuilder()
    .AddPage("/", homePage)
    .AddPage("/about", aboutPage)
    .AddPage("/contact", () => CreateContactPage()) // Lazy factory
    .Build();

await generator.GenerateSiteAsync(pages);
```

---

## HTML Renderer

### HtmlRenderer

Renders SumerUI elements to HTML strings.

```csharp
using SumerUI.Renderers;

var renderer = new HtmlRenderer(minify: false);
```

#### Methods

##### RenderToString

```csharp
string html = renderer.RenderToString(element);
```

Renders an element tree to an HTML string.

**Example:**

```csharp
var page = Div()
    .Class("container")
    .Content(
        H1().Text("Hello")
    );

var html = renderer.RenderToString(page);
// Output: <div class="container"><h1>Hello</h1></div>
```

### IRenderer Interface

Implement custom renderers:

```csharp
public interface IRenderer
{
    string RenderToString(Element element);
}
```

---

## Complete Example

Putting it all together:

```csharp
using SumerUI.Elements;
using SumerUI.Extensions;
using SumerUI.Generators;
using static SumerUI.Elements.HtmlElements;

// Create a card component
Element Card(string title, string content)
{
    return Div()
        .Padding(2.Rem())
        .BackgroundColor("#ffffff")
        .Rounded(0.5.Rem())
        .Shadow()
        .MaxWidth(24.Rem())
        .Content(
            H2()
                .Text(title)
                .FontBold()
                .TextXl()
                .MarginBottom(1.Rem()),
            P()
                .Text(content)
                .TextBase()
                .TextColor("#6b7280")
        );
}

// Create a page
var page = Html().Content(
    Head().Content(
        Meta().Attr("charset", "UTF-8"),
        Title().Text("My Site")
    ),
    Body()
        .Padding(2.Rem())
        .BackgroundColor("#f3f4f6")
        .Content(
            Div()
                .Flex()
                .FlexCol()
                .ItemsCenter()
                .Gap(2.Rem())
                .Content(
                    H1()
                        .Text("Welcome")
                        .FontBold()
                        .Text3Xl(),
                    Card("Card 1", "First card content"),
                    Card("Card 2", "Second card content")
                )
        )
);

// Generate the site
var generator = new StaticSiteGenerator("./out");
await generator.GeneratePageAsync("/", page);
```

---

## Need Help?

- Check the [Getting Started Guide](getting-started.md)
- Browse [Examples](../examples/)
- Open an [issue on GitHub](https://github.com/itsmuntadhar/sumer-ui/issues)
