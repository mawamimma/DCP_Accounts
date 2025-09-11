using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows;
using Newtonsoft.Json;

namespace DCP_Accounts2
{
    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient;

        public MainWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:5001/api/") };
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            dpEntryDate.SelectedDate = DateTime.Now;
            await LoadDataAsync();
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtExpCode.Text) || string.IsNullOrWhiteSpace(txtExpDetails.Text) || string.IsNullOrWhiteSpace(txtUserID.Text))
            {
                MessageBox.Show("Please fill all fields!");
                return;
            }

            var data = new ExpendHead
            {
                ExpCode = txtExpCode.Text,
                ExpDetails = txtExpDetails.Text,
                UserID = txtUserID.Text,
                EntryDate = dpEntryDate.SelectedDate ?? DateTime.Now
            };

            string json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("ExpendHead", content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Saved Successfully!");
                ClearForm();
                await LoadDataAsync();
            }
            else
            {
                MessageBox.Show("Error saving data!");
            }
        }

        private async System.Threading.Tasks.Task LoadDataAsync()
        {
            var response = await _httpClient.GetAsync("ExpendHead");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<List<ExpendHead>>(json);
                dgData.ItemsSource = list;
            }
        }

        private void ClearForm()
        {
            txtExpCode.Text = "";
            txtExpDetails.Text = "";
            txtUserID.Text = "";
            dpEntryDate.SelectedDate = DateTime.Now;
        }
    }

    public class ExpendHead
    {
        public string ExpCode { get; set; } = string.Empty;
        public string ExpDetails { get; set; } = string.Empty;
        public string UserID { get; set; } = string.Empty;
        public DateTime EntryDate { get; set; }
    }
}
