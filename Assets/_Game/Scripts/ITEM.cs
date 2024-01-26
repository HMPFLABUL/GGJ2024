using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITEM : MonoBehaviour
{
    private void OnMouseEnter()
    {
        if (CheckDistance())
            CursorManager.Instance.SetInteractionCursor();
    }

    protected bool CheckDistance()
    {
        if (Vector3.Distance(Player.Instance.transform.position, transform.position) < 3)
            return true;
        return false;
    }

    private void OnMouseExit()
    {
        CursorManager.Instance.SetDefaultCursor();
    }
}
