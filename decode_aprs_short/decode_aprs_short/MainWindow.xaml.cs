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
            aprs Encode = new aprs();
            aprs Decode = new aprs();

            if (result == true)
            {
               // Datum + Uhrzeit aus System lesen und in das entsprechende Format bringen
               DateTime system_date = System.DateTime.Now;                               // System Datum+Uhrzeit holen
               system_date = System.DateTime.SpecifyKind(system_date, DateTimeKind.Utc);  // System Datum+Uhrzeit  in UTC    
               string sytem_date_str = system_date.ToUniversalTime().ToString("u");      // System Datum+Uhrzeit Konvertieren in "Universelles, sortierbares Datums-/Zeitmuster."
               sytem_date_str = sytem_date_str.Remove(sytem_date_str.Length - 1);         // Das letzte Zeichen "Z" aus dem Datum löschen, wird immer mit rangehängt
               Encode.uns_data = System.IO.File.ReadAllLines(dialog.FileName).ToList();
               for (int i = 0; i < Encode.uns_data.Count; i++)
               {
                   if (Encode.uns_data[i].Contains(">:"))
                   {
                       Encode.sort_data.Add(Encode.uns_data[i + 1]);
                       // Ausgabe in Text Box
                       // myTextBox.Text = "Hoöz";          
                   }
               }          
               for (int i = 0; i < Encode.sort_data.Count; i++)
               {
                   List<string> temp_list = new List<string> (Encode.sort_data[i].Split(new char[]{'/','E'},StringSplitOptions.RemoveEmptyEntries));
                   Encode.Time.Add(temp_list[0]);
                   Encode.Raw_Position.Add(temp_list[1]);
               }
               for (int j = 0; j < Encode.Time.Count; j++)
               {
                  Encode.Time[j] = Encode.Time[j].Insert(2, ":");
                  Encode.Time[j] = Encode.Time[j].Insert(5, ":");
                  Encode.Time[j] = Encode.Time[j].Remove(8); // h an letzter Stelle entferne
               }
                //
                //float test = 90 - (new int (Encode.Position[0]) - 33); //* 91^3 + (Encode.Position[1] -33) *  91^2 + (Encode.Position[2] -33) * 91 + Encode.Position[4] -33) / 380926;
               for (int i = 0; i < Encode.Raw_Position.Count; i++)
               {
                   // 90 - ((y 1 -33) x  91 3 + (y 2 -33) x  91 2 + (y 3 -33) x 91 + y 4 -33) / 380926
                   double lat = (double) (90 - ((Encode.Raw_Position[i][0] - 33) * Math.Pow(91,3) + (Encode.Raw_Position[i][1] - 33) * Math.Pow(91,2) + (Encode.Raw_Position[i][2] - 33) * 91 + (Encode.Raw_Position[i][3] - 33)) / 380926);
                   Decode.Lat.Add(lat);
                   double longd = (double) (-180 + ((Encode.Raw_Position[i][4] -33) * Math.Pow(91,3) + (Encode.Raw_Position[i][5] -33) * Math.Pow(91,2) + (Encode.Raw_Position[i][6] -33) *  91 + Encode.Raw_Position[i][7] -33) / 190463);
                   Decode.Long.Add(longd);
                   //double lat = (double) 90 - ((Encode.Position[i][0] - 33) * Math.Pow(91,3));
               }
                
               
            }
        }
    }
}
