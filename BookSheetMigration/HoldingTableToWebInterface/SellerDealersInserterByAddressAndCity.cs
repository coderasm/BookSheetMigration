﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookSheetMigration.HoldingTableToWebInterface
{
    class SellerDealersInserterByAddressAndCity : CollectionInserter<DealerDTO>
    {
        public SellerDealersInserterByAddressAndCity(AWGTransactionDTO transaction)
        {
            this.transaction = transaction;
        }

        protected override bool entityArguemntsExist()
        {
            return transaction.sellerAddress != null && transaction.sellerCity != null;
        }

        protected override object[] getEntityArguments()
        {
            return new object[]
            {
                transaction.sellerAddress,
                transaction.sellerCity
            };
        }

        protected override async Task<List<DealerDTO>> findEntities(params object[] entityArguments)
        {
            var entitiesFinder = new DealersFinderByAddressAndCity((string)entityArguments[0], (string)entityArguments[1]);
            return await entitiesFinder.find();
        }

        protected override void setPossibleCollection(List<DealerDTO> entity)
        {
            transaction.buyers = entity;
        }
    }
}
