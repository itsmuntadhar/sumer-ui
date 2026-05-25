# SumerUI

A type-safe, fluent C# library for generating static HTML with Tailwind-inspired utilities.

## Features

- 🎨 **Fluent API** - Chainable methods for building HTML
- 🔒 **Type-safe** - No magic strings, full IntelliSense support
- 🎯 **Tailwind-inspired** - Familiar utility-first approach
- 📦 **Static site generation** - Export to HTML files for CDN deployment
- 🚀 **Zero JavaScript** - Pure server-side rendering
- **Typst source rendering** - Reuse element trees for static print-oriented documents

## Quick Start

```csharp
using SumerUI.Elements;
using SumerUI.Generators;
using static SumerUI.Elements.HtmlElements;

// Create a page
var page = Div()
    .Flex()
    .ItemsCenter()
    .JustifyCenter()
    .Padding(2.Rem())
    .BackgroundColor(Color.Emerald50)
    .Content(
        H1().Text("Hello, SumerUI!").FontBold().Text2Xl()
    );

// Generate static site
var generator = new StaticSiteGenerator("./out");
await generator.GeneratePageAsync("/", page);
```

### Typst Source

```csharp
using SumerUI.Renderers;

var renderer = new TypstRenderer();
var source = renderer.RenderToString(page);

foreach (var diagnostic in renderer.Diagnostics)
{
    Console.WriteLine($"{diagnostic.Code}: {diagnostic.Message}");
}
```

`TypstRenderer` emits Typst source; it does not compile PDFs. It maps static document styling and reports diagnostics when browser-only behavior such as responsive rules, hover states, scripts, or animations is omitted.

## Installation

```bash
dotnet add package SumerUI
dotnet add package SumerUI.Renderers
dotnet add package SumerUI.Generators
```

## Examples

See [`examples/`](examples/) for complete examples:
- [`basic/`](examples/basic/) - ASP.NET server-side rendering
- [`basic-generator/`](examples/basic-generator/) - Static site generation

## Documentation

- [Getting Started](docs/getting-started.md) - Installation and first steps
- [API Reference](docs/api-reference.md) - Complete API documentation
- [Components Guide](docs/components-guide.md) - Building reusable components
- [Architecture Guide](docs/architecture-guide.md) - Project structure and patterns
- [Real-World Examples](docs/examples.md) - Production-ready examples
- [Code Examples](examples/) - Working example projects

## Contributing

Contributions welcome! See [CONTRIBUTING.md](CONTRIBUTING.md)

## License

MIT
