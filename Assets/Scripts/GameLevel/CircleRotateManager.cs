using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CircleRotateManager : MonoBehaviour
{
    string hangiSonuc;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "mermi")
        {
            gameObject.transform.DORotate(transform.eulerAngles + Quaternion.AngleAxis(45, Vector3.forward).eulerAngles, 0.5f);

            if (collision.gameObject != null)
            {
                Destroy(collision.gameObject);
            }
            if (gameObject.name == "SolDaire")
            {
                hangiSonuc = GameObject.Find("solText").GetComponent<Text>().text;
            }else if(gameObject.name == "OrtaDaire")
            {
                hangiSonuc = GameObject.Find("ortaText").GetComponent<Text>().text;
            }
            else if (gameObject.name == "SagDaire")
            {
                hangiSonuc = GameObject.Find("sagText").GetComponent<Text>().text;
            }

            gameManager.SonucuKontrolEt(int.Parse(hangiSonuc));
                   
        }
    }
}
