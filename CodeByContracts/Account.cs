using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace CodeByContracts {
    class Account {

        public string Name { get; set; }

        public double Balance { get; set; }

        public Account(string name, double balance) {
            this.Name = name;
            this.Balance = balance;
        }
        
        [ContractInvariantMethod]
        private void ObjectInvariant() {
            Contract.Invariant(Balance >= 0);
            Contract.Invariant(!String.IsNullOrWhiteSpace(Name));
        }
        
        [ContractAbbreviator]
        private void TransactionRules(double amount) {
            Contract.Requires(amount > 0, "Amount should be positive.");
            Contract.Requires<ArgumentException>(amount > 0, "Exception");
        }

        public double Withdraw(double amount) {
            Contract.Ensures(Contract.Result<double>() < Contract.OldValue(Balance));
            TransactionRules(amount);
            
            return Balance -= amount;
        } 


        public double Deposit(double amount) {
            Contract.Ensures(Contract.Result<double>() > Contract.OldValue(Balance));
            TransactionRules(amount);
            
            return Balance += amount;
        }



    }
}
