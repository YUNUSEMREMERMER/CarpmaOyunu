using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Transform gun;

    [SerializeField]
    private GameObject[] mermiPrefab;

    [SerializeField]
    private Transform mermiPozisyon;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip topClick;

    float angle;

    float donusHizi = 5f;

    float ikiMermiArasiSure = 200f;

    float sonrakiAtisSuresi;

    public bool rotaDegissinMi;
    // Start is called before the first frame update
    void Start()
    {
        rotaDegissinMi = false;
    }

    void Update()
    {
        if (rotaDegissinMi)
        {
            RotateDegistir();
        }
        
    }

    void RotateDegistir()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gun.transform.position;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        gun.transform.rotation = Quaternion.Slerp(gun.transform.rotation, rotation, donusHizi * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            
            if(Time.time>sonrakiAtisSuresi)
            {
                sonrakiAtisSuresi = Time.time + ikiMermiArasiSure / 1000;
                MermiAt();
            }
            

        }


    }

    void MermiAt()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            audioSource.PlayOneShot(topClick);
        }
        
        GameObject mermi = Instantiate(mermiPrefab[Random.Range(0,mermiPrefab.Length)], mermiPozisyon.position, mermiPozisyon.rotation) as GameObject;
    }


    }
