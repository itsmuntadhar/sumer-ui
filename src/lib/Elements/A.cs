namespace SumerUI.Elements;

public class A : Element
{
    public A(string href) : base("a")
    {
        Attr("href", href);
    }
}
