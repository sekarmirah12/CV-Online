﻿using CV_Online;
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
using System.Windows.Shapes;

namespace CvOnline
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        MyContext contex = new MyContext();
        Client client = new Client();
        Admin admin = new Admin();
        public Login()
        {
            InitializeComponent();
        }
        

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxEmail.Text == "")
            {
                MessageBox.Show("Please insert your email");
            } else if (passwordBox.Password == "")
            {
                MessageBox.Show("Please insert your password");
            } else if (textBoxEmail.Text.Equals("") && passwordBox.Password .Equals(""))
            {
                MessageBox.Show("Please insert your email / username and password");
            }
            else
            {
                var UserClient = contex.Clients.Where(x => x.Email == textBoxEmail.Text && x.Password == passwordBox.Password).ToList();
                var UserAdmin = contex.Admins.Where(x => x.Username == textBoxEmail.Text && x.Password == passwordBox.Password).ToList();
                var UserJobCreator = contex.Job_Creators.Where(x => x.Email == textBoxEmail.Text && x.Password == passwordBox.Password).ToList();
                if (UserClient.Count != 0)
                {
                    ClientHome cl = new ClientHome();
                    cl.Show();
                    this.Close();
                    string type = textBoxEmail.Text;
                    var getData = contex.Clients.Include("Villages").
                        Include("Villages.districts").Include("Villages.districts.regencies").
                        Include("Villages.districts.regencies.provinces").SingleOrDefault(x => x.Email.Equals(textBoxEmail.Text));
                    var getClient= contex.Clients.Find(getData.Id);
                    cl.textBoxId.Text = Convert.ToString(getClient.Id);
                    cl.txtNameProfil.Text = getClient.Name;
                    cl.txtPlaceProfil.Text = getClient.Place;
                    cl.birthday.Text = getClient.Birthday.ToString();
                    cl.txtAgeProfil.Text = Convert.ToString(getClient.Age);
                    cl.txtEmailProfil.Text = getClient.Email;
                    cl.txtPasswordProfil.Text = getClient.Password;
                    cl.txtContactProfil.Text = getClient.Contact;
                    cl.txtAddressProfil.Text = getClient.Address;
                    cl.cmbProvinceProfil.Text = getClient.provinces.Name;
                    cl.cmbRegency.Text = getClient.regencies.Name;
                    cl.cmbDistrict.Text = getClient.districts.Name;
                    cl.cmbVillage.Text = getClient.villages.Name;
                     
    }
                else if (UserAdmin.Count != 0)
                {
                    MainWindow main = new MainWindow();
                    this.Close();
                    main.Show();
                }
                else if (UserJobCreator.Count != 0)
                {
                    string type = textBoxEmail.Text;
                    var getData = contex.Job_Creators.SingleOrDefault(x => x.Email.Equals(textBoxEmail.Text));
                    var getType = contex.Job_Creators.Find(getData.Id);

                    if (getType.Type.Equals("HR"))
                    {
                        HRHome hr = new HRHome();
                        hr.Show();
                        this.Close();
                    }
                    else    
                    {
                        ManagerHome mh = new ManagerHome();
                        mh.Show();
                        this.Close();
                    }
                }
            }
        }
    }
}