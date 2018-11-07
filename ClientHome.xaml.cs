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
    public partial class ClientHome : Page
    {
        Base_Context.MyContext context = new Base_Context.MyContext();
        Models.Company company = new Models.Company();
        Models.Job_Detail jobdetail = new Models.Job_Detail();
        Models.Job_List joblist = new Models.Job_List();
        Models.Provinces province = new Models.Provinces();
        public ClientHome()
        {
            InitializeComponent();
            //LoadDataCompany();
            LoadDataJobDetail();
            LoadDataJobList();
            LoadDataProvince();
        }

        //public void LoadDataCompany()
        //{
        //    try
        //    {
        //        var getData = context.Companies.Where(x => x.IsDelete == false).ToList();
        //        dataGrid.ItemsSource = getData;
        //        var getDataSupply = context.Companies.ToList();
        //        cmb.ItemsSource = getDataSupply;
        //        combosupplierfromtransaction.ItemsSource = getDataSupply;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.InnerException);

        //    }
        //}

        public void LoadDataJobDetail()
        {
            try
            {
                var getData = context.Job_Details.Where(x => x.IsDelete == false).ToList();
                dataGridSearchJob.ItemsSource = getData;
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
                var getData = context.Job_Lists.Where(x => x.IsDelete == false).ToList();
                dataGridSearchJob.ItemsSource = getData;
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
                var getData = context.Provinces.Where(x => x.IsDelete == false).ToList();
                dataGridSearchJob.ItemsSource = getData;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);

            }
        }

        private void dataGridSearchJob_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object search = dataGridSearchJob.SelectedItem;
            cmbJob_Category.Text = (dataGridSearchJob.SelectedCells[0].Column.GetCellContent(search) as TextBlock).Text;
            cmbProvince1.Text = (dataGridSearchJob.SelectedCells[1].Column.GetCellContent(search) as TextBlock).Text;
            cmbJob_Type.Text = (dataGridSearchJob.SelectedCells[2].Column.GetCellContent(search) as TextBlock).Text;
         
        }

        private void cmbJob_Category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt16(cmbJob_Category.SelectedValue);
                var getData = context.Job_Details.Where(x => x.job_lists.Id == id).ToList();
                cmbJob_Category.ItemsSource = getData;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        private void cmbProvince1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt16(cmbProvince1.SelectedValue);
                var getData = context.Provinces.Find(id);
                cmbProvince1.ItemsSource = Convert.ToString(getData.Name);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        private void cmbJob_Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt16(cmbJob_Type.SelectedValue);
                var getData = context.Job_Details.Find(id);
                cmbJob_Type.ItemsSource = Convert.ToString(getData.Type);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }

        }

        private void btnCV_Click(object sender, RoutedEventArgs e)
        {
            Stream checkStream = null;
            //   OpenFileDialog op1 = new OpenFileDialog();
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Filter = "All Image Files | *.*";
            //dlg.Filter = "(*.pfw)|*.pfw|All files (*.*)|*.*";
            Nullable<bool> result = dlg.ShowDialog();
            // if ((bool)dlg.ShowDialog())
            if (result == true)
            {
                try
                {
                    if ((checkStream = dlg.OpenFile()) != null)
                    {
                        //   MyImage.Source = new BitmapImage(new Uri(dlg.FileName, UriKind.Absolute));
                        //listBox1.Items.Add(openFileDialog.FileName);
                        string filename = dlg.FileName;
                        txtCV.Text = filename;
                        // tb_file.AppendText(dlg.FileName.ToString());
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

        private void btnKTP_Click(object sender, RoutedEventArgs e)
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
                        txtKTP.Text = filename;
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
    }
}
