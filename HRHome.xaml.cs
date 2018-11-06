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
    public partial class HRHome : Page
    {
        Base_Context.MyContext context = new Base_Context.MyContext();
        Models.Company company = new Models.Company();
        Models.Job_Detail jobdetail = new Models.Job_Detail();
        Models.Job_List joblist = new Models.Job_List();
        Models.Provinces province = new Models.Provinces();
        Models.Regencies regency = new Models.Regencies();
        Models.Districts district = new Models.Districts();
        Models.Villages village = new Models.Villages();
        public HRHome()
        {
            InitializeComponent();
            LoadDataCompany();
            LoadDataJobDetail();
            LoadDataJobList();
            LoadDataProvince();
            LoadDataRegency();
            LoadDataDistrict();
            LoadDataVillage();
        }
        #region LoadData
        public void LoadDataCompany()
        {
            try
            {
                var getDataCompany = context.Job_Details.Where(x => x.IsDelete == false).ToList();
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
                var getDataJobType = context.Job_Details.Where(x => x.IsDelete == false).ToList();
                dataGridPostJob.ItemsSource = getDataJobType;
                cmbJobType.ItemsSource = getDataJobType;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        public void LoadDataJobList()
        {
            try
            {
                var getDataJobPos = context.Job_Lists.Where(x => x.IsDelete == false).ToList();
                dataGridPostJob.ItemsSource = getDataJobPos;
                cmbJobPosition.ItemsSource = getDataJobPos;
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
                var getDataProvince = context.Provinces.Where(x => x.IsDelete == false).ToList();
                dataGridPostJob.ItemsSource = getDataProvince;
                cmbProvince.ItemsSource = getDataProvince;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);

            }
        }

        public void LoadDataRegency()
        {
            try
            {
                var getDataRegency = context.Provinces.Where(x => x.IsDelete == false).ToList();
                dataGridPostJob.ItemsSource = getDataRegency;
                cmbRegency.ItemsSource = getDataRegency;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);

            }
        }

        public void LoadDataDistrict()
        {
            try
            {
                var getDataDistrict = context.Regencies.Where(x => x.IsDelete == false).ToList();
                dataGridPostJob.ItemsSource = getDataDistrict;
                cmbDistrict.ItemsSource = getDataDistrict;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);

            }
        }

        public void LoadDataVillage()
        {
            try
            {
                var getDataVillage = context.Districts.Where(x => x.IsDelete == false).ToList();
                dataGridPostJob.ItemsSource = getDataVillage;
                cmbVillage.ItemsSource = getDataVillage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);

            }
        }
        #endregion LoadData
        //private void cmbJobType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    try
        //    {
        //        int id = Convert.ToInt16(cmbJobType.SelectedValue);
        //        var getDataJobType = context.Job_Details.Find(id);

        //        cmbJobType.ItemsSource = Convert.ToString(getDataJobType.Type);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.InnerException);
        //    }
        //}

        private void cmbJobPosition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt16(cmbJobPosition.SelectedValue);
                var getDataJobPos = context.Job_Lists.Find(id);

                cmbJobPosition.ItemsSource = Convert.ToString(getDataJobPos.Job_Position);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }
        private void cmbCompany_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt16(cmbCompany.SelectedValue);
                var getDataCompany = context.Job_Details.Where(x => x.companies.Id == id).ToList();

                cmbCompany.ItemsSource = getDataCompany;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        private void cmbProvince_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt16(cmbProvince.SelectedValue);
                var getDataRegency = context.Regencies.Where(x => x.provinces.Id == id).ToList();

                cmbRegency.ItemsSource = getDataRegency;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        private void cmbRegency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //try
            //{
            //    int id = Convert.ToInt16(cmbRegency.SelectedValue);
            //    var getDataDistrict = context.Regencies.Find(id);

            //    cmbDistrict.Text = Convert.ToString(getDataDistrict.Name);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.InnerException);
            //}

            try
            {
                int id = Convert.ToInt16(cmbRegency.SelectedValue);
                var getDataDistrict = context.Districts.Where(x => x.regencies.Id == id).ToList();

                cmbDistrict.ItemsSource = getDataDistrict;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        private void cmbDistrict_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //try
            //{
            //    int id = Convert.ToInt16(cmbDistrict.SelectedValue);
            //    var getDataVillage = context.Villages.Find(id);

            //    cmbVillage.Text = Convert.ToString(getDataVillage.Name);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.InnerException);
            //}

            try
            {
                int id = Convert.ToInt16(cmbDistrict.SelectedValue);
                var getDataVillage = context.Villages.Where(x => x.districts.Id == id).ToList();

                cmbVillage.ItemsSource = getDataVillage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        private void cmbVillage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt16(cmbVillage.SelectedValue);
                var getData = context.Villages.Find(id);
                cmbVillage.Text = Convert.ToString(getData.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        private void dataGridPostJob_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object item = dataGridPostJob.SelectedItem;
            txtHRName.Text = (dataGridPostJob.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            cmbJobPosition.Text = (dataGridPostJob.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            cmbJobType.Text = (dataGridPostJob.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            cmbLastEducation.Text = (dataGridPostJob.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            txtAge.Text = (dataGridPostJob.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
            txtWork.Text = (dataGridPostJob.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
            txtSalary.Text = (dataGridPostJob.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
            cmbCompany.Text = (dataGridPostJob.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text;
            cmbProvince.Text = (dataGridPostJob.SelectedCells[8].Column.GetCellContent(item) as TextBlock).Text;
            cmbRegency.Text = (dataGridPostJob.SelectedCells[9].Column.GetCellContent(item) as TextBlock).Text;
            cmbDistrict.Text = (dataGridPostJob.SelectedCells[10].Column.GetCellContent(item) as TextBlock).Text;
            cmbVillage.Text = (dataGridPostJob.SelectedCells[11].Column.GetCellContent(item) as TextBlock).Text;
        }
    }
}
