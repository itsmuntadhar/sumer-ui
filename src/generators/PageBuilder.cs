using SumerUI.Elements;

namespace SumerUI.Generators;

public class PageBuilder
{
    private readonly Dictionary<string, Element> _pages = new();

    public PageBuilder AddPage(string route, Element page)
    {
        _pages[route] = page;
        return this;
    }

    public PageBuilder AddPage(string route, Func<Element> pageFactory)
    {
        _pages[route] = pageFactory();
        return this;
    }

    public Dictionary<string, Element> Build() => _pages;
}
