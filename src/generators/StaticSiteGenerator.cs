using SumerUI.Elements;
using SumerUI.Renderers;

namespace SumerUI.Generators;

public class StaticSiteGenerator
{
    private readonly IRenderer _renderer;
    private readonly string _outputDir;
    private readonly StaticSiteOptions _options;

    public StaticSiteGenerator(string outputDir, StaticSiteOptions? options = null)
    {
        _outputDir = outputDir;
        _options = options ?? new StaticSiteOptions();
        _renderer = new HtmlRenderer(_options.MinifyHtml);
    }

    public async Task GeneratePageAsync(string route, Element page)
    {
        var html = _renderer.RenderToString(page);
        var filePath = GetFilePath(route);

        var directory = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrEmpty(directory))
        {
            Directory.CreateDirectory(directory);
        }

        await File.WriteAllTextAsync(filePath, html);

        if (_options.Verbose)
        {
            Console.WriteLine($"✓ Generated: {filePath}");
        }
    }

    public async Task GenerateSiteAsync(Dictionary<string, Element> pages)
    {
        if (_options.CleanOutput && Directory.Exists(_outputDir))
        {
            Directory.Delete(_outputDir, true);
        }

        Directory.CreateDirectory(_outputDir);

        var tasks = pages.Select(kvp => GeneratePageAsync(kvp.Key, kvp.Value));
        await Task.WhenAll(tasks);

        Console.WriteLine($"✨ Generated {pages.Count} pages to {_outputDir}");
    }

    public async Task CopyStaticAssetsAsync(string assetsDir)
    {
        if (!Directory.Exists(assetsDir))
            return;

        var targetDir = Path.Combine(_outputDir, "assets");
        Directory.CreateDirectory(targetDir);

        foreach (var file in Directory.GetFiles(assetsDir, "*", SearchOption.AllDirectories))
        {
            var relativePath = Path.GetRelativePath(assetsDir, file);
            var targetPath = Path.Combine(targetDir, relativePath);

            var targetFileDir = Path.GetDirectoryName(targetPath);
            if (!string.IsNullOrEmpty(targetFileDir))
            {
                Directory.CreateDirectory(targetFileDir);
            }

            File.Copy(file, targetPath, true);
        }

        if (_options.Verbose)
        {
            Console.WriteLine($"✓ Copied static assets from {assetsDir}");
        }
    }

    private string GetFilePath(string route)
    {
        if (route == "/")
        {
            return Path.Combine(_outputDir, "index.html");
        }

        var cleanRoute = route.Trim('/');

        if (_options.PrettyUrls)
        {
            // /about -> about/index.html
            return Path.Combine(_outputDir, cleanRoute, "index.html");
        }
        else
        {
            // /about -> about.html
            return Path.Combine(_outputDir, $"{cleanRoute}.html");
        }
    }
}

public class StaticSiteOptions
{
    public bool CleanOutput { get; set; } = true;
    public bool MinifyHtml { get; set; } = false;
    public bool PrettyUrls { get; set; } = true;
    public bool Verbose { get; set; } = true;
}
