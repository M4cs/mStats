using UnityEngine;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace mStats
{
    public class ModStats
    {
        private static int modId;
        public ModStats(int modId)
        {
            ModStats.modId = modId;
            CheckForUUID();
            IDownloadedIt();
        }

        private async void CheckForUUID()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var subFolderPath = Path.Combine(path, ".mStats");
            if (!Directory.Exists(subFolderPath))
            {
                Directory.CreateDirectory(subFolderPath);
                var client = new HttpClient();
                HttpResponseMessage response = new HttpResponseMessage();
                try
                {
                    var task = client.GetAsync("https://mstats.sxlservers.com/send-uuid/" + SystemInfo.deviceUniqueIdentifier);
                    task.Wait();
                    response = task.Result;
                } catch (Exception)
                {
                    response.StatusCode = HttpStatusCode.RequestTimeout;
                }
                using (StreamWriter writer = File.CreateText(Path.Combine(subFolderPath, "mStats.txt")))
                {
                    await writer.WriteAsync(SystemInfo.deviceUniqueIdentifier);
                }
                using (StreamWriter writer = File.CreateText(Path.Combine(subFolderPath, "README.txt")))
                {
                    await writer.WriteAsync("This is a download tracker for SkaterXL mods. Please do NOT delete the mStats.txt file unless you wish your downloads to not be tracked.");
                }
            }

        }

        private void IDownloadedIt()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var uuidPath = Path.Combine(path, ".mStats", "mStats.txt");
            string uuid = File.ReadAllText(uuidPath);
            var client = new HttpClient();
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                var task = client.GetAsync("https://mstats.sxlservers.com/idownloadedit/" + ModStats.modId + "/" + uuid);
                task.Wait();
                response = task.Result;
            }
            catch (Exception)
            {
                response.StatusCode = HttpStatusCode.RequestTimeout;
            }

        }

    }
}
