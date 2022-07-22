

if (args.Length>0)
{
    string Result;
    if (args[0]=="1")
    {
       Result = await HubSpotDAL.HubSpotProcess.GetContact();
    }
    else
    {
        Result = await HubSpotDAL.HubSpotProcess.UpdContact();
    }
    Console.WriteLine(Result);
}
else
{
    Console.WriteLine("No se ha enviado el parámetro de la acción, envie el valor 1 para HubSpot a BD o el valor 2  para KRM a HubSpot");
    Console.ReadLine();
}

//
//var a = await HubSpotDAL.HubSpotProcess.SendProspectostoKRM();



Console.WriteLine("Finalizado");
//Console.ReadLine();

