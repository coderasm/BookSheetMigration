using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookSheetMigration;

namespace BookSheetMigration.Test
{
    [TestClass]
    public class TransactionUpdaterTest
    {
        [TestMethod]
        [Ignore]
        public void WhenSingleDealerMatched_ThenSaveItsInformation()
        {
            AWGTransactionDTO transaction = new AWGTransactionDTO();
            TransactionSellerDealerIdMatcher transactionSellerDealerIdMatcher = new TransactionSellerDealerIdMatcher(transaction);
            transactionSellerDealerIdMatcher.matchAndInsertIds();
        }
    }
}
