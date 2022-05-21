

// See https://aka.ms/new-console-template for more information
//var a = await HubSpotDAL.HubSpotProcess.UpdContact();
//var a = await HubSpotDAL.HubSpotProcess.GetContact();
var a = await HubSpotDAL.HubSpotProcess.SendProspectostoKRM();

Console.WriteLine(a);

Console.WriteLine("Finalizado");

Console.ReadLine();

