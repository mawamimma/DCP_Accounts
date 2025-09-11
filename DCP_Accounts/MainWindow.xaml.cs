using System;
using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Set EntryDate to today automatically
            dpEntryDate.SelectedDate = DateTime.Today;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string userId = txtUserID.Text;
            string password = pwdPassword.Password;
            string phone = txtPhoneNumber.Text;
            string empID = txtEmployeeID.Text;
            string entryBy = txtEntryBy.Text;
            DateTime? entryDate = dpEntryDate.SelectedDate;

            MessageBox.Show($"User ID: {userId}\nPassword: {password}\nPhone: {phone}\nEmployee ID: {empID}\nEntry By: {entryBy}\nEntry Date: {entryDate?.ToString("yyyy-MM-dd")}");
        }

        private void ResetPassword_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show("Reset password clicked!");
        }
    }
}
