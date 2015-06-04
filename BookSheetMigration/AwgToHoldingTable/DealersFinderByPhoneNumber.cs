namespace BookSheetMigration.AwgToHoldingTable
{
    class DealersFinderByPhoneNumber : DealersFinder
    {
        private const string queryPart = " AND c1.PHONE1 LIKE '%{0}%'";

        public DealersFinderByPhoneNumber(string phoneNumber) : base(phoneNumber, queryPart)
        {
        }
    }
}
