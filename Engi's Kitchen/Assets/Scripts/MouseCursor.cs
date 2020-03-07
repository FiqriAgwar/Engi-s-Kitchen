using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    private SpriteRenderer rend;
    public Sprite normalCursor;
    public Sprite pointerCursor;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;

        if(Input.GetMouseButtonDown(0)){
            rend.sprite = pointerCursor;
        }
        else if(Input.GetMouseButtonUp(0)){
            rend.sprite = normalCursor;
        }
    }
}
