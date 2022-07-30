using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anket_2
{
    public partial class Form1 : Form
    {
        List<User> list = new List<User>();
        public Form1()
        {
            InitializeComponent();
        }

        private void ElaveEt_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Name = AdBox.Text;
            user.SurName = SoyadBox.Text;
            user.Email = EmailBox.Text;
            user.PhoneNumber = TelMasked.Text;
            user.BirthDay = DogumMasked.Text;
            list.Add(user);
            listBox1.DataSource = null;
            listBox1.DataSource = list;
            // listBox1.Items.Add(user);
            listBox1.DisplayMember = nameof(User.Name);

        }

        private void Load_Click(object sender, EventArgs e)
        {
            list = FileHelper.ReadFromJson(textBox1.Text);
            listBox1.DisplayMember = nameof(User.Name);
            listBox1.DataSource = list;
        }

        private void Save_Click(object sender, EventArgs e)
        {

            FileHelper.WriteToFile(list, textBox1.Text);
        }

        private void Deyis_Click(object sender, EventArgs e)
        {
            var user = listBox1.SelectedItem as User;
            user.Name=AdBox.Text;
            user.SurName=SoyadBox.Text;
            user.Email=EmailBox.Text;
            user.PhoneNumber=TelMasked.Text;
            user.BirthDay= DogumMasked.Text;
            listBox1.DataSource= null;
            listBox1.DataSource = list;
            listBox1.DisplayMember = nameof(User.Name);

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            var user = listBox1.SelectedItem as User;
            AdBox.Text = user.Name;
            SoyadBox.Text = user.SurName;
            EmailBox.Text = user.Email;
            DogumMasked.Text = user.BirthDay;
            TelMasked.Text = user.PhoneNumber;
            listBox1.DisplayMember = nameof(User.Name);
        }
    }
}
