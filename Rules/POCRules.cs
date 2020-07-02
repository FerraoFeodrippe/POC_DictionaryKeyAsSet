using POC_SetToRules.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace POC_SetToRules.Rules
{
    public class POCRules
    {
        private readonly NBA _nba;

        public ISet<Func<bool>> Bundle1 { get; private set; }
        public ISet<Func<bool>> Bundle2 { get; private set; }
        public ISet<Func<bool>> Bundle3 { get; private set; }
        public ISet<Func<bool>> Bundle4 { get; private set; }

        public ISet<Func<bool>> GeneralRules { get; private set; }



        public POCRules(NBA nba)
        {
            _nba = nba;

          Bundle1 = new HashSet<Func<bool>>
          {
            Rule1,
            Rule2,
            Rule3,
            Rule4,
           };
        
            Bundle2 = new HashSet<Func<bool>>
            {
                Rule1,
                Rule4,
            };

            Bundle3 = new HashSet<Func<bool>>
            {
                Rule2,
                Rule3,
            };

            Bundle4 = new HashSet<Func<bool>>
            {
                Rule5,
            };

            GeneralRules = new HashSet<Func<bool>>
            {
                CantInstallmentWithPercentDiscount,
            };
        }

      


        public Func<bool> Rule1
        {
            get
            {
                return () =>
                {
                    Console.WriteLine("Rule1");

                    return true;
                };
            }
        }

        public Func<bool> Rule2
        {
            get
            {
                return () =>
                {
                    Console.WriteLine("Rule2");

                    return true;
                };
            }
        }

        public Func<bool> Rule3
        {
            get
            {
                return () =>
                {
                    Console.WriteLine("Rule3");

                    return true;
                };
            }
        }

        public Func<bool> Rule4
        {
            get
            {
                return () =>
                {
                    Console.WriteLine("Rule4");

                    return true;
                };
            }
        }

        public Func<bool> Rule5
        {
            get
            {
                return () =>
                {
                    Console.WriteLine("Rule5");

                    return false;
                };
            }
        }

        public Func<bool> CantInstallmentWithPercentDiscount
        {
            get
            {
                return () =>
                {
                    Console.WriteLine("CantInstallmentWithPercentDiscount");
                    string[] toCheck = { "Parcelamento", "Desconto Percentual" };

                    return !_nba.Actions.Select(a=> a.Name).ToHashSet().IsSupersetOf(toCheck);
                };
            }
        }

    }
}
