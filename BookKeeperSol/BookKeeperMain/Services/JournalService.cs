using System;
using System.IO;
using System.Runtime.InteropServices;
using BookKeeperMain.bo;



namespace BookKeeperMain.Services
{
    class JournalService
    {


        public void DoAccounting(String filePath)
        {

            // Load data from the given file.
            StreamReader streamReader = null;
            Transaction[] transactions = new Transaction[100];
            int transactionCounter = 0;
            try
            {
                streamReader = new StreamReader(filePath);
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    string[] lineParts = line.Split(',');
                    Transaction transaction = new Transaction(
                        lineParts[0],
                        Convert.ToDecimal(lineParts[1]),
                        (TransactionType)Enum.Parse(typeof(TransactionType), lineParts[2])
                    );
                    transactions[transactionCounter] = transaction;
                    transactionCounter++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                    streamReader.Dispose();
                }
            }

            // Process data and do accounting.
            Journal journal = new Journal();
            journal.AddStartEntry(0, 0);
            for (int i = 0; i < transactionCounter; i++)
            {
                journal.AddEntry(transactions[i]);
            }
            journal.AddEndEntry();


            // Display results on the console.
            Console.Clear();
            Print("Description", "Amount", "EntryType", "CashCreditAmount", "CashDebitAmount", "CashBalance", "BankCreditAmount", "BankDebitAmount", "BankBalance");
            for (int i = 0; i < journal.entryCounter; i++)
            {
                Print(journal.entries[i].description,
                    $"{journal.entries[i].amount}",
                    $"{journal.entries[i].entryType}",
                    $"{journal.entries[i].cashCreditAmount}",
                    $"{journal.entries[i].cashDebitAmount}",
                    $"{journal.entries[i].cashBalance}",
                    $"{journal.entries[i].bankCreditAmount}",
                    $"{journal.entries[i].bankDebitAmount}",
                    $"{journal.entries[i].bankBalance}");
            }
            Console.ReadKey();

        }

        static void Print(params string[] texts)
        { 
            int width1 = 35;
            int width2 = 20;
            string split = " | ";
            string row = "";

            for(int i = 0; i < texts.Length; i++)
            {
                if (i == 0)
                {
                    row += texts[i].PadRight(width1) + split;
                }
                else
                {
                    row += texts[i].PadRight(width2) + split;
                }
            }
            Console.WriteLine(row);
        }
    }
}
