using POC_SetToRules.Managers;
using POC_SetToRules.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace POC_SetToRules
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Aplicação START");
            Console.WriteLine("________________________________");

            List<NBA> testes = new List<NBA>()
            { 
                new NBA()
                {
                    ID = "NBA-1",
                    NBAType = "Retencao",
                    Actions = new List<NBAAction>() { new NBAAction() { ID = "1", Name = "UpDowngrade" } }
                },
                new NBA()
                {
                    ID = "NBA-2",
                    NBAType = "Retencao",
                    Actions = new List<NBAAction>() { new NBAAction() { ID = "2", Name = "Faixa de Preço" } }
                },
                new NBA()
                {
                    ID = "NBA-3",
                    NBAType = "Retencao",
                    Actions = new List<NBAAction>() { 
                        new NBAAction() { ID = "1", Name = "UpDowngrade" },
                        new NBAAction() { ID = "3", Name = "A La Carte" },
                    }
                },
                new NBA()
                {
                    ID = "NBA-4",
                    NBAType = "Retencao",
                    Actions = new List<NBAAction>() {
                        new NBAAction() { ID = "1", Name = "UpDowngrade" },
                        new NBAAction() { ID = "", Name = "Parcelamento" },
                        new NBAAction() { ID = "3", Name = "A La Carte" }
                    }
                }, 
                new NBA()
                {
                    ID = "NBA-5",
                    NBAType = "Retencao",
                    Actions = new List<NBAAction>() {
                        new NBAAction() { ID = "4", Name = "AlgoMais" }
                    }
                }, 
               new NBA()
                {
                    ID = "NBA-6",
                    NBAType = "Retencao",
                    Actions = new List<NBAAction>() {
                        new NBAAction() { ID = "5", Name = "Broad" },
                    }
                }, 
                new NBA()
                {
                    ID = "NBA-7",
                    NBAType = "Retencao",
                    Actions = new List<NBAAction>() {
                        new NBAAction() { ID = "1", Name = "UpDowngrade" },
                        new NBAAction() { ID = "5", Name = "Broad" },
                    }
                }, 
                new NBA()
                {
                    ID = "NBA-8",
                    NBAType = "Retencao",
                    Actions = new List<NBAAction>() {
                        new NBAAction() { ID = "1", Name = "UpDowngrade" },
                        new NBAAction() { ID = "2", Name = "Faixa de Preço" },
                    }
                },
                new NBA()
                {
                    ID = "NBA-9",
                    NBAType = "Retencao",
                    Actions = new List<NBAAction>() {
                        new NBAAction() { ID = "1", Name = "UpDowngrade" },
                        new NBAAction() { ID = "", Name = "Parcelamento" },
                        new NBAAction() { ID = "4", Name = "AlgoMais" }
                    }
                },
                new NBA()
                {
                    ID = "NBA-10",
                    NBAType = "Retencao",
                    Actions = new List<NBAAction>() {
                        new NBAAction() { ID = "1", Name = "UpDowngrade" },
                        new NBAAction() { ID = "", Name = "Parcelamento" },
                        new NBAAction() { ID = "7", Name = "Desconto Percentual" }
                    }
                },
                new NBA()
                {
                    ID = "NBA-11",
                    NBAType = "Retencao",
                    Actions = new List<NBAAction>() {
                        new NBAAction() { ID = "", Name = "Parcelamento" },
                        new NBAAction() { ID = "7", Name = "Desconto Percentual" }
                    }
                },
                new NBA()
                {
                    ID = "NBA-12",
                    NBAType = "Retencao",
                    Actions = new List<NBAAction>() {
                        new NBAAction() { ID = "", Name = "Parcelamento" },
                    }
                },
                new NBA()
                {
                    ID = "NBA-13",
                    NBAType = "Retencao",
                    Actions = new List<NBAAction>() {
                        new NBAAction() { ID = "7", Name = "Desconto Percentual" },
                    }
                },
            };

            foreach(var nba in testes)
            {
                Console.WriteLine(nba.ID + " - " + nba.NBAType + " - Actions: {" + string.Join(", ", nba.Actions.Select(e=> e.Name)) + "}" );
                POCManager poc = new POCManager(nba);
                Console.WriteLine("IsValid => " + poc.IsValid());
                Console.WriteLine("");
            }

            Console.WriteLine("________________________________");
            Console.WriteLine("Aplicação END");
            
        }
    }
}
