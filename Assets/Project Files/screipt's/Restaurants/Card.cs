using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    
    private List<Items> Order_List = new List<Items>();
    public List<Items> Get_OrderList
    {
        get 
        {
            return this.Order_List;
        }
    }



    //call from UI Add Button and it will be Add to card List
    public void AddItem()
    {
        ApplicationManager AP_manager = ApplicationManager.instance;

        string itemID = AP_manager.CurrentID;//Get Selected Model ID
        Items SelectedItem = AP_manager.Get_Item(itemID);
        AddToCard(SelectedItem);
        Debug.Log("count " + Order_List.Count);
    }

    protected void AddToCard(Items NewItem)
    {
        int exestingIndx = -1;

        foreach (Items item in Order_List)
        {
            if (item.ID != NewItem.ID)
                continue;
            
            //existing index storing from here
            exestingIndx = Order_List.IndexOf(item);
            break;
            
        }

        /*Note: if "exestingIndx" value is greater than orequal 0 
          it will represent Product Allready added, even you want to buy more this item
        */
        if (exestingIndx >= 0)
            Order_List[exestingIndx].Add(NewItem);
        else
            Order_List.Add(NewItem);
          
    }


    //call from UI Add Button and it will pass this order data into the database
    public void Purcesses(ClientsOrder Client, Database_controller database)
    {
        database.Purcesses(Client);
    }

}
