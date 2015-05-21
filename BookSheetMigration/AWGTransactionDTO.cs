using System;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using AsyncPoco;

namespace BookSheetMigration
{
    [TableName(Settings.ABSBookSheetTransactionTable)]
    [PrimaryKey("EventId, TransactionId", autoIncrement = false)]
    public class AWGTransactionDTO
    {
        public AWGTransactionDTO()
        {
            soldDate = DateTime.Now;
        }

        [Column("EventId")]
        public int eventId { get; set; }

        [XmlElement("TransactionId")]
        [Column("TransactionId")]
        public int transactionId { get; set; }

        [XmlElement("Amount")]
        [Column("BidAmount")]
        public decimal bidAmount { get; set; }

        [XmlIgnore]
        [Column("SoldDate")]
        public DateTime soldDate { get; set; }

        [XmlElement("SellerNumber")]
        [Column("SellerDmvNumber")]
        public string sellerNumber { get; set; }

        [Column("SellerDealerId")]
        public string sellerDealerId { get; set; }

        [XmlElement("SellerDealerName")]
        [Column("SellerCompanyName")]
        public string sellerCompanyName { get; set; }

        [XmlElement("SellerFirstName")]
        [Column("SellerFirstName")]
        public string sellerFirstName { get; set; }

        [XmlElement("SellerLastName")]
        [Column("SellerLastName")]
        public string sellerLastName { get; set; }

        [XmlElement("SellerAddress")]
        [Column("SellerAddress")]
        public string sellerAddress { get; set; }

        [XmlElement("SellerCity")]
        [Column("SellerCity")]
        public string sellerCity { get; set; }

        [XmlElement("SellerState")]
        [Column("SellerState")]
        public string sellerState { get; set; }

        [XmlElement("SellerZip")]
        [Column("SellerZip")]
        public string sellerZip { get; set; }

        private string sellersPhone = "";

        [XmlElement("SellerPhone")]
        [Column("SellerPhone")]
        public string sellerPhone {
            get
            {
                return sellersPhone;
            }
            set
            {
                sellersPhone = returnOnlyNumbers(value);
            }
        }

        [XmlElement("BuyerNumber")]
        [Column("BuyerDmvNumber")]
        public string buyerNumber { get; set; }

        [Column("BuyerDealerId")]
        public string buyerDealerId { get; set; }

        [Column("BuyerContactId")]
        public string buyerContactId { get; set; }

        [XmlElement("BuyerDealerName")]
        [Column("BuyerCompanyName")]
        public string buyerCompanyName { get; set; }

        [XmlElement("BuyerFirstName")]
        [Column("BuyerFirstName")]
        public string buyerFirstName { get; set; }

        [XmlElement("BuyerLastName")]
        [Column("BuyerLastName")]
        public string buyerLastName { get; set; }

        [XmlElement("BuyerAddress")]
        [Column("BuyerAddress")]
        public string buyerAddress { get; set; }

        [XmlElement("BuyerCity")]
        [Column("BuyerCity")]
        public string buyerCity { get; set; }

        [XmlElement("BuyerState")]
        [Column("BuyerState")]
        public string buyerState { get; set; }

        [XmlElement("BuyerZip")]
        [Column("BuyerZip")]
        public string buyerZip { get; set; }

        private string buyersPhone = "";

        [XmlElement("BuyerPhone")]
        [Column("BuyerPhone")]
        public string buyerPhone {
            get
            {
                return buyersPhone;
            }
            set
            {
                buyersPhone = returnOnlyNumbers(value);
            }
        }

        private static string returnOnlyNumbers(string uncleaned)
        {
            return Regex.Replace(uncleaned, @"[^\d]", "");
        }

        [XmlElement("Mileage")]
        [Column("Mileage")]
        public int mileage { get; set; }

        [XmlElement("VIN")]
        [Column("VIN")]
        public string vin { get; set; }

        [XmlElement("VehicleYear")]
        [Column("VehicleYear")]
        public string year { get; set; }

        [XmlElement("Make")]
        [Column("Make")]
        public string make { get; set; }

        [XmlElement("Model")]
        [Column("Model")]
        public string model { get; set; }

        [XmlElement("OtherCharges")]
        [Column("TransportFee")]
        public decimal transportFee { get; set; }

        public override bool Equals(object obj)
        {
            AWGTransactionDTO transactionDto = obj as AWGTransactionDTO;
            if (transactionDto == null)
                return false;
            return eventId == transactionDto.eventId && transactionId == transactionDto.transactionId;
        }

        public bool Equals(AWGTransactionDTO transactionDto)
        {
            if (transactionDto == null)
                return false;
            return eventId == transactionDto.eventId && transactionId == transactionDto.transactionId;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
