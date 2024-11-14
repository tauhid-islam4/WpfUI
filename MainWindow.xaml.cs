using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Person> PeopleList { get; set; }

        private DispatcherTimer _timer;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            // Initialize data for ListView and DataGrid
            PeopleList = new ObservableCollection<Person>
            {
                new Person { ID = 1, Name = "John Doe", Age = 30 },
                new Person { ID = 2, Name = "Jane Smith", Age = 25 },
                new Person { ID = 3, Name = "Sam Brown", Age = 35 }
            };

            // Set up timer
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimerText.Text = $"Time: {DateTime.Now:HH:mm:ss}";
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }

    // Person class for data binding
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}