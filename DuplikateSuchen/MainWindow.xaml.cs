using System.Windows;

namespace DuplikateSuchen
{

    public partial class MainWindow : Window
    {

        private readonly ViewModel.DuplikateSuchenViewModel duplikateSuchenViewModel;

        public MainWindow()
        {

            duplikateSuchenViewModel = new ViewModel.DuplikateSuchenViewModel(this);
            InitializeComponent();
            DataContext = duplikateSuchenViewModel;
        }
    }
}