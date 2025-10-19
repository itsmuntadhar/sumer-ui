namespace SumerUI.Elements;

public class Form : Element
{
    public Form(string action, string method = "POST") : base("form")
    {
        Attr("action", action);
        Attr("method", method);
    }
}
