using HubSpotDAL.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HubSpotDAL.WebClient
{
    internal static class KRMApi
    {
        public static async Task<string> SendProspectostoKRM(ListProspectos Prospectos)
        {
            try
            {
                var Apitoken = await GettokenKRM();
                //var ColumnsContac = Helpers.SettingSync.SettingHubSpot.ColumsEntity.Find(element => element.Entity == EnumEntityHubSport.Contact.ToString());

                var AccessTKResult = JsonConvert.DeserializeObject<AccessToken>(Apitoken);

                var url = string.Format(@"api/data/krmprospectos");

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(Prospectos);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
                string baseUrl = Helpers.SettingSync.SettingHubSpot.UrlApiKRM;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessTKResult.access_token);
                    var responseTask = client.PostAsync(url, data);
                    responseTask.Wait();
                    string Result = string.Empty;
                    if (responseTask.Result.IsSuccessStatusCode)
                    {
                        var jsonr = responseTask.Result.Content.ReadAsStringAsync();

                        if (jsonr != null)
                        {
                            Result = jsonr.Result;
                        }
                    }
                    return Result;
                }
            }
            catch (Exception ex)
            {
                Helpers.ExcepcionLog.WriteLog("SendProspectostoKRM", ex);
                return "";
            }
        }

        public static async Task<string> GettokenKRM()
        {
            try
            {
                //var Apitoken = "";
                //var ColumnsContac = Helpers.SettingSync.SettingHubSpot.ColumsEntity.Find(element => element.Entity == EnumEntityHubSport.Contact.ToString());

                var url = string.Format(@"token");

                //var json = Newtonsoft.Json.JsonConvert.SerializeObject(Prospectos);
                HttpContent content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", Helpers.SettingSync.SettingHubSpot.User),
                new KeyValuePair<string, string>("password", Helpers.SettingSync.SettingHubSpot.Password),
                new KeyValuePair<string, string>("grant_type", Helpers.SettingSync.SettingHubSpot.Grant_type)
            });

               // content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

                //var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
                string baseUrl = Helpers.SettingSync.SettingHubSpot.UrlApiKRM;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                   // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Apitoken);
                    var responseTask = client.PostAsync(url, content);
                    responseTask.Wait();
                    string Result = string.Empty;
                    if (responseTask.Result.IsSuccessStatusCode)
                    {
                        var jsonr = responseTask.Result.Content.ReadAsStringAsync();

                        if (jsonr != null)
                        {
                            Result = jsonr.Result;
                        }
                    }
                    return Result;
                }
            }
            catch (Exception ex)
            {
                Helpers.ExcepcionLog.WriteLog("GettokenKRM", ex);
                return "";
            }
        }

    }
}
