using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace PersonalExpenseApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ExpenseDataContext e;// Object for LINQ
        public MainWindow()
        {
            InitializeComponent();
            GetData();
        }

        /// <summary>
        /// Method to get and refresh the data by refreshing the object.
        /// </summary>
        private void GetData()
        {
            e = new ExpenseDataContext(); //Initialises the object/ refreshes the object
            TravelGrid.ItemsSource = e.Travels;
            LeisureGrid.ItemsSource = e.Leisures;
            MiscGrid.ItemsSource = e.Miscs;
            IncomeGrid.ItemsSource = e.Incomes;
            SummaryGrid.ItemsSource = e.Summaries;
        }

        /// <summary>
        /// This method is to update the values in the database.
        /// </summary>
        private void UpdateSum()
        {
            e.SubmitChanges();
            e.UpdateSummary();     //Stored procedure to update the summary page           
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            UpdateSum();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            GetData();
        }

    }
}
