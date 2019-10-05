using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horario
{
    class MakeHorary
    {
        public int codigo { get; set; }
        public string materia { get; set; }
        public string grupo { get; set; }
        public string dia { get; set; }
        public string hora { get; set; }
        public string docente { get; set; }
        public void generate()
        {

        }
        public string[] getValidHorary(string[] lines, string[] spearator, int count)
        {
            String[] strlist = { "" };
            foreach (string item in lines)
            {
                string tempLine = item;
                string c = tempLine.Substring(0, 1);
                //string temcode = "";
                //string tempmateria = "";
                if (Char.IsNumber(c, 0) && (tempLine.Length > 20))
                {
                    strlist = tempLine.Split(spearator, count,
               StringSplitOptions.RemoveEmptyEntries);
                }
            }
            return strlist;
        }
        public string[] getTextMat(string[] strlist, int pos)
        {
            string temcode = string.Empty;
            string tempmateria = string.Empty;
            //string[] tempArrayCode = strlist[0].Split(' ');
            string[] tempArrayCode = strlist[pos].Split(' ');
            
            for (int i = 0; i < tempArrayCode[pos].Length; i++)
            {
                if (Char.IsNumber(strlist[pos].Substring(i, 1), 0))
                {
                    temcode += strlist[pos].Substring(i, 1);
                }
                else
                {
                    tempmateria += strlist[pos].Substring(i, 1);
                }
            }
            String[] data = {temcode,tempmateria+" "+tempArrayCode[1]};
            return data;
        }
        public string[] getTextNameDoc(string[] strlist, int pos)
        {
            string nameDocente = string.Empty;
            string[] tempArray1 = strlist[1].Split(' ');
            for (int i = 1; i < tempArray1.Length; i++)
            {
                   nameDocente += tempArray1[i]+" ";
            }
            String[] data = { tempArray1[0], nameDocente };
            return data;
        }
    }
}
