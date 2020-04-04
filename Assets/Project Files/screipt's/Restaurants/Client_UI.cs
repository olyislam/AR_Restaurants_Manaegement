using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Client_UI : UI_Management
{
    #region Property

    [SerializeField]
    private GameObject Scaning_Page;
    [SerializeField]
    private GameObject Description_Page;
    [SerializeField]
    private GameObject OrderList_Page;

    //TotalPrice Will Show in here
    [Space]
    [SerializeField]
    private InputField TableNoField;
    [SerializeField]
    private Button DetailsBtn;
    [SerializeField]
    private Text TotalPrice;
    [SerializeField]
    private VuforiaMonoBehaviour ar_Camera;


    [Space]
    [Header("Scrollbar Content Object")]
    [SerializeField]
    private UI_OrderedContents Ordered_Contents;
    public bool Active_ArCam
    {
        set
        {
            ar_Camera.enabled = value;
        }
    }
#endregion Property

    //Set initial home page
    public virtual void Start()
    {
        base.Start();
        DetailsBtn_isInteractable = false;
        Active_ArCam = false;
    }


    //call from UI Add Button and it will be Add to card List
    public void AddItem()
    {
        string itemID = ApplicationManager.CurrentID;//Get Selected Model ID

        ApplicationManager AP_manager = ApplicationManager.instance;
        Items SelectedItem = AP_manager.Get_Item(itemID);
        AP_manager.card.AddToCard(SelectedItem);
    }


    //Call from ui confirm button
    public void Purcesses()
    {
        int TableNo = ApplicationManager.TableNo;//reference table no where ordered

        ApplicationManager APmanager = ApplicationManager.instance;
        Client_DB_Access Client_DB = APmanager.Client_DataBase;
        Card card = APmanager.card;

        ClientsOrder Client = new ClientsOrder(TableNo, card.Get_OrderList);
        card.Purcesses(Client, Client_DB);
        //Ordered_Contents.CleanOrderPage();
    }


    #region UI_&_Page_Transaction
    //detail Button interactable active and deactive in here
    //initial from "Get_Tracked_ID" class and this Start methode
    public bool DetailsBtn_isInteractable
    {
        set
        {
            DetailsBtn.interactable = value;
        }

    }
    //Call Form UI Button for start this Application
    //and set active AR camera from here
    public void StartScanning()
    {
        string tableno = TableNoField.text;
        try
        {
            int TableNO = System.Int32.Parse(tableno);
            ApplicationManager.TableNo = TableNO;
            Active_ArCam = true;
            Set_CurrenPage(Scaning_Page);

        }
        catch (System.FormatException e)
        {
            TableNoField.text = "";
            Text message = TableNoField.placeholder.GetComponent<Text>();
            message.text = "Enter Positive Integer";
            message.color = Color.red;
        }

    }


    //go to home page and actice ar camera
    public void Back()
    {
        Set_CurrenPage(Scaning_Page);
        Active_ArCam = true;
        Ordered_Contents.CleanOrderPage();
        TotalPrice.text = "0" + " BDT";
    }

    public void Show_Description()
    {
        Active_ArCam = false;
        Set_CurrenPage(Description_Page);//active discription page where will show description
        string id = ApplicationManager.CurrentID;//Get Current Item Id for get the certain model

        ApplicationManager APmanager = ApplicationManager.instance;//Assign ApplicationManager reference 
        Items item = APmanager.Get_Item(id);

        //Assign reference where show item description 
        Item_Shower description = Description_Page.GetComponent<Item_Shower>();
        description.Show(item);//show methode will be show item description that pass into formal parameter

    }

    public void Show_OrderList()
    {
        Active_ArCam = false;
        Set_CurrenPage(OrderList_Page);//Actice Order list Page
        //get all reference from ApplicationManager to show Order List
        int TableNo = ApplicationManager.TableNo;

        Card card = ApplicationManager.instance.card;

        Ordered_Contents.ShowOrderList(card.Get_OrderList);//Pass Order List for Show on ui

        ClientsOrder Client = new ClientsOrder(TableNo, card.Get_OrderList);
        TotalPrice.text = "Total: " + Client.Total_Price + " BDT";
    }
    #endregion _Page_Transaction
}
