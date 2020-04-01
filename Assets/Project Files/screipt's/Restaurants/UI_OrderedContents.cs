using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
[RequireComponent(typeof(VerticalLayoutGroup))]
public class UI_OrderedContents : MonoBehaviour
{
    [SerializeField]
    private RectTransform ContentsParent;//Uiparent where information show

    //Instantiate this panel for show item info
    //Note this object has "Item_Shower" component
    [SerializeField]
    private GameObject OrderedElementShoewr;


    private const int contentlength = 300;//single content size
    private int TotalLength = 0;//this variable will increased and hold to total Content length

    //Call From UI_Management class for show order list on ui
    public void ShowOrderList(List<Items> items)
    {
        foreach (Items item in items)
        {
            //Generate a free space on scrollbar for show new content 
            TotalLength += contentlength;
            ContentsParent.sizeDelta = new Vector2(ContentsParent.sizeDelta.x, TotalLength); 
           
            
            GameObject Shoer = Instantiate(OrderedElementShoewr, ContentsParent);//Create new UI panel under the content object
            Item_Shower ordered_item = Shoer.GetComponent<Item_Shower>();//get shower object where show item
            ordered_item.Show(item);//set item information on UI element
        }
    }
    public void CleanOrderPage()
    {
        if (ContentsParent.childCount > 0)
        {
            int TotalElements = ContentsParent.childCount;
            for (int i = 0; i < TotalElements; i++)
            {
                GameObject item = ContentsParent.GetChild(i).gameObject;
                Destroy(item);
            }
            TotalLength = 0;
            ContentsParent.sizeDelta = new Vector2(ContentsParent.sizeDelta.x, TotalLength);
        }
    }

}
