
namespace Functionality
{
    public class TrängselskattGBG
    {
        public static void RäknaTotalBelopp(string datumOchTidInput)
        {
            var passager = SkapaPassagerFrånInput(datumOchTidInput);
            passager.Sort((a, b) => a.tidpunkt.CompareTo(b.tidpunkt));

            int totalBelopp = BeräknaMaxBeloppPerTimme(passager);
            totalBelopp = KontrolleraDagligMaxgräns(totalBelopp);

            Console.WriteLine($"Totala avgiften är {totalBelopp} kr");
        }

        private static List<(DateTime tidpunkt, int belopp)> SkapaPassagerFrånInput(string datumOchTidInput)
        {
            var datumTider = datumOchTidInput.Split(',');
            var passager = new List<(DateTime tidpunkt, int belopp)>();

            foreach (var datumTidStr in datumTider)
            {
                var datumTid = datumTidStr.Trim();

                if (DateTime.TryParse(datumTid, out DateTime tidpunkt))
                {
                    int belopp = ÄrSkattefriDagEllerMånad(tidpunkt) ? 0 : BeräknaTrängselskatt(tidpunkt.Hour, tidpunkt.Minute);
                    passager.Add((tidpunkt, belopp));
                }
                else
                {
                    Console.WriteLine($"Ogiltigt datum och tid: {datumTid}");
                }
            }
            return passager;
        }

        private static int BeräknaMaxBeloppPerTimme(List<(DateTime tidpunkt, int belopp)> passager)
        {
            int totalBelopp = 0;
            int maxBeloppFörPeriod = 0;
            DateTime periodStart = passager[0].tidpunkt;

            foreach (var passage in passager)
            {
                if ((passage.tidpunkt - periodStart).TotalMinutes <= 60)
                {
                    maxBeloppFörPeriod = Math.Max(maxBeloppFörPeriod, passage.belopp);
                }
                else
                {
                    totalBelopp += maxBeloppFörPeriod;
                    periodStart = passage.tidpunkt;
                    maxBeloppFörPeriod = passage.belopp;
                }
            }

            totalBelopp += maxBeloppFörPeriod;
            return totalBelopp;
        }

        private static int BeräknaTrängselskatt(int timme, int minut)
        {
            return timme switch
            {
                6 => minut <= 29 ? 8 : 13,
                7 => 18,
                8 => minut <= 29 ? 13 : 8,
                >= 9 and <= 14 => 8,
                15 => minut <= 29 ? 13 : 18,
                16 => 18,
                17 => 13,
                18 => minut <= 29 ? 8 : 0,
                _ => 0
            };
        }

        private static int KontrolleraDagligMaxgräns(int belopp)
        {
            return belopp > 60 ? 60 : belopp;
        }

        private static bool ÄrSkattefriDagEllerMånad(DateTime datum)
        {
            return datum.DayOfWeek == DayOfWeek.Saturday ||
                   datum.DayOfWeek == DayOfWeek.Sunday ||
                   datum.Month == 7;
        }

    }

}
