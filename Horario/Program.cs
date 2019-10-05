using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Horario
{
    class Program
    {
        public List<MakeHorary> horarios = new List<MakeHorary>();
        static void Main(string[] args)
        {
            Program p = new Program();
            MakeHorary mh =new MakeHorary();
            Export ex = new Export();
            ReadFile reader = new ReadFile("c:\\Users/REYNALDINHO/Downloads/Horarios Sistemas II-2019.pdf");
            string text = reader.readPdf();
            TextUtil tu = new TextUtil(null,'\n',text);
            //var result = text.Split('\n');
            var result = tu.extract();
            String[] spearator = { "-" };
            Int32 count = 2;
            string[] listHorary= mh.getValidHorary(result,spearator, count);

            foreach (string item in result)
            {
                string tempLine = item;
                string c =tempLine.Substring(0, 1);
                
                if (Char.IsNumber(c,0) && (tempLine.Length>20) ) {

                    String[] strlist = tempLine.Split(spearator, count,
               StringSplitOptions.RemoveEmptyEntries);
                    string[] dataCodMat = mh.getTextMat(strlist, 0);
                    string[] tempArray = strlist[0].Split(' ');
             
                    
                    string cadenaMateria = dataCodMat[1];
                    
                    int lengtext = tempArray.Length;
                    for (int i = 2; i < lengtext-3; i++)
                    {
                        cadenaMateria += tempArray[i]+" ";
                    }
                    //Console.WriteLine(cadenaMateria);
                    //string nameDocente=string.Empty;
                    string[] dataNameDoc = mh.getTextNameDoc(strlist, 1);
                    
                    ///// agregar datos al objeto
                    
                    p.horarios.Add(new MakeHorary {codigo=int.Parse(dataCodMat[0]) ,materia = cadenaMateria, grupo = tempArray[lengtext-3],dia= tempArray[lengtext-2], hora = tempArray[lengtext-1]+dataNameDoc[0], docente = dataNameDoc[1] });

                    cadenaMateria = "";
                    
                }
            }
            
            ex.cvs(p.horarios, @"D:\\HorarioFile.csv");
            //ex.view(p.horarios);
            Console.ReadKey();  
        }
            
    }
    
}
