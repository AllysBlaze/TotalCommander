using System;
using System.IO;

namespace TC.MODEL
{
    class PanelTModel
    {
        public string[] Drives
        {
            get
            {
                return Directory.GetLogicalDrives();
            }
        }
        public string[] Kolekcja { get; set; }
        public string Sciezka { get; set; }
        public void GetSciezka(string dysk)
        {
            Sciezka = null;
            Sciezka = dysk;
            Kolekcja = GetKolekcja();
        }

        public bool IsDirectory(string s)
        {
            FileAttributes a = File.GetAttributes(s);
            if (a.HasFlag(FileAttributes.Directory))
                return true;
            else
                return false;
        }

        public string[] GetKolekcja()
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"niewiem.txt", true))
            {
                file.WriteLine(Sciezka);
            }
            var pliki = Directory.GetFiles(Sciezka);
            var foldery = Directory.GetDirectories(Sciezka);
            int dlugosc = pliki.Length + foldery.Length;
            string[] k = new string[dlugosc];
            Array.Copy(foldery, k,  foldery.Length);
            Array.Copy(pliki, 0,k, foldery.Length, pliki.Length);
            Kolekcja = k;
            return Kolekcja;
        }
        public void GetSciezkeZIndeksu(int i)
        {
            /*
            if (Kolekcja[i] == "...")
            {
                Cofnij();
                Kolekcja = GetKolekcja();
            }
            else*/ if (IsDirectory(Kolekcja[i]) == false)
            {
                Sciezka = Kolekcja[i];
            }
            else
            {
                var t = Kolekcja[i];
                Sciezka = t;
                Kolekcja = GetKolekcja();
            }
        }
        public void Cofnij()
        {
            
            if (Sciezka != null)
            {
                try
                {
                    var s = Directory.GetParent(Sciezka).ToString();
                    Sciezka = s;
                }
                catch
                {

                }
            }

        }

        public void Kopiuj(string source, string cel)
        {
            string nazwa = Path.GetFileName(source);
            string destination = Path.Combine(cel, nazwa);
            File.Copy(source, destination, true);
        }
    }
}
