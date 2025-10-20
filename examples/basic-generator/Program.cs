using SumerUI.BasicGeneratorExample;
using SumerUI.BasicGeneratorExample.Dashboard;
using SumerUI.BasicGeneratorExample.Dashboard.Home;
using SumerUI.Generators;

var layout = new Layout();

var builder = new PageBuilder()
    .AddPage("/", () => new Layout().Content(new HomeView(layout, new[]
    {
        new Feature(Guid.NewGuid(), "Feature One", "This is the first feature."),
        new Feature(Guid.NewGuid(), "Feature Two", "This is the second feature."),
        new Feature(Guid.NewGuid(), "Feature Three", "This is the third feature."),
        new Feature(Guid.NewGuid(), "Feature Four", "This is the fourth feature."),
        new Feature(Guid.NewGuid(), "Feature Five", "This is the fifth feature."),
        new Feature(Guid.NewGuid(), "Feature Six", "This is the sixth feature.")
    })))
    .AddPage("/about", () => new Layout().Content(new AboutView(layout)))
    .AddPage("/contact", () => new Layout().Content(new ContactView(layout)))
    .AddPage("/grid-examples", () => new Layout().Content(new GridExamplesView()))
    .AddPage("/responsive", () => new Layout().Content(new ResponsiveExamplesView()))
    .AddPage("/typography", () => new Layout().Content(new TypographyExamplesView()))
    .AddPage("/transforms", () => new Layout().Content(new TransformTransitionExamplesView()));

var generator = new StaticSiteGenerator("./out", new StaticSiteOptions
{
    CleanOutput = true,
    PrettyUrls = true,
    MinifyHtml = false,
    Verbose = true
});

await generator.GenerateSiteAsync(builder.Build());
await generator.CopyStaticAssetsAsync("./assets");

Console.WriteLine("🚀 Site ready for deployment!");
