using UnityEngine;
using UnityEngine.UI;

public class UI_Management : MonoBehaviour
{

    #region Property

    //ALL Activity Pages
    [SerializeField]
    protected GameObject Home_Page;   

    //active Current page and deacive old page
    private GameObject Activated_Page;
    #endregion UI_&Property




    public virtual void Start()
    {
        Set_CurrenPage(Home_Page); //Active Home Page
    }


    protected void Set_CurrenPage(GameObject New_Activity)
    {
        if (New_Activity == Activated_Page)
            return;

        Activated_Page = Activated_Page == null ? New_Activity : Activated_Page;
        Activated_Page.SetActive(false);
        New_Activity.SetActive(true);
        Activated_Page = New_Activity;
    }


}
