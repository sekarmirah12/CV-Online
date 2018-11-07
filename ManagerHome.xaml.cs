using CV_Online.Base_Context;
using CV_Online.Models;
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
    /// Interaction logic for ManagerHome.xaml
    /// </summary>
    public partial class ManagerHome : Page
    {
        MyContext context = new MyContext();
        Job_Detail jobdetail = new Job_Detail();
        Categories category = new Categories();
        Positions position = new Positions();
        Client client = new Client();
        Interview interview = new Interview();
        Regencies regency = new Regencies();

        public ManagerHome()
        {
            InitializeComponent();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var data = dataGrid.SelectedItem;
            string PositionName = (dataGrid.SelectedCells[0].Column.GetCellContent(data) as TextBlock).Text;
            txtJobPosition.Text = position.Name;
            string ClientName = (dataGrid.SelectedCells[1].Column.GetCellContent(data) as TextBlock).Text;
            txtClient.Text = client.Name;
            string schedule = (dataGrid.SelectedCells[2].Column.GetCellContent(data) as TextBlock).Text;
            txtSchedule.Text = Convert.ToString(interview.Schedule);
            string address = (dataGrid.SelectedCells[3].Column.GetCellContent(data) as TextBlock).Text;
            txtAddress.Text = interview.Address;
            //string regency = (dataGrid.SelectedCells[4].Column.GetCellContent(data) as TextBlock).Text;
            //txtRegency.Text = regency.Name;
            string result = (dataGrid.SelectedCells[5].Column.GetCellContent(data) as TextBlock).Text;
            cmbResult.Text = interview.Result;
            string comment = (dataGrid.SelectedCells[6].Column.GetCellContent(data) as TextBlock).Text;
            txtComment.Text = interview.Comment;

            //if (e.RowIndex >=0)
            //{
            //    DataGrid row = this.dataGrid.Rows[e.RowIndex];

            //    txtJobPosition.Text = row.Cells["Name"].Value.ToString();
            //    txtClient.Text = row.Cells["Name"].Value.ToString();
            //    txtSchedule.Text = row.Cells["Name"].Value.ToString();
            //    txtAddress.Text = row.Cells["Name"].Value.ToString();
            //    cmbResult.Text = row.Cells["Name"].Value.ToString();
            //    txtComment.Text = row.Cells["Name"].Value.ToString();
            //}
        }
    }
}
