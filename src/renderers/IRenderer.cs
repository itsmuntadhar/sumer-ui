using SumerUI.Elements;

namespace SumerUI.Renderers;

public interface IRenderer
{
    Stream RenderToStream(Element element);
    string RenderToString(Element element);
}
