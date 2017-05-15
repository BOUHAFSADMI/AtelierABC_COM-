using System.Collections.Generic;
using System.EnterpriseServices;
using System.IO;
using System.Runtime.InteropServices;

namespace CaisseLibrary
{
    public interface ICaisse
    {

        void Vider();
        void Alimenter(List<int> jetons);
        int GetMontant();
        List<int> RendreMonnaie(int price);
        void Encaisser(List<int> jetons, int price);
        void LoadCaisse();
        void SaveCaisse();

    }

    public class Caisse : ServicedComponent, ICaisse
    {

        public Dictionary<int, int> caisse;

        public Caisse() { }

        public void Alimenter(List<int> jetons)
        {
            foreach (int item in jetons)
            {
                caisse[item]++;
            }
        }

        public void Encaisser(List<int> jetons, int price)
        {
            Alimenter(jetons);
            RendreMonnaie(price);
        }

        public int GetMontant()
        {
            int montant = 0;
            foreach (int key in caisse.Keys)
            {
                montant += caisse[key] * key;
            }
            return montant;
        }

        public void LoadCaisse()
        {
            using (TextReader r = File.OpenText("caisse.txt"))
            {
                string s;
                int key, value;
                while ((s = r.ReadLine()) != null)
                {
                    int.TryParse(s.Split(' ')[0], out key);
                    int.TryParse(s.Split(' ')[1], out value);
                    caisse[key] = value;
                }
            }
        }

        public List<int> RendreMonnaie(int price)
        {
            int montant = GetMontant();
            int remainedPrice = price;
            int max = 0;
            List<int> listARendre = new List<int>();

            while (remainedPrice > 0)
            {
                max = GetMax(remainedPrice);
                remainedPrice -= max;
                caisse[max]--;
                listARendre.Add(max);
            }
            return listARendre;
        }

        public void SaveCaisse()
        {
            using (TextWriter w = File.CreateText("caisse.txt"))
            {
                foreach (int key in caisse.Keys)
                {
                    w.WriteLine(key + " " + caisse[key]);
                }
            }

        }

        public void Vider()
        {
            foreach (int key in caisse.Keys)
            {
                caisse[key] = 0;
            }
        }


        private int GetMax(int borneSup)
        {
            int max = 0;
            foreach (int key in caisse.Keys)
            {
                if (key > max & caisse[key] != 0 & key < borneSup)
                    max = key;
            }
            return max;
        }
    }
}
