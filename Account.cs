using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountAppClassLibrary
{
    [Serializable]
    public class Account
    {
        private int _accountNo;
        private string _accountHolderName;
        private string _bankName;
        private double _balance;

        public int AccountNo { get { return _accountNo; } set { _accountNo = value; } }
        public string AccountHolderName { get { return _accountHolderName; } set { _accountHolderName = value; } }
        public string BankName { get { return _bankName; } set { _bankName = value; } }
        public double Balance { get { return _balance; } set { _balance = value; } }

        public double OpeningBalance { get; internal set; }

        public Account() { }
        public Account(int accountNo, string accountHolderName, string bankName, double balance)
        {
            _accountNo = accountNo;
            _accountHolderName = accountHolderName;
            _bankName = bankName;
            _balance = balance;
        }
    }
}
