using SumerUI.Elements;
using SumerUI.Extensions;
using static SumerUI.Extensions.Elements;

namespace SumerUI.Example;

public sealed class Layout : Element
{
    private readonly List<Element> _metaTags =
    [
        Meta().Attr("charset", "UTF-8"),
        Meta().Attr("name", "viewport").Attr("content", "width=device-width, initial-scale=1.0"),
        Title().Text("SumerUI Basic Example"),
    ];

    private readonly List<Element> _headScripts =
    [
        Script("https://cdn.jsdelivr.net/npm/@tailwindcss/browser@4")
    ];

    public Layout(params Element[] children) : base("")
    {
        BuildLayout(children);
    }

    private void BuildLayout(IEnumerable<Element> children)
    {
        Children.Clear();
        Content(Html()
            .Attr("lang", "en")
            .Content(
                Head().Content(_metaTags.Concat(_headScripts)),
                Body()
                    .Relative()
                    .Flex()
                    .FlexColumn()
                    .Gap(1.Rem())
                    .Padding(1.Rem())
                    .BackgroundColor(Color.White)
                    .Content(
                        BuildHeader(),
                        BuildMainContent(children)
                    )
            )
        );
    }

    private static Element BuildHeader()
    {
        return Div()
            .Class("backdrop-blur-lg")
            .Flex()
            .FlexRow()
            .Gap(1.Rem())
            .AlignItems("center")
            .BorderWidth(2.Px())
            .BorderColor(Color.Black, 0.7)
            .Absolute()
            .Left(1.Rem())
            .Right(1.Rem())
            .Top(1.Rem())
            .Height(3.Rem())
            .Padding(0.Px(), 1.Rem())
            .BorderWidth(2.Px())
            .BorderColor(Color.Black, 0.7)
            .BackgroundColor(Color.Gray200, 0.1)
            .Flex()
            .FlexRow()
            .Gap(1.Rem())
            .AlignItems("center")
            .Shadow2Xl()
            .BorderRadius(0.375.Rem())
            .Content(H1().Text("SumerUI Basic Example").TextXl().FontSemibold());
    }

    private static Element BuildMainContent(IEnumerable<Element> children)
    {
        return Div()
            .Class("p-4 absolute left-4 right-4 bottom-4 top-[4.5rem] rounded-md bg-white/20 border-2 border-black/70 shadow-2xl backdrop-blur-lg overflow-y-auto")
            .Content(children);
    }

    public override Element Content(params IEnumerable<Element> children)
    {
        Children.Clear();
        base.Content(Html()
            .Attr("lang", "en")
            .Attr("dir", "ltr")
            .Content(
                Head().Content(_metaTags.Union(_headScripts)),
                Body()
                    .Class("relative flex flex-col gap-4 p-4 bg-white")
                    .Content(
                        Div()
                            .Class("px-4 absolute left-4 right-4 top-4 h-12 rounded-md bg-gray-200/10 border-2 border-black/70 shadow-2xl backdrop-blur-lg flex flex-row gap-4 items-center")
                            .Content(
                                H1().Text("SumerUI Basic Example").Class("text-xl font-semibold")
                            ),
                        Div()
                            .Class("p-4 absolute left-4 right-4 bottom-4 top-[4.5rem] rounded-md bg-white/20 border-2 border-black/70 shadow-2xl backdrop-blur-lg overflow-y-auto")
                            .Content(children)
                        )
                )
        );
        return this;
    }

    public Layout WithMeta(params Element[] metaTags)
    {
        _metaTags.AddRange(metaTags);
        return this;
    }

    public Layout WithHeadScripts(params Element[] headScripts)
    {
        _headScripts.AddRange(headScripts);
        return this;
    }
}
