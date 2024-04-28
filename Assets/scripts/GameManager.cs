using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static int vidas = 3;
    public static int puntos = 0;

    public static int muertes = 0; 

    public static bool  estoyMuerto = false;

    GameObject vidasText;
    


    // Start is called before the first frame update
    void Start()
    {
        vidasText = GameObject.Find("vidasText");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("puntos:"+puntos);
        Debug.Log("Deads:"+ muertes);
        
      vidasText.GetComponent<TextMeshProUGUI>().text = vidas.ToString();

    }
}
