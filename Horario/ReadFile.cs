using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace Horario
{
    class ReadFile
    {
        public string path { get; set; }
        public ReadFile(string path)
        {
            this.path = path;
        }
        public string readPdf()
        {
            PdfReader reader = new PdfReader(path);
            //PdfReader reader = new PdfReader("c:\\Users/REYNALDINHO/Downloads/Horarios Sistemas II-2019.pdf");
            string text = string.Empty;
            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                text += PdfTextExtractor.GetTextFromPage(reader, page);

            }
            return text;
        }
    }
}
