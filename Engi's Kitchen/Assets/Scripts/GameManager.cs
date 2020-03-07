using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public int inGameMoney = 0;
    int maxGameMoney = 100;

    float playTime = 60f;
    public Image timerClock;
    public Slider scoreBar;

    void Update(){
        timerClock.fillAmount += 1.0f/playTime * Time.deltaTime;
        scoreBar.value = inGameMoney / maxGameMoney * 100f;
    }

    public void increaseMoney(int money){
        inGameMoney += money;
    }
}
