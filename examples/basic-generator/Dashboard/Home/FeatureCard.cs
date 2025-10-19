using SumerUI.Elements;
using SumerUI.Extensions;
using static SumerUI.Extensions.Elements;

namespace SumerUI.BasicGeneratorExample.Dashboard.Home;

public sealed class FeatureCard : Element
{
    public FeatureCard(string title, string description) : base("")
    {
        Content(
            Div()
                .Padding(1.Rem())
                .BackgroundColor(Color.Emerald50)
                .HoverBackgroundColor(Color.Emerald100)
                .BorderWidth(1.Px())
                .BorderColor(Color.Emerald600)
                .Cursor("pointer")
                .Class("rounded-lg shadow-md hover:shadow-xl transition-shadow duration-700")
                .Content(
                    H2().Text(title).Class("text-2xl mb-2").FontSemibold(),
                    P().Text(description).TextColor(Color.Gray700)
                )
        );
    }
}

public sealed record Feature(Guid Id, string Title, string Description);
