﻿using HubSpotDAL.EntityHS.ContactHS;
using HubSpotDAL.Model;
using HubSpotDAL.WebClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubSpotDAL.DAL
{
    internal class ProspectosDAL
    {
        public async void SendProspectotoKRM(string conexionString, List<ContactData> Contacts)
        {
            try
            {
                string ResultKRM = string.Empty;
                DAL.ContactDAL ContactDAL;
                  Prospecto Prospecto;
                if (Contacts.Count > 0)
                {
                    ListProspectos Prospectos = new ListProspectos();
                    foreach (var itemContact in Contacts)
                    {
                        Prospecto = new Prospecto()
                        {
                            IdHubspot = itemContact.id,
                            Nombre = itemContact.properties.nombre_completo,
                            ApellidoPaterno = itemContact.properties.lastname,
                            ApellidoMaterno = itemContact.properties.apellido_materno,
                            FechadeNacimiento = String.IsNullOrEmpty(itemContact.properties.date_of_birth) ? "" : DateTime.Parse( itemContact.properties.date_of_birth).ToString("yyyy-MM-dd"),
                            RFC = itemContact.properties.rfc,
                            Telefono = itemContact.properties.telefono_2,
                            Genero = Helpers.SettingSync.GetGenero(itemContact.properties.gender),
                            TelefonoMovil = itemContact.properties.phone,
                            Email = itemContact.properties.correo_electrnico,
                            TipoPersona = itemContact.properties.tipo_persona,
                            EstadoCivil = itemContact.properties.estado_civil,
                            Etapa = "1",
                            PuntoVenta = Helpers.SettingSync.GetPuntoVenta(itemContact.properties.punto_de_venta),
                            MedioPubicidad = Helpers.SettingSync.GetMedioPublicidad(itemContact.properties.canal_tradicional),
                            CampañaPublicidad = Helpers.SettingSync.GetCampaniaPublicidad(itemContact.properties.campana),
                        };
                        if(Prospecto.isValid())
                            Prospectos.Prospectos.Add(Prospecto);
                    }

                    //Send data to krm
                    if (Prospectos.Prospectos.Count > 0)
                    {
                      ResultKRM =  await  KRMApi.SendProspectostoKRM(Prospectos);
                        try
                        {
                            ResultKRM = ResultKRM.Replace("\\r\\n      ", "").Replace("\\r\\n  ", "").Replace("\\r\\n", "").Replace("\\\"", "\"").Replace("\"{", "{").Replace("}\"", "}");
                            ProspectosResult PropespetosResult = JsonConvert.DeserializeObject<ProspectosResult>(ResultKRM);
                            //Sacar los que fueron exitosos
                           if (PropespetosResult!=null && PropespetosResult.Result.Count()>0)
                            {
                                string ListHuspotId = string.Empty;
                              var ProspetotoKRM =   PropespetosResult.Result.Where(Prospecto => Prospecto.success == "True");
                                foreach (var item in ProspetotoKRM)
                                {
                                    ListHuspotId = ListHuspotId ==string.Empty ? item.id_HubSpot :  string.Format("{0},{1}", ListHuspotId, item.id_HubSpot);
                                }

                                //Actualizar la Base de datos como enviado
                                if (ListHuspotId != string.Empty)
                                {
                                    ContactDAL = new DAL.ContactDAL();
                                    ContactDAL.InsUpdData(conexionString, ListHuspotId);
                                }
                            }


                        }
                        catch (Exception ex)
                        {

                            Helpers.ExcepcionLog.WriteLog("SendProspectostoKRM", "No se puedo procesar la respuesta de KRM: " + ex.Message);
                        }
                    }
                }

            }
            catch (Exception ex) 
            {

                Helpers.ExcepcionLog.WriteLog("SendProspectotoKRM", ex);
            }
        }

       

        
       
    }
}
