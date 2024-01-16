using AoC2022D2;

namespace AoC2022D2Tests;

public class SolverTest : IDisposable
{
    private readonly Solver _sut;

    public SolverTest()
    {
        _sut = new Solver();
    }


    // X = Lose Y = Draw Z = Win
    [Theory]
    [InlineData('A', 'X', 3)] 
    [InlineData('A', 'Y', 4)]
    [InlineData('A', 'Z', 8)]
    [InlineData('B', 'X', 1)]
    [InlineData('B', 'Y', 5)]
    [InlineData('B', 'Z', 9)]
    [InlineData('C', 'X', 2)]
    [InlineData('C', 'Y', 6)]
    [InlineData('C', 'Z', 7)]
    public async Task DetermineScore_Should_Calculate_CorrectScore_For_All_Possible_Hands(char opponent,
        char desiredOutcome, int score)
    {
        // Arrange
        var sw = new StreamWriter(Environment.CurrentDirectory + "/input.txt");
        await sw.WriteLineAsync(opponent + " " + desiredOutcome);
        sw.Close();

        // Act
        var res = await _sut.DetermineScore();

        // Assert
        Assert.Equal(score, res);
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        File.Delete(Environment.CurrentDirectory + "/input.txt");
    }
}
