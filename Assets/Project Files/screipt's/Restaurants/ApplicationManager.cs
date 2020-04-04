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

    #region property
    [Space]
    [Header ("ApplicationManager Reference & property")]

    [SerializeField]
    private Client_DB_Access Client_DB;
    public UI_Management ui;
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

}
