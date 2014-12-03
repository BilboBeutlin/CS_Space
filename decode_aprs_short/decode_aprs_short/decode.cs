using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace decode_aprs_short
{
    class decode
    {
        string text;
        uint count;

        public string GetText()
        {
            return text;
        }

        public decode(string text1)
        {
            this.text = text1;
            count = 0;
        }

        public void PlusOne()
        {
            count++;
        }
    }
}
