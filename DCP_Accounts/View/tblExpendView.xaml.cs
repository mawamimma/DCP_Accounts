using System.Windows;
using DCP_Accounts.ViewModel;

namespace DCP_Accounts.View
{
    public partial class tblExpendView : Window
    {
        public tblExpendView()
        {
            InitializeComponent();
            DataContext = new tblExpendViewModel(); // bind VM
        }
    }
}
