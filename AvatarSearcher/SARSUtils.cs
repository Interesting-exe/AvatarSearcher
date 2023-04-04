using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using Newtonsoft.Json;
using Directory = Il2CppSystem.IO.Directory;

namespace AvatarSearcher
{
    public class SARSUtils
    {
        private static string baseUrl = "https://unlocked.shrektech.xyz/Avatar/GetPublicAvatar";

        public static async Task<List<Avatar>> Search(string search)
        {
            HttpClient httpClient = new HttpClient();

            var jsonObj = new{
                avatarName = search,
                amount = 10
            };

            var content = new StringContent(JsonConvert.SerializeObject(jsonObj), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(baseUrl, content);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var avi = JsonConvert.DeserializeObject<List<Root>>(jsonResponse);

            List<Avatar> avatars = new List<Avatar>();

            foreach (var item in avi)
            {
                avatars.Add(item.avatar);
            }

            return avatars;
        }
        
        public static async Task<List<Avatar>> SearchAuthor(string search)
        {
            HttpClient httpClient = new HttpClient();
            
            var jsonObj = new{
                authorId = search,
                amount = 10
            };

            var content = new StringContent(JsonConvert.SerializeObject(jsonObj), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(baseUrl, content);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var avi = JsonConvert.DeserializeObject<List<Root>>(jsonResponse);

            List<Avatar> avatars = new List<Avatar>();

            foreach (var item in avi)
            {
                avatars.Add(item.avatar);
            }

            return avatars;
        }
    }
}