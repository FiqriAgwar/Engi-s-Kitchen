using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill : MonoBehaviour
{
    public bool unlock;
    public string acceptableName;
    public string cookedName;
    public string burnedName;

    [Header("Cooking Time")]
    public float cookTime;
    public float burnTime;

    [Header("Sprite Editor")]
    public Sprite locked;
    public Sprite ready;
    public Sprite cookingRaw;
    public Sprite cookingGrill;
    public Sprite burnedGrill;

    private bool cooking;
    private bool burning;
    private bool burned;
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
            burning = false;
            burned = false;
            currentTime = 0;
        }
        else{
            rend.sprite = locked;
        }
    }

    void OnMouseDown(){
        if((cursor.currentCursorName == acceptableName) && !cooking && !burning && !burned){
            cursor.currentCursorName = null;
            cooking = true;
        }
        else if(!cooking && (burning || burned) && (cursor.currentCursorName == null)){
            cursor.currentCursorName = currentName;
            cooking = false;
            burned = false;
            burning = false;
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
        else if(burning){
            currentTime += Time.deltaTime;
            rend.sprite = cookingGrill;
            currentName = cookedName;
        }
        else if(burned){
            rend.sprite = burnedGrill;
            currentName = burnedName;
        }
        else{
            rend.sprite = ready;
        }

        if(currentTime > cookTime + burnTime){
            rend.sprite = burnedGrill;
            currentName = burnedName;
            burned = true;
            burning = false;
        }
        else if(currentTime > cookTime){
            burning = true;
            cooking = false;
        }
    }
}
