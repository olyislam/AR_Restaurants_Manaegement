using UnityEngine;
using UnityEngine.UI;

public class UI_Management : MonoBehaviour
{

    #region Property

    //ALL Activity Pages
    [SerializeField]
    private GameObject Home_Page;
    [SerializeField]
    private GameObject Description_Page;
    [SerializeField]
    private GameObject OrderList_Page;

    //TotalPrice Will Show in here
    [Space]
    [SerializeField]
    private Text TotalPrice;

    
    [Space]
    [Header("Scrollbar Content Object")]
    [SerializeField]
    private UI_OrderedContents Ordered_Contents;

    #endregion Property


    public void Start()
    {
        Debug.Log("UI Handeller");
        Set_CurrenPage(Home_Page); //Active Home Page
    }
    public void Purcesses()
    {
        ApplicationManager APmanager = ApplicationManager.instance;
        Database_controller database = APmanager.DataBase;
        int TableNo = APmanager.TableNo;
        Card card = APmanager.card;

        ClientsOrder Client = new ClientsOrder(TableNo, card.Get_OrderList);
        card.Purcesses(Client, database);
    }

    #region Page_Transaction
    public void Go_Home()
    {
        Set_CurrenPage(Home_Page);
        Ordered_Contents.CleanOrderPage();
        TotalPrice.text = "0" + " BDT";
    }

    public void Show_Description()
    {
        Set_CurrenPage(Description_Page);//active discription page where will show description

        ApplicationManager APmanager = ApplicationManager.instance;//Assign ApplicationManager reference 
        string id = APmanager.CurrentID;//Get Current Item Id for get the certain model
        Items item = APmanager.Get_Item(id);

        //Assign reference where show item description 
        Item_Shower description = Description_Page.GetComponent<Item_Shower>();
        description.Show(item);//show methode will be show item description that pass into formal parameter

    }

    public void Show_OrderList()
    {
        Set_CurrenPage(OrderList_Page);//Actice Order list Page
        //get all reference from ApplicationManager to show Order List
        ApplicationManager APmanager = ApplicationManager.instance;
        int TableNo = APmanager.TableNo;
        Card card = APmanager.card;

        Ordered_Contents.ShowOrderList(card.Get_OrderList);//Pass Order List for Show on ui

        ClientsOrder Client = new ClientsOrder(TableNo, card.Get_OrderList);
        TotalPrice.text ="Total: "+ Client.Total_Price + " BDT";
    }


    //active Current page and deacive old page
    private GameObject Activated_Page;
    protected void Set_CurrenPage(GameObject New_Activity)
    {
        if (New_Activity == Activated_Page)
            return;

        Activated_Page = Activated_Page == null ? New_Activity : Activated_Page;
        Activated_Page.SetActive(false);
        New_Activity.SetActive(true);
        Activated_Page = New_Activity;
    }
    #endregion Page_Transaction
}
