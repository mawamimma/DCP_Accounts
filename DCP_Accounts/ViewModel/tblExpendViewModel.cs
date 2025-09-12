// DCP_Accounts/ViewModel/tblExpendViewModel.cs
using DCP_Accounts.Model;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace DCP_Accounts.ViewModel
{
    public class tblExpendViewModel
    {
        public tblExpendModel tblExpendModel { get; set; }
        public ICommand SaveCommand { get; }

        private readonly HttpClient _httpClient;
        private const string Path = "api/Expend"; // <-- matches your controller route

        public tblExpendViewModel()
        {
            tblExpendModel = new tblExpendModel();

            // Use the API URL you pinned in launchSettings.json:
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7149") };

            SaveCommand = new RelayCommand(async _ => await SaveAsync());
        }

        private async Task SaveAsync()
        {
            try
            {
                // If EntryDate left empty in UI, let API set it—no need to prefill here
                var resp = await _httpClient.PostAsJsonAsync(Path, tblExpendModel);

                if (resp.IsSuccessStatusCode)
                {
                    MessageBox.Show("Data sent to API successfully!");
                    tblExpendModel = new tblExpendModel(); // optional: reset
                    return;
                }

                // Show details to debug quickly
                var body = await resp.Content.ReadAsStringAsync();
                var msg = $"API Error\nURL: {_httpClient.BaseAddress}{Path}\n" +
                          $"Status: {(int)resp.StatusCode} {resp.ReasonPhrase}\n" +
                          $"Body: {body}";
                MessageBox.Show(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Func<object, Task> _executeAsync;
        public RelayCommand(Func<object, Task> executeAsync) => _executeAsync = executeAsync;

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => true;
        public async void Execute(object parameter) => await _executeAsync(parameter);
    }
}
