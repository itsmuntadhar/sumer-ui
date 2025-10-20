# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [0.2.0] - 2025-10-20

### Added

#### Grid System Extensions (80+ new utilities)
- Complete CSS Grid utility library (`GridExtensions.cs`)
- Grid display: `Grid()`, `GridInline()`
- Template columns/rows: `GridCols(int)`, `GridRows(int)`, `GridColsNone()`, `GridRowsNone()`
- Column/row spanning: `ColSpan(int)`, `RowSpan(int)`, `ColSpanFull()`, `RowSpanFull()`
- Grid positioning: `ColStart(int)`, `ColEnd(int)`, `RowStart(int)`, `RowEnd(int)`
- Grid flow: `GridFlowRow()`, `GridFlowCol()`, `GridFlowDense()`, `GridFlowRowDense()`, `GridFlowColDense()`
- Auto columns/rows: `AutoColsAuto()`, `AutoColsMin()`, `AutoColsMax()`, `AutoColsFr()` (and rows variants)
- Place content: `PlaceContentCenter()`, `PlaceContentStart()`, `PlaceContentEnd()`, `PlaceContentBetween()`, `PlaceContentAround()`, `PlaceContentEvenly()`, `PlaceContentStretch()`
- Place items: `PlaceItemsCenter()`, `PlaceItemsStart()`, `PlaceItemsEnd()`, `PlaceItemsStretch()`
- Justify/align items: Full set of `JustifyItems*()` and `AlignItems*()` methods
- Justify/align content: Full set of `JustifyContent*()` and `AlignContent*()` methods
- Place self: `PlaceSelfAuto()`, `PlaceSelfStart()`, `PlaceSelfCenter()`, `PlaceSelfEnd()`, `PlaceSelfStretch()`
- 25 comprehensive unit tests for grid functionality

#### Responsive Breakpoint System
- Mobile-first responsive design with breakpoint modifiers (`BreakpointExtensions.cs`)
- Five predefined breakpoints:
  - `Sm(callback)` - 640px and up
  - `Md(callback)` - 768px and up
  - `Lg(callback)` - 1024px and up
  - `Xl(callback)` - 1280px and up
  - `TwoXl(callback)` - 1536px and up
- Custom breakpoints: `MediaQuery(string query, callback)`
- Automatic media query injection in `HtmlRenderer`
- Unique element ID generation for responsive styles
- Proper CSS cascade ordering (mobile-first, smallest to largest)
- 14 comprehensive unit tests for responsive functionality

#### Enhanced Typography Extensions (53 new utilities)
- **Font weights:**
  - `FontWeight(int)` - Custom font weight (100-900)
  - `FontExtraLight()` - 200
  - `FontExtraBold()` - 800
  - `FontBlack()` - 900
- **Line heights:**
  - `LineHeight(string)` - Custom line height
  - `LeadingSnug()` - 1.375
  - `LeadingLoose()` - 2
- **Letter spacing:**
  - `LetterSpacing(string)` - Custom letter spacing
  - `TrackingTighter()`, `TrackingTight()`, `TrackingNormal()`, `TrackingWide()`, `TrackingWider()`, `TrackingWidest()`
- **Font families:**
  - `FontFamily(string)` - Custom font family
  - `FontSans()`, `FontSerif()`, `FontMono()` - System font stacks
- **Text decoration:**
  - `Underline()`, `Overline()`, `LineThrough()`, `NoUnderline()`
  - `DecorationSolid()`, `DecorationDouble()`, `DecorationDotted()`, `DecorationDashed()`, `DecorationWavy()`
- **Text overflow:**
  - `Truncate()` - Combines overflow, ellipsis, and nowrap
  - `TextEllipsis()`, `TextClip()`
- **White space:**
  - `WhiteSpace(string)`, `WhitespaceNormal()`, `WhitespaceNowrap()`, `WhitespacePre()`, `WhitespacePreLine()`, `WhitespacePreWrap()`
- **Word break:**
  - `BreakNormal()`, `BreakWords()`, `BreakAll()`
- **Text style:**
  - `Italic()`, `NotItalic()`
