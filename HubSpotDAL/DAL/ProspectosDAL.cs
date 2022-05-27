using HubSpotDAL.EntityHS.ContactHS;
using HubSpotDAL.Model;
using HubSpotDAL.WebClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubSpotDAL.DAL
{
    internal class ProspectosDAL
    {
        public void SendProspectotoKRM(string conexionString, List<ContactData> Contacts)
        {
            try
            {
                if (Contacts.Count > 0)
                {
                    ListProspectos Prospectos = new ListProspectos();
                    foreach (var itemContact in Contacts)
                    {

                        Prospectos.Prospectos.Add(new Prospecto()
                        {
                            IdHubspot = itemContact.id,
                            Nombre = itemContact.properties.nombre_completo,
                            ApellidoPaterno = itemContact.properties.lastname,
                            ApellidoMaterno = itemContact.properties.apellido_materno,
                            FechadeNacimiento = itemContact.properties.date_of_birth,
                            RFC = itemContact.properties.rfc,
                            Telefono = itemContact.properties.telefono_2,
                            Genero = Helpers.SettingSync.GetGenero(itemContact.properties.gander),
                            TelefonoMovil = itemContact.properties.phone,
                            Email = itemContact.properties.correo_electrnico,
                            TipoPersona = Helpers.SettingSync.GetTipoPersona(itemContact.properties.tipo_persona),
                            EstadoCivil = Helpers.SettingSync.GetEstadoCivil(itemContact.properties.estado_civil),
                            Etapa = "1",
                            PuntoVenta = itemContact.properties.punto_de_venta,
                            MedioPubicidad = Helpers.SettingSync.GetMedioPublicidad(itemContact.properties.canal_tradicional),
                            CampañaPublicidad = Helpers.SettingSync.GetCampaniaPublicidad(itemContact.properties.campana),
                        });
                    }

                    //Send data to krm
                    if (Prospectos.Prospectos.Count > 0)
                    {
                        KRMApi.SendProspectostoKRM(Prospectos);
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
