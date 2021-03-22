using System;

namespace BookKeeperMain.bo
{
    public class Transaction
    {
        public string description;
        public decimal amount;
        public TransactionType transactionType;

        public Transaction(string description, decimal amount, TransactionType transactionType)
        {
            this.description = description;
            this.amount = amount;
            this.transactionType = transactionType;
        }
    }
}
