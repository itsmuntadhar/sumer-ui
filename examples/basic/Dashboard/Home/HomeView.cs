using SumerUI.Elements;
using SumerUI.Extensions;
using static SumerUI.Extensions.Elements;

namespace SumerUI.Example.Dashboard.Home;

public sealed class HomeView : Element
{
    private readonly Layout _layout;
    private readonly IEnumerable<Feature> _features;

    public HomeView(Layout layout, IEnumerable<Feature> features) : base("")
    {
        _features = features;
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
            H1().Text("Home View")
                .FontBold()
                .MarginBottom(1.Rem())
                .FontSize(2.Rem()
            ),
            P().Text("Welcome to the Home View of the Dashboard!"),
            P().Text("This is a simple example of a SumerUI application using Tailwind CSS for styling.").MarginBottom(1.Rem()),
            P().Text("Feel free to explore and modify the code to see how SumerUI works!"),
            P().Text("This thing is inside of a layout xDD").MarginBottom(4.Rem()),
            Div().Class("grid gap-4 grid-cols-1 md:grid-cols-2 lg:grid-cols-3")
                .Content(
                    _features.Select(feature =>
                        new FeatureCard(feature.Title, feature.Description)
                    )
                )
        );
    }
}
