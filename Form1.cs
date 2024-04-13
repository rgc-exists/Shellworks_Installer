using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Shellworks_Installer
{
    public partial class Form1 : Form
    {

        public string wysInstallLocation = "";

        public Label errorLabel;
        public Form1()
        {
            InitializeComponent();

            wysInstallLocation = DetectInstallLocation();
            UpdateInstallTextbox();

            this.ActiveControl = label1;

            errorLabel = label3;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(wysInstallLocation))
            {
                wysInstallLocation = textBox1.Text;
            }
            else
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            wysInstallLocation = DetectInstallLocation();
            UpdateInstallTextbox();
        }

        private void UpdateInstallTextbox()
        {
            textBox1.Text = wysInstallLocation;
        }

        private string DetectInstallLocation()
        {
            Debug.WriteLine("Detecting install path...");
            try
            {
                string regKey = "Software\\Valve\\Steam";
                if (Environment.Is64BitOperatingSystem)
                {
                    regKey = "Software\\Wow6432Node\\Valve\\Steam";
                }

                string steam_appID = "1115050";

                using (var key = Registry.LocalMachine.OpenSubKey(regKey))
                {
                    Debug.WriteLine(key);
                    string steamPath = key?.GetValue("InstallPath") as string;
                    if (!string.IsNullOrWhiteSpace(steamPath))
                    {
                        Debug.WriteLine("steam path is not null");
                        string libFoldersPath = Path.Combine(steamPath, "steamapps", $"libraryfolders.vdf");
                        if (File.Exists(libFoldersPath))
                        {
                            Debug.WriteLine("Lib folders path exists");
                            string installLocInfo = File.ReadAllText(libFoldersPath);

                            var pathMatches = Regex.Matches(installLocInfo, "\"path\"\t\t\"(.*)\"");
                            foreach (Match match in pathMatches)
                            {
                                if (match.Success)
                                {
                                    Debug.WriteLine("Found match");
                                    string gamesInstallLocation = match.Groups[1].Value.Replace(@"\\", @"\");
                                    Debug.WriteLine("Checking directory: " + gamesInstallLocation);
                                    if (Directory.Exists(gamesInstallLocation))
                                    {
                                        Debug.WriteLine("Directory exists: " + gamesInstallLocation);
                                        string possibleInstallLocation = Path.Combine(gamesInstallLocation, "steamapps", "common", "Will You Snail");
                                        if (Directory.Exists(possibleInstallLocation))
                                        {
                                            Debug.WriteLine("Game directory exists: " + possibleInstallLocation);
                                            return possibleInstallLocation;
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.WriteLine("Regex match was not successful.");
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                string errorString = "Error while detecting install path:\n" + e.Message + "\n" + e.StackTrace + "\n" + e.Data;
                Debug.WriteLine(errorString);

                string shortErrorString = "Error while installing Shellworks:\n" + e.GetType().ToString();
                errorLabel.Text = shortErrorString;
                errorLabel.ForeColor = Color.Red;
            }
            return null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(wysInstallLocation) && Directory.Exists(wysInstallLocation))
            {
                errorLabel.Text = "";
                button3.Enabled = false;
                button4.Enabled = false;
                WYSInstaller.Uninstall(wysInstallLocation, this);
                errorLabel.Text = "";
                WYSInstaller.Install(wysInstallLocation, this);
                button3.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                string errorString = "Directory is empty or does not exist:\n" + wysInstallLocation;
                errorLabel.Text = errorString;
                errorLabel.ForeColor = Color.Red;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(wysInstallLocation))
            {
                openFileDialog1.InitialDirectory = wysInstallLocation;
            }
            else
            {
                openFileDialog1.InitialDirectory = Path.GetPathRoot(Environment.SystemDirectory);
            }
            var dialogResult = openFileDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string possibleInstallLocation = Path.Combine(openFileDialog1.FileName, "..");
                if (Directory.Exists(possibleInstallLocation))
                {
                    wysInstallLocation = possibleInstallLocation;
                    UpdateInstallTextbox();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(wysInstallLocation) && Directory.Exists(wysInstallLocation))
            {
                errorLabel.Text = "";
                button3.Enabled = false;
                button4.Enabled = false;
                WYSInstaller.Uninstall(wysInstallLocation, this);
                button3.Enabled = true;
                button4.Enabled = true;
            } else
            {
                string errorString = "Directory is empty or does not exist:\n" + wysInstallLocation;
                errorLabel.Text = errorString;
                errorLabel.ForeColor = Color.Red;
            }
        }
    }
}
