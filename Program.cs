
using CSharpBank.Enum;
using CSharpBank.Models;

Console.WriteLine("*******************************");
Console.WriteLine("**********CSharp Bank**********");
Console.WriteLine("*******************************");
Console.WriteLine();

var adress = new Adress{
        CEP = "412411125125",
        street = "Rua IX",
        num = 899
};

var titular01 = new Owner("Lucas Henrique","11111111111","148992773",adress);
var titular02 = new Owner("Maria","11111111111","148992773",adress);
var titular03 = new Owner("Lucas Henrique","11111111111","148992773",adress);

var conta01 = new CheckingAccount(titular01,2000.00);
var conta02 = new SavingsAccount(titular02);
var conta03 = new InvestmentAccount(titular03,1000.0);

/*conta01.Deposit(1000.0);

conta02.Deposit(500.0);
conta02.Withdraw(100.0);

conta03.Tranfer(conta02,100.0);

conta01.PrintExtract();
conta02.PrintExtract();
conta03.PrintExtract();*/

conta02.Withdraw(100.0);
conta02.PrintExtract();
conta02.Deposit(50.0);
conta02.PrintExtract();
