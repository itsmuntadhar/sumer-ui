using SumerUI.Elements;
using SumerUI.Extensions;
using static SumerUI.Extensions.Elements;

namespace SumerUI.BasicGeneratorExample.Dashboard.Home;

public sealed class AboutView : Element
{
    private readonly Layout _layout;

    public AboutView(Layout layout) : base("")
    {
        _layout = layout;
        SetContent();
        _layout.WithMeta(
            Meta().Attr("name", "description").Attr("content", "A basic example of a SumerUI application using Tailwind CSS for styling."),
            Meta().Attr("name", "author").Attr("content", "Your Name")
        );
    }

    private void SetContent()
    {
        Content(
            H1().Text("About View")
                .FontBold()
                .MarginBottom(1.Rem())
                .FontSize(2.Rem()
            ),
            P().Text("About Contoso")
        );
    }
}
