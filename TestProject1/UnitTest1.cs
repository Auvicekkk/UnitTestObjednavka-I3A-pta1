using ObjednavkaProjekt.Třídy;
using Xunit;

namespace ObjednavkaTesty
{
    public class ObjednavkaTesty
    {
        [Theory]
        [InlineData(1000, 0, 99)]   // Doprava 0, cena pod 1500 -> doprava 99
        [InlineData(1500, 0, 0)]    // Doprava 0, cena 1500 a více -> doprava 0
        [InlineData(3000, 1, 199)]  // Doprava 1 -> doprava 199
        [InlineData(500, 2, 0)]     // Jiný typ dopravy -> doprava 0
        public void VypocitejDopravu_Test(decimal cenaZbozi, int typDopravy, decimal ocekavanaDoprava)
        {
            var objednavka = new Objednavka(cenaZbozi, typDopravy);
            Assert.Equal(ocekavanaDoprava, objednavka.VypocitejDopravu());
        }

        [Theory]
        [InlineData(1999, 0)]       // Cena pod 2000 -> sleva 0
        [InlineData(2000, 100)]     // Cena 2000-4999 -> sleva 5 % (100)
        [InlineData(5000, 500)]     // Cena 5000 a více -> sleva 10 % (500)
        public void VypocitejSlevu_Test(decimal cenaZbozi, decimal ocekavanaSleva)
        {
            var objednavka = new Objednavka(cenaZbozi, 0);
            Assert.Equal(ocekavanaSleva, objednavka.VypocitejSlevu());
        }

        [Theory]
        [InlineData(1000, 0, 1099)] // 1000 - 0 + 99 = 1099
        [InlineData(6000, 0, 5400)] // 6000 - 600 + 0 = 5400
        public void VypocitejCelkem_Test(decimal cenaZbozi, int typDopravy, decimal ocekavanaCelkem)
        {
            var objednavka = new Objednavka(cenaZbozi, typDopravy);
            Assert.Equal(ocekavanaCelkem, objednavka.VypocitejCelkem());
        }
    }
}