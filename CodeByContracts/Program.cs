using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeByContracts {
    class Program {
        static void Main(string[] args) {
            Account account = new Account("Roberts Konto", 18);

            account.Withdraw(20);

            Console.WriteLine("Account Balance: {0}", account.Balance);
            Console.ReadKey();
        }
    }
}
