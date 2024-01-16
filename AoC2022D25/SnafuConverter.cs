using System.Text;

namespace AoC2022D25;

public class SnafuConverter
{
    private readonly Dictionary<char, int> _snafuValues = new()
    {
        {'2',2},
        {'1', 1},
        {'0',0},
        {'-',-1},
        {'=',-2}
    };

    public long ConvertSnafuToDecimal(string snafu)
    {
        long total = 0;
        for (var i = 0; i < snafu.Length; i++)
        {
            // -1 as the "base" position doesn't need a multiplier hence everything shifts by 1
            // second part of the expression refers to the multiplier. pos 3 f.e. X25
            total += _snafuValues[snafu[i]] * (long) Math.Pow(5, snafu.Length -i -1); // whoops it kept overflowing here as we used int instead of long.
        }

        return total;
    }
    
    // Example for future me:
    // remainder 3 = and increment following number.
    // remainder 4 - and increment following number.
    // remainder anything else number representation
    // https://www.youtube.com/watch?v=F4l_aDCdOgY
    public string ConvertDecimalToSnafu(long decimalNumber)
    {   
        var snafu = new StringBuilder();
        while(decimalNumber != 0)
        {
            // This remainder represents the value of the digit in the Snafu system.
            var remainder = decimalNumber % 5;
            decimalNumber /= 5; // this does the "raw" conversion to base 5 let's us know the "leftover" for the next step.

            if (remainder > 2) // remainder is too big outside of base 5 system.
            {
                remainder -= 5;
                decimalNumber++; // we "carry the 1" only instead of carrying it we borrow it from the next quotient.
            }

            var snafuDigit = _snafuValues.First(x => x.Value == remainder).Key;
            snafu.Insert(0, snafuDigit);
        }
        return snafu.ToString();
    }
}
