using CvOnline;
using CvOnline.MyModel;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for ClientHome.xaml
    /// </summary>
    public partial class ClientHome : Window
    {
        MyContext context = new MyContext();
        Company company = new Company();
        Job_Detail jobdetail = new Job_Detail();
        Provinces province = new Provinces();
        Client client = new Client();
        Language language = new Language();
        Experience experience = new Experience();
        Skill skill = new Skill();
        public ClientHome()
        {
            InitializeComponent();
            TampilPos();
            TampilComp();
            TampilExperience();
            TampilLanguage();
            TampilSkill();
            TampilProvince();
            TampilRegency();
            TampilDistrict();
            TampilVillage();
            //TampilPhoto();
        }

        //public void LoadDataJobDetail()
        //{
        //    var getDataJob = context.
        //       Job_Details.Include("Villages").Where(x => x.isDelete == false).ToList();
        //    dataGridSearchJob.ItemsSource = getDataJob;
        //}

        #region Tampil
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        public void TampilPos()
        {
            //int id = Convert.ToInt16(cmbPosition.SelectedValue);
            //var getDataPosition = context.Experiences.Where(x => x.Position.Id == id).ToList();

            //cmbPosition.ItemsSource = getDataPosition;

            try
            {
                int id = Convert.ToInt16(cmbPosition.SelectedValue);
                var getData = context.Positions.ToList();
                cmbPosition.ItemsSource = getData;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }

        }

        public void TampilComp()
        {
            try
            {
                int id = Convert.ToInt16(cmbCompany.SelectedValue);
                var getDataCompany = context.Companies.ToList();
                cmbCompany.ItemsSource = getDataCompany;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }

        }
        public void TampilExperience()
        {
            //try
            //{
            //    var getData = context.Suppliers.Where(x => x.IsDelete == false).ToList();
            //    dataGrid.ItemsSource = getData;
            //    var getDataSupply = context.Suppliers.ToList();
            //    combosupplierfromitem.ItemsSource = getDataSupply;
            //    combosupplierfromtransaction.ItemsSource = getDataSupply;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.InnerException);

            //}
            var getData = context.Experiences.Where(x => x.isDelete == false).ToList();
            dataGridExperience.ItemsSource = getData;

        }

        public void TampilLanguage()
        {
            var getData = context.Languages.Where(x => x.isDelete == false).ToList();
            dataGridLanguage.ItemsSource = getData;

        }

        public void TampilSkill()
        {
            var getData = context.Skills.Where(x => x.isDelete == false).ToList();
            dataGridSkill.ItemsSource = getData;

        }

        public void TampilProvince()
        {
            try
            {
                int id = Convert.ToInt16(cmbProvinceProfil.SelectedValue);
                var getData = context.Provincies.ToList();
                cmbProvinceProfil.ItemsSource = getData;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }

        }

        public void TampilRegency()
        {
            try
            {
                int id = Convert.ToInt16(cmbRegency.SelectedValue);
                var getData = context.Regencies.ToList();
                cmbRegency.ItemsSource = getData;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }

        }

        public void TampilDistrict()
        {
            try
            {
                int id = Convert.ToInt16(cmbDistrict.SelectedValue);
                var getData = context.Districts.ToList();
                cmbDistrict.ItemsSource = getData;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }

        }

        public void TampilVillage()
        {
            try
            {
                int id = Convert.ToInt16(cmbVillage.SelectedValue);
                var getData = context.Villages.ToList();
                cmbVillage.ItemsSource = getData;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }

        }

        //public void TampilPhoto()
        //{
        //    try
        //    {
        //        txtPhoto.Text = getDataSupply;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.InnerException);

        //    }
        //}
        #endregion Tampil
        //private void dataGridSearchJob_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    object search = dataGridSearchJob.SelectedItem;
        //    cmbJob_Category.Text = (dataGridSearchJob.SelectedCells[0].Column.GetCellContent(search) as TextBlock).Text;
        //}


        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            if (cmbJobSearch.Text.Equals("Category"))
            {
                var getDataJob = context.
                Job_Details.Include("Villages").Where(x => x.Category.Contains(textBoxSearch.Text)).ToList();
                dataGridSearchJob.ItemsSource = getDataJob;
            }
            else if (cmbJobSearch.Text.Equals("Position"))
            {
                var getDataJob = context.
                Job_Details.Include("Villages").Where(x => x.Position.Contains(textBoxSearch.Text)).ToList();
                dataGridSearchJob.ItemsSource = getDataJob;
            }
            else
            {
                var getDataJob = context.
                Job_Details.Where(x => x.Company.Contains(textBoxSearch.Text)).ToList();
                dataGridSearchJob.ItemsSource = getDataJob;
            }
        }
       
        private void btnPhoto_Click(object sender, RoutedEventArgs e)
        {
            Stream checkStream = null;
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Filter = "All Image Files | *.*";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                try
                {
                    if ((checkStream = dlg.OpenFile()) != null)
                    {
                        string filename = dlg.FileName;
                        txtPhoto.Text = filename;
                        MessageBox.Show("Successfully done", filename);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Problem occured, try again later");
            }
        }

        private void dataGridExperience_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object exp = dataGridExperience.SelectedItem;
            cmbPosition.Text = (dataGridExperience.SelectedCells[2].Column.GetCellContent(exp) as TextBlock).Text;
            cmbCompany.Text = (dataGridExperience.SelectedCells[3].Column.GetCellContent(exp) as TextBlock).Text;
            txtLength.Text = (dataGridExperience.SelectedCells[4].Column.GetCellContent(exp) as TextBlock).Text;
        }

        private void dataGridLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object language = dataGridLanguage.SelectedItem;
            txtLanguage.Text = (dataGrid.SelectedCells[0].Column.GetCellContent(language) as TextBlock).Text;
        }

        private void btnAddExp_Click(object sender, RoutedEventArgs e)
        {
            dataGridExperience.Items.Add(
            new
            {
            Position_Id = cmbPosition.SelectedValue,
            Company_Id = cmbCompany.SelectedValue,
            Name = cmbPosition.Text,
            CompanyName = cmbCompany.Text,
            JobPosition = cmbPosition.Text,
            Company = cmbCompany.Text,
            Length = txtLength.Text
            });
        }

        private void btnAddLang_Click(object sender, RoutedEventArgs e)
        {
            language.Name = txtLanguage.Text;
            //context.Languages.Add(language);
            //context.SaveChanges();
            //LoadDataLanguage();

            try
            {
                context.Languages.Add(language);
                context.SaveChanges();
                TampilLanguage();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        private void btnAddSkill_Click(object sender, RoutedEventArgs e)
        {
            skill.Name = txtSkill.Text;
            try
            {
                context.Skills.Add(skill);
                context.SaveChanges();
                TampilSkill();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog op = new Microsoft.Win32.OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
                imagePhoto.Source = new BitmapImage(new Uri(op.FileName));
                txtPhoto.Text = op.FileName;
            }
        }

        private void buttonKTP_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog op = new Microsoft.Win32.OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgKTP.Source = new BitmapImage(new Uri(op.FileName));
                textBoxKTP.Text = op.FileName;
            }
        }

        private void buttonCV_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog op = new Microsoft.Win32.OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgCV.Source = new BitmapImage(new Uri(op.FileName));
                textBoxCV.Text = op.FileName;
            }
        }

        private void btnUpdateProfil_Click(object sender, RoutedEventArgs e)
        {
            var id = context.Clients.Find(Convert.ToInt16(txtIdProfil));
            id.Name = txtNameProfil.Text;
            id.Place = txtPlaceProfil.Text;
            id.Age = Convert.ToInt16(txtAgeProfil.Text);
            id.Email = txtEmailProfil.Text;
            id.Password = txtPasswordProfil.Text;
            id.Contact = txtContactProfil.Text;
            id.Collage = txtCollege.Text;
            id.Departement = txtDepartment.Text;
            id.Address = txtAddressProfil.Text;
            id.Photo = txtPhoto.Text;
            int p = Convert.ToInt16(cmbProvinceProfil.SelectedValue);
            var q = context.Provincies.Find(p);
            id.provinces = q;
            int r = Convert.ToInt16(cmbRegency.SelectedValue);
            var s = context.Regencies.Find(r);
            id.regencies = s;
            int d = Convert.ToInt16(cmbDistrict.SelectedValue);
            var getdistrict = context.Districts.Find(p);
            id.districts = getdistrict;
            int v = Convert.ToInt16(cmbVillage.SelectedValue);
            var w = context.Villages.Find(v);
            id.villages = w;

            try
            {
                context.Entry(id).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                MessageBox.Show("Modified Data is Success");
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException);
            }
        }
    }
}
