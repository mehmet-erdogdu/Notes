using DevExpress.XtraBars.Docking2010;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            Tema.LookAndFeel.SkinName = Properties.Settings.Default.ATema;
            Size = Properties.Settings.Default.ABoyut;
            try
            {
                yapilacakTableAdapter1.Fill(vtXDataSet1.Yapilacak);
                notlarTableAdapter1.Fill(vtXDataSet1.Notlar);
                bitenTableAdapter1.Fill(vtXDataSet1.Biten);
                copTableAdapter.Fill(vtXDataSet1.Cop);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            status = barStaticItem1.ItemAppearance.Normal.ForeColor;
            cameraControl1.Stop();
        }

        private void BarButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form5 ab = new Form5
            {
            };
            ab.Show();
        }

        private void BarButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void BarButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            if (Size.Height < 600)
            {
                Size = new Size(Size.Width, 600);
            }
            if (Size.Width < 800)
            {
                Size = new Size(800, Size.Height);
            }
            barStaticItem1.Caption = Size.ToString();
            Properties.Settings.Default.ABoyut = Size;
            Properties.Settings.Default.Save();
        }

        int temad = 0;
        private void BarButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (temad)
            {
                case 0:
                    Tema.LookAndFeel.SkinName = "DevExpress Style";
                    windowsUIButtonPanel1.AppearanceButton.Normal.ForeColor = Color.DarkRed;
                    temad++;
                    break;
                case 1:
                    Tema.LookAndFeel.SkinName = "DevExpress Dark Style";
                    windowsUIButtonPanel1.AppearanceButton.Normal.ForeColor = Color.White;
                    temad++;
                    break;
                case 2:
                    Tema.LookAndFeel.SkinName = "Visual Studio 2013 Dark";
                    windowsUIButtonPanel1.AppearanceButton.Normal.ForeColor = Color.White;
                    temad = 0;
                    break;
            }
            Properties.Settings.Default.ATema = Tema.LookAndFeel.SkinName;
            Properties.Settings.Default.Save();
        }

        private void BarButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form5 x = new Form5();
            x.Show();
        }

        private void PanelControl1_Click(object sender, EventArgs e)
        {
            panelControl1.ContentImage = cameraControl1.TakeSnapshot();
            label2.Parent = panelControl1;
            label3.Parent = panelControl1;
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            cameraControl1.Start();
            Int32 px = this.Location.X + panelControl1.Location.X + simpleButton1.Location.X;
            Int32 py = this.Location.Y + panelControl1.Location.Y + simpleButton1.Location.Y;
            radialMenu1.ShowPopup(new Point(px, py));
        }

        Color status;
        string ts;

        int sayac;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            if (sayac == 1)
            {
                barStaticItem1.ItemAppearance.Normal.ForeColor = Color.Lime;
            }
            if (sayac == 2)
            {
                barStaticItem1.ItemAppearance.Normal.ForeColor = status;
                sayac = 0;
                timer1.Enabled = false;
            }
        }

        private void GridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (aktifsil == 1)
            {
            }
            else
            {
                int veri1 = Convert.ToInt32(tileView1.GetFocusedRowCellValue("Kimlik"));
                string veri2 = tileView1.GetFocusedRowCellValue("Olusturma").ToString();
                string veri3 = tileView1.GetFocusedRowCellValue("Baslik").ToString();
                string veri4 = tileView1.GetFocusedRowCellValue("Icerik").ToString();
                string veri5 = tileView1.GetFocusedRowCellValue("Ek").ToString();
                string veri6 = tileView1.GetFocusedRowCellValue("Hatirlatici").ToString();

                Form2 frm2 = new Form2
                {
                    kategori = 1,
                    veri1 = veri1,
                    veri2 = veri2,
                    veri3 = veri3,
                    veri4 = veri4,
                    veri5 = veri5,
                    veri6 = veri6
                };
                frm2.ShowDialog();
            }
        }

        private void GridControl2_DoubleClick(object sender, EventArgs e)
        {
            if (aktifsil == 1)
            {
            }
            else
            {
                int veri1 = Convert.ToInt32(tileView2.GetFocusedRowCellValue("Kimlik"));
                string veri2 = tileView2.GetFocusedRowCellValue("Olusturma").ToString();
                string veri3 = tileView2.GetFocusedRowCellValue("Baslik").ToString();
                string veri4 = tileView2.GetFocusedRowCellValue("Icerik").ToString();
                string veri5 = tileView2.GetFocusedRowCellValue("Ek").ToString();
                ts = Tema.LookAndFeel.SkinName.ToString();
                Form2 frm2 = new Form2
                {
                    kategori = 2,
                    veri1 = veri1,
                    veri2 = veri2,
                    veri3 = veri3,
                    veri4 = veri4,
                    veri5 = veri5
                };
                frm2.ShowDialog();
            }
        }

        private void GridControl3_DoubleClick(object sender, EventArgs e)
        {
            if (aktifsil == 1)
            {
            }
            else
            {
                int veri1 = Convert.ToInt32(tileView3.GetFocusedRowCellValue("Kimlik"));
                string veri2 = tileView3.GetFocusedRowCellValue("Olusturma").ToString();
                string veri3 = tileView3.GetFocusedRowCellValue("Baslik").ToString();
                string veri4 = tileView3.GetFocusedRowCellValue("Icerik").ToString();
                string veri5 = tileView3.GetFocusedRowCellValue("Ek").ToString();
                string veri6 = tileView3.GetFocusedRowCellValue("Hatirlatici").ToString();
                string veri7 = tileView3.GetFocusedRowCellValue("Bitirme").ToString();
                ts = Tema.LookAndFeel.SkinName.ToString();
                Form2 frm2 = new Form2
                {
                    kategori = 3,
                    veri1 = veri1,
                    veri2 = veri2,
                    veri3 = veri3,
                    veri4 = veri4,
                    veri5 = veri5,
                    veri6 = veri6,
                    veri7 = veri7
                };
                frm2.ShowDialog();
            }
        }

        private void TileView1_ItemCustomize(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventArgs e)
        {
            if (e.Item["Hatirlatici"].Text == "1.01.2018")
            {
                e.Item["Hatirlatici"].Text = "";
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            if (e.KeyCode == Keys.F11)
            {
                if (WindowState == FormWindowState.Maximized)
                {
                    WindowState = FormWindowState.Normal;
                }
                else
                    WindowState = FormWindowState.Maximized;
            }
        }

        int konum = 0, boy;
        public static int dyenile = 0;
        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (label6.Font.Bold == false)
            {
                label6.Font = new Font(label6.Font, FontStyle.Bold);
            }
            else
            {
                label6.Font = new Font(label6.Font, FontStyle.Regular);
            }
            if (dyenile == 1)
            {
                dyenile = 0;
                yapilacakTableAdapter1.Fill(vtXDataSet1.Yapilacak);
                gridControl1.DataSource = yapilacakBindingSource;
                notlarTableAdapter1.Fill(vtXDataSet1.Notlar);
                gridControl2.DataSource = notlarBindingSource;
                bitenTableAdapter1.Fill(vtXDataSet1.Biten);
                gridControl3.DataSource = bitenBindingSource;
                copTableAdapter.Fill(vtXDataSet1.Cop);
                gridControl4.DataSource = copBindingSource;
                barStaticItem1.Caption = "Veri güncelleme isteği uygulandı.";
                timer1.Enabled = true;
                barStaticItem1.ItemAppearance.Normal.ForeColor = Color.Red;
            }
        }

        private void WindowsUIButtonPanel1_ButtonClick(object sender, ButtonEventArgs e)
        {
            WindowsUIButton x = e.Button as WindowsUIButton;
            if (x.Caption == "Yeni Kayıt")
            {
                ts = Tema.LookAndFeel.SkinName.ToString();
                Form2 frm2 = new Form2
                {
                    kategori = 4
                };
                frm2.ShowDialog();
            }
        }

        private void TileView3_ItemCustomize(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemCustomizeEventArgs e)
        {
            if (e.Item["Hatirlatici"].Text == "1.01.2018")
            {
                e.Item["Hatirlatici"].Text = "";
            }
            if (e.Item["Bitirme"].Text == "1.01.2018")
            {
                e.Item["Bitirme"].Text = "";
            }
        }

        private void navBarItem4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (konum == 0)
            {
                navigationFrame1.SelectedPageIndex = 2;
                konum = 1;
                //navBarItem6.Appearance.FontStyleDelta = FontStyle.Bold;
                boy = navBarItem4.Appearance.FontSizeDelta;
                navBarItem4.Appearance.FontSizeDelta = 15;
            }
            else
            {
                navBarItem4.Appearance.FontSizeDelta = boy;
                //navBarItem6.Appearance.FontStyleDelta = FontStyle.Regular;
                navigationFrame1.SelectedPageIndex = 0;
                konum = 0;
            }
        }

        Color cbul;
        int k1 = 0;
        private void BarButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (k1 == 0)
            {
                cbul = barButtonItem9.ItemAppearance.Normal.BackColor;
                layoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                barButtonItem9.ItemAppearance.Normal.BackColor = Color.Blue;
                k1 = 1;
            }
            else
            {
                layoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                barButtonItem9.ItemAppearance.Normal.BackColor = cbul;
                k1 = 0;
            }
        }

        private void BarButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        Color cyaz;
        private void BarButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cyaz = barButtonItem12.ItemAppearance.Normal.BackColor;
            barButtonItem12.ItemAppearance.Normal.BackColor = Color.SeaGreen;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ClientSize = new Size(600, 800);
            printPreviewDialog1.ShowDialog();
            barButtonItem12.ItemAppearance.Normal.BackColor = cyaz;
        }

        private void JumpListItemTask1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }

        Int32 satir;
        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                e.Graphics.DrawString("ÇIKTI BAŞLIĞI", new Font("Times New Roman", 12.0f, FontStyle.Bold),
                        Brushes.Black, e.PageBounds.Width / 2 - 50, e.MarginBounds.Top);
                String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
                e.Graphics.DrawString(strDate, new Font("Times New Roman", 10.0f),
                    Brushes.Black, e.MarginBounds.Right - 150, e.MarginBounds.Top);
                satir = e.MarginBounds.Top + 50;
                e.Graphics.DrawString("Mehmet", new Font("Times New Roman", 10.0f),
                    Brushes.DarkRed, e.MarginBounds.Left, satir);
                satir += 20;
                e.Graphics.DrawString("ERDOĞDU", new Font("Times New Roman", 10.0f),
                    Brushes.DarkRed, e.MarginBounds.Left, satir);
                satir += 20;
                e.Graphics.DrawString("0506 180 35 80", new Font("Times New Roman", 10.0f),
                     Brushes.DarkRed, e.MarginBounds.Left, satir);
                satir += 20;
                e.Graphics.DrawString("mehmet.erdogdu52@hotmail.com", new Font("Times New Roman", 10.0f),
                    Brushes.DarkBlue, e.MarginBounds.Right - 200, satir);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int aktifsil = 0;
        Color csil;
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (aktifsil == 0)
            {
                layoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                csil = barButtonItem6.ItemAppearance.Normal.BackColor;
                barButtonItem6.ItemAppearance.Normal.BackColor = Color.Red;
                aktifsil = 1;
            }
            else
            {
                barButtonItem6.ItemAppearance.Normal.BackColor = csil;
                layoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                aktifsil = 0;
            }
            layoutControlItem12.Size = new Size(layoutControlItem12.Size.Width, 35);
            layoutControlItem4.Size = new Size(layoutControlItem4.Size.Width, 30);
            layoutControlItem5.Size = new Size(layoutControlItem5.Size.Width, 30);
            layoutControlItem5.Size = new Size(layoutControlItem5.Size.Width, 30);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            layoutControlItem12.Size = new Size(layoutControlItem12.Size.Width, 35);
            layoutControlItem4.Size = new Size(layoutControlItem4.Size.Width, 30);
            layoutControlItem5.Size = new Size(layoutControlItem5.Size.Width, 30);
            layoutControlItem5.Size = new Size(layoutControlItem5.Size.Width, 30);
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Application.OpenForms["asd"] == null)
            {
                Form3 asd = new Form3();
                asd.Name = "asd";
                asd.Show();
            }
            else
                Application.OpenForms["asd"].Focus();
        }

        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            if (gcalis == 1)
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    Properties.Settings.Default.FBoyut = "0";
                }
                else if (this.WindowState == FormWindowState.Normal)
                {
                    Properties.Settings.Default.FBoyut = "1";
                }
                Properties.Settings.Default.Save();
            }
        }


        int gcalis;
        private void Form1_Shown(object sender, EventArgs e)
        {
            string x = Properties.Settings.Default.FBoyut;
            if (x == "0")
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
                CenterToScreen();
            gcalis = 1;
            try
            {
                ribbonControl1.Toolbar.RestoreLayoutFromXml(Kayit);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        string Kayit = Application.StartupPath + "\\Ayarlar.ini";
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ribbonControl1.Toolbar.SaveLayoutToXml(Kayit);
        }

        private void schedulerControl1_EditAppointmentFormShowing(object sender, DevExpress.XtraScheduler.AppointmentFormEventArgs e)
        {
            DevExpress.XtraScheduler.SchedulerControl scheduler = ((DevExpress.XtraScheduler.SchedulerControl)(sender));
            WindowsFormsApp1.OutlookAppointmentForm form = new WindowsFormsApp1.OutlookAppointmentForm(scheduler, e.Appointment, e.OpenRecurrenceForm);
            try
            {
                e.DialogResult = form.ShowDialog();
                e.Handled = true;
            }
            finally
            {
                form.Dispose();
            }

        }

        private void NavBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (konum == 0)
            {
                navigationFrame1.SelectedPageIndex = 1;
                konum = 1;
                //navBarItem6.Appearance.FontStyleDelta = FontStyle.Bold;
                boy = navBarItem6.Appearance.FontSizeDelta;
                navBarItem6.Appearance.FontSizeDelta = 15;
            }
            else
            {
                navBarItem6.Appearance.FontSizeDelta = boy;
                //navBarItem6.Appearance.FontStyleDelta = FontStyle.Regular;
                navigationFrame1.SelectedPageIndex = 0;
                konum = 0;
            }
        }
    }
}

