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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listele();
        }

        public void listele()
        {
            string satir;
            string[] kayitlar;
            int kelimeSirasi = 0; // Listeleme kısmında kelimeleri farklı renge boyamak için.
            int satirSirasi = 0;  // listeleme kısmında bold ve normal karakterleri ayırmak için.
            char[] renkler = new char[4]; // txt dosyasından renk kısmını ve 1 birim boşluğu ayırmak için.
            StreamWriter dosya = new StreamWriter("veriler.txt",true);
            dosya.Close();
            StreamReader dosyaOku = new StreamReader("veriler.txt");
            while (!dosyaOku.EndOfStream) //txt dosyası okunuyor
            {
                dosyaOku.ReadBlock(renkler, 0, 4); //renkler char dizisine alınıyor.
                satir = dosyaOku.ReadLine(); //satırlar okutuluyor
                kayitlar = satir.Split(' '); // kelimeler ayırılıyor
                kelimeSirasi = 0; // yeni satıra geçtiğinde kelimesırası 0 lanıyor.
                satirSirasi++; // ve satır sırası arttırılıyor.
                foreach (string gecici in kayitlar) // richtextbox'a yazıların eklendiği döngü
                {
                    if(satirSirasi %2 == 0)
                    {
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        richTextBox1.AppendText(gecici);
                        
                    }
                    else if(satirSirasi %2 != 0)
                    {
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText(gecici);
                    }
                    kelimeSirasi++;  //Aşağıda renklendirme kısmı yapılıyor ve bir sonraki renk için burada kelimesirasi değişkeni arttırılıyor.
                    richTextBox1.Select(richTextBox1.Text.Length - gecici.Length, gecici.Length);
                    if (renkler[kelimeSirasi - 1] == 'k')
                        richTextBox1.SelectionColor = Color.Red;
                    else if (renkler[kelimeSirasi - 1] == 'm')
                        richTextBox1.SelectionColor = Color.Blue;
                    else if (renkler[kelimeSirasi - 1] == 'y')
                        richTextBox1.SelectionColor = Color.Green;
                    if (!gecici.Equals(kayitlar[2]))
                        richTextBox1.AppendText( " ");
                }
                richTextBox1.AppendText("\n"); 
            }
            dosyaOku.Close();
            
        }


        private void button1_Click(object sender, EventArgs e) //Kayit ekleme sekmesine ulaşmak için
        {
            this.Hide();
            Form2 kayit = new Form2();
            kayit.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) //Listeyi gizleme butonu için
        {
            if (checkBox1.Checked)
                richTextBox1.Visible = true;
            else
                richTextBox1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e) //Çıkış butonu
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e) // Kayıt sil sekmesine ulaşmak için
        {
            this.Hide();
            Form3 kayitsil = new Form3();
            kayitsil.Show();
        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
