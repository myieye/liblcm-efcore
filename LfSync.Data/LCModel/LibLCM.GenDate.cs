using System.Text;

namespace LfSync.Data.LCModel;

public struct GenDate : IEquatable<GenDate>, IComparable
{
    /// <summary>
    /// The unknown day value.
    /// </summary>
    public const int UnknownDay = 0;
    /// <summary>
    /// The unknown month value.
    /// </summary>
    public const int UnknownMonth = 0;
    /// <summary>
    /// The unknown year value.
    /// </summary>
    public const int UnknownYear = 0;
    /// <summary>
    /// The maximum year value.
    /// </summary>
    public const int MaxYear = 9999;
    /// <summary>
    /// The minimum year value
    /// </summary>
    public const int MinYear = 1;
    /// <summary>
    /// The maximum month value.
    /// </summary>
    public const int MaxMonth = 12;
    /// <summary>
    /// The minimum month value.
    /// </summary>
    public const int MinMonth = 1;
    /// <summary>
    /// The minimum day value.
    /// </summary>
    public const int MinDay = 1;
    /// <summary>
    /// An arbitrary leap year. Used to validate dates whose year is unknown, making Feb 29 valid.
    /// </summary>
    private const int LeapYear = 2008;

    /// <summary>
    /// The generic date precision types.
    /// </summary>
    public enum PrecisionType
    {
        /// <summary>
        /// Before
        /// </summary>
        Before = 0,
        /// <summary>
        /// Exact
        /// </summary>
        Exact = 1,
        /// <summary>
        /// Approximate
        /// </summary>
        Approximate = 2,
        /// <summary>
        /// After
        /// </summary>
        After = 3
    }

    private readonly int m_day;
    private readonly int m_month;
    private readonly int m_year;
    private readonly bool m_ad;
    private readonly PrecisionType m_precision;

