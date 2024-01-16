namespace AoC2022D2;

public class Solver
{
    private const int WinScoreBonus = 6;
    private const int TieScoreBonus = 3;

    private readonly Dictionary<HandState, int> _scoreTable = new()
    {
        {HandState.Rock, 1}, // Rock
        {HandState.Paper, 2}, // Paper
        {HandState.Scissors, 3} // Scissors
    };


    public async Task<int> DetermineScore()
    {
        var gameHands = await ReadGameHandsFromFile();
        var score = 0;
        foreach (var hand in gameHands)
        {
            var outcome = DetermineWinner(hand.PlayerChoice, hand.OpponentsChoice);
            score += _scoreTable[hand.PlayerChoice];
            switch (outcome)
            {
                case GameOutcome.Win:
                    score += WinScoreBonus;
                    break;
                case GameOutcome.Tie:
                    score += TieScoreBonus;
                    break;
            }
        }

        return score;
    }


    private static async Task<List<GameHand>> ReadGameHandsFromFile()
    {
        var gameHands = new List<GameHand>();
        var sr = new StreamReader(Environment.CurrentDirectory + "/input.txt");

        var line = await sr.ReadLineAsync();
        while (line != null)
        {
            var selections = line.Split(' ');
            // the first entry is the "opponents choice" second is the desired outcome
            gameHands.Add(new GameHand(selections[0][0],
                selections[1][0])); // a string is a char array hence the double "array selector"

            //Read the next line
            line = await sr.ReadLineAsync();
        }

        sr.Close();

        return gameHands;
    }


    private GameOutcome DetermineWinner(HandState player, HandState opponent)
    {
        // Get the scores for the players
        var score1 = _scoreTable[player];
        var score2 = _scoreTable[opponent];

        // Logic to determine the winner
        if (score1 == score2) return GameOutcome.Tie;

        if ((score1 == 1 && score2 == 3) || (score1 == 2 && score2 == 1) || (score1 == 3 && score2 == 2))
            return GameOutcome.Win;

        return GameOutcome.Loss;
    }
}
