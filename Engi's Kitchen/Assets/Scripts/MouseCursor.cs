using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    private SpriteRenderer rend;
    public Sprite normalCursor;
    public Sprite pointerCursor;

    [HideInInspector]
    public string currentCursorName;
    public CustomCursor[] listCursor;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        rend = GetComponent<SpriteRenderer>();
        currentCursorName = null;
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
            updateCursor();
        }
    }

    void updateCursor(){
        if(currentCursorName == null){
            rend.sprite = normalCursor;
        }
        else{
            for(int i=0;i<listCursor.Length;i++){
                CustomCursor iterationCursor = listCursor[i];
                if(currentCursorName == iterationCursor.nameCursor){
                    rend.sprite = iterationCursor.cursorSprite;
                    return;
                }
            }
        }
    }
}
