using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientsOrder
{

    public int TableNO = 0;

    public List<string> IDs = new List<string>();
    public List<int> Quantitys = new List<int>();
    public int Total_Price = 0;
  

    public ClientsOrder(int tableNo, List<Items> TotalOrdered)
    {
        this.TableNO = tableNo;
        foreach (Items order in TotalOrdered)
        {
            this.IDs.Add(order.ID);
            this.Quantitys.Add(order.Quantity);
            this.Total_Price += order.Purced_Price;
        }
    }


}
