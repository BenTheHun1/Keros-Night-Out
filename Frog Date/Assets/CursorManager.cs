using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D openCursor;
    public Texture2D pointCursor;
    public Vector2 cursorHotSpot;

    public void CursorEnter()
    {
        Cursor.SetCursor(pointCursor, cursorHotSpot, CursorMode.Auto);
    }

    public void CursorExit()
    {
        Cursor.SetCursor(openCursor, cursorHotSpot, CursorMode.Auto);
    }
}
