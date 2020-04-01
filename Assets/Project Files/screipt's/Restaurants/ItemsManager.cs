using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    #region property
    [Header ("ItemsManager Property")]
    [SerializeField]
    private List<string> Items_ID;
    [SerializeField]
    private List<string> Items_Name;
    [SerializeField]
    private List<int> Items_Price;
    [SerializeField]
    private List<Texture2D> Items_Image;
    #endregion property


    public Items Get_Item(string ID)
    {
        int indx = Items_ID.IndexOf(ID);
        return indx < 0  ?  null : new Items(Items_ID[indx], Items_Name[indx], Items_Price[indx], Items_Image[indx]);
    }

}
