
namespace TC.viewModel
{
    using MODEL;
    using BaseClass;
    class PanelViewModel : ViewModelBase
    {
        private PanelTModel tc = new PanelTModel();
        public PanelViewModel()
        {
            DyskiLogiczne = tc.Drives;
            indeks = -1;
        }

        private string[] _dyskiLogiczne = null;
        public string[] DyskiLogiczne
        {
            get
            {
                return _dyskiLogiczne;
            }
            set
            {
                _dyskiLogiczne = tc.Drives;
                onPropertyChanged(nameof(DyskiLogiczne));
            }
        }

        private string _obecnyDysk=null;
        public string obecnyDysk
        {
            get
            {
                return _obecnyDysk;
            }
            set
            {
                //indeks = -1;
                _obecnyDysk = value;
                tc.GetSciezka(obecnyDysk);

                onPropertyChanged(nameof(obecnyDysk), nameof(sciezka),nameof(kolekcja));
            }
        }
        public string sciezka
        {
            get
            {
                return tc.Sciezka;
            }
            set
            {
                onPropertyChanged(nameof(sciezka));
            }
        }
        private int _indeks = -1;
        public int indeks
        {
            get
            {
                return _indeks;
            }
            set
            {
                _indeks = value;
                if (_indeks!=-1)
                {
                    tc.GetSciezkeZIndeksu(indeks);
                }

                _indeks = -1;
                onPropertyChanged(nameof(indeks),nameof(sciezka), nameof(kolekcja));
            }
           
        }
        private string[] _kolekcja = null;
        public string[] kolekcja
        {
            get
            {
                if (sciezka != null)
                    try
                    {
                        return tc.Kolekcja;
                    }
                    catch
                    {
                        return _kolekcja;
                    }
                else
                    return _kolekcja; 
            }
            set
            {
                _kolekcja = value;
                onPropertyChanged(nameof(kolekcja));
            }
        }

        public void Refresh()
        {
            kolekcja = tc.GetKolekcja();
        }
    }
}