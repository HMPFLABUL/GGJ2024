using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviourSingleton<CursorManager>
{
    [SerializeField] Texture2D defaultCursorTexture;
    [SerializeField] Texture2D dialogueCursorTexture;
    [SerializeField] Texture2D interactionCursorTexture;
    private Vector2 cursorSpot;

    private void Start()
    {
        SetDefaultCursor();
    }
    public void SetDefaultCursor()
    {
        cursorSpot = new Vector2(defaultCursorTexture.width / 2, defaultCursorTexture.height / 2);
        Cursor.SetCursor(defaultCursorTexture, cursorSpot, CursorMode.Auto);
    }
    public void SetDialogueCursor()
    {
        cursorSpot = new Vector2(defaultCursorTexture.width / 2, defaultCursorTexture.height / 2);
        Cursor.SetCursor(dialogueCursorTexture, cursorSpot, CursorMode.Auto);
    }
    public void SetInteractionCursor()
    {
        cursorSpot = new Vector2(defaultCursorTexture.width / 2, defaultCursorTexture.height / 2);
        Cursor.SetCursor(interactionCursorTexture, cursorSpot, CursorMode.Auto);
    }
}
