using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMouse : MonoBehaviour
{
    public Texture2D cursorArrow;
    public int width;
    public int height;


    void Start()
    {
        //cursorArrow.Resize( width, height); 
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }

}
