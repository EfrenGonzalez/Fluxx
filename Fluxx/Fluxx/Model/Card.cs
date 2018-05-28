using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluxx.Model
{
    class Card
    {
        int Id;
        int Type;
        string Name;
        Tuple<int, int> Goal;
        Tuple<int, int> Rule;

        /*Para type
         * Type == 1 -> Keeper
         * Type == 2 -> Regla
         * Type == 3 -> Meta
         * Type == 4 -> Accion (Pendiente)*/

        /*Para rule
         * Item1 -> Tipo de regla
         * Item1 == 1 -> Cartas por tomar
         * Item1 == 2 -> Acciones
         * Item2 -> Valor
         * Quedan reglas pendientes*/

        public Card(int id, int type, string name, Tuple<int, int> goal, Tuple<int, int> rule)
        {
            Id = id;
            Type = type;
            Name = name;
            Goal = goal;
            Rule = rule;
        }

        public Card() { }

        void Define(int id, int type, string name, Tuple<int, int> goal, Tuple<int, int> rule)
        {
            Id = id;
            Type = type;
            Name = name;
            Goal = goal;
            Rule = rule;
        }

        public Card(int id)
        {
            Tuple<int, int> Zero = new Tuple<int, int>(0, 0);
            if (id <= 19) Define(id, 1, "Keeper" + Convert.ToString(id), Zero, Zero);
            else if (id <= 23) Define(id, 2, "Toma" + Convert.ToString(id - 18), Zero, new Tuple<int, int>(1, id - 18));
            else if (id <= 27) Define(id, 2, "Juega" + Convert.ToString(id - 22), Zero, new Tuple<int, int>(2, id - 22));
            else if (id == 28) Define(28, 3, "Keeper 13 + Keeper 16", new Tuple<int, int>(13, 16), Zero);
            else if (id == 29) Define(29, 3, "Keeper 2 + Keeper 10", new Tuple<int, int>(2, 10), Zero);
            else if (id == 30) Define(30, 3, "Keeper 18 + Keeper 11", new Tuple<int, int>(18, 11), Zero);
            else if (id == 31) Define(31, 3, "Keeper 7 + Keeper 10", new Tuple<int, int>(7, 10), Zero);
            else if (id == 32) Define(32, 3, "Keeper 5 + Keeper 16", new Tuple<int, int>(5, 16), Zero);
            else if (id == 33) Define(33, 3, "Keeper 19 + Keeper 15", new Tuple<int, int>(19, 15), Zero);
            else if (id == 34) Define(34, 3, "Keeper 18 + Keeper 1", new Tuple<int, int>(18, 1), Zero);
            else if (id == 35) Define(35, 3, "Keeper 1 + Keeper 16", new Tuple<int, int>(1, 16), Zero);
            else if (id == 36) Define(36, 3, "Keeper 9 + Keeper 6", new Tuple<int, int>(9, 6), Zero);
            else if (id == 37) Define(37, 3, "Keeper 3 + Keeper 16", new Tuple<int, int>(3, 16), Zero);
            else if (id == 38) Define(38, 3, "Keeper 10 + Keeper 11", new Tuple<int, int>(10, 11), Zero);
            else if (id == 39) Define(39, 3, "Keeper 3 + Keeper 15", new Tuple<int, int>(3, 15), Zero);
            else if (id == 40) Define(40, 3, "Keeper 6 + Keeper 1", new Tuple<int, int>(6, 1), Zero);
            else if (id == 41) Define(41, 3, "Keeper 8 + Keeper 7", new Tuple<int, int>(8, 7), Zero);
            else if (id == 42) Define(42, 3, "Keeper 12 + Keeper 4", new Tuple<int, int>(12, 4), Zero);
            else if (id == 43) Define(43, 3, "Keeper 2 + Keeper 7", new Tuple<int, int>(2, 7), Zero);
            else if (id == 44) Define(44, 3, "Keeper 19 + Keeper 10", new Tuple<int, int>(19, 10), Zero);
            else if (id == 45) Define(45, 3, "Keeper 9 + Keeper 15", new Tuple<int, int>(9, 15), Zero);
            else if (id == 46) Define(46, 3, "Keeper 10 + Keeper 9", new Tuple<int, int>(10, 9), Zero);
            else if (id == 47) Define(47, 3, "Keeper 17 + Keeper 11", new Tuple<int, int>(17, 11), Zero);
        }

        public bool Win(List<Card> Cards)
        {
            int qwin = 0;
            foreach (var x in Cards)
                if (Goal.Item1 == x.Id || Goal.Item2 == x.Id) qwin++;
            return (qwin == 2);
        }

        public List<Card> Decodificar(string HashString)
        {
            List<Card> Cards = new List<Card>();
            string[] Ids = HashString.Split(',');
            foreach (var Id in Ids)
                Cards.Add(new Card(Convert.ToInt32(Id)));
            return Cards;
        }

        public string Codificar()
        {
            List<int> Ids = new List<int>();
            for (int i = 1; i <= 47; i++) Ids.Add(i);
            int swaps = 50;
            Random rnd = new Random();
            while (swaps > 0)
            {
                int i = rnd.Next(47, 1);
                int j = rnd.Next(47, i);
                int k = Ids[i];
                Ids[i] = Ids[j];
                Ids[j] = k;
                swaps--;
            }
            string Hash = "";
            for (int i = 0; i < 46; i++) Hash += Convert.ToString(Ids[i]) + ",";
            Hash += Convert.ToString(Ids[46]);
            return Hash;
        }
    }
}