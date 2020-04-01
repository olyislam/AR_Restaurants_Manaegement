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
    private Database_controller dataBase;
    public UI_Management ui;
    public Card card;


    public static int TableNo = 0;
    public static
    string CurrentID ;
    #endregion property

    public Database_controller DataBase
    {
        get
        {
            return dataBase;
        }
    }

}
