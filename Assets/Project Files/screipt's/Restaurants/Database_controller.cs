using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Database_controller : MonoBehaviour
{
    protected DatabaseReference Panding_Path;//database Path where store Panding Order
    protected DatabaseReference Processing_Path;//database Path where store Panding Order


    public virtual void Start()
    {
        // firebase DB reference here
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://sign-ebff6.firebaseio.com");
        Panding_Path = FirebaseDatabase.DefaultInstance.RootReference.Child("Pending Orders");
        Processing_Path = FirebaseDatabase.DefaultInstance.RootReference.Child("Processing");
    }






}
