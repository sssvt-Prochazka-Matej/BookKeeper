using System;

namespace BookKeeperMain.bo
{
    public class AccountingEntry
    {
        public string description;
        public decimal? amount;
        public EntryType entryType;
        public decimal? cashCreditAmount;
        public decimal? cashDebitAmount;
        public decimal? cashBalance;
        public decimal? bankCreditAmount;
        public decimal? bankDebitAmount;
        public decimal? bankBalance;
    }
}
