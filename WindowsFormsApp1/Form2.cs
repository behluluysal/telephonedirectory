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
    public partial class Form2 : Form
    {
        private bool isPressed1 = false;  // Bu kısım enter a basıldığında progress barın 1 ilerlemesini sağlamak için var.
        private bool isPressed2 = false;  
        private bool isPressed3 = false;
        private bool isPressed4 = false;
        private bool isPressed5 = false;
        private bool isPressed6 = false;  

        public Form2()
        {
            InitializeComponent();  //Kayıt sırasında enter tuşuna basılmadan bir sonraki sekmelere ulaşmayı engellemek için
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
        }

        public string renkKontrol(int a) //txt dosyasından okunan renkler string e dönüştürülüyor.
        {
            if (a == 0)
                return "k";
            else if (a == 1)
                return "m";
            return "y";
        }

       

        private void button2_Click(object sender, EventArgs e) // Ana Menüye dönmek için
        {
            this.Close();
            Form1 anamenu = new Form1();
            anamenu.Show();
        }

        private void button1_Click(object sender, EventArgs e)  //Kayıt ekle butonu
        {
            {
                StreamWriter dosyaYaz = File.AppendText("veriler.txt");  
                if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1 && comboBox3.SelectedIndex != -1
                    && textBox1.Text != "" &&   textBox2.Text != "") // Eğer boş bırakılan bir sekme varsa hata mesajı vermek için.
                {
                    if (textBox3.Text == "") // Numara eklenmemişse Numara yok olarak dolduruluyor.
                        textBox3.Text = "Numara Yok";
                    dosyaYaz.WriteLine(renkKontrol(comboBox1.SelectedIndex) + renkKontrol(comboBox2.SelectedIndex)
                    + renkKontrol(comboBox3.SelectedIndex) + " " + textBox1.Text + " " + textBox2.Text + " " + textBox3.Text);
                    dosyaYaz.Flush(); //kayıt tamamlanıyor.
                }
                else
                    MessageBox.Show("Lütfen Yıldızlı Alanları Doldurunuz."); //boş bırakılan yer varsa hata mesajı veriliyor.
                dosyaYaz.Close();
                if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1 && comboBox3.SelectedIndex != -1
                    && textBox1.Text != "" && textBox2.Text != "")
                {
                    MessageBox.Show("Kayıt Tamamlandı.");
                    this.Close();
                    Form2 cleanForm2 = new Form2();
                    cleanForm2.Show();
                }
            }

        }

        private void Form2_Load(object sender, EventArgs e) // Doldurulması gereken kutuların özellikleri
        {
            textBox1.MaxLength = 10;
            textBox2.MaxLength = 10;
            textBox3.MaxLength = 11;
            progressBar1.Maximum = 102; //Doldurulması gereken 6 yer olduğu için progressbar limiti 102/6=17
            progressBar1.Step = 17;
            progressBar1.Style = ProgressBarStyle.Continuous;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) //İsim kısmı
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
            if (Convert.ToInt32(e.KeyChar) == 13 && textBox1.Text != "" && !isPressed1)
            {
                isPressed1 = true;
                progressBar1.PerformStep();
                textBox2.Enabled = true;
                textBox2.Focus();
            }
                
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e) // Soyisim Kısmı
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
            if (Convert.ToInt32(e.KeyChar) == 13 && textBox1.Text != "" && !isPressed2)
            {
                isPressed2 = true;
                progressBar1.PerformStep();
                textBox3.Enabled = true;
                textBox3.Focus();
            }

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e) // Numara kısmı
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //Numara kısmına sadece rakam girilebiliyor. Kod benim kodum istediğim gibi ayarlarım.
            if (Convert.ToInt32(e.KeyChar) == 13 && textBox2.Text != "" && !isPressed3)
            {
                isPressed3 = true;
                progressBar1.PerformStep();
                comboBox1.Enabled = true;
                comboBox1.Focus();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //Renk1
        {
            if(!isPressed4 && comboBox1.SelectedIndex != -1)
            {
                isPressed4 = true;
                progressBar1.PerformStep();
            }
            comboBox2.Enabled = true;
            comboBox2.Focus();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) //Renk2
        {
            if(!isPressed5 && comboBox2.SelectedIndex != -1)
            {
                isPressed5 = true;
                progressBar1.PerformStep();
            }
            comboBox3.Enabled = true;
            comboBox3.Focus();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) // Renk3
        {
            if (!isPressed6 && comboBox3.SelectedIndex != -1)
            {
                isPressed6 = true;
                progressBar1.PerformStep();
                button1.Focus();
            }

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e) //Renk kutularında enter'a basmayı açabilmek için
        {
            e.Handled = true;
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

    }
}
