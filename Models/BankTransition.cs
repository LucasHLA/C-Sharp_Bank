using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpBank.Enum;

namespace CSharpBank.Models
{
    public class BankTransition
    {
        #region Atributes
        private DateTime dateTimeBankTransition{get;set;}

        private TransitionType TransitionType{get;set;}

        private double Value{get;set;}
        #endregion

        #region Builders
        public BankTransition(TransitionType transitionType,double value){
            dateTimeBankTransition = DateTime.Now;
            TransitionType = transitionType;
            Value = value;
        }

        public BankTransition(TransitionType aCCOUNT_OPENING)
        {
        }


        #endregion

        #region methods
        public override string ToString()
        {
            var value = (this.TransitionType == TransitionType.WITHDRAW || 
                         this.TransitionType == TransitionType.TRANFERENCE)
                ? "-R$ "+Value
                : "R$ "+Value;

            return $"{dateTimeBankTransition}hs | {TransitionType} | {value}";
        }
        #endregion
    }
}