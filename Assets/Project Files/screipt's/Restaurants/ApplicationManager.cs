using UnityEngine;

public class ApplicationManager : ItemsManager
{    //singleton from here
    #region singleton
    private static ApplicationManager _instance;
    public static ApplicationManager instance
    {
        get
        {
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }

    #endregion singleton

    #region Admin
    

    #endregion Admin


/**********************************************************************************/


    #region Client

    #region property


    [Header ("Client Reference Propertys")]

    [SerializeField]
    private Client_DB_Access Client_DB;
    public Client_UI ui;
    public Card card;


    public static int TableNo = 0;
    public static string CurrentID ;

    #endregion property

    public Client_DB_Access Client_DataBase
    {
        get
        {
            return Client_DB;
        }
    }
    #endregion Client
}
