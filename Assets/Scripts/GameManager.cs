using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uimanager;
    public void Start()
    {
        CoinCalcuator(0);
        Debug.Log(PlayerPrefs.GetInt("moneyy"));
    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("FinishLine"))
        {
            Debug.Log("oyun bitti");
            CoinCalcuator(100);
            uimanager.CoinTextUpdate();
            uimanager.FinishScreen();
            
        }
    }
    
    public void CoinCalcuator(int money) 
    {
        if (PlayerPrefs.HasKey("moneyy"))
        {
            int oldScore = PlayerPrefs.GetInt("moneyy");
            PlayerPrefs.SetInt("moneyy", oldScore + money);
        }
        else
            PlayerPrefs.SetInt("moneyy", 0);
    }

   
}
