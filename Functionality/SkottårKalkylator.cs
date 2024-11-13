using System.Globalization;

namespace Functionality
{
    public class SkottårKalkylator
    {
        public bool ÄrSkottår(int år)
        {
            return (år % 400 == 0) || (år % 4 == 0 && år % 100 != 0);
        }

        public int FåDagNummer(DateTime datum)
        {
            return datum.DayOfYear;
        }

        public int FåVeckoNummer(DateTime datum)
        {
            Calendar kalender = CultureInfo.InvariantCulture.Calendar;

            int vecka = kalender.GetWeekOfYear(datum, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

            return vecka;
        }

        public string FåVeckoDag(DateTime datum)
        {
            return datum.DayOfWeek.ToString();
        }
    }

}
