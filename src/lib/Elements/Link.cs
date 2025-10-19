namespace SumerUI.Elements;

public sealed class Link : Element
{
    public Link() : base("link") { }

    public Link Href(string href)
    {
        return (Link)Attr("href", href);
    }
}

public sealed class Script : Element
{
    public Script() : base("script") { }

    public Script Src(string src)
    {
        return (Script)Attr("src", src);
    }

    public Script(string src) : this() => Src(src);
}
