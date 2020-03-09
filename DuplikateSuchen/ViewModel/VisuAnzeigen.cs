namespace DuplikateSuchen.ViewModel
{
    using System.ComponentModel;
    using System.Threading;

    public class VisuAnzeigen : INotifyPropertyChanged
    {
        private readonly Model.DuplikateSuchen duplikateSuchen;
        private readonly MainWindow mainWindow;

        public VisuAnzeigen(MainWindow mw, Model.DuplikateSuchen ds)
        {
            mainWindow = mw;
            duplikateSuchen = ds;
            TextAnzeige = "leer";
            AnzahlDateien = 0;
            DateiTyp = "ölsadfjk:jpg";

            System.Threading.Tasks.Task.Run(() => VisuAnzeigenTask());

        }

        private void VisuAnzeigenTask()
        {
            while (true)
            {
                if (duplikateSuchen.Od != null) AnzahlDateien = duplikateSuchen.Od.Anzahl;
                if (duplikateSuchen.OrdnerString != null)
                {

                    if (duplikateSuchen.Od.Fertig)
                    {
                        duplikateSuchen.Od.Fertig = false;

                        foreach (string s in duplikateSuchen.Od.EindeutigeNamen.Keys)
                        {
                            duplikateSuchen.OrdnerString.Append(s);
                            duplikateSuchen.OrdnerString.Append("\n");
                        }
                    }
                    TextAnzeige = duplikateSuchen.OrdnerString.ToString();
                }

                Thread.Sleep(100);
            }
        }



        private void ListeAktualisieren()
        {
            int anzahl = 0;
            duplikateSuchen.OrdnerString.Clear();

            foreach (var eintrag in duplikateSuchen.Od.EindeutigeNamen)
            {
                if (eintrag.Key.ToLower().Contains(DateiTyp))
                {
                    anzahl = eintrag.Value.Count;
                    duplikateSuchen.OrdnerString.Append(anzahl + "->" + eintrag.Key);
                    duplikateSuchen.OrdnerString.Append("\n");

                    foreach (string s in eintrag.Value)
                    {
                        duplikateSuchen.OrdnerString.Append("      " + s + "\n");
                    }
                    duplikateSuchen.OrdnerString.Append("\n");
                }
            }

            TextAnzeige = duplikateSuchen.OrdnerString.ToString();
        }




        #region AnzahlDateien
        private int _anzahlDateien;
        public int AnzahlDateien
        {
            get { return _anzahlDateien; }
            set
            {
                _anzahlDateien = value;
                OnPropertyChanged(nameof(AnzahlDateien));
            }
        }

        #endregion
               
        #region DateiTyp
        private string _dateiTyp;
        public string DateiTyp
        {
            get { return _dateiTyp; }
            set
            {
                var v = value.Split(':');
                _dateiTyp = v[1].Trim();
                OnPropertyChanged(nameof(DateiTyp));
                ListeAktualisieren();
            }
        }
        #endregion

        #region TextAnzeige
        private string _textAnzeige;
        public string TextAnzeige
        {
            get { return _textAnzeige; }
            set
            {
                _textAnzeige = value;
                OnPropertyChanged(nameof(TextAnzeige));
            }
        }

        #endregion


        #region iNotifyPeropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion iNotifyPeropertyChanged Members

    }
}
