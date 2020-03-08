using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector]
    public int inGameMoney = 0;
    int maxGameMoney = 100;

    float playTime = 60f;
    public Image timerClock;
    public Slider scoreBar;

    [HideInInspector]
    public string handHold = null;

    void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
            return;
        }
    }

    void Update(){
        timerClock.fillAmount += 1.0f/playTime * Time.deltaTime;
        scoreBar.value = inGameMoney / maxGameMoney * 100f;
    }

    public void increaseMoney(int money){
        inGameMoney += money;
    }
}
