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

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            listele();
        }
        public void listele()
        {
            char[] renkler = new char[4];
            string satir;
            StreamReader sr = new StreamReader("veriler.txt");
            while(!sr.EndOfStream)
            {
                satir = sr.ReadLine();
                listBox1.Items.Add(satir);
            }
            sr.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string newlines = "";
            string oku = "";
            char[] renkler = new char[4];
            StreamReader ar = new StreamReader("veriler.txt");
            StreamWriter ye = new StreamWriter("veriler2.txt");
            newlines = listBox1.GetItemText(listBox1.SelectedItem);
            if (listBox1.SelectedItem == null)
                MessageBox.Show("Kayıt silmek için birini seçiniz.");
            else
                while(!ar.EndOfStream)
                {
                    oku = ar.ReadLine();
                    if (newlines == oku)
                        continue;
                    else
                        ye.WriteLine(oku);    
                }
            if(newlines != "")
                MessageBox.Show("Kayıt Silme Başarılı");

            listBox1.Items.Remove(newlines);
            ar.Close();
            ye.Close();
            File.Delete("veriler.txt");
            File.Move("veriler2.txt", "veriler.txt");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 anaMenu = new Form1();
            anaMenu.Show();
        }
    }
}
