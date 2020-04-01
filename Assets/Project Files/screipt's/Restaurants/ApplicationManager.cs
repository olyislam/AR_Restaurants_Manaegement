using System.Collections;
using System.Collections.Generic;
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


    public int TableNo = 3;
    public string CurrentID = "121";
    #endregion property

    public Database_controller DataBase
    {
        get
        {
            return dataBase;
        }
    }

}
