namespace SumerUI.Elements;

public static class FormElements
{
    public static Input Input(string type = "text") => new(type);
    public static Input Email() => Input("email");
    public static Input Password() => Input("password");
    public static Input Number() => Input("number");
    public static TextArea TextArea() => new TextArea();
    public static Select Select() => new Select();
    public static Option Option() => new Option();
    public static Label Label() => new Label();
}
