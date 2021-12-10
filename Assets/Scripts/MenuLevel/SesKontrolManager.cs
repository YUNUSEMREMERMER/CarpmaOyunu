using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesKontrolManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SesAc();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SesAc()
    {
        PlayerPrefs.SetInt("sesDurumu", 1);
    }
    public void SesKapat()
    {
        PlayerPrefs.SetInt("sesDurumu", 0);
    }
}
