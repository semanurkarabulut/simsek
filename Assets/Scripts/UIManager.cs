using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Image whiteeffectimage;
    private int effectcontrol = 0;


    public Animator LayoutAnimator ;

    public TextMeshProUGUI coin_text;
    //Butonlar
    public GameObject settings_Open;
    public GameObject settings_Close;

    public GameObject RestartScreen;

    //Oyun sonu ekraný
    public GameObject finishScreen;
    public GameObject background;
    public GameObject complete;


    public void Start()
    {
       CoinTextUpdate();
    }

    public void CoinTextUpdate() 
    {
        coin_text.text = PlayerPrefs.GetInt("moneyy").ToString();
    }
    public void RestartButtonActive() 
    {
        RestartScreen.SetActive(true); 
    }

    public void RestartScene() 
    {
        Variables.firsttouch = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void FinishScreen() 
    {
        StartCoroutine("FinishLaunch");
    }

    public IEnumerator FinishLaunch() 
    {
        Time.timeScale = 0.3f;
        finishScreen.SetActive(true);
        background.SetActive(true);
        yield return new WaitForSecondsRealtime(0.8f);
        complete.SetActive(true);
    }

    //Buton Fonksiyonlarý

    public void Settings_Open() 
    {
        settings_Open.SetActive(false);
        settings_Close.SetActive(true);
        LayoutAnimator.SetTrigger("Slide_in");

    }

    public void Settings_Close()
    {
        settings_Open.SetActive(true);
        settings_Close.SetActive(false);
        LayoutAnimator.SetTrigger("Slide_out");

    }

    public IEnumerator WhiteEffect() 
    {
        whiteeffectimage.gameObject.SetActive(true);
        while (effectcontrol==0) 
        {
            yield return new WaitForSeconds(0.001f);
            whiteeffectimage.color += new Color(0, 0, 0, 0.1f);
            if (whiteeffectimage.color==new Color(whiteeffectimage.color.r, whiteeffectimage.color.g, whiteeffectimage.color.b,1))
            {
                effectcontrol = 1;
            }
        }
        while (effectcontrol==1) 
        {
            yield return new WaitForSeconds(0.001f);
            whiteeffectimage.color -= new Color(0, 0, 0, 0.1f);
            if (whiteeffectimage.color == new Color(whiteeffectimage.color.r, whiteeffectimage.color.g, whiteeffectimage.color.b, 0))
            {
                effectcontrol = 2;
            }
        }
        if (effectcontrol ==2)
        {
            Debug.Log("efekt bitti");
        }
        
    }
}
