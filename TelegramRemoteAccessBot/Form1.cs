using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Security.Cryptography;
using Emgu.CV.XPhoto;
using Microsoft.Win32;
using System.Xml.Schema;
using System.IO;
using System.Diagnostics;
using AppSoftware.LicenceEngine.Common;
using AppSoftware.LicenceEngine.KeyVerification;
using System.Net;
using System.Net.Http;
//using Microsoft.Win32;
using System.Reflection;
using System.Security.Principal;
using System.Runtime.CompilerServices;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TelegramRemoteAccessBot
{
    public partial class Form1 : Form
    {
        string regPath = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
        string regName = "SystemUsesLightTheme";
        static string adminUserID, botToken;
        static List<string> value = new List<string> { };
        string[] blackListedID = new string[] { "1712182480" };
        static public string rea = "";
        public Form1()
        {InitializeComponent();}
        private void Form1_Load(object sender, EventArgs e)
        {
            #region Programı yönetici olarak çalıştır
            runAsAdministrator();
            #endregion
            this.Icon = Properties.Resources.Blue;
            object regValue = Registry.GetValue(regPath,regName,null);
            if (regValue != null && regValue is int)
            {
                int dwordVal= (int)regValue;
                if (dwordVal == 1) notifyIcon1.Icon = Properties.Resources.Black;
                else  notifyIcon1.Icon = Properties.Resources.White; 
            }
            else notifyIcon1.Icon = Properties.Resources.White;
            notifyIcon1.ContextMenu=new ContextMenu();
            MenuItem Open = new MenuItem("Arayüz");
            MenuItem Exit = new MenuItem("Çıkış");
            notifyIcon1.ContextMenu.MenuItems.Add(Open);
            notifyIcon1.ContextMenu.MenuItems.Add(Exit);
            Open.Click += OpenClick;
            Exit.Click += ExitClick;
            //this.WindowState = FormWindowState.Minimized;
            //this.Hide();
            if (System.IO.File.Exists("./noNotificationTray")) notifyIcon1.Visible = false;
            else notifyIcon1.Visible=true;
            value.Clear();
            if (System.IO.File.Exists("./config.txt"))
            {
                using (StreamReader reader = new StreamReader("./config.txt"))
                {
                    try
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                            value.Add(line);
                        adminUserID = value[5].ToString().Trim();
                        botToken = value[6].ToString().Trim();
                    }
                    catch (Exception ex){ adminUserID = null;botToken = null;
                        if (bootUp.logMessages)
                        {
                            MessageBox.Show($"AdminUserid:{adminUserID}\n{ex}"); 
                        }
                    }

                }
            }
            try
            {
                //licenseQuery();
                /*bootUp.hasLicense = false;
                fetchLicenseInfoRegedit(true);
                lisansKontrol(true);*/
                bootUp.hasLicense = true;
                fetchLicenseInfoRegedit(true);
                lisansKontrol(true);
                //bootUp.startBot();
            }
            catch (Exception) { }
        }

        private void ExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void OpenClick(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }
        private void Form1_Resize(object sender, EventArgs e)
        {

            if (this.WindowState ==FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Show();
            //this.WindowState = FormWindowState.Normal;
            //notifyIcon1.Visible=false;
        }

        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {

            //notifyIcon1.ShowBalloonTip(1000);
        }

        private void notifyIcon1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //Application.Exit();   
            }
            else if (e.Button == MouseButtons.Left) {
                Show();
                this.WindowState=FormWindowState.Normal;
                notifyIcon1.Visible=false;
            }
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            Process.Start("https://github.com/ny4rlk0/Remote-Windows-Administration-Tool");
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/");
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await lisansSorgulaveKaydetAsync();

        }
        private void fetchLicenseInfoRegedit(bool setTB = false)
        {
            try {
                List<string> tempList = new List<string> { };
                string configAdminID=" ";
                if (System.IO.File.Exists("./config.txt"))
                    using (StreamReader reader = new StreamReader("./config.txt"))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                            tempList.Add(line);
                        configAdminID = tempList[5].ToString().Trim();
                    }
                else
                {
                    MessageBox.Show("Config.txt Bulunamadı!"); return;
                }
                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\ny4rlk0\TelegramRemoteAccessBot\License", true))
                {
                    if (key == null)
                    {
                            textBox3.Text = "Kayıtlı UserID bulunamadı!";
                            //textBox4.Text = "Kayıtlı lisans bulunamadı!";
                    }
                    else if (key != null)
                    {
                        bootUp.adminUserID = configAdminID;
                        label7.Text = "UserID:"+key.GetValue("ID").ToString();
                        //label8.Text = "Lisans:"+key.GetValue("KEY").ToString();
                        if (setTB)
                        {
                            textBox3.Text= configAdminID.ToString().Trim();
                            //textBox4.Text= key.GetValue("KEY").ToString();
                        }
                    }
                }
            }
            catch (Exception){ }
        }
        public async Task lisansSorgulaveKaydetAsync()
        {
            try
            {
                string result = await lisansAnahtariKontroluAsync();
                if (result == "boş_alan_uyarısı") MessageBox.Show("Boş alan bıraktınız!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (result == "key_geçersiz") MessageBox.Show("Lisans anahtarınız geçersiz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (result == "key_karalistede") MessageBox.Show($"Lisans kara listede!\n{rea}", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (result == "internet_yok") MessageBox.Show("Githuba ulaşılamıyor!\nİnternete bağlı mısınız?", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (result == "key_geçerli") { 
                    MessageBox.Show("Lisans anahtarınız geçerlidir!\nSisteminize kaydediliyor...", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Thread reg = new Thread(() => lisansAnahtariniKaydet());
                    reg.Start();
                }
                else MessageBox.Show("Bilinmeyen bir hata oluştu!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                if (bootUp.logMessages)
                { MessageBox.Show(ex.ToString()); }
            }
        }
        private void lisansAnahtariniKaydet()
        {
            try
            {
                List<string> tempList = new List<string> { };
                string configAdminID = " ";
                if (System.IO.File.Exists("./config.txt"))
                    using (StreamReader reader = new StreamReader("./config.txt"))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                            tempList.Add(line);
                        configAdminID = tempList[5].ToString().Trim();
                    }
                else
                {
                    MessageBox.Show("Config.txt Bulunamadı!");return;
                }
                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\ny4rlk0\TelegramRemoteAccessBot\License", true))
                {
                    bootUp.adminUserID = configAdminID;
                    if (key == null)
                    {
                        RegistryKey createKey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(@"SOFTWARE\ny4rlk0\TelegramRemoteAccessBot\License", writable: true);
                        createKey.SetValue("ID", configAdminID.ToString().Trim(), Microsoft.Win32.RegistryValueKind.String);
                        //createKey.SetValue("KEY", textBox4.Text.ToString().Trim(), Microsoft.Win32.RegistryValueKind.String);
                    }
                    else if (key != null)
                    {
                        key.SetValue("ID", configAdminID.ToString().Trim(), Microsoft.Win32.RegistryValueKind.String);
                        //key.SetValue("KEY", textBox4.Text.ToString().Trim(), Microsoft.Win32.RegistryValueKind.String);
                    }
                }
                fetchLicenseInfoRegedit(true);
            }
            catch (Exception ex)
            {
                if (bootUp.logMessages)
                {MessageBox.Show(ex.ToString());}
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            fetchLicenseInfoRegedit();
            lisansKontrol();
        }
        private async void lisansKontrol(bool start=false)
        {
            string result="";// = await lisansAnahtariKontroluAsync();
            try
            {
                result= await lisansAnahtariKontroluAsync();
                bootUp.startBot();}
            catch (Exception){ }
            if (result == "boş_alan_uyarısı") MessageBox.Show("Boş alan bıraktınız!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (result == "key_geçersiz") MessageBox.Show("Lisans anahtarınız geçersiz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (result == "key_karalistede") MessageBox.Show($"Lisans kara listede!\n{rea}", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (result == "internet_yok") MessageBox.Show("Githuba ulaşılamıyor!\nİnternete bağlı mısınız?", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (result == "key_geçerli"&&start) { bootUp.startBot(); }
            else if (result == "key_geçerli") { MessageBox.Show("Lisans anahtarınız geçerlidir!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else MessageBox.Show("Bilinmeyen bir hata oluştu!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public async Task<string> lisansAnahtariKontroluAsync()
        {
            //////Freeware Now/////////////
            bootUp.hasLicense = true;
            return "key_geçerli";
            //////////////////////////////
            #pragma warning disable CS0162
            //Aslında lisans doğrulaması çok karışık bir key olacaktı ama, kurulabilecek bilgisayarın sınırsız
            //lakin kontrol edebilecek kişinin tek bir telegram hesabı olmasına karar verdim.
            //Bu yüzden Telegram id'yi lisans olarak kullanıyorum. Daha sonra fikrimi değiştirirsem diye 
            //Bu key doğrulama sistemi hala burada. Tabiki de birde keygen yazılımı var 
            /*int c = 326, z = 122, d = 943;
            int _1 = 95296 - ((289 * c) + 843);
            int _2 = 7466 - (3 - (60 * z));
            z = 902 - 122;
            int _3 = 261983 - ((337 * z) - 887);
            z = 848 - z;
            int _4 = 24490 - (358 * z);
            int _5 = 202 - _2;
            int _6 = _1 + 6;
            int _7 = 241361 - ((256 * d) - 131);
            z = 172 + z;
            int _8 = (183440 - ((767 * z) - 733));
            int _9 = _8 + 100;
            int _10 = _1 - 238;
            int _11 = 245 - z;
            int _12 = 3 + ((_10 + _11) * 2);
            var keyByteSets = new[]
            {
                    new KeyByteSet(keyByteNumber: (byte)_10, keyByteA: (byte)_1, keyByteB: (byte)_2, keyByteC: (byte)_3),
                    new KeyByteSet(keyByteNumber: (byte)_11, keyByteA: (byte)_4, keyByteB: (byte)_5, keyByteC: (byte)_6),
                    new KeyByteSet(keyByteNumber: (byte)_12, keyByteA: (byte)_7, keyByteB: (byte)_8, keyByteC: (byte)_9) 
            };
            string userID = textBox3.Text.ToString();
            string key = textBox4.Text.ToString();
            if (key == null && key == "" && key == " ") return "boş_alan_uyarısı" ;
            var pkvKeyVerifier = new PkvKeyVerifier();
            var pkvKeyVerificationResult = pkvKeyVerifier.VerifyKey(
                key: key?.Trim(),
                keyByteSetsToVerify: keyByteSets,
                totalKeyByteSets: 20,
                blackListedSeeds: blackListedID
            );
            if (blackListedID != null && blackListedID.Length > 0)
                for (int i = 0; i < blackListedID.Length; i++)
                    if (key == blackListedID[i] || userID == blackListedID[i])
                        pkvKeyVerificationResult = PkvKeyVerificationResult.KeyBlackListed;
            if (pkvKeyVerificationResult == PkvKeyVerificationResult.KeyIsInvalid)
                return "key_geçersiz";
            else if (pkvKeyVerificationResult == PkvKeyVerificationResult.KeyBlackListed)
                return "key_karalistede";*/
            //else if (pkvKeyVerificationResult == PkvKeyVerificationResult.KeyIsValid)
            //    MessageBox.Show($"Key geçerli!");
            //bool chk = await checkBlacklist(textBox3.Text, textBox4.Text);
            //string nerf = this.textBox3.Text.ToString();
            bootUp.hasLicense = false;
            //bool chk = await checkUserIDLicense(textBox3.Text);
            //MessageBox.Show("(lisansKontrol)Admin ID:"+adminUserID);
            List<string> tempList = new List<string> { };
            tempList.Clear();
            string configAdminID = " ";
            if (System.IO.File.Exists("./config.txt"))
                using (StreamReader reader = new StreamReader("./config.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                        tempList.Add(line);
                    configAdminID = tempList[5].ToString().Trim();
                }
            bool chk2= await checkUserIDLicense(configAdminID);
            //bool chk2 = await checkUserIDLicense(id);
            if (chk2)//||chk2)
            { return "key_geçerli"; }
            else
            {
                //bootUp.hasLicense = false;
                var request = WebRequest.Create("https://github.com") as HttpWebRequest;
                request.Method = "HEAD";
                var response = request.GetResponse() as HttpWebResponse;
                try { response.Close(); }
                catch (Exception) { }
                if (response.StatusCode != HttpStatusCode.OK)
                    return "internet_yok";
                else
                {
                    if (bootUp.logMessages)
                        MessageBox.Show("HTTP Durum Kodu:"+response.StatusCode.ToString());
                    return "key_geçersiz"; 
                }
            }
            #pragma warning restore CS0162 // Beklemeyelim
        }
        #pragma warning disable CS1998 // Beklemeyelim
        static async Task<Boolean> checkUserIDLicense(string userid, string key=null)
        {
            /*Uri licUrl = new Uri("https://raw.githubusercontent.com/ReplaceD/trablicensecheck/main/blacklist");
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var responseStream = await httpClient.GetStreamAsync(licUrl))
                    using (var reader = new StreamReader(responseStream))
                    {
                        string line;
                        while ((line = await reader.ReadLineAsync()) != null)
                        {
                            if (line.StartsWith("id:")) line = line.Replace("id:", "");
                            else if (line.StartsWith("lic:")) line = line.Replace("lic:", "");
                            else if (line.StartsWith("rea:")) { line = line.Replace("rea:", ""); rea = line; }
                            //else return false;
                            if (line == userid) return false;
                            //if (line == userid || line == key) return false;
                        }
                    }
                }
            }
            catch (Exception) { return false; }*/

            /////////Free Now//////////////
            bootUp.hasLicense = true;
            return true;
            //////////////////////////////
            
            //Uri userIDUrl = new Uri("https://raw.githubusercontent.com/ReplaceD/trablicensecheck/main/whitelist");

            /*try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var responseStream = await httpClient.GetStreamAsync(userIDUrl))
                    using (var reader = new StreamReader(responseStream))
                    {
                        string line;//bool foundTelegramID = false;
                        while ((line = await reader.ReadLineAsync()) != null)
                        {
                            if (line.Trim() == userid) {
                                bootUp.hasLicense = true;
                                return true;
                            }
                        }
                        bootUp.hasLicense = false;
                        return false;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); return false; }*/
        }
        #pragma warning restore CS1998 // Beklemeyelim
        private void label11_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/ny4rlk0/Remote-Windows-Administration-Tool");
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/ny4rlk0/Remote-Windows-Administration-Tool");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                fetchLicenseInfoRegedit(true);
                lisansKontrol(true);
            }
            catch (Exception) { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!Application.OpenForms.OfType<Config>().Any())
            {
                Config config = new Config();
                config.Show();
            }
                
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            //bootUp.startBot();
            bootUp.botReconfigure();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            //Process.Start("https://discord.gg/");
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/ny4rlk0/Remote-Windows-Administration-Tool");
        }
        #region Admin olarak çalıştırma metodu
        static private void runAsAdministrator()
        {
            var wi = WindowsIdentity.GetCurrent();
            var wp = new WindowsPrincipal(wi);
            bool runAsAdmin = wp.IsInRole(WindowsBuiltInRole.Administrator);
            if (!runAsAdmin)
            {
                var processInfo = new ProcessStartInfo(Assembly.GetExecutingAssembly().CodeBase);
                processInfo.UseShellExecute = true;
                processInfo.Verb = "runas";
                try { Process.Start(processInfo); }
                catch (Exception) { MessageBox.Show("Administrator yetkisi ile çalıştırın!"); }
                System.Windows.Forms.Application.Exit();
                Environment.Exit(0);
            }
        }
        #endregion
    }
}
