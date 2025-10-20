# SumerUI

A type-safe, fluent C# library for generating static HTML with Tailwind-inspired utilities.

## Features

- 🎨 **Fluent API** - Chainable methods for building HTML
- 🔒 **Type-safe** - No magic strings, full IntelliSense support
- 🎯 **Tailwind-inspired** - Familiar utility-first approach
- 📦 **Static site generation** - Export to HTML files for CDN deployment
- 🚀 **Zero JavaScript** - Pure server-side rendering

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

- [Getting Started](docs/getting-started.md) _(coming soon)_
- [API Reference](docs/api-reference.md) _(coming soon)_
- [Examples](examples/)

## Contributing

Contributions welcome! See [CONTRIBUTING.md](CONTRIBUTING.md)

## License

MIT
