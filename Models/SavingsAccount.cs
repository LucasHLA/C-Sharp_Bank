using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpBank.Models
{
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(Owner accountOwner) : base(accountOwner)
        {
        }

        public SavingsAccount(Owner accountOwner, double openingBalance) : base(accountOwner, openingBalance)
        {
        }
            public override void PrintExtract()
        {
            Console.WriteLine("*******************************");
            Console.WriteLine("**********Savings Account**********");
            Console.WriteLine("*******************************");
            Console.WriteLine();

            System.Console.WriteLine("Generated in: "+DateTime.Now);
            Console.WriteLine();

            foreach(var transition in Transitions)
            {
                System.Console.WriteLine(transition.ToString());
            }
            System.Console.WriteLine("Your Balance: "+balance);
            System.Console.WriteLine("Your Overdraft: R$ "+overdraft);
            Console.WriteLine();
            
            Console.WriteLine("*******************************");
            Console.WriteLine("**********End of Extract**********");
            Console.WriteLine("*******************************");
            Console.WriteLine();
        }
        }
    }
