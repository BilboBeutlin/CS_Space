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
                string text = System.IO.File.ReadAllText(dialog.FileName); // Liest die *.txt ein

               string[] parts = text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries); // Die *.txt wird zeilen weise in ein Array geschrieben
               List<decode> encode = new List<decode>();
               for (int i = 0; i < parts.Length; i++)
               {
                   if (parts[i] != "")
                   {
                       bool exist = false;
                       for (int j = 0; j < encode.Count; j++)
                       {
                           if (encode[j].GetText() == parts[i] )
                           {
                               // TODO: PlusOne() ist nicht nötig
                                encode[j].PlusOne();
                                exist = true;
                                break;
                           }                          
                       }
                       if (!exist)
                       {
                           encode.Add(new decode(parts[i]));
                       }
                   }
               }
           
            }
        }
    }
}
