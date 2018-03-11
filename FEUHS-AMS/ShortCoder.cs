using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEUHS_AMS
{
    class ShortCoder
    {
        private string[] shortcodes;
        private string[] values;
        private string format;
        private string output;

        public ShortCoder(string[] s, string[] v, string f)
        {
            this.shortcodes = s;
            this.values = v;
            this.format = f;
        }

        public string performFormat()
        {
            string temp_format = this.format;
            for (int i = 0; i < shortcodes.Length; i++)
            {
                this.output = temp_format.Replace(this.shortcodes[i], this.values[i]);
                temp_format = this.output;
            }
            return this.output;
        }
    }
}