- **Font variants:**
  - `SmallCaps()`, `NormalNums()`, `OldstyleNums()`, `TabularNums()`
- 32 comprehensive unit tests for typography

#### Transform Extensions (110+ new utilities)
- **Transform origin:** `TransformOrigin(string)`, `OriginCenter()`, `OriginTop()`, `OriginRight()`, `OriginBottom()`, `OriginLeft()`, plus corner combinations
- **Scale transforms:**
  - `Scale(double)`, `ScaleX(double)`, `ScaleY(double)`, `Scale(x, y)`
  - 10 predefined scales: `Scale0()`, `Scale50()`, `Scale75()`, `Scale90()`, `Scale95()`, `Scale100()`, `Scale105()`, `Scale110()`, `Scale125()`, `Scale150()`
- **Rotate transforms:**
  - `Rotate(int degrees)`, `Rotate(string)` - Supports degrees, radians, turns
  - 16 predefined rotations: `Rotate0()` through `Rotate180()` (positive and negative)
- **Translate transforms:**
  - `Translate(x, y)`, `TranslateX(string)`, `TranslateY(string)`
  - 8 predefined translations: `TranslateXFull()`, `TranslateXHalf()`, `TranslateYFull()`, `TranslateYHalf()` (positive and negative)
- **Skew transforms:**
  - `Skew(x, y)`, `SkewX(int)`, `SkewY(int)`
  - 22 predefined skews: `SkewX0()` through `SkewX12()`, `SkewY0()` through `SkewY12()` (positive and negative)
- **Combined transforms:** `Transform(string)` - Custom transform string for complex effects
- 26 comprehensive unit tests for transforms

#### Transition & Animation Extensions (60+ new utilities)
- **Transition properties:**
  - `Transition(string)`, `TransitionProperty(string)`, `TransitionDuration(string)`, `TransitionTimingFunction(string)`, `TransitionDelay(string)`
- **Predefined transition properties:**
  - `TransitionNone()`, `TransitionAll()`, `TransitionColors()`, `TransitionOpacity()`, `TransitionShadow()`, `TransitionTransform()`
- **Predefined durations:** 8 presets from 75ms to 1000ms
- **Timing functions:** `EaseLinear()`, `EaseIn()`, `EaseOut()`, `EaseInOut()`
- **Predefined delays:** 8 presets from 75ms to 1000ms
- **Animation properties:**
  - `Animation(string)`, `AnimationName(string)`, `AnimationDuration(string)`, `AnimationTimingFunction(string)`, `AnimationDelay(string)`
  - `AnimationIterationCount(string)`, `AnimationDirection(string)`, `AnimationFillMode(string)`, `AnimationPlayState(string)`
- **Predefined animations:** `AnimateNone()`, `AnimateSpin()`, `AnimatePing()`, `AnimatePulse()`, `AnimateBounce()`
- **Performance optimization:** `WillChange(string)`, `WillChangeAuto()`, `WillChangeTransform()`, `WillChangeOpacity()`, `WillChangeScroll()`
- 32 comprehensive unit tests for transitions/animations

#### Example Pages & Documentation
- New example pages:
  - `GridExamplesView` - 6 grid layout examples
  - `ResponsiveExamplesView` - 6 responsive design examples
  - `TypographyExamplesView` - 8 typography sections with live examples
  - `TransformTransitionExamplesView` - 9 sections with interactive hover effects
- Comprehensive documentation:
  - `GRID_IMPLEMENTATION.md` - Complete grid system documentation
  - `RESPONSIVE_IMPLEMENTATION.md` - Responsive design guide
  - `TYPOGRAPHY_IMPLEMENTATION.md` - Typography utilities guide
  - `TRANSFORM_TRANSITION_IMPLEMENTATION.md` - Transform and animation guide

### Fixed
- **CSS Specificity Bug:** Fixed issue where inline styles overrode media query styles. Base responsive styles now use CSS classes instead of inline styles for proper specificity.
- **Media Query Ordering Bug:** Fixed alphabetical sorting of media queries that broke mobile-first cascade. Media queries now sort numerically by breakpoint value (640px → 768px → 1024px → 1280px → 1536px).

