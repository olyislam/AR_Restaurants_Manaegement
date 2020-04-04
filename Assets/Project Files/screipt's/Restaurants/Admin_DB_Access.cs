using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
public class Admin_DB_Access : Client_DB_Access
{
    
    public void Get_Order(int table_no)
    {
        string Table_Information = "Table NO: " + table_no;

         Panding_Path//.Child(Table_Information)
        .GetValueAsync().ContinueWith(task => {
             if (task.IsFaulted)
             {
                Debug.Log("Error " );
                      // Handle the error...
             }
             else if (task.IsCompleted)
             {
                // Do something with snapshot...
                DataSnapshot snapshot = task.Result;
                Debug.Log("completed " + snapshot);

                Debug.Log("Total dATA " + snapshot.ChildrenCount);

                DataSnapshot t1 = snapshot.Child(Table_Information);
                string T1Json = t1.GetRawJsonValue();
                ClientsOrder t1order = JsonUtility.FromJson<ClientsOrder>(T1Json);
                Debug.Log("retroved Data IDs: " + t1order.IDs.Count + " TotalProice = " + t1order.Total_Price);


                table_no = 3;
                Table_Information = "Table NO: " + table_no;
                DataSnapshot t2 = snapshot.Child(Table_Information);
                string T2Json = t2.GetRawJsonValue();
                ClientsOrder t2order = JsonUtility.FromJson<ClientsOrder>(T2Json);
                Debug.Log("retroved Data IDs: " + t2order.IDs.Count + " TotalProice = " + t2order.Total_Price);

            }
        });

    }
}
