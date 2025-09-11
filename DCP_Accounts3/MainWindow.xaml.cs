using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace DCP_Accounts3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Auto-fill EntryDate with today's date (read-only)
            txtEntryDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private async void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtExpDetails.Text))
                {
                    MessageBox.Show("Please enter Expense Details.");
                    return;
                }

                if (cmbExpCode.SelectedItem == null)
                {
                    MessageBox.Show("Please select an Expense Code.");
                    return;
                }

                if (!int.TryParse(txtUserID.Text, out int userId))
                {
                    MessageBox.Show("Please enter a valid User ID.");
                    return;
                }

                // Prepare object to send (including EntryDate)
                var expSub = new
                {
                    ExpDetails = txtExpDetails.Text,
                    ExpCode = ((ComboBoxItem)cmbExpCode.SelectedItem).Content.ToString(),
                    UserID = userId,
                    EntryDate = txtEntryDate.Text // auto-filled, read-only
                };

                var json = JsonSerializer.Serialize(expSub);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    var response = await client.PostAsync("https://localhost:5001/api/ExpSub", content);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Data submitted successfully!");
                        txtExpDetails.Clear();
                        cmbExpCode.SelectedIndex = -1;
                        txtUserID.Clear();
                        // Reset EntryDate to current time
                        txtEntryDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {
                        MessageBox.Show("Error: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }
    }
}
