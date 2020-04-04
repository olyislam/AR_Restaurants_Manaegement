using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client_DB_Access : Database_controller
{

    //this methode will Upload your Order into the firebase databas
    public void Purcesses(ClientsOrder OrderedData)
    {
        string Ordered_Json = JsonUtility.ToJson(OrderedData);

        //subdirectorey for Panding Order in database
        string Table_Information = "Table NO: " + OrderedData.TableNO.ToString();
        Panding_Path.Child(Table_Information).SetRawJsonValueAsync(Ordered_Json);//Pass to firebase
    }

}
