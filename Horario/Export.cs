using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Horario
{
    class Export
    {
        Program p = new Program();
        MakeHorary mh = new MakeHorary();
        /*private DataTable TablaEnvioSms()
        {
            DataTable dtSms = new DataTable();

            dtSms.Columns.Add("Fila", typeof(string));
            dtSms.Columns.Add("Nombres", typeof(string));
            dtSms.Columns.Add("Apellidos", typeof(string));
            dtSms.Columns.Add("Direccion", typeof(string));
            dtSms.Columns.Add("Telefono", typeof(string));
            return dtSms;
        }*/

        public void cvs(List<MakeHorary> list, string path)
        {
            var file = path;
            using (var stream = File.AppendText(file))
            {
                /* initialize elements of array n */

                /*for (int i = 0; i < 10; i++)
                {*/

                foreach (var item in list)
                {
                    mh = (MakeHorary)item;
                    string csvRow = mh.codigo + "," + mh.materia + "," + mh.grupo + "," + mh.dia + "," + mh.hora + "," + mh.docente;
                    Console.WriteLine(csvRow);
                    stream.WriteLine(csvRow);

                }


                //}

            }
        }
        public void view(List<MakeHorary> list)
        {
            foreach (var item in list)
            {
                mh = (MakeHorary)item;
                Console.WriteLine(mh.materia);
            }
        }
    }
}
