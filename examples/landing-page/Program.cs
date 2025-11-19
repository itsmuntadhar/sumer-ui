using SumerUI.Generators;
using SumerUI.LandingPage;

var builder = new PageBuilder()
    .AddPage("/", () => new LandingPage());

var generator = new StaticSiteGenerator("./out", new StaticSiteOptions
{
    CleanOutput = true,
    PrettyUrls = true,
    MinifyHtml = false,
    Verbose = true
});

await generator.GenerateSiteAsync(builder.Build());

Console.WriteLine("🚀 SumerUI Landing Page is ready!");
Console.WriteLine("📂 Generated at: ./out");
Console.WriteLine("💡 Open ./out/index.html in your browser");
