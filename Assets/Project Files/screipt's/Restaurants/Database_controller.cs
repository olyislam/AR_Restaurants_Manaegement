using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Database_controller : MonoBehaviour
{
    protected DatabaseReference Pending_Path;//database Path where store Panding Order
    protected string pending_Sub_Dir = "Table NO: ";

    protected DatabaseReference Processing_Path;//database Path where store Panding Order



    public virtual void Start()
    {
        // firebase DB reference here
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://sign-ebff6.firebaseio.com");
        Pending_Path = FirebaseDatabase.DefaultInstance.RootReference.Child("Pending Orders");
        Processing_Path = FirebaseDatabase.DefaultInstance.RootReference.Child("Processing");
    }
 



    protected void Remove_Data(DatabaseReference Path)
    {
        Path.RemoveValueAsync();
    }

    public void SendData(ClientsOrder OrderedData)
    {
        string Ordered_Json = JsonUtility.ToJson(OrderedData);

        //subdirectorey for Panding Order in database
        string Table_Information = pending_Sub_Dir + OrderedData.TableNO.ToString();
        Pending_Path.Child(Table_Information).SetRawJsonValueAsync(Ordered_Json);//Pass to firebase
    }
}
