using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpBank.Enum;

namespace CSharpBank.Models
{
    public abstract class BankAccount
    {
        #region Atibutes
        public Owner Owner{get;set;}
        public double balance{get;private set;}

        public DateTime openingDate {get;set;}

        public double overdraft{get;set;}

        protected List<BankTransition> Transitions {get;private set;}

        protected readonly double MINIMUN_VALUE = 10.0;
        

        #endregion

        #region Builders
        public BankAccount(Owner accountOwner, double openingBalance){
            Owner = accountOwner;
            balance = openingBalance;
            overdraft = 1000;
            openingDate = DateTime.Now;
            Transitions = new List<BankTransition>()
            {
                new BankTransition(TransitionType.ACCOUNT_OPENING,openingBalance)
            };

        }

        public BankAccount(Owner accountOwner){
            Owner = accountOwner;
            balance = 0;
            overdraft = 1000;
            openingDate = DateTime.Now;
            Transitions = new List<BankTransition>()
            {
                new BankTransition(TransitionType.ACCOUNT_OPENING,balance)
            };
        }
        #endregion

        #region Methods

        public void Deposit(double value){
            if(value < MINIMUN_VALUE)
            {
                throw new Exception("The minimun value for deposit is R$ "+MINIMUN_VALUE);
            }

            if(overdraft < 1000){
                double dif;
                dif = 1000 - overdraft;

                if(value <= dif){
                    overdraft += value;
                    Transitions.Add(new BankTransition(TransitionType.OVERDRAFT,value));
                    balance -= (value - dif);
                }
                else if(value >= dif){
                    overdraft += dif;
                    Transitions.Add(new BankTransition(TransitionType.OVERDRAFT,value));
                    balance -= (value - dif);
                }  
            }
            else{
                balance += value;
                Transitions.Add(new BankTransition(TransitionType.DEPOSIT,value));
            } 
        }

        public double Withdraw(double value){
            if(value < MINIMUN_VALUE)
            {
                throw new Exception("The minimun value for withdraw is R$ "+MINIMUN_VALUE);
            }
            else if(value > balance)
            {

                if(overdraft >= value){
                    overdraft -= value;
                    System.Console.WriteLine("You made a withdraw from your overdraft!");
                    System.Console.WriteLine("Overdraft: R$ "+overdraft);
                    Transitions.Add(new BankTransition(TransitionType.OVERDRAFT,value));
                }
            }
            
            balance -= value;
            Transitions.Add(new BankTransition(TransitionType.WITHDRAW,value));

            return value;
        }

        public void Tranfer(BankAccount destinyAccont, double value)
        {
            if(value < MINIMUN_VALUE)
            {
                    throw new Exception("The minimun value for tranference is R$ "+MINIMUN_VALUE);
            }
            else if(value > balance)
            {
                throw new Exception("You can not make the transference because ou do not have enough balance!");
                throw new Exception("Your current balance is: R$ "+balance);
            }

            destinyAccont.Deposit(value);
            balance -= value;
            Transitions.Add(new BankTransition(TransitionType.TRANFERENCE,value));

        }

        public virtual void PrintExtract(){
            Console.WriteLine("Printing yout account extract");
        }

        #endregion

    }
}