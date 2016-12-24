using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;


namespace CSGO_Config_Manager
{
    public partial class Form1 : Form
    {
        private List<long> steamIDs = new List<long>();
        private List<string> profilePaths = new List<string>();
        private List<string> accountStrs = new List<string>();
        private List<string> copyAccountStrs = new List<string>();
        private bool importOnly = false;
        private bool oneAccount = false;
        private bool copyAccountSelected = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tb_log.AppendText("Welcome to CS:GO Config Manager!");
            //tb_log.AppendText(Environment.NewLine + "ERROR: This is a test.", Color.Red);
            //tb_log.AppendText(Environment.NewLine + "xD");
            DisableBoxes();
            CfgSearch();
        }

        private void DisableBoxes()
        {
            b_import.Enabled = false;
            b_export.Enabled = false;
            b_open.Enabled = false;
            b_copy.Enabled = false;
            b_refresh.Enabled = false;
        }

        private void EnableBoxes()
        {
            if (!oneAccount && !importOnly && steamIDs.Count > 1 && copyAccountSelected)
            {
                b_copy.Enabled = true;
            }

            if (!importOnly)
            {
                b_export.Enabled = true;
                b_open.Enabled = true;
            }

            b_import.Enabled = true;
            b_refresh.Enabled = true;
        }

        private void CfgSearch()
        {
            string[] dirs;
            XmlDocument xml = new XmlDocument();
            XmlNodeList personaname;
            bool connectionFail = false;

            oneAccount = false;
            steamIDs.Clear();
            profilePaths.Clear();
            accountStrs.Clear();

            if (!File.Exists(Properties.Settings.Default.steamDir + @"\steam.exe"))
            {
                tb_log.AppendText(Environment.NewLine + "ERROR: Steam was not found on your computer.", Color.Red);
                DisableBoxes();
                return;
            }

            try { dirs = Directory.GetDirectories(Properties.Settings.Default.steamDir + @"\userdata"); }
            catch
            {
                tb_log.AppendText(Environment.NewLine + "ERROR: There is no user data. Have you logged in?", Color.Red);
                DisableBoxes();
                return;
            }

            for (int i = 0; i < dirs.Length; i++)
            {
                dirs[i] = dirs[i].Replace(Properties.Settings.Default.steamDir + @"\userdata\", "");
                if (dirs[i] != "anonymous")
                {
                    steamIDs.Add(Convert.ToInt64(dirs[i]) + 76561197960265728);
                    profilePaths.Add(Properties.Settings.Default.steamDir + @"\userdata\" + dirs[i]);

                    try
                    {
                        xml.Load("http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=16D07778A2708A0A6BA90AC7B52B5F1F&format=xml&steamids=" + steamIDs[i]);
                        personaname = xml.GetElementsByTagName("personaname");
                        accountStrs.Add(personaname[0].InnerText + " (" + steamIDs[i] + ")");
                    }
                    catch
                    {
                        connectionFail = true;
                        accountStrs.Add("(" + steamIDs[i] + ")");
                    }
                    //tb_log.AppendText(Environment.NewLine + accountStrs[i]);
                }
            }

            if (connectionFail) tb_log.AppendText(Environment.NewLine + "Warning: Failed to connect to Steam web API. Account names are unavailable.", Color.DarkOrange);
            if (steamIDs.Count < 2) oneAccount = true;

            tb_log.AppendText(Environment.NewLine + steamIDs.Count + " account(s) found.");
            cb_account.DataSource = new List<string>();
            cb_account.DataSource = accountStrs;
        }

        private void cb_account_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!File.Exists(profilePaths[cb_account.SelectedIndex] + @"\730\local\cfg\config.cfg"))
            {
                tb_log.AppendText(Environment.NewLine + "Selected account does not have a config. You can only import.", Color.DarkOrange);
                importOnly = true;
            }
            else importOnly = false;

            copyAccountStrs.Clear();
            clb_copyto.Items.Clear();
            if (steamIDs.Count > 1)
            {
                for (int i = 0; i < steamIDs.Count; i++)
                {
                    if (i != cb_account.SelectedIndex)
                    {
                        copyAccountStrs.Add(accountStrs[i]);
                        clb_copyto.Items.Add(accountStrs[i]);
                    }
                }
            }

            copyAccountSelected = false;
            DisableBoxes();
            EnableBoxes();
        }

