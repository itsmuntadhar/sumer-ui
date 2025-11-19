# Components Guide

Learn how to build reusable, maintainable components with SumerUI.

## Table of Contents

- [Component Basics](#component-basics)
- [Component Patterns](#component-patterns)
- [Props and Configuration](#props-and-configuration)
- [Composition](#composition)
- [Layout Components](#layout-components)
- [Best Practices](#best-practices)

---

## Component Basics

### What is a Component?

In SumerUI, a component is simply a method or class that returns an `Element`. Components promote reusability and maintainability.

### Simple Function Component

The simplest way to create a component is with a function:

```csharp
using SumerUI.Elements;
using SumerUI.Extensions;
using static SumerUI.Extensions.Elements;

Element Button(string text)
{
    return Html.Button()
        .Text(text)
        .Padding(0.75.Rem(), 1.5.Rem())
        .BackgroundColor("#3b82f6")
        .TextColor("#ffffff")
        .Rounded(0.375.Rem())
        .FontMedium()
        .TransitionAll()
        .Duration300()
        .Cursor("pointer");
}

// Usage
var myButton = Button("Click Me!");
```

### Class-Based Component

For more complex components, use a class that extends `Element`:

```csharp
public class Card : Element
{
    public Card(string title, string content) : base("div")
    {
        this.Padding(2.Rem())
            .BackgroundColor("#ffffff")
            .Rounded(0.5.Rem())
            .Shadow()
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
}

// Usage
var card = new Card("Welcome", "This is a card component");
```

---

## Component Patterns

### Builder Pattern

Create components with fluent configuration:

```csharp
public class ButtonBuilder
{
    private string _text = "Button";
    private string _variant = "primary";
    private string _size = "medium";

    public ButtonBuilder Text(string text)
    {
        _text = text;
        return this;
    }

    public ButtonBuilder Variant(string variant)
    {
        _variant = variant;
        return this;
    }

    public ButtonBuilder Size(string size)
    {
        _size = size;
        return this;
    }

    public Element Build()
    {
        var button = Html.Button().Text(_text).Cursor("pointer");

        // Apply variant styles
        button = _variant switch
        {
            "primary" => button
                .BackgroundColor("#3b82f6")
                .TextColor("#ffffff"),
            "secondary" => button
                .BackgroundColor("#6b7280")
                .TextColor("#ffffff"),
            "danger" => button
                .BackgroundColor("#ef4444")
                .TextColor("#ffffff"),
            _ => button
        };

        // Apply size styles
        button = _size switch
        {
            "small" => button.Padding(0.5.Rem(), 1.Rem()).TextSm(),
            "medium" => button.Padding(0.75.Rem(), 1.5.Rem()).TextBase(),
            "large" => button.Padding(1.Rem(), 2.Rem()).TextLg(),
            _ => button
        };

        return button.Rounded(0.375.Rem())
            .TransitionAll()
            .Duration300();
    }
}

// Usage
var button = new ButtonBuilder()
    .Text("Delete")
    .Variant("danger")
    .Size("large")
    .Build();
```

### Factory Pattern

Create different variations of a component:

```csharp
public static class AlertFactory
{
    public static Element Success(string message)
    {
        return CreateAlert(message, "#10b981", "#d1fae5", "#065f46");
    }

    public static Element Error(string message)
    {
        return CreateAlert(message, "#ef4444", "#fee2e2", "#991b1b");
    }

    public static Element Warning(string message)
    {
        return CreateAlert(message, "#f59e0b", "#fef3c7", "#92400e");
    }

    public static Element Info(string message)
    {
        return CreateAlert(message, "#3b82f6", "#dbeafe", "#1e40af");
    }

    private static Element CreateAlert(
        string message,
        string borderColor,
        string bgColor,
        string textColor)
    {
        return Div()
            .Padding(1.Rem())
            .BackgroundColor(bgColor)
            .BorderLeft($"4px solid {borderColor}")
            .Rounded(0.375.Rem())
            .Content(
                P().Text(message).TextColor(textColor).FontMedium()
            );
    }
}

// Usage
var alert = AlertFactory.Success("Operation completed successfully!");
```

---

## Props and Configuration

### Using Records for Props

Define component configuration with records:

```csharp
public record CardProps(
    string Title,
    string Content,
    string? ImageUrl = null,
    bool ShowFooter = false
);

public class Card : Element
{
    public Card(CardProps props) : base("div")
    {
        this.Padding(2.Rem())
            .BackgroundColor("#ffffff")
            .Rounded(0.5.Rem())
            .Shadow();

        var children = new List<Element>();

        // Optional image
        if (!string.IsNullOrEmpty(props.ImageUrl))
        {
            children.Add(
                Html.Img()
                    .Attr("src", props.ImageUrl)
                    .Attr("alt", props.Title)
                    .Width(100.Percent())
                    .Rounded(0.375.Rem())
                    .MarginBottom(1.Rem())
            );
        }

        // Title and content
        children.Add(
            H2().Text(props.Title)
                .FontBold()
                .TextXl()
                .MarginBottom(1.Rem())
        );

        children.Add(
            P().Text(props.Content)
                .TextBase()
                .TextColor("#6b7280")
        );

        // Optional footer
        if (props.ShowFooter)
        {
            children.Add(
                Div()
                    .BorderTop("1px solid #e5e7eb")
                    .MarginTop(1.Rem())
                    .PaddingTop(1.Rem())
                    .Content(
                        P().Text("Card Footer").TextSm().TextColor("#9ca3af")
                    )
            );
        }

        this.Content(children);
    }
}

// Usage
var card = new Card(new CardProps(
    Title: "Beautiful Card",
    Content: "This card has all the features!",
    ImageUrl: "/images/hero.jpg",
    ShowFooter: true
));
```

### Configuration Classes

For complex components with many options:

```csharp
public class TableConfig
{
    public bool Striped { get; set; } = false;
    public bool Hoverable { get; set; } = false;
    public bool Bordered { get; set; } = false;
    public string HeaderBg { get; set; } = "#f9fafb";
    public string BorderColor { get; set; } = "#e5e7eb";
}

public class Table : Element
{
    public Table(
        string[] headers,
        string[][] rows,
        TableConfig? config = null) : base("table")
    {
        config ??= new TableConfig();

        this.Width(100.Percent())
            .BorderCollapse("collapse");

        if (config.Bordered)
        {
            this.Border($"1px solid {config.BorderColor}");
        }

        // Build header
        var headerRow = Html.Tr()
            .BackgroundColor(config.HeaderBg)
            .Content(
                headers.Select(h =>
                    Html.Th()
                        .Text(h)
                        .Padding(0.75.Rem())
                        .TextLeft()
                        .FontSemibold()
                        .BorderBottom($"2px solid {config.BorderColor}")
                )
            );

        // Build rows
        var bodyRows = rows.Select((row, index) =>
        {
            var tr = Html.Tr();

            if (config.Striped && index % 2 == 1)
            {
                tr.BackgroundColor("#f9fafb");
            }

            if (config.Hoverable)
            {
                tr.TransitionAll()
                  .Duration200()
                  .Cursor("pointer");
                // Add hover effect via CSS
            }

            return tr.Content(
                row.Select(cell =>
                    Html.Td()
                        .Text(cell)
                        .Padding(0.75.Rem())
                        .BorderBottom($"1px solid {config.BorderColor}")
                )
            );
        });

        this.Content(
            Html.Thead().Content(headerRow),
            Html.Tbody().Content(bodyRows)
        );
    }
}

// Usage
var table = new Table(
    headers: new[] { "Name", "Email", "Role" },
    rows: new[]
    {
        new[] { "John Doe", "john@example.com", "Admin" },
        new[] { "Jane Smith", "jane@example.com", "User" }
    },
    config: new TableConfig
    {
        Striped = true,
        Hoverable = true,
        Bordered = true
    }
);
```

---

## Composition

### Container Components

Create components that wrap other content:

```csharp
public class Container : Element
{
    public Container(params Element[] children) : base("div")
    {
        this.MaxWidth(80.Rem())
            .Margin("0 auto")
            .Padding(0.Rem(), 1.Rem())
            .Md(e => e.Padding(0.Rem(), 2.Rem()))
            .Content(children);
    }
}

// Usage
var page = new Container(
    H1().Text("My Page"),
    P().Text("Content goes here")
);
```

### Slot Pattern

Create components with named content areas:

```csharp
public class Modal : Element
{
    public Modal(
        Element header,
        Element body,
        Element? footer = null) : base("div")
    {
        this.Position("fixed")
            .Top(0.Px())
            .Left(0.Px())
            .Width(100.Percent())
            .Height(100.Vh())
            .BackgroundColor("rgba(0, 0, 0, 0.5)")
            .Flex()
            .ItemsCenter()
            .JustifyCenter()
            .ZIndex(1000);

        var modalContent = Div()
            .BackgroundColor("#ffffff")
            .Rounded(0.5.Rem())
            .Shadow()
            .MaxWidth(32.Rem())
            .Width(100.Percent())
            .Margin(1.Rem());

        var children = new List<Element>
        {
            // Header
            Div()
                .Padding(1.5.Rem())
                .BorderBottom("1px solid #e5e7eb")
                .Content(header),

            // Body
            Div()
                .Padding(1.5.Rem())
                .Content(body)
        };

        // Optional footer
        if (footer != null)
        {
            children.Add(
                Div()
                    .Padding(1.5.Rem())
                    .BorderTop("1px solid #e5e7eb")
                    .Flex()
                    .JustifyEnd()
                    .Gap(0.5.Rem())
                    .Content(footer)
            );
        }

        modalContent.Content(children);
        this.Content(modalContent);
    }
}

// Usage
var modal = new Modal(
    header: H2().Text("Confirm Action").FontBold(),
    body: P().Text("Are you sure you want to continue?"),
    footer: Div().Content(
        Button("Cancel").Class("btn-secondary"),
        Button("Confirm").Class("btn-primary")
    )
);
```

### Higher-Order Components

Components that enhance other components:

```csharp
public static class ComponentExtensions
{
    public static Element WithLoading(this Element element, bool isLoading)
    {
        if (!isLoading) return element;

        return Div()
            .Position("relative")
            .Content(
                element.Style("opacity", "0.5").Style("pointer-events", "none"),
                Div()
                    .Position("absolute")
                    .Top(50.Percent())
                    .Left(50.Percent())
                    .Translate("-50%", "-50%")
                    .Content(
                        Div()
                            .Width(2.Rem())
                            .Height(2.Rem())
                            .Border("3px solid #e5e7eb")
                            .BorderTop("3px solid #3b82f6")
                            .Rounded(50.Percent())
                            .AnimateSpin()
                    )
            );
    }

    public static Element WithBadge(this Element element, string badgeText)
    {
        return Div()
            .Position("relative")
            .Display("inline-block")
            .Content(
                element,
                Div()
                    .Text(badgeText)
                    .Position("absolute")
                    .Top(-0.5.Rem())
                    .Right(-0.5.Rem())
                    .BackgroundColor("#ef4444")
                    .TextColor("#ffffff")
                    .Rounded(50.Percent())
                    .Padding(0.25.Rem(), 0.5.Rem())
                    .TextXs()
                    .FontBold()
            );
    }
}

// Usage
var button = Button("Messages")
    .WithBadge("5")
    .WithLoading(isLoading: false);
```

---

## Layout Components

### Grid Layout Component

```csharp
public class Grid : Element
{
    public Grid(int columns, params Element[] items) : base("div")
    {
        this.Grid()
            .GridCols(1)
            .Gap(1.Rem())
            .Sm(e => e.GridCols(Math.Min(2, columns)))
            .Md(e => e.GridCols(Math.Min(3, columns)))
            .Lg(e => e.GridCols(columns))
            .Content(items);
    }
}

// Usage
var gallery = new Grid(
    columns: 4,
    Image("/photo1.jpg"),
    Image("/photo2.jpg"),
    Image("/photo3.jpg"),
    Image("/photo4.jpg")
);
```

### Stack Component

```csharp
public class Stack : Element
{
    public Stack(string direction = "vertical", params Element[] items) : base("div")
    {
        this.Flex()
            .Gap(1.Rem());

        if (direction == "vertical")
        {
            this.FlexCol();
        }
        else
        {
            this.FlexRow();
        }

        this.Content(items);
    }
}

// Convenience methods
public static class StackHelpers
{
    public static Element VStack(params Element[] items) => new Stack("vertical", items);
    public static Element HStack(params Element[] items) => new Stack("horizontal", items);
}

// Usage
var layout = VStack(
    H1().Text("Title"),
    P().Text("Description"),
    HStack(
        Button("Cancel"),
        Button("Submit")
    )
);
```

### Section Component

```csharp
public class Section : Element
{
    public Section(
        string? id = null,
        string? className = null,
        params Element[] children) : base("section")
    {
        this.Padding(4.Rem(), 0.Rem())
            .Md(e => e.Padding(6.Rem(), 0.Rem()));

        if (!string.IsNullOrEmpty(id))
        {
            this.Attr("id", id);
        }

        if (!string.IsNullOrEmpty(className))
        {
            this.Class(className);
        }

        this.Content(
            new Container(children)
        );
    }
}

// Usage
var page = Html.Body().Content(
    new Section(id: "hero", className: "bg-gradient",
        H1().Text("Welcome"),
        P().Text("Hero content")
    ),
    new Section(id: "features",
        H2().Text("Features"),
        new Grid(3,
            FeatureCard("Fast"),
            FeatureCard("Secure"),
            FeatureCard("Reliable")
        )
    )
);
```

---

## Best Practices

### 1. Keep Components Focused

Each component should have a single, well-defined purpose:

```csharp
// Good: Focused component
public class Avatar : Element
{
    public Avatar(string imageUrl, string alt, string size = "medium") : base("img")
    {
        var sizeValue = size switch
        {
            "small" => 2.Rem(),
            "medium" => 3.Rem(),
            "large" => 4.Rem(),
            _ => 3.Rem()
        };

        this.Attr("src", imageUrl)
            .Attr("alt", alt)
            .Width(sizeValue)
            .Height(sizeValue)
            .Rounded(50.Percent())
            .Style("object-fit", "cover");
    }
}

// Bad: Doing too much
public class UserProfileWithNavigationAndComments : Element { }
```

### 2. Use Meaningful Names

```csharp
// Good: Clear, descriptive names
public class PricingCard : Element { }
public class TestimonialSlider : Element { }
public class NewsletterSignupForm : Element { }

// Bad: Vague names
public class Component1 : Element { }
public class Box : Element { }
public class Thing : Element { }
```

### 3. Provide Sensible Defaults

```csharp
public class Button : Element
{
    public Button(
        string text,
        string variant = "primary",  // Default value
        string size = "medium",      // Default value
        bool disabled = false) : base("button")
    {
        // Implementation
    }
}
```

### 4. Make Components Composable

```csharp
// Good: Components can be combined
public class Card : Element
{
    public Card(params Element[] children) : base("div")
    {
        this.Padding(2.Rem())
            .BackgroundColor("#ffffff")
            .Rounded(0.5.Rem())
            .Shadow()
            .Content(children);  // Accept any children
    }
}

// Usage: Flexible composition
var card = new Card(
    H2().Text("Title"),
    P().Text("Content"),
    new Button("Action")
);
```

### 5. Document Your Components

```csharp
/// <summary>
/// A reusable card component with consistent styling.
/// </summary>
/// <param name="title">The card title (required)</param>
/// <param name="content">The card content (required)</param>
/// <param name="imageUrl">Optional image to display at the top</param>
/// <param name="actions">Optional action buttons for the footer</param>
public class Card : Element
{
    public Card(
        string title,
        string content,
        string? imageUrl = null,
        Element[]? actions = null) : base("div")
    {
        // Implementation
    }
}
```

### 6. Extract Common Patterns

```csharp
// Create a base class for cards with common styling
public abstract class BaseCard : Element
{
    protected BaseCard() : base("div")
    {
        this.Padding(2.Rem())
            .BackgroundColor("#ffffff")
            .Rounded(0.5.Rem())
            .Shadow();
    }
}

// Specific card types extend the base
public class ProductCard : BaseCard
{
    public ProductCard(string name, decimal price) : base()
    {
        this.Content(
            H3().Text(name),
            P().Text($"${price:F2}")
        );
    }
}

public class BlogCard : BaseCard
{
    public BlogCard(string title, string excerpt) : base()
    {
        this.Content(
            H2().Text(title),
            P().Text(excerpt)
        );
    }
}
```

### 7. Organize Components by Feature

```
src/
  Components/
    Layout/
      Header.cs
      Footer.cs
      Sidebar.cs
    UI/
      Button.cs
      Card.cs
      Modal.cs
    Forms/
      Input.cs
      Select.cs
      Checkbox.cs
    Blog/
      BlogCard.cs
      BlogPost.cs
      BlogList.cs
```

---

## Next Steps

- Check out the [API Reference](api-reference.md) for all available utilities
- See [Architecture Guide](architecture-guide.md) for project organization
- Browse [Examples](../examples/) for complete applications

Happy building!
