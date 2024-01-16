using AoC2022D2;

namespace AoC2022D2Tests;

public class GameHandTest
{
    // X = Lose Y = Draw Z = Win
    [Theory]
    // Paper
    [InlineData('A', 'X', HandState.Scissors)]
    [InlineData('A', 'Y', HandState.Rock)]
    [InlineData('A', 'Z', HandState.Paper)]
    // Rock
    [InlineData('B', 'X', HandState.Rock)]
    [InlineData('B', 'Y', HandState.Paper)]
    [InlineData('B', 'Z', HandState.Scissors)]
    // Scissors
    [InlineData('C', 'X', HandState.Paper)]
    [InlineData('C', 'Y', HandState.Scissors)]
    [InlineData('C', 'Z', HandState.Rock)]
    public void PlayerChoice_Should_Return_TheCorrect_Choice_Dependant_On_DesiredOutcome(char opponent, char outcome,
        HandState expectedResult)
    {
        // Arrange
        // Act
        var hand = new GameHand(opponent, outcome);

        // Assert
        Assert.Equal(expectedResult, hand.PlayerChoice);
    }
    
    [Theory]
    [InlineData('A','X', HandState.Rock)]
    [InlineData('B','X', HandState.Paper)]
    [InlineData('C','X', HandState.Scissors)]
    public void Gamehand_Should_Properly_Convert_Opponent_Handstate_When_Initialized(char handstate, char outcome, HandState expectedOpponentHandState)
    {
        // Arrange
        
        // Act
        var res = new GameHand(handstate, outcome);
        
        // Assert
        Assert.Equal(expectedOpponentHandState, res.OpponentsChoice);
    }

    [Fact]
    public void HandState_Should_Throw_ArgOutOfRangeExcp_When_Invalid_Arg_Is_Passed()
    {
        // Arrange
        const char handstate = 'Z';
        const char outcome = 'X';
        
        // Act
        Action act = () =>
        {
            _ = new GameHand(handstate, outcome);
        };

        // Assert
        var excp = Assert.Throws<ArgumentOutOfRangeException>(act);
        Assert.Equal($"Exception of type 'System.ArgumentOutOfRangeException' was thrown. (Parameter 'opponentsChoice'){Environment.NewLine}Actual value was Z.",excp.Message);
    }
    
    [Fact]
    public void GameOutcome_Should_Throw_ArgOutOfRangeExcp_When_Invalid_Arg_Is_Passed()
    {
        // Arrange
        const char handstate = 'A';
        const char outcome = 'A';
        
        // Act
        Action act = () =>
        {
            _ = new GameHand(handstate, outcome);
        };

        // Assert
        var excp = Assert.Throws<ArgumentOutOfRangeException>(act);
        Assert.Equal($"Exception of type 'System.ArgumentOutOfRangeException' was thrown. (Parameter 'desiredOutcome'){Environment.NewLine}Actual value was A.",excp.Message);
    }
}
