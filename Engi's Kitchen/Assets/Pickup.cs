using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public string resource;
    private MouseCursor cursor;
    // Start is called before the first frame update
    void Start()
    {
        if(cursor == null){
            cursor = GameObject.FindObjectOfType<MouseCursor>();
        }
    }

    void OnMouseDown(){
        if(cursor.currentCursorName == null){    
            cursor.currentCursorName = resource;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
