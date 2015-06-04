namespace BookSheetMigration.AwgToHoldingTable
{
    public class DealersFinderByDmvNumber : DealersFinder
    {
        private const string queryPart = " AND c1.UDMVNUM LIKE '%{0}%'";

        public DealersFinderByDmvNumber(string dmvNumber) : base(dmvNumber, queryPart)
        {
        }
    }
}
