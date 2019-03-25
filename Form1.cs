using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace _152120151071_OOP2_Lab
{
    public partial class Form1 : Form
    {
        List<Staff> _item = new List<Staff>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                String Line = "";

                using (StreamReader sr = new StreamReader("Staff.txt"))
                {
                    while ((Line = sr.ReadLine()) != null)
                    {
                        string[] k = Line.Split(',');
                        for (int i = 0; i < k.Length - 4; i++)
                        {
                            Staff stf = new Staff(k[i], k[i + 1], k[i + 2], k[i + 3], Int32.Parse(k[i + 4]));
                            lstboxStaff.Items.Add(k[i] + "\t" + k[i + 1] + "\t" + k[i + 2] + "\t" + k[i + 3] + "\t" + k[i + 4]);
                            _item.Add(stf);
                        }
                    }
                }
            lstboxStaff.Sorted = true;
            _item.Sort((a, b) => a.ıd.CompareTo(b.ıd));
            if (lstboxStaff.SelectedIndex == -1)
            {
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }
            

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Staff stf = new Staff(txtID.Text, txtName.Text,txtSurname.Text,txtAdress.Text,Int32.Parse(txtSalary.Text));
            _item.Add(stf);
            lstboxStaff.Items.Add(txtID.Text + "\t" + txtName.Text + "\t" + txtSurname.Text + "\t" + txtAdress.Text + "\t" +txtSalary.Text);
            txtID.Text = "";txtName.Text = "";txtSurname.Text = "";txtAdress.Text = "";txtSalary.Text = "";
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            
        }

       

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _item.Sort((a, b) => a.ıd.CompareTo(b.ıd));
            using (TextWriter tw = new StreamWriter("Staff.txt"))
            {
                foreach (var item in _item)
                {
                    tw.WriteLine(string.Format("{0},{1},{2},{3},{4}", item.ıd, item.Name, item.Surname, item.Address, item.Salary));
                }
            }
        }

        private void lstboxStaff_DoubleClick(object sender, EventArgs e)
        {
            
            MessageBox.Show(lstboxStaff.SelectedItem.ToString(),"Staff Information");
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int a = lstboxStaff.SelectedIndex;
            _item[a].ıd = txtID.Text;
            _item[a].Name = txtName.Text;
            _item[a].Surname = txtSurname.Text;
            _item[a].Address = txtAdress.Text;
            _item[a].Salary = Int32.Parse(txtSalary.Text);

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int x = lstboxStaff.SelectedIndex;
            DialogResult dia = MessageBox.Show("Are You Sure?", "Delete", MessageBoxButtons.YesNoCancel);
            if (dia == DialogResult.Yes)
            {
                _item.RemoveAt(x);
                lstboxStaff.Items.RemoveAt(x);
            }
           
        }
        private void lstboxStaff_SelectedIndexChanged(object sender, EventArgs e)
        { 
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
            int a = lstboxStaff.SelectedIndex;
            txtID.Text = _item[a].ıd;
            txtName.Text = _item[a].Name;
            txtSurname.Text = _item[a].Surname;
            txtAdress.Text = _item[a].Address;
            txtSalary.Text = _item[a].Salary.ToString();


        }

      
    }
}
