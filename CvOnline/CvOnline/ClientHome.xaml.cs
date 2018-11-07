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
        public ClientHome()
        {
            InitializeComponent();
            
        }

        //public void LoadDataJobDetail()
        //{
        //    var getDataJob = context.
        //       Job_Details.Include("Villages").Where(x => x.isDelete == false).ToList();
        //    dataGridSearchJob.ItemsSource = getDataJob;
        //}

       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

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
