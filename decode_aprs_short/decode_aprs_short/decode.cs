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
        public string time;
        public List<string> uns_data = new List<string>();
        public List<string> sort_data = new List<string>();
        

        public aprs()
        {
            // TODO: Complete member initialization
        }

        public void TimeCpy (string input)
        {
            if(input[0] == '/')
            {
                for (int i = 1; i < 6; i++)
			    {
                    time[i] = input[i];
			    }
            }
        }

    }
}
