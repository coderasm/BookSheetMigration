using AsyncPoco;

namespace BookSheetMigration
{
    public class DealerDTO
    {
        [Column("ACCOUNTNO")]
        public string dealerId { get; set; }

        [Column("COMPANY")]
        public string companyName { get; set; }
    }
}