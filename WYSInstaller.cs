using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Reflection;
using System.Diagnostics;

namespace Shellworks_Installer
{
    public class WYSInstaller
    {
        private static readonly HttpClient client = new();
        private static JsonNode? json;
        private static string shellworksDirectory = "";
        private static string shellworks_modName = "Shellworks";
        static public void Install(string wysPath, Form1 activeForm)
        {
            try
            {
                Debug.WriteLine("Installing shellworks...");

                shellworksDirectory = Path.Combine(wysPath, "gmsl", "mods", shellworks_modName);

                client.DefaultRequestHeaders.Add("Accept", "application/vnd.github+json");
                client.DefaultRequestHeaders.Add("User-Agent", "Shellworks updater");
                var task = Task.Run(() => client.GetAsync("https://api.github.com/repos/rgc-exists/Shellworks/releases/latest"));
                task.Wait();
                using HttpResponseMessage response = task.Result;
                response.EnsureSuccessStatusCode();
                var task2 = Task.Run(() => response.Content.ReadAsStringAsync());
                task2.Wait();
                json = JsonSerializer.Deserialize<JsonNode>(task2.Result);

                if (!Directory.Exists(shellworksDirectory))
                    Directory.CreateDirectory(shellworksDirectory);

                Debug.WriteLine($"Downloading new shellworks version {json["tag_name"].GetValue<string>()}");
                using var task3 = Task.Run(() => client.GetStreamAsync(json["assets"][0]["browser_download_url"].GetValue<string>()));
                task.Wait();

                string autoupdaterPath = Path.Combine(wysPath, "Shellworks_AutoUpdater");
                if (!Directory.Exists(autoupdaterPath))
                {
                    Directory.CreateDirectory(autoupdaterPath);
                }
                var shellworksZip = Path.Combine(autoupdaterPath, "shellworks_extracted_cache.zip");

                var stream = new FileStream(shellworksZip, FileMode.Create);
                task3.Result.CopyTo(stream);
                stream.Dispose();

                Debug.WriteLine("Unzipping new shellworks");
                var extracted = Path.Combine(wysPath);

                if (Directory.Exists(Path.Combine(shellworksDirectory, "code")))
                {
                    Directory.Delete(Path.Combine(shellworksDirectory, "code"), true);
                }
                if (File.Exists(Path.Combine(shellworksDirectory, "needsToBeUpdated.txt")))
                {
                    File.Delete(Path.Combine(shellworksDirectory, "needsToBeUpdated.txt"));
                }

                System.IO.Compression.ZipFile.ExtractToDirectory(shellworksZip, extracted, true);
                
                File.WriteAllText(Path.Combine(wysPath, "Shellworks_AutoUpdater", "shellworks_version.txt"), json["tag_name"].GetValue<string>());

                string infoString = "Successfully installed Shellworks.";
                activeForm.errorLabel.Text = infoString;
                activeForm.errorLabel.ForeColor = Color.Black;
            }
            catch (Exception e)
            {
                string errorString = "Error while installing Shellworks:\n" + e.GetType().ToString();
                activeForm.errorLabel.Text = errorString;
                activeForm.errorLabel.ForeColor = Color.Red;
                Debug.WriteLine(errorString);
            }
        }

        static public void Uninstall(string wysPath, Form1 activeForm)
        {
            try
            {
                string versionDllPath = Path.Combine(wysPath, "version.dll");
                if (File.Exists(versionDllPath)) File.Delete(versionDllPath);

                string gmslPath = Path.Combine(wysPath, "gmsl");
                if (Directory.Exists(gmslPath)) Directory.Delete(gmslPath, true);

                string autoUpdaterPath = Path.Combine(wysPath, "Shellworks_AutoUpdater");
                if (Directory.Exists(autoUpdaterPath)) Directory.Delete(autoUpdaterPath, true);

                string infoString = "Successfully uninstalled Shellworks.";
                activeForm.errorLabel.Text = infoString;
                activeForm.errorLabel.ForeColor = Color.Black;
            }
            catch (Exception e)
            {
                string errorString = "Error while uninstalling Shellworks:\n" + e.GetType().ToString();
                activeForm.errorLabel.Text = errorString;
                activeForm.errorLabel.ForeColor = Color.Red;
                Debug.WriteLine(errorString);
            }
        }
    }
}
