using SumerUI.Elements;
using SumerUI.Generators;
using static SumerUI.Extensions.Elements;

namespace SumerUI.Tests.Generators;

public class StaticSiteGeneratorTests
{
    [Fact]
    public async Task GeneratePageAsync_ShouldCreateFile()
    {
        var tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        var generator = new StaticSiteGenerator(tempDir);

        try
        {
            var page = Div().Content(H1().Text("Test"));
            await generator.GeneratePageAsync("/", page);

            var indexPath = Path.Combine(tempDir, "index.html");
            Assert.True(File.Exists(indexPath));

            var html = await File.ReadAllTextAsync(indexPath);
            Assert.Contains("<h1>Test</h1>", html);
        }
        finally
        {
            if (Directory.Exists(tempDir))
            {
                Directory.Delete(tempDir, true);
            }
        }
    }

    [Fact]
    public async Task GeneratePageAsync_WithPrettyUrls_ShouldCreateIndexFile()
    {
        var tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        var options = new StaticSiteOptions { PrettyUrls = true, Verbose = false };
        var generator = new StaticSiteGenerator(tempDir, options);

        try
        {
            var page = Div().Text("About");
            await generator.GeneratePageAsync("/about", page);

            var aboutPath = Path.Combine(tempDir, "about", "index.html");
            Assert.True(File.Exists(aboutPath));

            var html = await File.ReadAllTextAsync(aboutPath);
            Assert.Contains(">About<", html);
        }
        finally
        {
            if (Directory.Exists(tempDir))
            {
                Directory.Delete(tempDir, true);
            }
        }
    }

    [Fact]
    public async Task GenerateSiteAsync_ShouldCreateMultipleFiles()
    {
        var tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        var options = new StaticSiteOptions { Verbose = false };
        var generator = new StaticSiteGenerator(tempDir, options);

        try
        {
            var pages = new Dictionary<string, Element>
            {
                ["/"] = Div().Text("Home"),
                ["/about"] = Div().Text("About"),
                ["/contact"] = Div().Text("Contact")
            };

            await generator.GenerateSiteAsync(pages);

            Assert.True(File.Exists(Path.Combine(tempDir, "index.html")));
            Assert.True(File.Exists(Path.Combine(tempDir, "about", "index.html")));
            Assert.True(File.Exists(Path.Combine(tempDir, "contact", "index.html")));
        }
        finally
        {
            if (Directory.Exists(tempDir))
            {
                Directory.Delete(tempDir, true);
            }
        }
    }

    [Fact]
    public async Task GenerateSiteAsync_WithCleanOutput_ShouldRemoveExistingFiles()
    {
        var tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        Directory.CreateDirectory(tempDir);
        var existingFile = Path.Combine(tempDir, "old.txt");
        await File.WriteAllTextAsync(existingFile, "old content");

        var options = new StaticSiteOptions { CleanOutput = true, Verbose = false };
        var generator = new StaticSiteGenerator(tempDir, options);

        try
        {
            var pages = new Dictionary<string, Element>
            {
                ["/"] = Div().Text("New")
            };

            await generator.GenerateSiteAsync(pages);

            Assert.False(File.Exists(existingFile));
            Assert.True(File.Exists(Path.Combine(tempDir, "index.html")));
        }
        finally
        {
            if (Directory.Exists(tempDir))
            {
                Directory.Delete(tempDir, true);
            }
        }
    }

    [Fact]
    public async Task CopyStaticAssetsAsync_ShouldCopyFiles()
    {
        var tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        var assetsDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
        
        try
        {
            Directory.CreateDirectory(assetsDir);
            var testFile = Path.Combine(assetsDir, "test.css");
            await File.WriteAllTextAsync(testFile, "body { margin:0; }");

            var options = new StaticSiteOptions { Verbose = false };
            var generator = new StaticSiteGenerator(tempDir, options);

            await generator.CopyStaticAssetsAsync(assetsDir);

            var copiedFile = Path.Combine(tempDir, "assets", "test.css");
            Assert.True(File.Exists(copiedFile));

            var content = await File.ReadAllTextAsync(copiedFile);
            Assert.Equal("body { margin:0; }", content);
        }
        finally
        {
            if (Directory.Exists(tempDir))
            {
                Directory.Delete(tempDir, true);
            }
            if (Directory.Exists(assetsDir))
            {
                Directory.Delete(assetsDir, true);
            }
        }
    }
}
