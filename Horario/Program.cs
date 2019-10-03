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
                string temcode ="";
                string tempmateria = "";
                
                if (Char.IsNumber(c,0) && (tempLine.Length>20) ) {

                    String[] strlist = tempLine.Split(spearator, count,
               StringSplitOptions.RemoveEmptyEntries);
                    string[] dataCodMat = mh.getCodeAndMateria(strlist);
                    string[] tempArrayCode = strlist[0].Split(' ');
             
                    for (int i = 0; i < tempArrayCode[0].Length; i++)
                    {
                        if (Char.IsNumber(strlist[0].Substring(i, 1), 0)) {
                            temcode += strlist[0].Substring(i, 1);
                        }
                        else
                        {
                            tempmateria+= strlist[0].Substring(i, 1);
                        }
                    }
                    string cadenaMateria = tempmateria+" "+tempArrayCode[1]+" ";
                    //string cadenaMateria = dataCodMat[1];
                    
                    int lengtext = tempArrayCode.Length;
                    for (int i = 2; i < lengtext-3; i++)
                    {
                        cadenaMateria += tempArrayCode[i]+" ";
                    }
                    //Console.WriteLine(cadenaMateria);
                    string nameDocente=string.Empty;

                    string[] tempArrayCode1 = strlist[1].Split(' ');
                    for (int i = 1; i < tempArrayCode1.Length; i++)
                    {
                        nameDocente += tempArrayCode1[i]+" ";
                    }
                    ///// agregar datos al objeto
                    
                    p.horarios.Add(new MakeHorary {codigo=int.Parse(dataCodMat[0]) ,materia = cadenaMateria, grupo = tempArrayCode[lengtext-3],dia= tempArrayCode[lengtext-2], hora = tempArrayCode[lengtext-1]+tempArrayCode1[0], docente = nameDocente });

                    cadenaMateria = "";
                    
                }
            }
            
            ex.cvs(p.horarios, @"D:\\HorarioFile.csv");
            //ex.view(p.horarios);
            Console.ReadKey();  
        }
            
    }
    
}
