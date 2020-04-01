using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Tracked_ID : DefaultTrackableEventHandler
{
    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        ApplicationManager.CurrentID = Item_ID;
        ApplicationManager.instance.ui.DetailsBtn_isInteractable = true;
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        ApplicationManager.instance.ui.DetailsBtn_isInteractable = false;

    }
}
