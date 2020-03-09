namespace DuplikateSuchen.ViewModel
{
    using System.ComponentModel;
    using System.Threading;

    public class VisuAnzeigen : INotifyPropertyChanged
    {
        private readonly Model.DuplikateSuchen duplikate;
        private readonly MainWindow mainWindow;
        public VisuAnzeigen(MainWindow mw, Model.DuplikateSuchen d)
        {
            mainWindow = mw;
            duplikate = d;
          
          
         

            System.Threading.Tasks.Task.Run(() => VisuAnzeigenTask());
        }
        private void VisuAnzeigenTask()
        {
            while (true)
            {
              
                Thread.Sleep(10);
            }
        }
      

        #region iNotifyPeropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion iNotifyPeropertyChanged Members
    }
}
