using SumerUI.Example;
using SumerUI.Example.Dashboard.Home;
using SumerUI.Renderers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(o =>
{
    o.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
    o.CombineLogs = true;
});

var app = builder.Build();
app.UseHttpLogging();

var _features = new List<Feature>
{
    new(Guid.NewGuid(), "Feature 1", "Description of feature 1."),
    new(Guid.NewGuid(), "Feature 2", "Description of feature 2."),
    new(Guid.NewGuid(), "Feature 3", "Description of feature 3."),
    new(Guid.NewGuid(), "Feature 4", "Description of feature 4."),
    new(Guid.NewGuid(), "Feature 5", "Description of feature 5."),
    new(Guid.NewGuid(), "Feature 6", "Description of feature 6.")
};

app.MapGet("/", async () =>
{
    var layout = new Layout();
    await Task.Delay(200);
    var homeView = new HomeView(layout, _features);
    layout.Content(homeView);

    var renderer = new HtmlRenderer(minify: false);
    var html = renderer.RenderToStream(layout);

    return Results.Stream(html, "text/html");
});


app.Run();
