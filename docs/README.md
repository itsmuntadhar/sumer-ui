# SumerUI Documentation

Complete documentation for building static sites with SumerUI.

## Documentation Index

### Getting Started
**[Getting Started Guide](getting-started.md)** - New to SumerUI? Start here!
- Installation instructions
- Your first page
- Building multi-page sites
- Using Tailwind-inspired utilities
- Unit system
- Generator options
- Deployment guides

### API Reference
**[API Reference](api-reference.md)** - Complete reference for all APIs
- **Core Elements** - HTML element types
- **Layout Utilities** - Spacing, sizing, display, positioning (50+ utilities)
- **Flexbox Utilities** - Complete flexbox system (30+ utilities)
- **Grid Utilities** - CSS Grid with 80+ utility methods
- **Responsive Breakpoints** - Mobile-first design (sm, md, lg, xl, 2xl)
- **Typography Utilities** - Font size, weight, alignment, decorations (40+ utilities)
- **Color Utilities** - Background, text, border colors with Tailwind palette
- **Transform Utilities** - Scale, rotate, translate, skew (40+ utilities)
- **Transition & Animation** - Smooth transitions and animations (30+ utilities)
- **Unit Extensions** - Type-safe CSS units (rem, px, em, %, vh, vw)
- **Static Site Generator** - Generate and deploy static sites
- **HTML Renderer** - Render elements to HTML strings

### Component Development
**[Components Guide](components-guide.md)** - Build reusable components
- Component basics (functions vs classes)
- Component patterns (Builder, Factory)
- Props and configuration
- Composition strategies
- Layout components
- Best practices
- Code organization

### Architecture & Patterns
**[Architecture Guide](architecture-guide.md)** - Structure large projects
- Project structure (small, medium, large)
- Separation of concerns (layers)
- State management
- Routing and navigation
- Asset management
- Testing strategy
- Performance optimization

### Real-World Examples
**[Real-World Examples](examples.md)** - Production-ready code
- **Landing Page** - Hero, features, pricing sections
- **Blog System** - List pages, detail pages, categories
- **Dashboard Layout** - Admin interface with sidebar
- **E-commerce** - Product pages (coming soon)
- **Portfolio Site** - Personal portfolio (coming soon)

### Code Examples
**[Code Examples](../examples/)** - Working projects
- `basic/` - ASP.NET server-side rendering
- `basic-generator/` - Static site generation

## Quick Navigation by Task

### "I want to..."

#### Learn the Basics
→ Start with [Getting Started Guide](getting-started.md)

#### Build My First Page
→ See [Getting Started - Your First Page](getting-started.md#your-first-page)

#### Use Grid or Flexbox
→ Check [API Reference - Grid Utilities](api-reference.md#grid-utilities)  
→ Check [API Reference - Flexbox Utilities](api-reference.md#flexbox-utilities)

#### Make It Responsive
→ See [API Reference - Responsive Breakpoints](api-reference.md#responsive-breakpoints)

#### Create Reusable Components
→ Read [Components Guide](components-guide.md)

#### Structure a Large Project
→ Follow [Architecture Guide](architecture-guide.md)

#### See Real Examples
→ Browse [Real-World Examples](examples.md)

#### Style with Typography
→ Reference [API Reference - Typography](api-reference.md#typography-utilities)

#### Add Animations
→ Learn [API Reference - Transitions](api-reference.md#transition--animation-utilities)

#### Deploy My Site
→ See [Getting Started - Deployment](getting-started.md#deployment)

## Reading Order

### For Beginners
1. [Getting Started Guide](getting-started.md)
2. [API Reference - Core Elements](api-reference.md#core-elements)
3. [API Reference - Layout Utilities](api-reference.md#layout-utilities)
4. [Components Guide - Component Basics](components-guide.md#component-basics)
5. [Real-World Examples](examples.md)

### For Experienced Developers
1. [API Reference](api-reference.md) - Skim for capabilities
2. [Components Guide](components-guide.md) - Learn patterns
3. [Architecture Guide](architecture-guide.md) - Project structure
4. [Real-World Examples](examples.md) - See it in action

### For Migrating from Other Frameworks
1. [API Reference - Responsive Breakpoints](api-reference.md#responsive-breakpoints)
2. [Components Guide](components-guide.md)
3. [Architecture Guide - Separation of Concerns](architecture-guide.md#separation-of-concerns)

## API Quick Reference

### Most Used Utilities

#### Layout
```csharp
.Padding(2.Rem())
.Margin(1.Rem())
.Width(100.Percent())
.MaxWidth(64.Rem())
```

#### Flexbox
```csharp
.Flex()
.FlexRow()
.ItemsCenter()
.JustifyBetween()
.Gap(1.Rem())
```

#### Grid
```csharp
.Grid()
.GridCols(3)
.Gap(2.Rem())
.GridColSpan(2)
```

#### Responsive
```csharp
.Md(e => e.GridCols(2))
.Lg(e => e.GridCols(4))
```

#### Typography
```csharp
.Text("Hello")
.FontBold()
.TextXl()
.TextCenter()
```

#### Colors
```csharp
.BackgroundColor("#3b82f6")
.TextColor("#ffffff")
```

#### Transitions
```csharp
.TransitionAll()
.Duration300()
.EaseInOut()
```

## Cheat Sheets

### Responsive Breakpoints
- `sm` - 640px (tablet)
- `md` - 768px (tablet landscape)
- `lg` - 1024px (laptop/desktop)
- `xl` - 1280px (large desktop)
- `2xl` - 1536px (extra large)

### Unit Extensions
- `.Rem()` - rem units
- `.Px()` - pixel units
- `.Em()` - em units
- `.Percent()` - percentage
- `.Vh()` - viewport height
- `.Vw()` - viewport width

### Text Sizes
- `TextXs()` - 0.75rem
- `TextSm()` - 0.875rem
- `TextBase()` - 1rem
- `TextLg()` - 1.125rem
- `TextXl()` - 1.25rem
- `Text2Xl()` - 1.5rem
- `Text3Xl()` - 1.875rem

### Font Weights
- `FontLight()` - 300
- `FontNormal()` - 400
- `FontMedium()` - 500
- `FontSemibold()` - 600
- `FontBold()` - 700

## Tips & Best Practices

1. **Start Simple** - Begin with basic components, refactor later
2. **Use Type Safety** - Leverage IntelliSense and compile-time checking
3. **Think Mobile-First** - Apply base styles, then use responsive modifiers
4. **Extract Components** - Reuse common patterns
5. **Organize by Feature** - Group related pages and components
6. **Use CSS Classes** - For repeated styles, use CSS classes instead of inline styles
7. **Test Your Components** - Write unit tests for complex components

## Getting Help

- **Issues** - Found a bug? [Open an issue](https://github.com/itsmuntadhar/sumer-ui/issues)
- **Discussions** - Have questions? [Start a discussion](https://github.com/itsmuntadhar/sumer-ui/discussions)
- **Contributing** - Want to contribute? See [CONTRIBUTING.md](../CONTRIBUTING.md)

## Next Steps

Ready to build? Pick your path:

- **Tutorial Path**: [Getting Started](getting-started.md) → [Components Guide](components-guide.md) → [Examples](examples.md)
- **Reference Path**: [API Reference](api-reference.md) → [Architecture Guide](architecture-guide.md)
- **Example Path**: [Real-World Examples](examples.md) → [Code Examples](../examples/)

Happy building!
