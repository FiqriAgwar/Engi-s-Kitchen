using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : MonoBehaviour
{
    private MouseCursor cursor;
    // Start is called before the first frame update
    void Start()
    {
        if(cursor == null){
            cursor = GameObject.FindObjectOfType<MouseCursor>();
        }
    }

    void OnMouseDown(){
        cursor.currentCursorName = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
