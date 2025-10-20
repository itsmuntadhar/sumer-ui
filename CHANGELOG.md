# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

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

[Unreleased]: https://github.com/itsmuntadhar/sumer-ui/compare/v0.1.0...HEAD
[0.1.0]: https://github.com/itsmuntadhar/sumer-ui/releases/tag/v0.1.0
