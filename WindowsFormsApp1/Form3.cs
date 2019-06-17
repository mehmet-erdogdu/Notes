using System;
using System.Security.Cryptography;
using System.Text;

namespace WindowsFormsApp1
{
    public partial class Form3 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form3()
        {
            InitializeComponent();
        }

        public string hash = "MehmetE";
        public string Encrypt(string sifre)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(sifre);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider()
                { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }


        public void HataLog(string hata)
        {
            labelControl4.Text = "Geçersiz veri : " + hata;
            timer1.Enabled = true;
            timer1.Interval = 4000;
            labelControl4.Visible = true;
        }

        public string Decrypt(string SifrelenmisDeger)
        {
            try
            {
                byte[] data = Convert.FromBase64String(SifrelenmisDeger);
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider()
                    { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform transform = tripDes.CreateDecryptor();
                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                        return UTF8Encoding.UTF8.GetString(results);
                    }
                }
            }
            catch (Exception ex)
            {
                HataLog(ex.Message);
                return "$Hata";
            }
        }

        public void Islem_Yap()
        {
            if (toggleSwitch1.IsOn == true)
            {
                if (Decrypt(textEdit1.Text) != "$Hata")
                {
                    textEdit2.Text = Decrypt(textEdit1.Text);
                }
            }
            if (toggleSwitch1.IsOn == false)
            {
                textEdit2.Text = Encrypt(textEdit1.Text);
            }
        }

        private void textEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            Islem_Yap();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelControl4.Visible = false;
            timer1.Enabled = false;
        }

        private void toggleSwitch1_Toggled(object sender, EventArgs e)
        {
            Islem_Yap();
        }
    }
}
