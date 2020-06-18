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
        public void Init(MonoBehaviour mod, int modId)
        {
            CheckForUUID();
        }

        private async void CheckForUUID()
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "..\\mStats\\"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "..\\mStats\\");
                var client = new HttpClient();
                HttpResponseMessage response = new HttpResponseMessage();
                try
                {
                    var task = client.GetAsync("http://localhost:5000/get-uuid");
                    task.Wait();
                    response = task.Result;
                } catch (Exception)
                {
                    response.StatusCode = HttpStatusCode.RequestTimeout;
                }
                var newTask = response.Content.ReadAsStringAsync();
                newTask.Wait();
                string uuid = newTask.Result;
                using (StreamWriter writer = File.CreateText(Directory.GetCurrentDirectory() + "..\\mStats\\mStats.txt")){
                    await writer.WriteAsync(uuid);
                }
            }

        }

    }
}
