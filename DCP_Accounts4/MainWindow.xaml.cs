using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace DCP_Accounts5
{
    public partial class MainWindow : Window
    {
        private readonly string apiBaseUrl = "https://localhost:5001/api/Expenditure"; // Update to your API URL

        public MainWindow()
        {
            InitializeComponent();
            txtEntryDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            LoadExpCodes();
        }

        private async void LoadExpCodes()
        {
            try
            {
                using HttpClient client = new HttpClient();
                var codes = await client.GetFromJsonAsync<string[]>(apiBaseUrl + "/expCodes");

                if (codes != null)
                {
                    cmbExpCode.Items.Clear();
                    foreach (var code in codes)
                    {
                        cmbExpCode.Items.Add(new ComboBoxItem { Content = code, Tag = code });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Expense Codes: " + ex.Message);
            }
        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbExpCode.SelectedItem == null)
                {
                    MessageBox.Show("Please select an Expense Code.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtExpDetails.Text))
                {
                    MessageBox.Show("Please enter Expense Details.");
                    return;
                }

                if (!int.TryParse(txtUserID.Text, out int userId))
                {
                    MessageBox.Show("Please enter a valid User ID.");
                    return;
                }

                if (dpExpDate.SelectedDate == null)
                {
                    MessageBox.Show("Please select an Expense Date.");
                    return;
                }

                var selectedCode = ((ComboBoxItem)cmbExpCode.SelectedItem).Tag?.ToString();
                if (string.IsNullOrEmpty(selectedCode))
                {
                    MessageBox.Show("Invalid Expense Code selected.");
                    return;
                }

                var expenditure = new
                {
                    ExpCode = selectedCode,
                    ExpDetails = txtExpDetails.Text,
                    UserID = userId,
                    ExpDate = dpExpDate.SelectedDate.Value,
                    EntryDate = DateTime.Now
                };

                string json = JsonSerializer.Serialize(expenditure);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                using HttpClient client = new HttpClient();
                var response = await client.PostAsync(apiBaseUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Data saved successfully!");

                    // Reset form
                    cmbExpCode.SelectedIndex = -1;
                    txtExpDetails.Clear();
                    txtUserID.Clear();
                    dpExpDate.SelectedDate = null;
                    txtEntryDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    MessageBox.Show("Error saving data: " + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }
    }
}
