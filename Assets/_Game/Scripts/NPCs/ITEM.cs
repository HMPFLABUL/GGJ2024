using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITEM : ENTITY
{
    bool changed = false;
    private void OnMouseOver()
    {
        if (!changed && CheckForGameplayState() && CheckDistanceToPlayer())
        {
            CursorManager.Instance.SetInteractionCursor();
            changed = true;
        }
    }

   
    private void OnMouseExit()
    {
        CursorManager.Instance.SetDefaultCursor();
        changed = false;
    }
}
