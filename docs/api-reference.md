# API Reference

Complete reference for all SumerUI APIs.

## Table of Contents

- [Core Elements](#core-elements)
- [Layout Utilities](#layout-utilities)
- [Flexbox Utilities](#flexbox-utilities)
- [Grid Utilities](#grid-utilities)
- [Responsive Breakpoints](#responsive-breakpoints)
- [Typography Utilities](#typography-utilities)
- [Color Utilities](#color-utilities)
- [Transform Utilities](#transform-utilities)
- [Transition & Animation Utilities](#transition--animation-utilities)
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

## Grid Utilities

SumerUI provides a comprehensive CSS Grid system with 80+ utility methods.

### Grid Display

```csharp
.Grid()                       // display: grid
.InlineGrid()                 // display: inline-grid
```

### Grid Template Columns

```csharp
.GridCols(int columns)        // grid-template-columns: repeat(columns, minmax(0, 1fr))
.GridCols(string template)    // grid-template-columns: {template}
.GridColsNone()               // grid-template-columns: none
```

**Example:**
```csharp
Div()
    .Grid()
    .GridCols(3)              // 3 equal columns
    .Gap(1.Rem())
    .Content(/* items */)

// Custom template
Div()
    .Grid()
    .GridCols("200px 1fr 2fr")
```

### Grid Template Rows

```csharp
.GridRows(int rows)           // grid-template-rows: repeat(rows, minmax(0, 1fr))
.GridRows(string template)    // grid-template-rows: {template}
.GridRowsNone()               // grid-template-rows: none
```

### Grid Column Spanning

```csharp
.GridColSpan(int span)        // span multiple columns
.GridColSpanFull()            // span all columns (1 / -1)
.GridColStart(int start)      // grid-column-start: {start}
.GridColEnd(int end)          // grid-column-end: {end}
```

**Example:**
```csharp
// Item spans 2 columns
Div().GridColSpan(2)

// Item spans from column 1 to 3
Div().GridColStart(1).GridColEnd(3)

// Header spans all columns
Div().GridColSpanFull()
```

### Grid Row Spanning

```csharp
.GridRowSpan(int span)        // span multiple rows
.GridRowSpanFull()            // span all rows (1 / -1)
.GridRowStart(int start)      // grid-row-start: {start}
.GridRowEnd(int end)          // grid-row-end: {end}
```

### Grid Auto Flow

```csharp
.GridFlowRow()                // grid-auto-flow: row
.GridFlowCol()                // grid-auto-flow: column
.GridFlowDense()              // grid-auto-flow: dense
.GridFlowRowDense()           // grid-auto-flow: row dense
.GridFlowColDense()           // grid-auto-flow: column dense
```

### Grid Auto Columns/Rows

```csharp
// Auto columns
.GridAutoColsAuto()           // grid-auto-columns: auto
.GridAutoColsMin()            // grid-auto-columns: min-content
.GridAutoColsMax()            // grid-auto-columns: max-content
.GridAutoColsFr()             // grid-auto-columns: minmax(0, 1fr)
.GridAutoCols(string value)   // custom value

// Auto rows
.GridAutoRowsAuto()           // grid-auto-rows: auto
.GridAutoRowsMin()            // grid-auto-rows: min-content
.GridAutoRowsMax()            // grid-auto-rows: max-content
.GridAutoRowsFr()             // grid-auto-rows: minmax(0, 1fr)
.GridAutoRows(string value)   // custom value
```

### Place Content

Control alignment and distribution of grid content:

```csharp
.PlaceContentCenter()         // place-content: center
.PlaceContentStart()          // place-content: start
.PlaceContentEnd()            // place-content: end
.PlaceContentBetween()        // place-content: space-between
.PlaceContentAround()         // place-content: space-around
.PlaceContentEvenly()         // place-content: space-evenly
.PlaceContentStretch()        // place-content: stretch
```

### Place Items

Control alignment of items within their grid areas:

```csharp
.PlaceItemsCenter()           // place-items: center
.PlaceItemsStart()            // place-items: start
.PlaceItemsEnd()              // place-items: end
.PlaceItemsStretch()          // place-items: stretch
```

### Justify Items & Content

```csharp
// Justify items (inline axis)
.JustifyItemsStart()          // justify-items: start
.JustifyItemsEnd()            // justify-items: end
.JustifyItemsCenter()         // justify-items: center
.JustifyItemsStretch()        // justify-items: stretch

// Justify content (inline axis)
.JustifyContentStart()        // justify-content: start
.JustifyContentEnd()          // justify-content: end
.JustifyContentCenter()       // justify-content: center
.JustifyContentBetween()      // justify-content: space-between
.JustifyContentAround()       // justify-content: space-around
.JustifyContentEvenly()       // justify-content: space-evenly
```

### Align Items & Content

```csharp
// Align items (block axis)
.AlignItemsStart()            // align-items: start
.AlignItemsEnd()              // align-items: end
.AlignItemsCenter()           // align-items: center
.AlignItemsStretch()          // align-items: stretch

// Align content (block axis)
.AlignContentStart()          // align-content: start
.AlignContentEnd()            // align-content: end
.AlignContentCenter()         // align-content: center
.AlignContentBetween()        // align-content: space-between
.AlignContentAround()         // align-content: space-around
.AlignContentEvenly()         // align-content: space-evenly
```

### Place Self

Control individual item placement:

```csharp
.PlaceSelfAuto()              // place-self: auto
.PlaceSelfStart()             // place-self: start
.PlaceSelfEnd()               // place-self: end
.PlaceSelfCenter()            // place-self: center
.PlaceSelfStretch()           // place-self: stretch
```

**Complete Grid Example:**

```csharp
var dashboard = Div()
    .Grid()
    .GridCols(12)
    .GridRows(3)
    .Gap(1.Rem())
    .Height(100.Vh())
    .Content(
        // Header spans all columns
        Div().GridColSpanFull()
            .BackgroundColor("#1f2937")
            .Content(H1().Text("Dashboard").TextWhite()),
        
        // Sidebar spans 2 columns, all rows
        Div().GridColSpan(2).GridRowSpan(2)
            .BackgroundColor("#374151")
            .Content(/* navigation */),
        
        // Main content spans remaining columns
        Div().GridColSpan(10).GridRowSpan(2)
            .Content(/* content */)
    );
```

---

## Responsive Breakpoints

SumerUI implements mobile-first responsive design with Tailwind-style breakpoints.

### Breakpoint Sizes

- **sm**: 640px and up (tablets)
- **md**: 768px and up (tablets landscape)
- **lg**: 1024px and up (laptops/desktops)
- **xl**: 1280px and up (large desktops)
- **2xl**: 1536px and up (extra large screens)

### Usage

Apply styles at specific breakpoints using the responsive modifier methods:

```csharp
.Sm(e => e./* styles for sm and up */)
.Md(e => e./* styles for md and up */)
.Lg(e => e./* styles for lg and up */)
.Xl(e => e./* styles for xl and up */)
.TwoXl(e => e./* styles for 2xl and up */)
```

### Mobile-First Approach

Start with base (mobile) styles, then layer on responsive styles:

```csharp
var card = Div()
    // Base styles (mobile)
    .Padding(1.Rem())
    .Width(100.Percent())
    .BackgroundColor("#ffffff")
    
    // Tablet (sm: 640px+)
    .Sm(e => e
        .Padding(1.5.Rem())
        .Width(50.Percent())
    )
    
    // Desktop (lg: 1024px+)
    .Lg(e => e
        .Padding(2.Rem())
        .Width(33.Percent())
    );
```

### Responsive Grid Example

```csharp
var gallery = Div()
    .Grid()
    .GridCols(1)              // 1 column on mobile
    .Gap(1.Rem())
    
    .Sm(e => e.GridCols(2))   // 2 columns on tablet
    .Md(e => e.GridCols(3))   // 3 columns on tablet landscape
    .Lg(e => e.GridCols(4))   // 4 columns on desktop
    .Xl(e => e.GridCols(6))   // 6 columns on large screens
    
    .Content(
        // Gallery items
    );
```

### Responsive Typography

```csharp
var heading = H1()
    .Text("Welcome")
    .TextLg()                 // 1.125rem on mobile
    .FontBold()
    
    .Md(e => e.Text2Xl())     // 1.5rem on tablet
    .Lg(e => e.Text3Xl())     // 1.875rem on desktop
    .TextCenter();
```

### Responsive Layout

```csharp
var container = Div()
    // Mobile: stack vertically
    .Flex()
    .FlexCol()
    .Padding(1.Rem())
    
    // Tablet: switch to horizontal
    .Md(e => e
        .FlexRow()
        .Padding(2.Rem())
        .Gap(2.Rem())
    )
    
    // Desktop: increase spacing
    .Lg(e => e
        .Padding(4.Rem())
        .MaxWidth(80.Rem())
        .Margin("0 auto")  // center container
    );
```

### Custom Media Queries

For custom breakpoints, use `MediaQuery`:

```csharp
element.MediaQuery("900px", e => e
    .FontSize(1.25.Rem())
    .Padding(2.Rem())
);
```

### Complete Responsive Example

```csharp
var hero = Div()
    // Mobile base styles
    .Padding(2.Rem())
    .TextCenter()
    .BackgroundColor("#f3f4f6")
    
    // Tablet
    .Md(e => e
        .Padding(4.Rem())
        .TextLeft()
    )
    
    // Desktop
    .Lg(e => e
        .Padding(6.Rem())
        .MaxWidth(72.Rem())
        .Margin("0 auto")
    )
    
    .Content(
        H1()
            .Text("Build Amazing Sites")
            .Text2Xl()
            .FontBold()
            .MarginBottom(1.Rem())
            
            .Md(e => e.Text3Xl())
            .Lg(e => e.FontSize(3.5.Rem())),
        
        P()
            .Text("Type-safe HTML generation with C#")
            .TextBase()
            .Md(e => e.TextLg())
    );
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

### Border

```csharp
.Border(string border)                  // border: {border}
.BorderWidth(string width)              // border-width: {width}
.BorderStyle(string style)              // border-style: {style}
.BorderTop(string border)               // border-top: {border}
.BorderBottom(string border)            // border-bottom: {border}
.BorderLeft(string border)              // border-left: {border}
.BorderRight(string border)             // border-right: {border}
```

### Shadow

```csharp
.Shadow()                               // box-shadow: 0 1px 3px 0 rgb(0 0 0 / 0.1)
.Shadow(string shadow)                  // box-shadow: {shadow}
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

## Transform Utilities

Apply CSS transforms to elements.

### Transform Origin

Set the origin point for transformations:

```csharp
.TransformOrigin(string origin)       // custom origin
.OriginCenter()                       // transform-origin: center
.OriginTop()                          // transform-origin: top
.OriginTopRight()                     // transform-origin: top right
.OriginRight()                        // transform-origin: right
.OriginBottomRight()                  // transform-origin: bottom right
.OriginBottom()                       // transform-origin: bottom
.OriginBottomLeft()                   // transform-origin: bottom left
.OriginLeft()                         // transform-origin: left
.OriginTopLeft()                      // transform-origin: top left
```

### Scale

```csharp
.Scale(double scale)                  // uniform scale
.ScaleX(double scale)                 // scale X axis only
.ScaleY(double scale)                 // scale Y axis only
.Scale(double x, double y)            // scale X and Y independently
```

**Predefined scales:**
```csharp
.Scale0()                             // scale(0)
.Scale50()                            // scale(0.5)
.Scale75()                            // scale(0.75)
.Scale90()                            // scale(0.9)
.Scale95()                            // scale(0.95)
.Scale100()                           // scale(1)
.Scale105()                           // scale(1.05)
.Scale110()                           // scale(1.1)
.Scale125()                           // scale(1.25)
.Scale150()                           // scale(1.5)
```

**Example:**
```csharp
// Hover scale effect (with CSS :hover)
Div()
    .Scale100()
    .TransitionTransform()
    .Duration300()
    // In actual CSS: :hover { transform: scale(1.05) }
```

### Rotate

```csharp
.Rotate(int degrees)                  // rotate({degrees}deg)
.Rotate(string value)                 // rotate({value})
```

**Predefined rotations:**
```csharp
.Rotate0()                            // rotate(0deg)
.Rotate45()                           // rotate(45deg)
.Rotate90()                           // rotate(90deg)
.Rotate180()                          // rotate(180deg)
.RotateNeg45()                        // rotate(-45deg)
.RotateNeg90()                        // rotate(-90deg)
.RotateNeg180()                       // rotate(-180deg)
```

Plus: `Rotate1()`, `Rotate2()`, `Rotate3()`, `Rotate6()`, `Rotate12()` and their negative variants.

### Translate

```csharp
.Translate(string x, string y)        // translate(x, y)
.TranslateX(string x)                 // translateX(x)
.TranslateY(string y)                 // translateY(y)
```

**Predefined translations:**
```csharp
// X-axis
.TranslateXFull()                     // translateX(100%)
.TranslateXHalf()                     // translateX(50%)
.TranslateXNegFull()                  // translateX(-100%)
.TranslateXNegHalf()                  // translateX(-50%)

// Y-axis
.TranslateYFull()                     // translateY(100%)
.TranslateYHalf()                     // translateY(50%)
.TranslateYNegFull()                  // translateY(-100%)
.TranslateYNegHalf()                  // translateY(-50%)
```

### Skew

```csharp
.Skew(int x, int y)                   // skew(x, y)
.SkewX(int degrees)                   // skewX(degrees)
.SkewY(int degrees)                   // skewY(degrees)
```

**Predefined skews:**
```csharp
.SkewX0()                             // skewX(0deg)
.SkewX3()                             // skewX(3deg)
.SkewX6()                             // skewX(6deg)
.SkewX12()                            // skewX(12deg)
.SkewXNeg3()                          // skewX(-3deg)
// Similar for SkewY
```

**Transform Example:**

```csharp
var card = Div()
    .Padding(2.Rem())
    .BackgroundColor("#ffffff")
    .Rounded(0.5.Rem())
    .OriginCenter()
    .Scale100()
    .Rotate0()
    .TransitionAll()
    .Duration300()
    .EaseInOut()
    .Content(/* content */);
```

---

## Transition & Animation Utilities

Add smooth transitions and animations to elements.

### Transition Property

Control which properties transition:

```csharp
.Transition(string transition)        // full transition shorthand
.TransitionProperty(string property)  // transition-property: {property}
.TransitionDuration(string duration)  // transition-duration: {duration}
.TransitionTimingFunction(string fn)  // transition-timing-function: {fn}
.TransitionDelay(string delay)        // transition-delay: {delay}
```

### Predefined Transition Properties

```csharp
.TransitionNone()                     // transition-property: none
.TransitionAll()                      // transition-property: all
.TransitionColors()                   // transition color properties
.TransitionOpacity()                  // transition-property: opacity
.TransitionShadow()                   // transition-property: box-shadow
.TransitionTransform()                // transition-property: transform
```

### Transition Duration

```csharp
.Duration75()                         // 75ms
.Duration100()                        // 100ms
.Duration150()                        // 150ms
.Duration200()                        // 200ms
.Duration300()                        // 300ms (recommended default)
.Duration500()                        // 500ms
.Duration700()                        // 700ms
.Duration1000()                       // 1000ms (1 second)
```

### Timing Functions

```csharp
.EaseLinear()                         // linear
.EaseIn()                             // cubic-bezier(0.4, 0, 1, 1)
.EaseOut()                            // cubic-bezier(0, 0, 0.2, 1)
.EaseInOut()                          // cubic-bezier(0.4, 0, 0.2, 1)
```

### Transition Delay

```csharp
.Delay75()                            // 75ms delay
.Delay100()                           // 100ms delay
.Delay150()                           // 150ms delay
.Delay200()                           // 200ms delay
.Delay300()                           // 300ms delay
.Delay500()                           // 500ms delay
.Delay700()                           // 700ms delay
.Delay1000()                          // 1000ms delay
```

### Animation

```csharp
.Animation(string animation)          // animation: {animation}
.AnimationName(string name)           // animation-name: {name}
.AnimationDuration(string duration)   // animation-duration: {duration}
.AnimationTimingFunction(string fn)   // animation-timing-function: {fn}
.AnimationDelay(string delay)         // animation-delay: {delay}
.AnimationIterationCount(string cnt)  // animation-iteration-count: {cnt}
.AnimationDirection(string dir)       // animation-direction: {dir}
.AnimationFillMode(string mode)       // animation-fill-mode: {mode}
.AnimationPlayState(string state)     // animation-play-state: {state}
```

### Predefined Animations

```csharp
.AnimateNone()                        // no animation
.AnimateSpin()                        // spinning animation
.AnimatePing()                        // ping/pulse outward
.AnimatePulse()                       // gentle pulse
.AnimateBounce()                      // bouncing animation
```

**Note:** These require corresponding `@keyframes` in your CSS:

```css
@keyframes spin {
  from { transform: rotate(0deg); }
  to { transform: rotate(360deg); }
}

@keyframes pulse {
  0%, 100% { opacity: 1; }
  50% { opacity: .5; }
}

@keyframes bounce {
  0%, 100% {
    transform: translateY(-25%);
    animation-timing-function: cubic-bezier(0.8, 0, 1, 1);
  }
  50% {
    transform: translateY(0);
    animation-timing-function: cubic-bezier(0, 0, 0.2, 1);
  }
}
```

### Performance Optimization

```csharp
.WillChange(string property)          // will-change: {property}
.WillChangeAuto()                     // will-change: auto
.WillChangeTransform()                // will-change: transform
.WillChangeOpacity()                  // will-change: opacity
.WillChangeScroll()                   // will-change: scroll-position
```

### Complete Transition Examples

**Button with hover effect:**

```csharp
var button = Button()
    .Text("Click Me")
    .Padding(0.75.Rem(), 1.5.Rem())
    .BackgroundColor("#3b82f6")
    .TextColor("#ffffff")
    .Rounded(0.375.Rem())
    .TransitionAll()
    .Duration300()
    .EaseInOut()
    .Cursor("pointer")
    // Add hover styles with CSS: :hover { background-color: #2563eb; transform: scale(1.05); }
    .Content();
```

**Fade-in card:**

```csharp
var card = Div()
    .Padding(2.Rem())
    .BackgroundColor("#ffffff")
    .Rounded(0.5.Rem())
    .Shadow()
    .TransitionAll()
    .Duration500()
    .EaseOut()
    .WillChangeTransform()
    .WillChangeOpacity()
    .Content(/* content */);
```

**Loading spinner:**

```csharp
var spinner = Div()
    .Width(3.Rem())
    .Height(3.Rem())
    .Border("4px solid #e5e7eb")
    .BorderTop("4px solid #3b82f6")
    .Rounded(50.Percent())
    .AnimateSpin();
```

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
