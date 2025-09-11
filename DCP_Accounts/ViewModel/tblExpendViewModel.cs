using DCP_Accounts.Model;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DCP_Accounts.ViewModel
{
    public class tblExpendViewModel
    {
        public tblExpendModel tblExpendModel { get; set; }
        public ICommand SaveCommand { get; }

        private readonly HttpClient _httpClient;

        public tblExpendViewModel()
        {
            tblExpendModel = new tblExpendModel();
            SaveCommand = new RelayCommand(async _ => await SaveAsync());

            // Replace with your API base URL
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7163")
            };
        }

        private async Task SaveAsync()
        {
            try
            {
                // Serialize manually instead of PostAsJsonAsync
                var json = JsonSerializer.Serialize(tblExpendModel);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("api/tblExpend", content);

                if (response.IsSuccessStatusCode)
                {
                    System.Windows.MessageBox.Show("Data sent to API successfully!");
                    tblExpendModel = new tblExpendModel(); // Reset form
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    System.Windows.MessageBox.Show("API Error: " + error);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Exception: " + ex.Message);
            }
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Func<object, Task> _executeAsync;

        public RelayCommand(Func<object, Task> executeAsync)
        {
            _executeAsync = executeAsync;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;
        public async void Execute(object parameter) => await _executeAsync(parameter);
    }
}
