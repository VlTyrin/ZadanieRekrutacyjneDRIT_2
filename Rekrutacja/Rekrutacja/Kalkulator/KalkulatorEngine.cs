using Rekrutacja.Enums;
using System;

namespace Rekrutacja.Kalkulator
{
    public static class KalkulatorEngine
    {
        public static int WykonajOpercje(Figura figura, double a, double b)
        {
            WalidujParametry(figura, a, b);

            double wynik;
            switch (figura)
            {
                case Figura.Kwadrat:
                    wynik = a * a;
                    break;
                case Figura.Prostokat:
                    wynik = a * b;
                    break;
                case Figura.Trojkat:
                    wynik = 0.5 * a * b;
                    break;
                case Figura.Kolo:
                    wynik = Math.PI * a * a;
                    break;
                default:
                    throw new InvalidOperationException("Nieprawidłowa figura.");
            }

            return KonwertujWalidujWynik(wynik);
        }

        private static void WalidujParametry(Figura figura, double a, double b)
        {
            if (a < 0 || (figura == Figura.Prostokat || figura == Figura.Trojkat) && b < 0)
            {
                throw new ArgumentException("Wymiary nie mogą być ujemne.");
            }
        }

        private static int KonwertujWalidujWynik(double wynik)
        {
            if (wynik > int.MaxValue)
            {
                throw new OverflowException("Wynik operacji wykracza poza zakres wartości typu int.");
            }

            return (int)Math.Round(wynik, MidpointRounding.AwayFromZero);
        }
    }
}
