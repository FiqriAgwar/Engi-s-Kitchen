using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panfry : MonoBehaviour
{
    public bool unlock;
    public string acceptableName;
    public string cookedName;

    [Header("Cooking Time")]
    public float cookTime;

    [Header("Sprite Editor")]
    public Sprite locked;
    public Sprite ready;
    public Sprite cookingRaw;
    public Sprite cookedFried;

    private bool cooking;
    private bool cooked;
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
        
        if(unlock){
            rend.sprite = ready;
            cooking = false;
            cooked = false;
            currentTime = 0;
        }
        else{
            rend.sprite = locked;
        }
    }

    void OnMouseDown(){
        if((cursor.currentCursorName == acceptableName) && !cooking && !cooked){
            cursor.currentCursorName = null;
            cooking = true;
        }
        else if(!cooking && cooked && (cursor.currentCursorName == null)){
            cursor.currentCursorName = currentName;
            cooking = false;
            cooked = false;
            currentTime = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(cooking){
            currentTime += Time.deltaTime;
            rend.sprite = cookingRaw;
            currentName = acceptableName;
        }
        else if(cooked){
            rend.sprite = cookedFried;
            currentName = cookedName;
        }
        else{
            rend.sprite = ready;
        }

        if(currentTime > cookTime){
            cooked = true;
            cooking = false;
        }
    }
}
