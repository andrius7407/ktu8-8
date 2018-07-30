using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ktu8_8
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"C:\Users\Andrius\Documents\Visual Studio 2017\ktu\ktu8-8\ktu8-8\koduote.txt";
            string[] lines = System.IO.File.ReadAllLines(fileName);
            Koduote[] kod = new Koduote[lines.Length];
            for(int i = 0; i < lines.Length; i++)
            {
                string eilute = lines[i];
                string[] eile = eilute.Split(' ');
                string kodas = eile[0];
                string simbolis = eile[1];
                kod[i] = new Koduote(kodas, simbolis);
            }

            string fileName2 = @"C:\Users\Andrius\Documents\Visual Studio 2017\ktu\ktu8-8\ktu8-8\laiskas.txt";
            string text = System.IO.File.ReadAllText(fileName2);
            string[] tex = text.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            
            int teisingai = 0;
            List<String> list = new List<string>();
            for(int i = 0; i < tex.Length; i++)
            {
                string kodas1 = tex[i];
                int kontrole = 0;
                for (int j = 0; j < kod.Length; j++)
                {
                    if(kodas1 == kod[j].kodas)
                    {
                        teisingai++;
                        kontrole++;
                        break;
                    }                  
                }
                if(kontrole == 0)
                {
                    list.Add(kodas1);
                }
            }

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\Andrius\Documents\Visual Studio 2017\ktu\ktu8-8\ktu8-8\rezultatai.txt"))
            {
                if (teisingai == tex.Length)
                {
                    file.WriteLine("Teisingai");
                }
                else
                {
                    foreach (String line in list)
                    {
                        file.WriteLine("{0} - neteisingas simbolis", line);
                    }
                }
            }
        }
    }
}
