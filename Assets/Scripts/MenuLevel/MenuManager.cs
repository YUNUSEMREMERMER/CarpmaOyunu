using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    public GameObject menuPanel;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip butonClick;

    [SerializeField]
    private GameObject sesPanel;

    bool sesPaneliAcýkMi;

    // Start is called before the first frame update
    void Start()
    {
        sesPaneliAcýkMi = false;

        if (menuPanel != null)
        {
            menuPanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
            menuPanel.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSceneMenuLevel2()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(butonClick);
        }

        SceneManager.LoadScene("MenuScene2");
    }

    public void OpenSettings()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(butonClick);
        }

        if (!sesPaneliAcýkMi)
        {
            sesPanel.GetComponent<RectTransform>().DOScale(1,0.5f);
            sesPaneliAcýkMi = true;

        }
        else
        {
            sesPanel.GetComponent<RectTransform>().DOScale(0, 0.1f);
            sesPaneliAcýkMi = false;
        }
    }

    public void QuitGame()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(butonClick);
        }
        Application.Quit();
    }
}
