using System;

namespace BookKeeperMain.bo
{
    public class Journal
    {
        public const int MaxNumberOfEntries = 100;
        public AccountingEntry[] entries;
        public int entryCounter;

        public Journal()
        {
            this.entries = new AccountingEntry[MaxNumberOfEntries];
            this.entryCounter = 0;
        }

        public void AddEntry(Transaction transaction)
        {
            AccountingEntry accountingEntry = new AccountingEntry();
            accountingEntry.description = transaction.description;
            accountingEntry.amount = transaction.amount;
            switch (transaction.transactionType)
            {

                case TransactionType.Cash:
                    if (transaction.amount >= 0)
                    {
                        accountingEntry.entryType = EntryType.CashCredit;
                        accountingEntry.cashCreditAmount = transaction.amount;
                    }
                    else
                    {
                        accountingEntry.entryType = EntryType.CashDebit;
                        accountingEntry.cashDebitAmount = transaction.amount;
                    }
                    accountingEntry.cashBalance = this.getLastCashBalance() + transaction.amount;
                    break;

                case TransactionType.Bank:
                    if (transaction.amount >= 0)
                    {
                        accountingEntry.entryType = EntryType.BankCredit;
                        accountingEntry.bankCreditAmount = transaction.amount;
                    }
                    else
                    {
                        accountingEntry.entryType = EntryType.BankDebit;
                        accountingEntry.bankDebitAmount = transaction.amount;
                    }
                    accountingEntry.bankBalance = this.getLastBankBalance() + transaction.amount;
                    break;

            }
            this.entries[this.entryCounter++] = accountingEntry;
        }

        public void AddStartEntry(decimal startCashBalance, decimal startBankBalance)
        {
            AccountingEntry accountingEntry = new AccountingEntry();
            accountingEntry.description = "Počáteční zůstatek";
            accountingEntry.amount = null;
            accountingEntry.entryType = EntryType.StartBalance;

            accountingEntry.cashCreditAmount = null;
            accountingEntry.cashDebitAmount = null;
            accountingEntry.cashBalance = startCashBalance;

            accountingEntry.bankCreditAmount = null;
            accountingEntry.bankDebitAmount = null;
            accountingEntry.bankBalance = startBankBalance;
            this.entries[this.entryCounter++] = accountingEntry;
        }

        public void AddEndEntry()
        {
            AccountingEntry accountingEntry = new AccountingEntry();
            accountingEntry.description = "Konečný zůstatek";
            accountingEntry.amount = null;
            accountingEntry.entryType = EntryType.EndBalance;

            accountingEntry.cashCreditAmount = null;
            accountingEntry.cashDebitAmount = null;
            accountingEntry.cashBalance = this.getLastCashBalance();

            accountingEntry.bankCreditAmount = null;
            accountingEntry.bankDebitAmount = null;
            accountingEntry.bankBalance = this.getLastBankBalance();
            this.entries[this.entryCounter++] = accountingEntry;
        }

        private decimal getLastCashBalance()
        {
            for (int i = this.entryCounter - 1; i >= 0; i--)
            {
                if (this.entries[i].cashBalance.HasValue)
                {
                    return this.entries[i].cashBalance.Value;
                }
            }
            return 0;
        }

        private decimal getLastBankBalance()
        {
            for (int i = this.entryCounter - 1; i >= 0; i--)
            {
                if (this.entries[i].bankBalance.HasValue)
                {
                    return this.entries[i].bankBalance.Value;
                }
            }
            return 0;
        }
    }
}
