using System;
using System.Xml.Serialization;

namespace BookSheetMigration
{
    public class AWGTransactionDTO
    {
        [XmlElement("SellerNumber")]
        public string sellerNumber;

        [XmlElement("SellerDealerName")]
        public string sellerCompanyName;

        [XmlElement("SellerFirstName")]
        public string sellerFirstName;

        [XmlElement("SellerLastName")]
        public string sellerLastName;

        [XmlElement("SellerAddress")]
        public string sellerAddress;

        [XmlElement("SellerCity")]
        public string sellerCity;

        [XmlElement("SellerState")]
        public string sellerState;

        [XmlElement("SellerZip")]
        public string sellerZip;

        [XmlElement("SellerPhone")]
        public string sellerPhone;

        [XmlElement("BuyerNumber")]
        public string buyerNumber;

        [XmlElement("BuyerDealerName")]
        public string buyerCompanyName;

        [XmlElement("BuyerFirstName")]
        public string buyerFirstName;

        [XmlElement("BuyerLastName")]
        public string buyerLastName;

        [XmlElement("BuyerAddress")]
        public string buyerAddress;

        [XmlElement("BuyerCity")]
        public string buyerCity;

        [XmlElement("BuyerState")]
        public string buyerState;

        [XmlElement("BuyerZip")]
        public string buyerZip;

        [XmlElement("BuyerPhone")]
        public string buyerPhone;

        [XmlElement("Mileage")]
        public string mileage;

        [XmlElement("VIN")]
        public string vin;

        [XmlElement("VehicleYear")]
        public string year;

        [XmlElement("Make")]
        public string make;

        [XmlElement("Model")]
        public string model;

        [XmlElement("OtherCharges")]
        public string transportFee;

        [XmlElement("BuyFee")]
        public string buyFee;

        [XmlElement("SellFee")]
        public string sellFee;

        [XmlElement("DocumentFee")]
        public string documentFee;

        [XmlElement("LastChanged")]
        public DateTime lastChanged;
    }
}
