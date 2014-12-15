using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace decode_aprs_short
{
    class aprs
    {
        string text;
        //public string time;
        // unsortierte Daten
        public List<string> uns_data    = new List<string>();
        // die wichtigsten Zeilen aus uns_date werde hier abgespeichert
        public List<string> sort_data   = new List<string>();
        // beinhaltetet die Zeit
        public List<string> Time = new List<string>();
        // beinhaltetet die Posiionswerte
        public List<string> Raw_Position = new List<string>();
        // beinhaltet die Latitude decodierten
        public List<double> Lat = new List<double>();
        // beinhaltet die Longditude decodierten
        public List<double> Long = new List<double>();
        // beinhaltet die Telemetriedaten
        public List<string> Telemetry = new List<string>();
        
        public aprs()
        {
            // TODO: Complete member initialization
        }

    }
}
