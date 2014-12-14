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
using Microsoft.Win32;

namespace decode_aprs_short
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
               string [] new_data = System.IO.File.ReadAllLines(dialog.FileName);
               List<decode> encode = new List<decode>();
               for (int i = 0; i < new_data.Length; i++)
               {
                       encode.Add(new decode(new_data[i]));
                   // Datum + Uhrzeit aus System lesen und in das entsprechende Format bringen
                       DateTime sytem_date = System.DateTime.Now;                               // System Datum+Uhrzeit holen
                       sytem_date = System.DateTime.SpecifyKind(sytem_date, DateTimeKind.Utc);  // System Datum+Uhrzeit  in UTC    
                       string sytem_date_str = sytem_date.ToUniversalTime().ToString("u");      // System Datum+Uhrzeit Konvertieren in "Universelles, sortierbares Datums-/Zeitmuster."
                       sytem_date_str = sytem_date_str.Remove(sytem_date_str.Length-1);         // Das letzte Zeichen "Z" aus dem Datum löschen, wird immer mit rangehängt
                   // Comprimierte Elemente im Protokoll finden                                 // lala
                        
                    // Ausgabe in Text Box
                       myTextBox.Text = sytem_date_str; 
                   
               }           
            }
        }
    }
}
