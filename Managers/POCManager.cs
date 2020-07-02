using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;
using POC_SetToRules.Models;
using POC_SetToRules.Rules;

namespace POC_SetToRules.Managers
{
    public class POCManager
    {
        private readonly NBA _nba;
        private readonly POCMapRules _mapRules;
        private readonly ISet<Func<bool>> _rules;

        //Recebe a NBA no contrutor
        public POCManager(NBA nba)
        {
            _nba = nba;
            _rules = new HashSet<Func<bool>>();
            _mapRules = new POCMapRules(new POCRules(nba));

            CreateRules();
        }

        private void CreateRules()
        {
            var combinacao = _nba.Actions.Select(e => e.Name).ToHashSet();

            var map = _mapRules.Map;
           
            Console.WriteLine("combinacao => " + string.Join(", ", combinacao));

            _rules.Clear();

            ISet<string> combinatiosAdded = new HashSet<string>();

            foreach(var m in map.Where(e=> e.Item1 != null))
            {
                var c = m.Item1;
                var r = m.Item2;

                if (c.IsSubsetOf(combinacao))
                {
                    if ( combinatiosAdded.Overlaps(c))
                    {
                        _rules.IntersectWith(r);
                    }
                    else
                    {
                        _rules.UnionWith(r);
                    }

                    combinatiosAdded.UnionWith(c);
                }
                 
            }

            // Para as regras gerais
            _rules.UnionWith(map.Where(e => e.Item1 == null).SelectMany(e => e.Item2));

            Console.WriteLine("Info");
            Console.WriteLine("_rules count = " +  _rules.Count());

        }

        public bool IsValid()
        {

            return _rules.All(e => e.Invoke());
        }

    }
}
