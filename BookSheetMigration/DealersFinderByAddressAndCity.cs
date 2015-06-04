using System.Text.RegularExpressions;

namespace BookSheetMigration
{
    class DealersFinderByAddressAndCity : DealersFinder
    {
        private const string queryPart = " AND c1.ADDRESS1 LIKE '%{0}%' AND c1.CITY LIKE '%{1}%'";
        private static string streetNumber = "";
        private static string cleanedCity = "";

        public DealersFinderByAddressAndCity(string streetAddress, string city) : base(returnFilledQueryPart(queryPart, streetNumber, cleanedCity))
        {
            streetNumber = cleanAndReturnStreetNumber(streetAddress);
            cleanedCity = city.Trim();
        }

        private static string cleanAndReturnStreetNumber(string address)
        {
            var addressOnlyWordCharacters = Regex.Replace(address, "[^\\w\\s]", "");
            var addressParts = addressOnlyWordCharacters.Split(' ');
            var streetNumber = addressParts[0].Trim();
            return streetNumber;
        }
    }
}
