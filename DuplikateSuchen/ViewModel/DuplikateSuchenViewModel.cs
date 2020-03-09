namespace DuplikateSuchen.ViewModel
{
    using DuplikateSuchen.Commands;
    using System.Windows.Input;

    public class DuplikateSuchenViewModel
    {

        public readonly Model.DuplikateSuchen duplikate;
        public VisuAnzeigen ViAnzeige { get; set; }
        public DuplikateSuchenViewModel(MainWindow mainWindow)
        {
            duplikate = new Model.DuplikateSuchen(mainWindow);
            ViAnzeige = new VisuAnzeigen(mainWindow, duplikate);
        }

        public Model.DuplikateSuchen Duplikate { get { return duplikate; } }


        #region SucheStarten
        private ICommand _sucheStarten;
        public ICommand SucheStarten
        {
            get
            {
                if (_sucheStarten == null)
                {
                    _sucheStarten = new RelayCommand(p => duplikate.SucheStarten(), p => true);
                }
                return _sucheStarten;
            }
        }
        #endregion

    }
}