### Changed
- Extended `Element` class with responsive tracking:
  - Added `ResponsiveStyles` dictionary for media query storage
  - Added `ResponsiveId` property for unique element identification
  - Added `EnsureResponsiveId()` method for thread-safe ID generation
- Enhanced `HtmlRenderer`:
  - Added `_mediaQueries` dictionary for collecting responsive styles
  - Added `InjectResponsiveStyles()` for inserting `<style>` tags
  - Added `GenerateResponsiveStylesTag()` for proper CSS generation
  - Added `ExtractBreakpointValue()` for numerical media query sorting
  - Modified `RenderElement()` to handle responsive styles and unique IDs

### Performance
- Grid utilities use native CSS Grid for optimal performance
- Responsive system generates minimal CSS (only used breakpoints)
- Transform/transition utilities leverage GPU acceleration
- Will-change hints for optimized animations

## [0.1.0] - 2025-10-20

### Added
- Initial release of SumerUI
- Core library (`SumerUI`) with:
  - Fluent API for building HTML elements
  - Type-safe element classes (Div, H1-H6, P, A, Form, Input, etc.)
  - Base `Element` class with chainable methods (Attr, Style, Class, Content, Text)
  
- Layout extensions (`LayoutExtensions`) with:
  - Spacing utilities (Margin, Padding with unit support)
  - Sizing utilities (Width, Height, MaxWidth, MinWidth, etc.)
  - Display & Position utilities (Display, Position, Top, Left, etc.)
  - Flexbox utilities (Flex, FlexRow, FlexColumn, AlignItems, JustifyContent, Gap)
  - Grid utilities (Grid, GridCols, GridRows, ColSpan, RowSpan)
  - Border utilities (Border, BorderRadius, BorderWidth, BorderStyle)
  - Shadow utilities (Shadow, ShadowSm, ShadowMd, ShadowLg, ShadowXl, Shadow2Xl)
  - Position helpers (Relative, Absolute, Fixed, Sticky)
  
- Typography extensions (`TypographyExtensions`) with:
  - Font size utilities (TextXs, TextSm, TextBase, TextLg, TextXl, Text2Xl, Text3Xl)
  - Font weight utilities (FontThin through FontBold)
  - Text alignment (TextLeft, TextCenter, TextRight)
  - Text transform (Uppercase, Lowercase, Capitalize)
  - Line height (LeadingNone, LeadingTight, LeadingNormal, LeadingRelaxed)
  
- Color extensions (`ColorExtensions`) with:
  - Background, text, and border color utilities
  - Tailwind color palette (Gray, Red, Orange, Yellow, Green, Emerald, Teal, Cyan, Blue, Indigo, Purple, Pink, Rose)
  - Hover state utilities
  - Opacity support
  - Gradient helpers
  
- Unit extensions (`UnitExtensions`) with:
  - Type-safe unit conversions (Px, Rem, Em, Percent, Vw, Vh)
  - Works with any numeric type (int, double, float, etc.)
  
- HTML Renderer (`SumerUI.Renderers`) with:
  - Renders elements to HTML strings or streams
  - Optional HTML minification
  - Self-closing tag support
  - Character escaping for security
  
- Static Site Generator (`SumerUI.Generators`) with:
  - Generate complete static websites from elements
  - Single page and multi-page generation
  - Configurable options (CleanOutput, MinifyHtml, PrettyUrls, Verbose)
  - Static asset copying
  - PageBuilder helper for organizing routes
  
- Comprehensive test suite with 43 unit tests
- Complete documentation (README, Getting Started, API Reference)
- Example projects (ASP.NET server-side rendering, static site generation)

[Unreleased]: https://github.com/itsmuntadhar/sumer-ui/compare/v0.2.0...HEAD
[0.2.0]: https://github.com/itsmuntadhar/sumer-ui/compare/v0.1.0...v0.2.0
[0.1.0]: https://github.com/itsmuntadhar/sumer-ui/releases/tag/v0.1.0
