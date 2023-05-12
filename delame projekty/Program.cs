public static class ProjektKvěten
{
    private class Produkt
    {
        public Produkt(string jmeno, double cena)
        {
            Cena = cena;
            Jmeno = jmeno;
        }
        public static bool cyklus = true;
        public string Jmeno;
        public double Cena;
    }

    private static class Inventář
    {
        public static List<Produkt> Produkty { get; set; } = new List<Produkt>();
        public static int Pocet { get; set; }
        public static void PřidejProdukt(string jmeno, double cena)
        {
            Produkty.Add(new Produkt(jmeno, cena));
        }
        public static void OdstranitProdukt(string jmeno)
        {
            var vybranýProdukt = Produkty.Find(p => p.Jmeno == jmeno); 
            Produkty.RemoveAt(Produkty.IndexOf(vybranýProdukt));
            Console.Clear();
        }
        public static void UkazProdukt()
        {
            Console.Clear();
            Console.WriteLine("aktualní list je");
            foreach (var item in Produkty) Console.WriteLine($"{item.Jmeno},{item.Cena} kč");
            Produkt.cyklus = false;
        }
    }
    public static void Main()
    {
        while (Produkt.cyklus == true)
        {
            try
            {
                Console.WriteLine(" přidat(p), zobrazit(z), odstranit(o)");
                char vyber = char.Parse(Console.ReadLine());
                if (vyber == 'p')
                {
                    Console.WriteLine("Zadej název produktu: ");
                    string jmeno = Console.ReadLine();
                    Console.WriteLine("Zadej cenu pls");
                    double cena = double.Parse(Console.ReadLine());
                    Inventář.PřidejProdukt(jmeno, cena);
                }

                else if(vyber == 'z')
                {
                    Inventář.UkazProdukt();
                }
                else if(vyber=='o')
                {
                    Console.WriteLine("napiš název produktu,který chceš smazat");
                    string jmeno = Console.ReadLine();
                    Inventář.OdstranitProdukt(jmeno);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("dal si spatny input si poop");break;
            }
        }
    }
}

