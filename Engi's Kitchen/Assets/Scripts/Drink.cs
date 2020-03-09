using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drink : MonoBehaviour
{
    public string readyName;

    [Header("Prepare Time")]
    public float prepareTime;

    [Header("Sprite Editor")]
    public Sprite ready;
    public Sprite preparing;
    public Sprite prepared;

    private bool pouring;
    private bool poured;
    private SpriteRenderer rend;
    private MouseCursor cursor;

    private float currentTime;
    private string currentName;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        if(cursor == null){
            cursor = GameObject.FindObjectOfType<MouseCursor>();
        }
        
        rend.sprite = ready;
        pouring = false;
        poured = false;
        currentTime = 0;
    }

    void OnMouseDown(){
        if((cursor.currentCursorName == null) && !pouring && !poured){
            pouring = true;
        }
        else if(!pouring && poured && (cursor.currentCursorName == null)){
            cursor.currentCursorName = currentName;
            pouring = false;
            poured = false;
            currentTime = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(pouring){
            currentTime += Time.deltaTime;
            rend.sprite = preparing;
        }
        else if(poured){
            rend.sprite = prepared;
            currentName = readyName;
        }
        else{
            rend.sprite = ready;
        }

        if(currentTime > prepareTime){
            poured = true;
            pouring = false;
        }
    }
}
