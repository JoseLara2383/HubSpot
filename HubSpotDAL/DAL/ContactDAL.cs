using HubSpotDAL.EntityHS.ContactHS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubSpotDAL.DAL
{
    internal class ContactDAL
    {
        public async void InsUpdData(string conexionString, DataResult DataResult, string SP = "")
        {
            // string message = string.Empty;
            SP = "dbo.st_InsUpdContacts";
            try
            {
                using (SqlConnection connection = new SqlConnection(conexionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = SP;
                  

                    SqlParameter Param;
                    connection.Open();
                    foreach (var itemContact in DataResult.results)
                    {
                        command.Parameters.Clear();
                        Param = new SqlParameter("@ID_Contacts",SqlDbType.BigInt);
                        Param.Direction = ParameterDirection.Output;
                        command.Parameters.Add(Param);
                     
                        Param = new SqlParameter("@id", itemContact.id);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@actualizado", itemContact.properties.actualizado);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@agenteid", itemContact.properties.agenteid);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@am_mkt", itemContact.properties.am_mkt);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@ap_mkt", itemContact.properties.ap_mkt);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@apellido_materno", itemContact.properties.apellido_materno);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@asesor", itemContact.properties.asesor);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@asistio_a_su_cita_programada", itemContact.properties.asistio_a_su_cita_programada_);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@banco", itemContact.properties.banco);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@campana", itemContact.properties.campana);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@canal", itemContact.properties.canal);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@canal_digital", itemContact.properties.canal_digital);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@canal_tradicional", itemContact.properties.canal_tradicional);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@cantidad_hijos", itemContact.properties.cantidad_hijos);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@clienteid", itemContact.properties.clienteid);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@comentarios", itemContact.properties.comentarios);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@contacto_efectivo", itemContact.properties.contacto_efectivo);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@correo_electrnico", itemContact.properties.correo_electrnico);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@creado_en", itemContact.properties.creado_en);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@credito", itemContact.properties.credito);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@curp", itemContact.properties.curp);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@date_of_birth", itemContact.properties.date_of_birth);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@desarrollo", itemContact.properties.desarrollo);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@duplicado", itemContact.properties.duplicado);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@enkontrol", itemContact.properties.enkontrol);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@estatus", itemContact.properties.estatus);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@fecha_apartado", itemContact.properties.fecha_apartado);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@fecha_asignacion", itemContact.properties.fecha_asignacion);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter("@fecha_atencion", SqlDbType.DateTime);
                        Param.Value = itemContact.properties.fecha_atencion == null ? (object)DBNull.Value : Convert.ToDateTime(itemContact.properties.fecha_atencion);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter("@fecha_cita", SqlDbType.DateTime);
                        Param.Value = itemContact.properties.fecha_cita == null ? (object)DBNull.Value : Convert.ToDateTime(itemContact.properties.fecha_cita);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter("@fecha_creacion", SqlDbType.DateTime);
                        Param.Value = itemContact.properties.fecha_creacion == null ? (object)DBNull.Value : Convert.ToDateTime(itemContact.properties.fecha_creacion);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter("@fecha_registro", SqlDbType.DateTime);
                        Param.Value = itemContact.properties.fecha_registro == null ? (object)DBNull.Value : Convert.ToDateTime(itemContact.properties.fecha_registro);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter("@first_conversion_event_name", itemContact.properties.first_conversion_event_name);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@grado_interes", itemContact.properties.grado_interes);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@horario_de_contacto", itemContact.properties.horario_de_contacto);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@hs_analytics_first_url", itemContact.properties.hs_analytics_first_url);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@hs_analytics_last_timestamp", SqlDbType.DateTime);
                        Param.Value = itemContact.properties.hs_analytics_last_timestamp == null ? (object)DBNull.Value : Convert.ToDateTime(itemContact.properties.hs_analytics_last_timestamp);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@hs_analytics_last_touch_converting_campaign", itemContact.properties.hs_analytics_last_touch_converting_campaign);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@hs_analytics_last_url", itemContact.properties.hs_analytics_last_url);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@hs_analytics_num_page_views", itemContact.properties.hs_analytics_num_page_views);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@hs_analytics_source", itemContact.properties.hs_analytics_source);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@hs_analytics_source_data_1", itemContact.properties.hs_analytics_source_data_1);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@hs_analytics_source_data_2", itemContact.properties.hs_analytics_source_data_2);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@hs_content_membership_email_confirmed", itemContact.properties.hs_content_membership_email_confirmed);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter("@hs_last_sales_activity_timestamp", SqlDbType.DateTime);
                        Param.Value = itemContact.properties.hs_last_sales_activity_timestamp == null ? (object)DBNull.Value : Convert.ToDateTime(itemContact.properties.hs_last_sales_activity_timestamp);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter("@hs_persona", itemContact.properties.hs_persona);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@hs_predictivescoringtier", itemContact.properties.hs_predictivescoringtier);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter("@hubspot_owner_assigneddate", SqlDbType.DateTime);
                        Param.Value = itemContact.properties.hubspot_owner_assigneddate == null ? (object)DBNull.Value : Convert.ToDateTime(itemContact.properties.hubspot_owner_assigneddate);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter("@hubspot_owner_id", itemContact.properties.hubspot_owner_id);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@imagen_url", itemContact.properties.imagen_url);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@isassignable", itemContact.properties.isassignable);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@isover", itemContact.properties.isover);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@isready", itemContact.properties.isready);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@lastname", itemContact.properties.lastname);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@lugares_reservados", itemContact.properties.lugares_reservados);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@motivo_de_compra", itemContact.properties.motivo_de_no_contacto);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@motivo_de_no_contacto", itemContact.properties.@motivo_de_no_contacto);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@nombre_categoria", itemContact.properties.nombre_categoria);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@nombre_completo", itemContact.properties.nombre_completo);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter("@notes_last_contacted", SqlDbType.DateTime);
                        Param.Value = itemContact.properties.notes_last_contacted == null ? (object)DBNull.Value : Convert.ToDateTime(itemContact.properties.notes_last_contacted);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter("@notes_last_updated", SqlDbType.DateTime);
                        Param.Value = itemContact.properties.notes_last_updated == null ? (object)DBNull.Value : Convert.ToDateTime(itemContact.properties.notes_last_updated);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter("@objecion", itemContact.properties.objecion);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@origen_de_referido", itemContact.properties.origen_de_referido);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@pauta", itemContact.properties.pauta);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@phone", itemContact.properties.phone);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@plataforma", itemContact.properties.plataforma);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@plaza", itemContact.properties.plaza);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@precio_fraccionamiento", itemContact.properties.precio_fraccionamiento);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@priority", itemContact.properties.priority);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@propietario", itemContact.properties.propietario);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@prototipo", itemContact.properties.prototipo);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@punto_de_encuentro", itemContact.properties.punto_de_encuentro);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@punto_de_venta", itemContact.properties.punto_de_venta);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@rango_ingresos", itemContact.properties.rango_ingresos);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@respondido", itemContact.properties.respondido);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@staff_mkt", itemContact.properties.staff_mkt);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@tagid", itemContact.properties.tagid);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@telefono_2", itemContact.properties.telefono_2);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@tiempo_interes_compra", itemContact.properties.tiempo_interes_compra);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@tiene_hijos", itemContact.properties.tiene_hijos);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@tipo_cita", itemContact.properties.tipo_cita);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@twitterprofilephoto", itemContact.properties.twitterprofilephoto);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@username", itemContact.properties.username);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@visita", itemContact.properties.visita);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@yotellevo", itemContact.properties.yotellevo);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@gander", itemContact.properties.gander);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@email", itemContact.properties.email);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@tipo_persona", itemContact.properties.tipo_persona);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@rfc", itemContact.properties.rfc);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter("@estado_civil", itemContact.properties.estado_civil);
                        command.Parameters.Add(Param);



                       int  i =  command.ExecuteNonQuery();

                        if (itemContact.properties.ID_Contacts ==0)
                        {
                            itemContact.properties.ID_Contacts =  command.Parameters["@ID_Contacts"].Value == DBNull.Value ? 0 : Convert.ToInt64(command.Parameters["@ID_Contacts"].Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Helpers.ExcepcionLog.WriteLog("InsUpdData", ex);
            }

          
        }
    }
}
