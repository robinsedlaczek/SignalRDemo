using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.AspNet.SignalR.Client;

namespace SignalRClients.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HubConnection _connection;
        private IHubProxy _proxy;

        public ObservableCollection<AccountData> AccountDataRows { get; set; }

        public MainWindow()
        {
            AccountDataRows = new ObservableCollection<AccountData>();

            DataContext = this;

            InitializeComponent();

            ConnectToPlanningGridHub();
        }

        private void ConnectToPlanningGridHub()
        {
            _connection = new HubConnection("http://localhost:8082/");
            _connection.TraceLevel = TraceLevels.All;
            _connection.TraceWriter = Console.Out;

            _proxy = _connection.CreateHubProxy("PlanningGridHub");

            /*await*/ _connection.Start();

            _proxy.On<string, decimal[]>("AccountDataChanged", (accountId, values) =>
            {
                var row = new AccountData()
                {
                    AccountId = accountId,
                    Jan = values[0], Feb = values[1], Mar = values[2], Apr = values[3], May = values[4], Jun = values[5],
                    Jul = values[6], Aug = values[7], Sep = values[8], Oct = values[9], Nov = values[10], Dec = values[11]
                };

                Dispatcher.Invoke(() => AccountDataRows.Add(row));
            });
        }

        private void OnSaveButtonClick(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() => SaveValuesToServer());
        }

        private async Task SaveValuesToServer()
        {
            decimal[] values;
            var accountId = ReadValuesFromInputFields(out values);

            bool success = await _proxy.Invoke<bool>("SaveAccountData", accountId, values);

            ClearInputFields();
        }

        private string ReadValuesFromInputFields(out decimal[] values)
        {
            var accountId = string.Empty;

            Dispatcher.Invoke(() => accountId = AccountIdTextBox.Text);

            values = new decimal[]
            {
                Dispatcher.Invoke(() => decimal.Parse(JanTextBox.Text)),
                Dispatcher.Invoke(() => decimal.Parse(FebTextBox.Text)),
                Dispatcher.Invoke(() => decimal.Parse(MarTextBox.Text)),
                Dispatcher.Invoke(() => decimal.Parse(AprTextBox.Text)),
                Dispatcher.Invoke(() => decimal.Parse(MayTextBox.Text)),
                Dispatcher.Invoke(() => decimal.Parse(JunTextBox.Text)),
                Dispatcher.Invoke(() => decimal.Parse(JulTextBox.Text)),
                Dispatcher.Invoke(() => decimal.Parse(AugTextBox.Text)),
                Dispatcher.Invoke(() => decimal.Parse(SepTextBox.Text)),
                Dispatcher.Invoke(() => decimal.Parse(OctTextBox.Text)),
                Dispatcher.Invoke(() => decimal.Parse(NovTextBox.Text)),
                Dispatcher.Invoke(() => decimal.Parse(DecTextBox.Text))
            };

            return accountId;
        }

        private void ClearInputFields()
        {
            Dispatcher.Invoke(() =>
            {
                AccountIdTextBox.Text = "-";
                JanTextBox.Text = "0";
                FebTextBox.Text = "0";
                MarTextBox.Text = "0";
                AprTextBox.Text = "0";
                MayTextBox.Text = "0";
                JunTextBox.Text = "0";
                JulTextBox.Text = "0";
                AugTextBox.Text = "0";
                SepTextBox.Text = "0";
                OctTextBox.Text = "0";
                NovTextBox.Text = "0";
                DecTextBox.Text = "0";
            });
        }

        private void OnGenerateRandomNumbersButtonClick(object sender, RoutedEventArgs e)
        {
            var random = new Random();

            AccountIdTextBox.Text = Guid.NewGuid().ToString().Substring(0, 12);
            JanTextBox.Text = random.Next(2000).ToString();
            FebTextBox.Text = random.Next(2000).ToString();
            MarTextBox.Text = random.Next(2000).ToString();
            AprTextBox.Text = random.Next(2000).ToString();
            MayTextBox.Text = random.Next(2000).ToString();
            JunTextBox.Text = random.Next(2000).ToString();
            JulTextBox.Text = random.Next(2000).ToString();
            AugTextBox.Text = random.Next(2000).ToString();
            SepTextBox.Text = random.Next(2000).ToString();
            OctTextBox.Text = random.Next(2000).ToString();
            NovTextBox.Text = random.Next(2000).ToString();
            DecTextBox.Text = random.Next(2000).ToString();

        }
    }
}