        private void b_refresh_Click(object sender, EventArgs e)
        {
            DisableBoxes();
            CfgSearch();
        }

        private void b_import_Click(object sender, EventArgs e)
        {
            OpenFileDialog importD = new OpenFileDialog();
            importD.Title = "Select a New Config to Import";
            importD.Filter = "(*.cfg)|*.cfg";
            importD.InitialDirectory = "s";

            if (importD.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("Importing a config will overwrite your existing config and permanently delete it. Are you sure you want to import?", "Confirm Config Import", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    if (!Directory.Exists(profilePaths[cb_account.SelectedIndex] + @"\730\local\cfg"))
                    {
                        Directory.CreateDirectory(profilePaths[cb_account.SelectedIndex] + @"\730\local\cfg");
                    }
                    File.Copy(importD.FileName, profilePaths[cb_account.SelectedIndex] + @"\730\local\cfg\config.cfg", true);
                    tb_log.AppendText(Environment.NewLine + "Config has been imported to account " + accountStrs[cb_account.SelectedIndex]);

                    importOnly = false;

                    DisableBoxes();
                    EnableBoxes();
                }
            }
        }

        private void b_export_Click(object sender, EventArgs e)
        {
            SaveFileDialog exportD = new SaveFileDialog();
            exportD.Title = "Export Your Config";
            exportD.Filter = "(*.cfg)|*.cfg";
            exportD.InitialDirectory = @"C:\Users\" + Environment.UserName + @"\Desktop";
            exportD.FileName = "config.cfg";

            if (exportD.ShowDialog() == DialogResult.OK)
            {
                File.Copy(profilePaths[cb_account.SelectedIndex] + @"\730\local\cfg\config.cfg", exportD.FileName, true);
                tb_log.AppendText(Environment.NewLine + "Config has been exported from account " + accountStrs[cb_account.SelectedIndex]);
            }
        }

        private void b_copy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Copying your config to the selected accounts will overwrite the existing config(s) and permenantly delete them. Are you sure you want to copy?", "Confirm Copy To...", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                for (int i = 0; i < clb_copyto.Items.Count; i++)
                {
                    if (clb_copyto.GetItemChecked(i))
                    {
                        int index = accountStrs.IndexOf(Convert.ToString(clb_copyto.Items[i]));
                        File.Copy(profilePaths[cb_account.SelectedIndex] + @"\730\local\cfg\config.cfg", profilePaths[index] + @"\730\local\cfg\config.cfg", true);

                        tb_log.AppendText(Environment.NewLine + accountStrs[cb_account.SelectedIndex] + "'s config has been copied to " + accountStrs[index] + "'s account.");
                    }
                }
                tb_log.AppendText(Environment.NewLine + "Copy complete.");
            }
        }


        private void b_open_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(profilePaths[cb_account.SelectedIndex] + @"\730\local\cfg\config.cfg");
        }

        private void cbl_copyto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clb_copyto.CheckedItems.Count > 0)
            {
                copyAccountSelected = true;
            }
            else
            {
                copyAccountSelected = false;
            }
            DisableBoxes();
            EnableBoxes();
        }

        private void b_steamdir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog steamDir = new FolderBrowserDialog();
            steamDir.Description = "Locate the Steam Folder";
            steamDir.SelectedPath = Properties.Settings.Default.steamDir;

            if (steamDir.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.steamDir = steamDir.SelectedPath;
                Properties.Settings.Default.Save();
                tb_log.AppendText(Environment.NewLine + "Steam folder changed to " + Properties.Settings.Default.steamDir);

                DisableBoxes();
                CfgSearch();
            }
        }
    }

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
