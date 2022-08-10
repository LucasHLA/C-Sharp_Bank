using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpBank.Models
{
    public class Owner
    {
        public string Name{get;set;}

        public string CPF{get;set;}

        public string Phone{get;set;}

        public Adress Adress{get;set;}


        public Owner (string name, string cpf, string phone){
            Name = name;
            CPF = cpf;
            Phone = phone;
        }

        public Owner (string name, string cpf, string phone, Adress adress){
            Name = name;
            CPF = cpf;
            Phone = phone;
            Adress = adress;
        }
    }
}