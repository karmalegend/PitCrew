namespace AoC2022D2;

public class GameHand
{
    // we pre compute this as there's limited options and it saves performance/complexity.
    private readonly Dictionary<HandState, HandState> _outcomesDict = new()
    {
        // first value represents wining value second losing value.
        {HandState.Rock, HandState.Scissors},
        {HandState.Paper, HandState.Rock},
        {HandState.Scissors, HandState.Paper}
    };

    public GameHand(char opponentsChoice, char desiredOutcome)
    {
        OpponentsChoice = CharToHandState(opponentsChoice);
        DesiredOutcome = CharToGameOutcome(desiredOutcome);
    }


    public HandState OpponentsChoice { get; init; }
    private GameOutcome DesiredOutcome { get; init; }
    public HandState PlayerChoice => CalculatePlayerChoice();

    private static HandState CharToHandState(char opponentsChoice)
    {
        return opponentsChoice switch
        {
            'A' => HandState.Rock,
            'B' => HandState.Paper,
            'C' => HandState.Scissors,
            _ => throw new ArgumentOutOfRangeException(nameof(opponentsChoice), opponentsChoice, null)
        };
    }

    private static GameOutcome CharToGameOutcome(char desiredOutcome)
    {
        return desiredOutcome switch
        {
            'X' => GameOutcome.Loss,
            'Y' => GameOutcome.Tie,
            'Z' => GameOutcome.Win,
            _ => throw new ArgumentOutOfRangeException(nameof(desiredOutcome), desiredOutcome, null)
        };
    }

    private HandState CalculatePlayerChoice()
    {
        return DesiredOutcome switch
        {
            // Lose
            GameOutcome.Loss => _outcomesDict[OpponentsChoice],
            // Tie
            GameOutcome.Tie => OpponentsChoice,
            // win
            // we could in theory also make an inverse dict here to save performance but increase allocation.
            // in most scenario's like these one should given the small size and thus memory footprint.
            // here however we chose not to since performance isn't a huge consideration.
            GameOutcome.Win => _outcomesDict.First(x => x.Value == OpponentsChoice).Key,
            _ => throw new ArgumentOutOfRangeException(nameof(DesiredOutcome), DesiredOutcome, "Invalid input")
        };
    }
}
