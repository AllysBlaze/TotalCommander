using System.Windows.Input;

namespace TC.viewModel
{
    using MODEL;
    using BaseClass;
    class ViewModel:ViewModelBase
    {
        private PanelViewModel _prawy = new PanelViewModel();
        private PanelViewModel _lewy = new PanelViewModel();
        PanelTModel ptc = new PanelTModel();
        public PanelViewModel prawy
        {
            get
            {
                return _prawy;
            }
            
        }

        public PanelViewModel lewy
        {
            get
            {
                return _lewy;
            }
        }

        private ICommand _kopiuj = null;
        public ICommand kopiuj
        {
            get
            {
                if (_kopiuj == null)
                {
                    _kopiuj = new RelayCommand(x => { ptc.Kopiuj(lewy.sciezka, prawy.sciezka);prawy.Refresh(); },
                        x => true);
                }
                return _kopiuj;
            }
            set
            {
                onPropertyChanged(nameof(lewy.kolekcja), nameof(prawy.kolekcja));
            }
        }
    }
}

