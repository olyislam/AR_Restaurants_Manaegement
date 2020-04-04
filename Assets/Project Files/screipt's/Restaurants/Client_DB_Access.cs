using UnityEngine;
using Firebase.Database;
public class Client_DB_Access : Database_controller
{

    public void Cancel_PendingOrder(int TableNo)
    {
        DatabaseReference path = Pending_Path.Child(pending_Sub_Dir + TableNo.ToString());
        Remove_Data(path);
    }


}
