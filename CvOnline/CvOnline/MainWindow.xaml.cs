using CV_Online;
using CvOnline.MyModel;
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

namespace CvOnline
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MyContext context = new MyContext();
        Client clients = new Client();
        Category categories = new Category();
        Company companies = new Company();
        Districts districts = new Districts();
        History_Client history_clients = new History_Client();
        Interview interviews = new Interview();
        Job_Creator job_creator = new Job_Creator();
        Job_Detail job_detail = new Job_Detail();
        Position positions = new Position();
        Provinces provinces = new Provinces();
        Regencies regencies = new Regencies();
        Villages villages = new Villages();

        public MainWindow()
        {
            InitializeComponent();
        }


        #region selectionchanged
        private void comboBoxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = Convert.ToInt16(comboBoxCategory.SelectedValue);
            var getData = context.Positions.Where(x => x.categories.Id == id).ToList();
            comboBoxPosition.ItemsSource = getData;
        }
        #endregion

        #region load data
        private void load_ComboBoxCategory()
        {
            var getData = context.Categories.ToList();
            comboBoxCategory.ItemsSource = getData;
        }
        public void load_ComboBoxPosition()
        {
            var getData = context.Positions.Include("Categories").ToList();
            comboBoxPosition.ItemsSource = getData;
        }
        public void load_ComboBoxLocation()
        {
            var getData = context.Provincies.ToList();
            comboBoxLocation.ItemsSource = getData;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            load_ComboBoxCategory();
            load_ComboBoxPosition();
            load_ComboBoxLocation();
        }
        #endregion
    }
}
