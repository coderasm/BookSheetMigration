using AsyncPoco;

namespace BookSheetMigration
{
    [TableName(Settings.ABSBookSheetTransactionTable)]
    [PrimaryKey("EventId, TransactionId", autoIncrement = false)]
    public class AbsTransactionSellingDealerDTO
    {
        [Column("EventId")]
        public int eventId { get; set; }

        [Column("TransactionId")]
        public int transactionId { get; set; }

        [Column("SellerDmvNumber")]
        public string sellerNumber { get; set; }

        [Column("SellerDealerId")]
        public string sellerDealerId { get; set; }

        [Column("SellerCompanyName")]
        public string sellerCompanyName { get; set; }

        [Column("SellerFirstName")]
        public string sellerFirstName { get; set; }

        [Column("SellerLastName")]
        public string sellerLastName { get; set; }
    }
}
