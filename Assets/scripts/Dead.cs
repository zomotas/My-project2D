using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    private GameObject walkcomplete_0; 
    private MovPersonaje movPersonaje; 
    

    // Start is called before the first frame update
    void Start()
    {
        walkcomplete_0 = GameObject.Find("walkcomplete_0");
        movPersonaje = walkcomplete_0.GetComponent<MovPersonaje>();
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col){

       if(col.name == "walkcomplete_0")
       { movPersonaje.Respawnear();
          AudioManager.Instance.SonarClipUnaVez(AudioManager.Instance.fxDead); /*el audio de la muerte se me pone en loop al empezar la escena,
          lo he quitado del AudioManager*/                                                       

        
       }
     
}}