    /// <summary>
    /// Initializes a new instance of the <see cref="GenDate"/> struct.
    /// </summary>
    /// <param name="precision">The precision.</param>
    /// <param name="month">The month.</param>
    /// <param name="day">The day.</param>
    /// <param name="year">The year.</param>
    /// <param name="ad">if set to <c>true</c> the date is AD, otherwise it is BC.</param>
    public GenDate(PrecisionType precision, int month, int day, int year, bool ad)
    {

        var badPart = ValidateParts(month, day, year, ad);
        if (badPart != null)
            throw new ArgumentOutOfRangeException(badPart);

        m_precision = precision;
        m_month = month;
        m_day = day;
        m_year = year;
        m_ad = ad;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="GenDate"/> struct.
    /// </summary>
    /// <param name="nVal">integer storage representation of a GenDate value</param>
    /// <remarks>
    /// Representing GenDate values as an integer is an artifact of its being stored in SQL databases
    /// in an earlier incarnation of FieldWorks.  But we're still using integers to persist GenDates.
    /// </remarks>
    public GenDate(int nVal)
    {
        m_ad = true;
        if (nVal < 0)
        {
            m_ad = false;
            nVal = -nVal;
        }
        m_precision = (GenDate.PrecisionType)(nVal % 10);
        nVal /= 10;
        m_day = nVal % 100;
        nVal /= 100;
        m_month = nVal % 100;
        m_year = nVal / 100;
    }

    /// <summary>
    /// Convert a GenDate back into the corresponding integer value.
    /// </summary>
    public int ToInt()
    {
        int nVal = m_year;
        nVal = (nVal * 100) + m_month;
        nVal = (nVal * 100) + m_day;
        nVal = (nVal * 10) + (int)m_precision;
        return m_ad ? nVal : -nVal;
    }

    /// <summary>
    /// If the specified arguments will make a valid GenDate, return null. Otherwise return the name of the bad parameter.
    /// </summary>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <param name="year"></param>
    /// <param name="ad"></param>
    /// <returns></returns>
    public static string ValidateParts(int month, int day, int year, bool ad)
    {
        if (year != UnknownYear && (year < MinYear || year > MaxYear))
            return "year";

        if (month != UnknownMonth && (!ad || month < MinMonth || month > MaxMonth))
            return "month";

        if (day != UnknownDay && (!ad || month == UnknownMonth
            || day < MinDay || day > DateTime.DaysInMonth(year == UnknownYear ? LeapYear : year, month)))
            return "day";
        return null; // all is well.
    }

    /// <summary>
    /// Gets the precision.
    /// </summary>
    /// <value>The precision.</value>
    public PrecisionType Precision
    {
        get
        {
            return m_precision;
        }
    }

    /// <summary>
    /// Gets the month.
    /// </summary>
    /// <value>The month.</value>
    public int Month
    {
        get
        {
            return m_month;
        }
    }

    /// <summary>
    /// Gets the day.
    /// </summary>
    /// <value>The day.</value>
    public int Day
    {
        get
        {
            return m_day;
        }
    }

    /// <summary>
    /// Gets the year.
    /// </summary>
    /// <value>The year.</value>
    public int Year
    {
        get
        {
            return m_year;
        }
    }

    /// <summary>
    /// Gets a value indicating whether the date is AD or BC.
    /// </summary>
    /// <value><c>true</c> if the year is AD; otherwise, the year is BC.</value>
    public bool IsAD
    {
        get
        {
            return m_ad;
        }
    }

    /// <summary>
    /// Gets a value indicating whether this instance represents an empty generic date.
    /// </summary>
    /// <value><c>true</c> if this instance is empty; otherwise, <c>false</c>.</value>
    public bool IsEmpty
    {
        get
        {
            return m_year == UnknownYear && m_month == UnknownMonth && m_day == UnknownDay;
        }
    }

    private DateTime Date
    {
        get
        {
            return new DateTime(m_year == UnknownYear ? 1 : m_year, m_month == UnknownMonth ? 1 : m_month,
                m_day == UnknownDay ? 1 : m_day);
        }
    }

    private static string[] GetMonthNames()
    {
        // The code that you think would work throws an exception for 'en' (and
        // presumably other semi-generic language/culture tags):
        // string[] monthNames = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
        // So we have to trick it into giving us the desired information.
        List<string> monthNames = new List<string>(12);
        for (int m = 1; m <= 12; ++m)
        {
            DateTime dt = new DateTime(2010, m, 1);
            string month = dt.ToString("MMMM");
            monthNames.Add(month);
        }
        return monthNames.ToArray();
    }

    /// <summary>
    /// Indicates whether the current generic date is equal to another generic date.
    /// </summary>
    /// <param name="other">A generic date to compare with this generic date.</param>
    /// <returns>
    /// true if the current generic date is equal to the <paramref name="other"/> parameter; otherwise, false.
    /// </returns>
    public override bool Equals(object other)
    {
        if (!(other is GenDate))
            return false;
        return Equals((GenDate)other);
    }

    /// <summary>
    /// Indicates whether the current generic date is equal to another generic date.
    /// </summary>
    /// <param name="other">A generic date to compare with this generic date.</param>
    /// <returns>
    /// true if the current generic date is equal to the <paramref name="other"/> parameter; otherwise, false.
    /// </returns>
    public bool Equals(GenDate other)
    {
        if (IsEmpty && other.IsEmpty)
            return true;

        return CompareTo(other) == 0;
    }

    /// <summary>
    /// Compares to.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns></returns>
    public int CompareTo(object other)
    {
        if (!(other is GenDate))
            throw new ArgumentException();
        return CompareTo((GenDate)other);
    }

    /// <summary>
    /// Implements the operator ==.
    /// </summary>
    /// <param name="g1">The first generic date.</param>
    /// <param name="g2">The second generic date.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator ==(GenDate g1, GenDate g2)
    {
        return g1.Equals(g2);
    }

    /// <summary>
    /// Implements the operator !=.
    /// </summary>
    /// <param name="g1">The first generic date.</param>
    /// <param name="g2">The second generic date.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator !=(GenDate g1, GenDate g2)
    {
        return !g1.Equals(g2);
    }

    /// <summary>
    /// Implements the operator &gt;.
    /// </summary>
    /// <param name="g1">The first generic date.</param>
    /// <param name="g2">The second generic date.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator >(GenDate g1, GenDate g2)
    {
        return g1.CompareTo(g2) > 0;
    }

    /// <summary>
    /// Implements the operator &gt;=.
    /// </summary>
    /// <param name="g1">The first generic date.</param>
    /// <param name="g2">The second generic date.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator >=(GenDate g1, GenDate g2)
    {
        return g1.CompareTo(g2) >= 0;
    }

    /// <summary>
    /// Implements the operator &lt;.
    /// </summary>
    /// <param name="g1">The first generic date.</param>
    /// <param name="g2">The second generic date.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator <(GenDate g1, GenDate g2)
    {
        return g1.CompareTo(g2) < 0;
    }

    /// <summary>
    /// Implements the operator &lt;=.
    /// </summary>
    /// <param name="g1">The first generic date.</param>
    /// <param name="g2">The second generic date.</param>
    /// <returns>The result of the operator.</returns>
    public static bool operator <=(GenDate g1, GenDate g2)
    {
        return g1.CompareTo(g2) <= 0;
    }

    /// <summary>
    /// Loads a standard GenDate integer from the string.
    /// </summary>
    /// <param name="genDateStr"></param>
    /// <returns></returns>
    public static GenDate LoadFromString(string genDateStr)
    {
        if (!string.IsNullOrEmpty(genDateStr) && Convert.ToInt32(genDateStr) != 0)
        {
            var ad = true;
            if (genDateStr.StartsWith("-"))
            {
                ad = false;
                genDateStr = genDateStr.Substring(1);
            }
            genDateStr = genDateStr.PadLeft(9, '0');
            var year = Convert.ToInt32(genDateStr.Substring(0, 4));
            var month = Convert.ToInt32(genDateStr.Substring(4, 2));
            var day = Convert.ToInt32(genDateStr.Substring(6, 2));
            var precision = (PrecisionType)Convert.ToInt32(genDateStr.Substring(8, 1));
            return new GenDate(precision, month, day, year, ad);
        }

        return new GenDate();
    }
}
