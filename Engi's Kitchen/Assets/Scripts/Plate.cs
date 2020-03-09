using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    [Header("Dishes")]
    public List<Dish> possibleDishes;
    public List<string> prohibitedOnDish;

    private SpriteRenderer rend;
    private MouseCursor cursor;
    private List<string> currentIngredients;
    
    [HideInInspector]
    public string currentDishName;
    public Sprite normalPlate;

    [Header("Special Cases")]
    public List<SpecialCases> cases;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        cursor = GameObject.FindObjectOfType<MouseCursor>();

        foreach(Dish dish in possibleDishes){
            dish.ingredients.Sort();
            dish.name = "Dish " + dish.name;
            prohibitedOnDish.Add(dish.name);
        }

        currentIngredients = new List<string>();
        currentDishName = null;
        rend.sprite = normalPlate;
    }

    void OnMouseDown(){
        if(cursor.currentCursorName == null){
            cursor.currentCursorName = currentDishName;
        }
        else{
            for(int i=0;i<prohibitedOnDish.Count;i++){
                if(cursor.currentCursorName == prohibitedOnDish[i]){
                    return;
                }
            }
            
            currentIngredients.Add(cursor.currentCursorName);
            currentIngredients.Sort();
            
            updateProhibitedList(cursor.currentCursorName);
            updateDish();
            // Debug.Log(currentDishName);
            // foreach(string ingredient in currentIngredients){
            //     Debug.Log(ingredient);
            // }

            cursor.currentCursorName = null;
        }
    }

    void updateProhibitedList(string updateComponent){
        prohibitedOnDish.Add(updateComponent);

        foreach(SpecialCases special in cases){
            if(special.ifClause == updateComponent){
                foreach(string clause in special.thenClause){
                    prohibitedOnDish.Add(updateComponent);
                }
            }
        }
    }

    void updateDish(){
        foreach(Dish dish in possibleDishes){
            bool match = true;
            int i = 0;

            if(dish.ingredients.Count != currentIngredients.Count){
                match = false;
            }

            while((i < dish.ingredients.Count) && match){
                if(dish.ingredients[i] != currentIngredients[i]){
                    match = false;
                }
                else{
                    i++;
                }
            }

            if(match){
                rend.sprite = dish.sprite;
                currentDishName = dish.name;
                return;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentIngredients.Count == 0){
            rend.sprite = normalPlate;
        }
    }
}
