using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelegramRemoteAccessBot
{
    public partial class Config : Form
    {
        static List<string> value = new List<string> { };
        public Config()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            value.Clear();
            if (comboBox1.Text=="disabled")
            {
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                comboBox2.Enabled = false;
            }
            else
            {
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                comboBox2.Enabled = true;
            }
        }

        private void Config_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists("./config.txt")) ayarlariDosyadanOku();
            }
            catch (Exception)
            {
                if (File.Exists("./config.txt")) File.Delete("./config.txt");
            }
            value.Clear();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            if (comboBox1.Text == "disabled")
            {
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                comboBox2.Enabled = false;
            }
            else
            {
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                comboBox2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ayarlariDosyadanOku();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ayarlariFormdanYaz();
        }
        private void ayarlariDosyadanOku()
        {
            value.Clear();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            if (System.IO.File.Exists("./config.txt"))
                using (StreamReader reader = new StreamReader("./config.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                        value.Add(line);
                    if (value[0].ToString().Trim() == "socks5") comboBox1.SelectedIndex = 1;
                    else if (value[0].ToString().Trim() == "http") comboBox1.SelectedIndex = 2;
                    else comboBox1.SelectedIndex = 0;
                    textBox2.Text = value[1].ToString().Trim();
                    textBox3.Text = value[2].ToString().Trim();
                    textBox4.Text = value[3].ToString();
                    textBox5.Text = value[4].ToString();
                    textBox6.Text = value[5].ToString().Trim();
                    textBox7.Text = value[6].ToString().Trim();
                    if (value[7].ToString().Trim()=="true")
                        comboBox2.SelectedIndex = 1;
                    else comboBox2.SelectedIndex = 0;
                }
        }
        private void ayarlariFormdanYaz()
        {
            if (File.Exists("./config.txt")) File.Delete("./config.txt");
            if (!File.Exists("./config.txt"))
                using (StreamWriter writer = new StreamWriter("./config.txt"))
                {
                    bootUp.adminUserID = textBox6.Text.ToString().Trim();
                    bootUp.adminUserID = textBox6.Text.ToString().Trim();
                    bootUp.adminUserID = textBox6.Text.ToString().Trim();
                    bootUp.adminUserID = textBox6.Text.ToString().Trim();
                    if (Application.OpenForms.OfType<Form1>().Any())
                    {
                        Form1 f1 = Application.OpenForms["Form1"] as Form1;
                        f1.textBox3.Text= textBox6.Text.ToString().Trim();
                    }
                    //MessageBox.Show(bootUp.adminUserID);
                    writer.WriteLine(comboBox1.Text.ToString().Trim());
                    writer.WriteLine(textBox2.Text.ToString().Trim());
                    writer.WriteLine(textBox3.Text.ToString().Trim());
                    writer.WriteLine(textBox4.Text.ToString().Trim());
                    writer.WriteLine(textBox5.Text.ToString().Trim());
                    writer.WriteLine(textBox6.Text.ToString().Trim());
                    writer.WriteLine(textBox7.Text.ToString().Trim());
                    writer.WriteLine(comboBox2.Text.ToString().Trim());
                    writer.Close();
                }
            value.Clear();
            MessageBox.Show("Ayarlar config dosyasına kaydedildi!","",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
