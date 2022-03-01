using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static HubSpotDAL.Helpers.EnumHubspot;

namespace HubSpotDAL.WebClient
{
    internal static class HubSpotApi
    {
        public static async Task<string> GetContact(string after="")
        {
            try
            {
                var ApiKey = Helpers.SettingSync.SettingHubSpot.APiKey;
                var ColumnsContac = Helpers.SettingSync.SettingHubSpot.ColumsEntity.Find(element => element.Entity == EnumEntityHubSport.Contact.ToString());

                var url = @"contacts/?{0}";

                var ListColums = ColumnsContac.Columns.Split(",");
                var columsProperty = string.Empty;
                 foreach (var item in ListColums)
                {
                    columsProperty = columsProperty + string.Format("properties={0}&", item);
                }
                
                url = string.Format(url, columsProperty);
                url = url + "hapikey={0}";

                //                properties=hs_analytics_source&properties=hs_analytics_source_data_1&properties=first_conversion_event_name&archived=false
                //&hapikey={0}&properties=currentlyinworkflow&properties=message&properties=hs_analytics_average_page_views";


                string baseUrl =Helpers.SettingSync.SettingHubSpot.UrlApiHubSpot ; //$"{_config.IDMServiceEndPoint}/{action}";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    // client. = System.Text.Encoding.UTF8;
                    // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tk); // I've tried "Token" as well.
                    // var byteContent = new ByteArrayContent(new byte[0]);
                    //var url = WebUtility.UrlEncode(WebUtility.UrlEncode(idMonday));
                   
                    var responseTask = client.GetAsync(string.Format(url, ApiKey));
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
            catch (HttpRequestException ex)
            {
                Helpers.ExcepcionLog.WriteLog("GetCliente", ex);
                return "";
            }
        }

        public static async Task<string> PostContact(string after ="")
        {
            try
            {
                var ApiKey = Helpers.SettingSync.SettingHubSpot.APiKey;
                var ColumnsContac = Helpers.SettingSync.SettingHubSpot.ColumsEntity.Find(element => element.Entity == EnumEntityHubSport.Contact.ToString());
                Model.FilterHubSpot FilterHubSpot = new Model.FilterHubSpot();

                var url = @"contacts/search?";

                var ListColums = ColumnsContac.Columns.Split(",");
                var columsProperty = string.Empty;
                foreach (var item in ListColums)
                {
                    FilterHubSpot.properties.Add(item);
                }

                url = url  +"hapikey={0}";

                var filter = new Model.Filter() { propertyName = "lastmodifieddate", @operator = "GT", value = "919747892000" };
                var filterg = new Model.FilterGroup();
                filterg.filters.Add(filter);
                FilterHubSpot.filterGroups.Add(filterg);              
                FilterHubSpot.limit = 100;
                FilterHubSpot.after = after;
               // string jsonf = @"{""filterGroups"": [{ ""filters"": [{""propertyName"":""lastmodifieddate"",""operator"": ""GT"",""value"":""919747892000""}]}],""properties"":[""actualizado"",""email"",""firstname""],""limit"": 100,""after"": 0}";
                //string.Format("{{\"security\":{{\"Email\":\"{0}\",\"Password\":\"{1}\"}}}}", 22, 22);
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(FilterHubSpot);
                var data = new System.Net.Http.StringContent(json, Encoding.UTF8, "application/json");
                
                string baseUrl = Helpers.SettingSync.SettingHubSpot.UrlApiHubSpot; //$"{_config.IDMServiceEndPoint}/{action}";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    // client. = System.Text.Encoding.UTF8;
                    // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tk); // I've tried "Token" as well.
                    // var byteContent = new ByteArrayContent(new byte[0]);
                    //var url = WebUtility.UrlEncode(WebUtility.UrlEncode(idMonday));                   
                    var responseTask = client.PostAsync(string.Format(url, ApiKey), data);
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
            catch (HttpRequestException ex)
            {
                // Helpers.ExcepcionLog.WriteLog("GetCliente", ex);
                return "";
            }
        }


    }
}
