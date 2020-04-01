using UnityEngine;
using UnityEngine.UI;

public class Item_Shower : MonoBehaviour
{
    [SerializeField]
    private RawImage Image;
    [SerializeField]
    private Text Name;
    [SerializeField]
    private Text Price;
    [SerializeField]
    private Text Quantity;

    //this object Instantiate each time with attached GameObject
    //this methode will show items description on UI  
    public void Show(Items New_Item)
    {
        Image.texture = New_Item.Image;
        Name.text = "Name: " + New_Item.Name;
        Price.text = "Price: " + New_Item.Price;
        if (Quantity != null)
        {
            Quantity.text = New_Item.Quantity.ToString() + " pic";
            Price.text = New_Item.Purced_Price.ToString() + " BDT";
        }
    }
}
