namespace CSharpBank.Models
{
    public class CheckingAccount : BankAccount
    {
        public CheckingAccount(Owner accountOwner) : base(accountOwner)
        {
        }

        public CheckingAccount(Owner accountOwner, double openingBalance) : base(accountOwner, openingBalance)
        {
        }

        public override void PrintExtract()
        {
            Console.WriteLine("*******************************");
            Console.WriteLine("**********Checking Account**********");
            Console.WriteLine("*******************************");
            Console.WriteLine();

            System.Console.WriteLine("Generated in: "+DateTime.Now);
            Console.WriteLine();

            foreach(var transition in Transitions)
            {
                System.Console.WriteLine(transition.ToString());
            }

            System.Console.WriteLine("Your Balance: R$ "+balance);
            System.Console.WriteLine("Your Overdraft: R$ "+overdraft);
            Console.WriteLine();

            Console.WriteLine("*******************************");
            Console.WriteLine("**********End of Extract**********");
            Console.WriteLine("*******************************");
            Console.WriteLine();
        }
    }
}