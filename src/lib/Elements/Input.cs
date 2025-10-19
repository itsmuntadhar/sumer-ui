namespace SumerUI.Elements;

public class Input : Element
{
    public Input(string type) : base("input")
    {
        Attr("type", type);
    }
}
