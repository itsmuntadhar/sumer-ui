using SumerUI.Extensions;

namespace SumerUI.Tests.Extensions;

public class UnitExtensionTests
{
    [Fact]
    public void Rem_ShouldConvert_IntToString()
    {
        var result = 1.Rem();
        Assert.Equal("1rem", result);
    }

    [Fact]
    public void Rem_ShouldConvert_DoubleToString()
    {
        var result = 1.5.Rem();
        Assert.Equal("1.5rem", result);
    }

    [Fact]
    public void Px_ShouldConvert_IntToString()
    {
        var result = 16.Px();
        Assert.Equal("16px", result);
    }

    [Fact]
    public void Px_ShouldConvert_DoubleToString()
    {
        var result = 16.5.Px();
        Assert.Equal("16.5px", result);
    }

    [Fact]
    public void Em_ShouldConvert_ToCorrectString()
    {
        var result = 2.Em();
        Assert.Equal("2em", result);
    }

    [Fact]
    public void Percent_ShouldConvert_ToCorrectString()
    {
        var result = 100.Percent();
        Assert.Equal("100%", result);
    }

    [Fact]
    public void Vw_ShouldConvert_ToCorrectString()
    {
        var result = 50.Vw();
        Assert.Equal("50vw", result);
    }

    [Fact]
    public void Vh_ShouldConvert_ToCorrectString()
    {
        var result = 100.Vh();
        Assert.Equal("100vh", result);
    }

    [Fact]
    public void Units_ShouldWork_WithVariables()
    {
        int size = 2;
        var result = size.Rem();
        Assert.Equal("2rem", result);
    }
}
