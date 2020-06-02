using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TC
{
    /// <summary>
    /// Logika interakcji dla klasy PanelTC.xaml
    /// </summary>
    public partial class PanelTC : UserControl
    {
        public static readonly DependencyProperty SciezkaProperty =
                DependencyProperty.Register(
                    "Sciezka",
                    typeof(string),
                    typeof(PanelTC),
                    new FrameworkPropertyMetadata(null)
                );
        //"czysta" właściwość powiązania z właściwości zależną
        //do niej będziemy się odnosić w XAMLU
        public string Sciezka
        {
            get { return (string)GetValue(SciezkaProperty); }
            set { SetValue(SciezkaProperty, value); }
        }
        public string WybranyDysk
        {
            get
            {
                return (string)GetValue(WybranyDyskDP);
            }
            set
            {
                SetValue(WybranyDyskDP, value);
            }
        }
        public static readonly DependencyProperty WybranyDyskDP = DependencyProperty.Register(nameof(WybranyDysk), typeof(string), typeof(PanelTC), new FrameworkPropertyMetadata(null));


        public string[] Dyski
        {
            get
            {
                return (string[])GetValue(DyskiDP);
            }
            set
            {
                SetValue(DyskiDP, value);
            }
        }
        public static readonly DependencyProperty DyskiDP = DependencyProperty.Register(nameof(Dyski), typeof(string[]), typeof(PanelTC), new FrameworkPropertyMetadata(null));

        public string[] Kolekcja
        {
            get
            {
                return (string[])GetValue(KolekcjaDP);
            }
            set
            {
                SetValue(KolekcjaDP, value);
            }
        }
        public static readonly DependencyProperty KolekcjaDP = DependencyProperty.Register(nameof(Kolekcja), typeof(string[]), typeof(PanelTC), new FrameworkPropertyMetadata(null));

        public int Indeks
        {
            get
            {
                return (int)GetValue(IndeksDP);
            }
            set
            {
                SetValue(IndeksDP, value);
            }
        }
        public static readonly DependencyProperty IndeksDP = DependencyProperty.Register(nameof(Indeks), typeof(int), typeof(PanelTC), new FrameworkPropertyMetadata(null));

        public static readonly RoutedEvent newEvent = EventManager.RegisterRoutedEvent(nameof(myEvent), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PanelTC));
        public event RoutedEventHandler myEvent
        {
            add { AddHandler(newEvent, value); }
            remove { RemoveHandler(newEvent, value); }
        }

        public PanelTC()
        {
            InitializeComponent();
        }
    }
}
