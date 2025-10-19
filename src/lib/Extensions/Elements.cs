using SumerUI.Elements;

namespace SumerUI.Extensions;

public static class Elements
{
    public static Html Html() => new();
    public static Head Head() => new();
    public static Body Body() => new();
    public static Title Title() => new();
    public static Meta Meta() => new();
    public static Script Script(string src) => new(src);
    public static Div Div() => new();
    public static Span Span() => new();
    public static P P() => new();
    public static H1 H1() => new();
    public static H2 H2() => new();
    public static H3 H3() => new();
    public static H4 H4() => new();
    public static H5 H5() => new();
    public static H6 H6() => new();
    public static A A(string href) => new(href);
    public static Ul Ul() => new();
    public static Li Li() => new();
    public static Button Button() => new();
    public static Input Input(string type) => new(type);
    public static Form Form(string action, string method = "POST") => new(action, method);
    public static TextArea TextArea() => new();
}
