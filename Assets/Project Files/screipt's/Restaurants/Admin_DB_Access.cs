using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.IO;


public class Admin_DB_Access : Client_DB_Access
{

    public void Get_PendingData()
    {
        Get_Orders();
        Cancel_PendingOrder(7);
    }

    public void Get_Orders()
    {

        Pending_Path.GetValueAsync()
       .ContinueWith(task =>
       {
           if (task.IsFaulted)
           {
                // Handle the error...
                Debug.Log("Error ");
           }
           else if (task.IsCompleted)
           {
                // Do something with snapshot...
                DataSnapshot snapshot = task.Result;
                Debug.Log("completed with Total Datas " + snapshot.ChildrenCount);

                   


                 IEnumerable<DataSnapshot> RawDatas = snapshot.Children;
                 List<DataSnapshot> SnapsDatas = RawDatas.ToList();
                 Debug.Log("We Get " + SnapsDatas.Count);



                 //this list hold all pending order list and it will be return from this methode
                 List<ClientsOrder> pendingOrders = new List<ClientsOrder>();
                 foreach (DataSnapshot snap in SnapsDatas)
                 {
                     string Json = snap.GetRawJsonValue();
                     ClientsOrder order = JsonUtility.FromJson<ClientsOrder>(Json);
                     pendingOrders.Add(order);
                     Debug.Log("Table no " + order.TableNO + " ID " + order.IDs.Count + " total Price" + order.Total_Price);
                 }

                 Debug.Log("Pendeing data stored " + pendingOrders.Count);
           
           }
       });


    }
}


