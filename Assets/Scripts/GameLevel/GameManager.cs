using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject baslaImage;

    [SerializeField]
    private GameObject dogruImage, yanlisImage;

    [SerializeField]
    private Text soruText,birinciSonucText,ikinciSonucText,ucuncuSonucText,dogruAdetText,yanlisAdetText,puanText;

    string hangiOyun;
    int birinciCarpan,ikinciCarpan,dogruSonuc, birinciYanlisSonuc, ikinciYanlisSonuc;
    public int dogruAdet, yanlisAdet, toplamPuan;

    PlayerManager playerManager;

    // Start is called before the first frame update
    void Start()
    {
        dogruAdet = 0;
        yanlisAdet = 0;
        dogruAdet = 0;

        dogruImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        yanlisImage.GetComponent<RectTransform>().localScale = Vector3.zero;

        if (PlayerPrefs.HasKey("hangiOyun"))
        {
            hangiOyun = PlayerPrefs.GetString("hangiOyun");
            //Debug.Log(PlayerPrefs.GetString("hangiOyun"));
        }

        StartCoroutine(baslaYaziRoutine());
        
    }

    private void Awake()
    {
        playerManager = Object.FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator baslaYaziRoutine()
    {
        baslaImage.GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        yield return new WaitForSeconds(0.6f);
        baslaImage.GetComponent<RectTransform>().DOScale(0f, 0.5f).SetEase(Ease.InBack);
        baslaImage.GetComponent<CanvasGroup>().DOFade(0f, 1f);
        yield return new WaitForSeconds(0.6f);

        OyunaBasla();

    }

    void OyunaBasla()
    {
        playerManager.rotaDegissinMi = true;
        SoruyuYazdir();
    }
    void BirinciCarpanAyarla()
    {
        switch (hangiOyun)
        {
            case "iki":
                birinciCarpan = 2;
                break;
            case "uc":
                birinciCarpan = 3;
                break;
            case "dort":
                birinciCarpan = 4;
                break;
            case "bes":
                birinciCarpan = 5;
                break;
            case "altý":
                birinciCarpan = 6;
                break;
            case "yedi":
                birinciCarpan = 7;
                break;
            case "sekiz":
                birinciCarpan = 8;
                break;
            case "dokuz":
                birinciCarpan = 9;
                break;
            case "on":
                birinciCarpan = 10;
                break;
            case "karýsýk":
                birinciCarpan = Random.Range(2,11);
                break;

        }
        
    }

    void SoruyuYazdir()
    {
        BirinciCarpanAyarla();
        ikinciCarpan = Random.Range(2, 11);
        int rastgeleDeger = Random.Range(0, 100);

        if (rastgeleDeger <= 50)
        {
           soruText.text = birinciCarpan.ToString() + "x" + ikinciCarpan.ToString();
        }
        else 
        {
            soruText.text = ikinciCarpan.ToString() + "x" + birinciCarpan.ToString();
        }
        dogruSonuc = birinciCarpan * ikinciCarpan;
        SonuclariYazdir();
    }

    void SonuclariYazdir()
    {
        birinciYanlisSonuc = dogruSonuc + Random.Range(2, 10);

        if (dogruSonuc > 10)
        {
            ikinciYanlisSonuc = dogruSonuc - Random.Range(2, 8);

        }
        else
        {
            ikinciYanlisSonuc = Mathf.Abs(dogruSonuc - Random.Range(1, 5));
        }


        int rastgeleDeger = Random.Range(0, 100);

        if (rastgeleDeger <= 33)
        {
            birinciSonucText.text = dogruSonuc.ToString();
            ikinciSonucText.text = birinciYanlisSonuc.ToString();
            ucuncuSonucText.text = ikinciYanlisSonuc.ToString();
        }
        else if(rastgeleDeger > 33 && rastgeleDeger <= 66)
        {
            ikinciSonucText.text = dogruSonuc.ToString();
            birinciSonucText.text = birinciYanlisSonuc.ToString();
            ucuncuSonucText.text = ikinciYanlisSonuc.ToString();
        }
        else
        {
            ucuncuSonucText.text = dogruSonuc.ToString();
            ikinciSonucText.text = birinciYanlisSonuc.ToString();
            birinciSonucText.text = ikinciYanlisSonuc.ToString();
        }
        
    }

    public void SonucuKontrolEt(int textSonucu)
    {
        dogruImage.GetComponent<RectTransform>().localScale = Vector3.zero;
        yanlisImage.GetComponent<RectTransform>().localScale = Vector3.zero;

        if (textSonucu==dogruSonuc)
        {
            dogruAdet++;
            toplamPuan += 20;
            dogruImage.GetComponent<RectTransform>().DOScale(1, .1f);
        }
        else
        {
            yanlisAdet++;
            yanlisImage.GetComponent<RectTransform>().DOScale(1, .1f);
        }

        dogruAdetText.text = dogruAdet.ToString() + " DOÐRU";
        yanlisAdetText.text = yanlisAdet.ToString() + " YANLIÞ";
        puanText.text = toplamPuan.ToString() + " PUAN";

        SoruyuYazdir();
    }
}
