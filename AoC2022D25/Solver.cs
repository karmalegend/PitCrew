namespace AoC2022D25;

public class Solver
{
    public async Task<string> CalculateSnafuFuel()
    {
        var converter = new SnafuConverter();
        
        var snafus = await ReadSnafuFile();
        var totalFuelInDecimal = snafus.Select(x => converter.ConvertSnafuToDecimal(x)).Sum();
        return converter.ConvertDecimalToSnafu(totalFuelInDecimal);
    }

    private static async Task<IEnumerable<string>> ReadSnafuFile()
    {
        var snafuNumbers = new List<string>();
        
        var sr = new StreamReader(Environment.CurrentDirectory + "/input.txt");
        var line = await sr.ReadLineAsync();
        while (line != null)
        {
            snafuNumbers.Add(line);
            //Read the next line
            line = await sr.ReadLineAsync();
        }

        sr.Close();
        return snafuNumbers;
    }
}
