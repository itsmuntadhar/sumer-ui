namespace SumerUI.Elements;

public class Element
{
    private static int _idCounter = 0;

    public string Tag { get; }
    public List<Element> Children { get; } = [];
    public Dictionary<string, string> Attributes { get; } = [];
    public Dictionary<string, string> Styles { get; } = [];
    public Dictionary<string, Dictionary<string, string>> ResponsiveStyles { get; } = [];
    public string? TextContent { get; set; }
    public string? ResponsiveId { get; private set; }

    public Element(string tag)
    {
        Tag = tag;
    }

    public Element()
    {
        Tag = "";
    }

    internal void EnsureResponsiveId()
    {
        ResponsiveId ??= $"sui-{Interlocked.Increment(ref _idCounter)}";
    }

    // fluent modifiers
    public virtual Element Attr(string name, string value) { Attributes[name] = value; return this; }
    public virtual Element Style(string name, string value) { Styles[name] = value; return this; }

    public virtual Element Class(string className) => Attr("class", MergeAttr("class", className));

    protected virtual string MergeAttr(string key, string newVal)
    {
        if (!Attributes.TryGetValue(key, out var prev) || string.IsNullOrEmpty(prev))
        {
            return newVal;
        }
        return prev + " " + newVal;
    }

    public virtual Element Content(params IEnumerable<Element> children)
    {
        foreach (var c in children)
        {
            Children.Add(c);
        }
        return this;
    }

    public virtual Element Text(string t)
    {
        TextContent = t;
        return this;
    }
}
