using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horario
{
    class TextUtil
    {
        public String[] delimiters { get; set; }
        public char delimit { get; set; }
        public string text { get; set; }
        public TextUtil(string[] delimiters, char delimit, string text)
        {
            this.delimiters = delimiters;
            this.delimit = delimit;
            this.text = text;
        }
        public string[] extract()
        {
           var result = text.Split(delimit);
            return result;
        }
    }
}
