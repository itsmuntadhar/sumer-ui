# Contributing to SumerUI

Thanks for your interest!

## How to Contribute

1. **Report bugs** - Open an issue with reproduction steps
2. **Request features** - Describe your use case
3. **Submit PRs** - Bug fixes and new utilities welcome!

## Adding New Utilities

We follow Tailwind's naming conventions. Example:

```csharp
// src/lib/Extensions/YourExtensions.cs
public static class YourExtensions
{
    public static Element YourUtility(this Element element)
    {
        return element.Style("css-property", "value");
    }
}
```

## Testing

```bash
dotnet test
```

## Questions?

Open an issue or discussion!
