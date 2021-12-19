using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class mouseCursor : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D cursor;
    public Texture2D cursorClicked;
    private SpriteRenderer rend;
    //public Sprite highlightCursor;
    private CursorControls controls;
    public void Awake()
    {
        controls = new CursorControls();
        ChangeCursor(cursor);
        Cursor.lockState = CursorLockMode.Confined;
    }
    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();

    }

    private void Start()
    {
        //Cursor.visible = false;
        controls.MouseActionMap.Click.started += _ => StartedClick();
        controls.MouseActionMap.Click.performed += _ => EndedClick();
    }
    private void StartedClick()
    {
        ChangeCursor(cursorClicked);
    }
    private void EndedClick()
    {
        ChangeCursor(cursor);
    }

    private void ChangeCursor(Texture2D cursorType)
    {
        Vector2 hotspot = new Vector2 (cursorType.width /2, cursorType.height /2);
        Cursor.SetCursor(cursorType, Vector2.zero,CursorMode.Auto);
    }

    
    
}
