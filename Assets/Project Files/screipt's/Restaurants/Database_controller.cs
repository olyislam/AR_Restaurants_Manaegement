using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Database_controller : MonoBehaviour
{
    DatabaseReference Panding_Path;//database Path where store Panding Order
    public virtual void Start()
    {
        // firebase DB reference here
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://sign-ebff6.firebaseio.com");


        Panding_Path = FirebaseDatabase.DefaultInstance.RootReference.Child("Pnading Orders");

    }

    //this methode will Upload Order into the firebase databas
    public void Purcesses(ClientsOrder OrderedData)
    {
        //subdirectorey for Panding Order in database
        string Table_Information = "Table NO: " + OrderedData.TableNO.ToString();


        string Ordered_Json = JsonUtility.ToJson(OrderedData);
        Panding_Path.Child(Table_Information).SetRawJsonValueAsync(Ordered_Json);//Pass to firebase
    }

}
