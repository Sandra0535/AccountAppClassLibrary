//using AccountAppInModularWay.Exceptions;
//using AccountAppInModularWay.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AccountAppClassLibrary.Service
{
    public class AccountManager
    {
        private Account account;
        private DataSerializer serializer;
        public bool AccountCreated { get; private set; }
        public AccountManager()
        {
            serializer = new DataSerializer(@"C:\Users\acer\Documents\AccountAppWithClassLibrary.txt");
            object deserializedObject = serializer.Deserialize();
            if (deserializedObject is Account acc)
            {
                //Console.WriteLine(AccountController.WelcomeBack(acc));
                Console.WriteLine(WelcomeBack(acc));
                account = acc;
                AccountCreated = true;
            }
        }
        public void CreateAccount(int accountNo, string accountHolderName, string bankName, double openingBalance)
        {
            account = new Account(accountNo, accountHolderName, bankName, openingBalance);
            AccountCreated = true;
        }
        public string Deposit(double depositAmount)
        {
            account.Balance += depositAmount;
            return "Amount Deposited Successfully";
        }
        public string Withdraw(double withdrawAmount)
        {
            if (account.Balance - withdrawAmount >= account.OpeningBalance)
            {
                account.Balance -= withdrawAmount;
                return "Amount Withdrawn successfully";
            }
            //else
            //{
                throw new InsufficientBalanceException($"Minimum balance of Rs{account.OpeningBalance} should be" +
                    $" maintained..Withdraw denied");
            //}
            //else
            //{
            //    return "Insufficient balance";
            //}
        }
        public string CheckBalance( )
        {
            if (account == null)
            {
                Console.WriteLine("Account not initialized.");
                return "";
            }

            return $"Account balance is {account.Balance}";
        }
        public void SerializeAccount()
        {
            if (account != null)
            {
                serializer.Serialize(account);
            }
        }
        private string WelcomeBack(Account acc)
        {
            return $"Welcome Back!\nAccount Holder name: {acc.AccountHolderName}\nAccount balance is {acc.Balance}";
        }
    }
}
