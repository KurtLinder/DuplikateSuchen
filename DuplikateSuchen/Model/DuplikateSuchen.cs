using System.Text;

namespace DuplikateSuchen.Model
{
    public class DuplikateSuchen
    {
        public OrdnerDateien Od { get; set; }
        public int AnzahlEintrage { get; set; }
        public StringBuilder OrdnerString { get; set; }

        private readonly string ordner = "k:\\1&1\\";

        public DuplikateSuchen()
        {
            AnzahlEintrage = 0;
            OrdnerString = new StringBuilder();
            Od = new OrdnerDateien();
        }

        internal void SucheStarten()
        {
            OrdnerString.Clear();
            Od.Suchen(ordner);           
        }
    }
}