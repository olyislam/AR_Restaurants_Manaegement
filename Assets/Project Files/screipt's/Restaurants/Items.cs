using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items 
{
    public Texture2D Image;
    public string Name;
    public string ID;
    public int Quantity;
    public int Price;
    public int Purced_Price;

    public Items(string id, string name, int price, Texture2D image)
    {
        this.Image = image;
        this.Name = name;
        this.ID = id;
        this.Price = price;
        this.Quantity = 1;
        this.Purced_Price = Price * Quantity;
    }

    //this methode use for increase item after added card
    public void Add(Items NewItem)
    {
        this.Quantity += NewItem.Quantity;
        this.Purced_Price = this.Price * this.Quantity;
        Debug.Log("price updated " + this.Purced_Price);
    }

 
}
