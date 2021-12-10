using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private Text sureText;

    [SerializeField]
    private GameObject sonucPanel;

    [SerializeField]
    private GameObject sonuclarObje, zamanObje, dogruYanlisObje, playerObje, puanObje;


    int kalanSure = 90;
    bool sureSaysinMi;
    void Start()
    {
        kalanSure = 10;
        sureSaysinMi = true;
        sonucPanel.SetActive(false);
        StartCoroutine(SureTimerRoutune());


        sonuclarObje.SetActive(true);
        zamanObje.SetActive(true);
        dogruYanlisObje.SetActive(true);
        playerObje.SetActive(true);
        puanObje.SetActive(true);
    }

    IEnumerator SureTimerRoutune()
    {
        while (sureSaysinMi)
        {
            yield return new WaitForSeconds(1f);

            if (kalanSure < 10)
            {
                sureText.text = "0" + kalanSure.ToString();
            }
            else
            {
                sureText.text = kalanSure.ToString();
            }
            if (kalanSure <= 0)
            {
                sureSaysinMi = false;
                sureText.text = "";

                EkraniTemizle();
                sonucPanel.SetActive(true);
            }
            kalanSure--;
        }
    }

    void EkraniTemizle()
    {
        sonuclarObje.SetActive(false);
        zamanObje.SetActive(false);
        dogruYanlisObje.SetActive(false);
        playerObje.SetActive(false);
        puanObje.SetActive(false);
    }
    
}
