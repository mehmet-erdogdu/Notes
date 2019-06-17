using DevExpress.XtraBars.Docking2010;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        public string veri3, veri4, veri5;
        public int veri1, kategori;
        public string veri2, veri6, veri7;

        private void Form2_Load(object sender, EventArgs e)
        {
            if (veri1 != 0)
            {
                TKimlik.Text = veri1.ToString();
                TOlusturma.Text = veri2;
                TBaslik.Text = veri3;
                TIcerik.Text = veri4;
                TEk.Text = veri5;
                THatirlatici.Text = veri6;
                TKategori.Text = kategori.ToString();
                windowsUIButtonPanel1.Buttons[2].Properties.Visible = false;
                if (kategori == 1)
                {
                }
                else
                {
                    windowsUIButtonPanel1.Buttons[0].Properties.Visible = false;
                }
                if (kategori == 2)
                {
                    label6.Visible = false;
                    THatirlatici.Visible = false;
                }
                if (kategori == 3)
                {
                    THatirlatici.Enabled = false;
                    label7.Visible = true;
                    TBitirme.Visible = true;
                    TBitirme.Text = veri7;
                }
            }
            if (kategori == 4)
            {
                comboBoxEdit1.Visible = true;
                TOlusturma.Text = DateTime.Now.ToString();
                label8.Visible = true;
                windowsUIButtonPanel1.Buttons[0].Properties.Visible = false;
                windowsUIButtonPanel1.Buttons[3].Properties.Visible = false;
                windowsUIButtonPanel1.Buttons[4].Properties.Visible = false;
            }
            if (kategori != 1)
            {
                windowsUIButtonPanel1.Buttons[1].Properties.Visible = false;
            }
            foreach (var item1 in panelControl1.Controls)
            {
                if (item1 is Label)
                {
                    //((Label)item1).ForeColor = Color.DarkRed;
                    if (((Label)item1).Text == "Saati güncelle")
                    {
                        ((Label)item1).ForeColor = Color.GreenYellow;
                    }
                }
            }
            //Yuvarlak buton
            //GraphicsPath gp = new GraphicsPath();
            //gp.AddEllipse(new Rectangle(Point.Empty, button1.Size));
            //button1.Region = new Region(gp);
            //button1.FlatAppearance.BorderSize = 0;
            //button1.BackColor = Color.SeaGreen;
            //button1.Parent = panelControl1;
            //
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void ovalShape1_MouseEnter(object sender, EventArgs e)
        {
            ovalShape1.BorderColor = Color.Red;
        }

        private void ovalShape1_MouseLeave(object sender, EventArgs e)
        {
            ovalShape1.BorderColor = Color.Black;
        }

        private void ComboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit1.Text == "Notlar")
            {
                THatirlatici.Visible = false;
                label6.Visible = false;
            }
            else
            {
                THatirlatici.Visible = true;
                label6.Visible = true;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            TOlusturma.Text = DateTime.Now.ToString();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.dyenile = 1;
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void WindowsUIButtonPanel1_ButtonClick(object sender, ButtonEventArgs e)
        {
            WindowsUIButton x = e.Button as WindowsUIButton;
            veri1 = Convert.ToInt32(TKimlik.Text);
            veri2 = TOlusturma.Text;
            veri3 = TBaslik.Text;
            veri4 = TIcerik.Text;
            veri5 = TEk.Text;
            veri6 = THatirlatici.Text;
            veri7 = TBitirme.Text;
            if (THatirlatici.Text == "")
            {
                veri6 = "01.01.2018 00:00";
            }
            if (TBitirme.Text == "")
            {
                veri7 = "01.01.2018 00:00";
            }
            if (x.Caption == "Kaydet")
            {
                if (comboBoxEdit1.Text == "Yapılacak")
                {
                    yapilacakTableAdapter1.Yapilacak_Kayit(Convert.ToDateTime(veri2), veri3, veri4, veri5, Convert.ToDateTime(veri6));
                }
                else if (comboBoxEdit1.Text == "Notlar")
                {
                    notlarTableAdapter1.Notlar_Kaydet(veri3, veri4, Convert.ToDateTime(veri2), veri5);
                }
            }
            if (x.Caption == "Güncelle")
            {
                if (TKategori.Text == "1")
                {
                    yapilacakTableAdapter1.Yapilacak_Guncelle(Convert.ToDateTime(veri2), veri3, veri4, veri5, Convert.ToDateTime(veri6), veri1);
                }
                else if (TKategori.Text == "2")
                {
                    notlarTableAdapter1.Notlar_Guncelle(veri3, veri4, Convert.ToDateTime(veri2), veri5, veri1);
                }
                else if (TKategori.Text == "3")
                {
                    bitenTableAdapter1.Biten_Guncelle(Convert.ToDateTime(veri2), veri3, veri4, veri5, Convert.ToDateTime(veri6), Convert.ToDateTime(veri7), veri1);
                }
            }
            if (x.Caption == "Sil")
            {
                if (TKategori.Text == "1")
                {
                    yapilacakTableAdapter1.Yapilacak_Sil(veri1);
                }
                else if (TKategori.Text == "2")
                {
                    notlarTableAdapter1.Notlar_Sil(veri1);
                }
                else if (TKategori.Text == "3")
                {
                    bitenTableAdapter1.Biten_Sil(veri1);
                }
                try
                {
                    copTableAdapter1.Cope_At(Convert.ToDateTime(veri2), veri3, veri4, veri5, Convert.ToDateTime(veri6), Convert.ToDateTime(veri7));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (x.Caption == "Bitir")
            {
                bitenTableAdapter1.Biten_Kaydet(Convert.ToDateTime(veri2), veri3, veri4, veri5, Convert.ToDateTime(veri6), DateTime.Now);
                yapilacakTableAdapter1.Yapilacak_Sil(veri1);
            }
            Close();
        }
    }
}
