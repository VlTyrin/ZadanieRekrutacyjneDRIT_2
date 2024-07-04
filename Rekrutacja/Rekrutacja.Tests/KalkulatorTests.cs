using NUnit.Framework;
using Rekrutacja.Enums;
using Rekrutacja.Kalkulator;
using System;

namespace Rekrutacja.Tests
{
    [TestFixture]
    public class KalkulatorTests
    {
        [Test]
        [TestCase(1, 1, 1)]
        [TestCase(3, -1, 9)]
        [TestCase(2.5, 52, 6)]
        [TestCase(2.6, 3, 7)]
        public void Kwadrat_Test(double a, double b, int expectedResult)
        {
            var actualResult = KalkulatorEngine.WykonajOpercje(Figura.Kwadrat, a, b);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(1, 2, 2)]
        [TestCase(2, 4, 8)]
        [TestCase(2.5, 4, 10)]
        [TestCase(7.1, 8.2, 58)]
        public void Prostokat_Test(double a, double b, int expectedResult)
        {
            var actualResult = KalkulatorEngine.WykonajOpercje(Figura.Prostokat, a, b);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(7, 8, 28)]
        [TestCase(3, 3, 5)]
        [TestCase(2.7, 4, 5)]
        [TestCase(5.7, 4.1, 12)]
        public void Trojkat_Test(double a, double b, int expectedResult)
        {
            var actualResult = KalkulatorEngine.WykonajOpercje(Figura.Trojkat, a, b);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(5, 0, 79)]
        [TestCase(3, 2, 28)]
        [TestCase(2.5, -1, 20)]
        [TestCase(7.1, 4.2, 158)]
        public void Kolo_Test(double a, double b, int expectedResult)
        {
            var actualResult = KalkulatorEngine.WykonajOpercje(Figura.Kolo, a, b);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase(Figura.Kwadrat, -1, 2)]
        [TestCase(Figura.Prostokat, -2, 3)]
        [TestCase(Figura.Prostokat, 2, -3)]
        [TestCase(Figura.Prostokat, -2, -3)]
        [TestCase(Figura.Trojkat, -2, 3)]
        [TestCase(Figura.Trojkat, 2.1, -3)]
        [TestCase(Figura.Trojkat, -2, -3)]
        [TestCase(Figura.Kolo, -1, 2)]
        public void WykonajOpercje_UjemneWymiary_Test(Figura figura, double a, double b)
        {
            Assert.Throws<ArgumentException>(() => KalkulatorEngine.WykonajOpercje(figura, a, b));
        }

        [Test]
        public void Nieprawidlowa_Figura_Test()
        {
            Assert.Throws<InvalidOperationException>(() => KalkulatorEngine.WykonajOpercje((Figura)10, 5, 3));
        }

        [Test]
        [TestCase(Figura.Kwadrat, 123456789123, 0)]
        [TestCase(Figura.Prostokat, 123456789, 123456789)]
        [TestCase(Figura.Trojkat, 123456789, 123456789)]
        [TestCase(Figura.Kolo, 123456789123, 0)]
        public void WykonajOpercje_Wynik_Wiekszy_Niz_Max_Int(Figura figura, double a, double b)
        {
            Assert.Throws<OverflowException>(() => KalkulatorEngine.WykonajOpercje(figura, a, b));
        }
    }
}
