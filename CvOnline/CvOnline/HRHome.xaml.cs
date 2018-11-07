using CvOnline;
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

namespace CV_Online
{
    /// <summary>
    /// Interaction logic for HRHome.xaml
    /// </summary>
    public partial class HRHome : Window
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

        public HRHome()
        {
            InitializeComponent();
        }
        #region LoadData
        private void LoadDataCategory()
        {
            var getData = context.Categories.ToList();
            cmbCategory.ItemsSource = getData;
        }
        public void LoadDataCompany()
        {
            try
            {
                var getDataCompany = context.Companies.Where(x => x.isDelete == false).ToList();
                dataGridPostJob.ItemsSource = getDataCompany;
                cmbCompany.ItemsSource = getDataCompany;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }


        public void LoadDataJobDetail()
        {
            try
            {
                var getDataJobType = context.Job_Details.Where(x => x.isDelete == false).ToList();
                dataGridPostJob.ItemsSource = getDataJobType;
                cmbJobType.ItemsSource = getDataJobType;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }


        public void LoadDataProvince()
        {
            try
            {
                var getDataProvince = context.Provincies.Where(x => x.isDelete == false).ToList();
                dataGridPostJob.ItemsSource = getDataProvince;
                cmbProvince.ItemsSource = getDataProvince;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);

            }
        }
        public void LoadDataPostJob()
        {
            var getDataJob = context.
                Job_Details.Include("Villages").
                Include("Villages.districts").Include("Villages.districts.regencies").
                Include("Villages.districts.regencies.provinces").Where(x => x.isDelete == false).ToList();
            dataGridPostJob.ItemsSource = getDataJob;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataCompany();
            LoadDataJobDetail();
            LoadDataProvince();
            LoadDataCategory();
            LoadDataPostJob();
        }
        #endregion LoadData

        private void comboBoxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = Convert.ToInt16(cmbCategory.SelectedValue);
            var getData = context.Positions.Where(x => x.categories.Id == id).ToList();
            cmbJobPosition.ItemsSource = getData;
        }
        private void cmbProvince_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt16(cmbProvince.SelectedValue);
                var getData = context.Regencies.Where(x => x.provinces.Id == id).ToList();
                cmbRegency.ItemsSource = getData;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        private void cmbRegency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt16(cmbRegency.SelectedValue);
                var getData = context.Districts.Where(x => x.regencies.Id == id).ToList();
                cmbDistrict.ItemsSource = getData;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        private void cmbDistrict_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt16(cmbDistrict.SelectedValue);
                var getData = context.Villages.Where(x => x.districts.Id == id).ToList();
                cmbVillage.ItemsSource = getData;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt16(cmbVillage.SelectedValue);
            var getVillage= context.Villages.Find(id);
            job_detail.Last_Education = cmbLastEducation.Text;
            job_detail.Max_Age = Convert.ToInt16(txtAge.Text);
            job_detail.Work_Experience = txtWork.Text;
            job_detail.Type = cmbJobType.Text;
            job_detail.Salary = Convert.ToInt16(txtSalary.Text);
            job_detail.Villages = getVillage;
            job_detail.Category = cmbCategory.Text;
            job_detail.Position = cmbJobPosition.Text;
            job_detail.Company = cmbCompany.Text;
            context.Job_Details.Add(job_detail);
            context.SaveChanges();
            LoadDataPostJob();
        }
        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxSearchBy.Text.Equals("Category"))
            {
                var getDataJob = context.
                Job_Details.Where(x => x.Category.Contains(textBoxSearch.Text)).ToList();
                dataGridSearchJob.ItemsSource = getDataJob;
            } else if (comboBoxSearchBy.Text.Equals("Position"))
            {
                var getDataJob = context.
                Job_Details.Where(x => x.Position.Contains(textBoxSearch.Text)).ToList();
                dataGridSearchJob.ItemsSource = getDataJob;
            }else
            {
                var getDataJob = context.
                Job_Details.Where(x => x.Company.Contains(textBoxSearch.Text)).ToList();
                dataGridSearchJob.ItemsSource = getDataJob;
            }
        }

        private void dataGridSearchJob_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var selectedJob = dataGridSearchJob.SelectedItem;
            int id = Convert.ToInt16((dataGridSearchJob.SelectedCells[0].Column.GetCellContent(selectedJob) as TextBlock).Text);

        }
    }
}
