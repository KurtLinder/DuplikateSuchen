using System;
using System.Collections.Generic;
using System.IO;

namespace DuplikateSuchen.Model
{
    public class OrdnerDateien
    {
        public bool Fertig { get; set; }
        public int Anzahl { get; set; }
        public SortedDictionary<string, List<string>> EindeutigeNamen { get; set; }

        public OrdnerDateien()
        {
            EindeutigeNamen = new SortedDictionary<string, List<string>>();
        }

        private void DateiEinfuegen(string n, string fn)
        {
            var l = new List<string>
            {
                fn
            };

            if (EindeutigeNamen.ContainsKey(n))
            {
                EindeutigeNamen[n].Add(fn);
            }
            else
            {
                EindeutigeNamen.Add(n, l);
            }
        }


        internal void Suchen(string ordner)
        {
            Fertig = false;
            System.Threading.Tasks.Task.Run(() => WalkFolders(ordner));
        }


        private void WalkFolders(string Directory)
        {
            Anzahl = 0;
            WalkFolders(new DirectoryInfo(Directory));
            Fertig = true;
        }

        private void WalkFolders(DirectoryInfo di)
        {
            try
            {
                // Alle Verzeichnisse rekursiv durchlaufen
                foreach (DirectoryInfo subdir in di.GetDirectories())
                {
                    WalkFolders(subdir);
                }

                // Alle Dateien durchlaufen
                foreach (FileInfo fi in di.GetFiles())
                {
                    Anzahl++;
                    DateiEinfuegen(fi.Name, fi.FullName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}