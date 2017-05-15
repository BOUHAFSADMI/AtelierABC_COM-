using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using CaisseLibrary;


namespace WpfClientApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Type objecttype = Type.GetTypeFromProgID("CaisseLibrary1.Class1");
            //object objt = Activator.CreateInstance(objecttype);
            //object c;
            //c = objecttype.InvokeMember("GetMontant", BindingFlags.InvokeMethod, null, objt, null);
            //Console.WriteLine(c);
            //Console.ReadLine();

            Caisse caisse = new Caisse();
            caisse.caisse = new Dictionary<int, int>();
            MessageBox.Show("Montant= "+caisse.GetMontant().ToString());
        }
    }
}
