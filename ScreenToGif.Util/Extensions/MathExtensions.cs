namespace ScreenToGif.Util.Extensions;

public static class MathExtensions
{
    #region Comparisons

    public static int DivisibleByTwo(this int number) => number % 2 == 0 ? number : number + 1;

    public static bool GreaterThan(this double a, double b, double epsilon = 0.00000153D)
    {
        return a > b && !NearlyEquals(a, b, epsilon);
    }

    public static bool SmallerThan(this double a, double b, double epsilon = 0.00000153D)
    {
        return a < b && !NearlyEquals(a, b, epsilon);
    }

    public static bool SmallerThanOrClose(this double a, double b, double epsilon = 0.00000153D)
    {
        return a < b || NearlyEquals(a, b, epsilon);
    }

    public static bool NearlyEquals(this double a, double b, double epsilon = 0.00000153D)
    {
        // ReSharper disable once CompareOfFloatsByEqualityOperator
        if (a == b)
            return true;

        var delta = a - b;

        return (delta < epsilon) && (delta > -epsilon);
    }

    public static bool NearlyEquals(this double a, int b, double epsilon = 0.00000153D)
    {
        // ReSharper disable once CompareOfFloatsByEqualityOperator
        if (a == b)
            return true;

        var delta = a - b;

        return (delta < epsilon) && (delta > -epsilon);
    }

    #endregion

    #region Calculations

    /// <summary>
    /// Gets the third value based on the other 2 parameters.
    /// Total       =   100 %
    /// Variable    =   percentage
    /// </summary>
    /// <returns>The value that was not filled.</returns>
    public static double CrossMultiplication(double? total, double? variable, double? percentage)
    {
        #region Validation

        //Only one of the parameters can bee null.
        var amount = (total.HasValue ? 0 : 1) + (variable.HasValue ? 0 : 1) + (percentage.HasValue ? 0 : 1);

        if (amount != 1)
            throw new ArgumentException("Only one of the parameters can bee null");

        #endregion

        if (!total.HasValue && percentage.HasValue && variable.HasValue)
            return (percentage.Value * 100d) / variable.Value;

        if (!percentage.HasValue && total.HasValue && variable.HasValue)
            return total is > 0 or < 0 ? (variable.Value * 100d) / total.Value : 0;

        if (!variable.HasValue && total.HasValue && percentage.HasValue)
            return (percentage.Value * total.Value) / 100d;

        return 0;
    }

    /// <summary>
    /// Gets the third value based on the other 2 parameters.
    /// Total       =   100 %
    /// Variable    =   percentage
    /// </summary>
    /// <returns>The value that was not filled.</returns>
    public static decimal CrossMultiplication(decimal? total, decimal? variable, decimal? percentage)
    {
        #region Validation

        //Only one of the parameters can bee null.
        var amount = (total.HasValue ? 0 : 1) + (variable.HasValue ? 0 : 1) + (percentage.HasValue ? 0 : 1);

        if (amount != 1)
            throw new ArgumentException("Only one of the parameters can bee null");

        #endregion

        if (!total.HasValue && percentage.HasValue && variable.HasValue)
            return (percentage.Value * 100m) / variable.Value;

        if (!percentage.HasValue && total.HasValue && variable.HasValue)
            return total is > 0 or < 0 ? (variable.Value * 100m) / total.Value : 0;

        if (!variable.HasValue && total.HasValue && percentage.HasValue)
            return (percentage.Value * total.Value) / 100m;

        return 0;
    }

    /// <summary>
    /// The Greater Common Divisor.
    /// </summary>
    public static double Gcd(double a, double b)
    {
        return b == 0 ? a : Gcd(b, a % b);
    }

    /// <summary>
    /// The Greater Common Divisor.
    /// </summary>
    public static decimal Gcd(decimal a, decimal b)
    {
        return b == 0 ? a : Gcd(b, a % b);
    }

    #endregion

    public static long PackLong(int left, int right) => (long)left << 32 | (uint)right;

    public static void UnpackLong(long value, out int left, out int right)
    {
        left = (int)(value >> 32);
        right = (int)(value & 0xffffffffL);
    }
    
    public static double RoundUpValue(double value, int decimalpoint = 0)
    {
        var result = Math.Round(value, decimalpoint);

        if (result < value)
            result += Math.Pow(10, -decimalpoint);

        return result;
    }
    
    /// <summary>
    /// Forces an integer to be between two values.
    /// </summary>
    public static int Clamp(this int value, int min, int max)
    {
        return (value <= min) ? min : (value >= max) ? max : value;
    }

    /// <summary>
    /// Forces a double to be between two values.
    /// </summary>
    public static double Clamp(this double value, double min, double max)
    {
        return (value <= min) ? min : (value >= max) ? max : value;
    }
}