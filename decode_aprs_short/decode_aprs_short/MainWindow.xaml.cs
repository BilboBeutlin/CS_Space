﻿using System;
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
               //string [] new_data = System.IO.File.ReadAllLines(dialog.FileName);
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
                   Encode.Position.Add(temp_list[1]);
                   //Encode.Time.


               }
               for (int j = 0; j < Encode.Time.Count; j++)
               {

                       Encode.Time[j] = Encode.Time[j].Insert(2, ":");
                       Encode.Time[j] = Encode.Time[j].Insert(5, ":");
                       var lang = Encode.Time[j].Length;   
                    //Encode.Time[j] = Encode.Time[j].Remove(9, 'h');
                       Encode.Time[j] = Encode.Time[j].Remove(8);           // h an letzter Stelle entfernen

               }

                
               
            }
        }
    }
}
