using AoC2022D25;

namespace AoC2022D25Tests;

public class SnafuConverterTest
{
    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    [InlineData(3, "1=")]
    [InlineData(4, "1-")]
    [InlineData(5, "10")]
    [InlineData(6, "11")]
    [InlineData(7, "12")]
    [InlineData(8, "2=")]
    [InlineData(9, "2-")]
    [InlineData(10, "20")]
    [InlineData(15, "1=0")]
    [InlineData(20, "1-0")]
    [InlineData(2022, "1=11-2")]
    [InlineData(12345, "1-0---0")]
    [InlineData(314159265, "1121-1110-1=0")]
    [InlineData(1490345522845,"20--1-2120==22=--0")]
    public void ConvertSnafuToDecimal_Should_Convert_To_The_Appropriate_Decimals_When_Called(long @decimal, string snafu)
    {
        // Arrange
        var sut = new SnafuConverter();

        // Act
        var res = sut.ConvertSnafuToDecimal(snafu);

        // Assert
        Assert.Equal(@decimal, res);
    }
    
    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    [InlineData(3, "1=")]
    [InlineData(4, "1-")]
    [InlineData(5, "10")]
    [InlineData(6, "11")]
    [InlineData(7, "12")]
    [InlineData(8, "2=")]
    [InlineData(9, "2-")]
    [InlineData(10, "20")]
    [InlineData(15, "1=0")]
    [InlineData(20, "1-0")]
    [InlineData(2022, "1=11-2")]
    [InlineData(12345, "1-0---0")]
    [InlineData(314159265, "1121-1110-1=0")]
    [InlineData(33_454,"21-==1-")]
    [InlineData(1490345522845,"20--1-2120==22=--0")]
    public void ConvertDecimalToSnaful_Should_Convert_To_The_Appropriate_Snafu_When_Called(long @decimal, string snafu)
    {
        // Arrange
        var sut = new SnafuConverter();

        // Act
        var res = sut.ConvertDecimalToSnafu(@decimal);

        // Assert
        Assert.Equal(snafu, res);
    }

    
}
