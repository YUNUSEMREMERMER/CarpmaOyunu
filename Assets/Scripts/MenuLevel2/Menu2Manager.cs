using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Menu2Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject menuPanel;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip butonClick;

    // Start is called before the first frame update
    void Start()
    {
        menuPanel.GetComponent<CanvasGroup>().DOFade(1,1f);
        menuPanel.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HangiOyunAcilsin(string hangiOyun)
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(butonClick);
        }
        PlayerPrefs.SetString("hangiOyun", hangiOyun);

        SceneManager.LoadScene("GameScene");
    }

    public void GeriDon()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(butonClick);
        }
        SceneManager.LoadScene("MenuScene");
    }
}
