namespace DuplikateSuchen.ViewModel
{
    using DuplikateSuchen.Commands;
    using System.Windows.Input;

    public class DuplikateSuchenViewModel
    {
        public readonly Model.DuplikateSuchen duplikateSuchen;
        public VisuAnzeigen ViAnzeige { get; set; }
        public DuplikateSuchenViewModel(MainWindow mainWindow)
        {
            duplikateSuchen = new Model.DuplikateSuchen();
            ViAnzeige = new VisuAnzeigen(mainWindow, duplikateSuchen);
        }

        public Model.DuplikateSuchen DuplikateSuchen { get { return duplikateSuchen; } }


        #region SucheStarten
        private ICommand _sucheStarten;
        public ICommand SucheStarten
        {
            get
            {
                if (_sucheStarten == null)
                {
                    _sucheStarten = new RelayCommand(p => duplikateSuchen.SucheStarten(), p => true);
                }
                return _sucheStarten;
            }
        }
        #endregion
    }
}
