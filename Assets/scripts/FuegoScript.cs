using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuegoScript : MonoBehaviour
{

   bool bolaDerecha = true;   

   public float speedBala = 2.0f;

   float tiempoDestruccion = 5.0f;
   
   float queHoraEs;

    void Start()
    {
        
        bolaDerecha = MovPersonaje.miraDerecha;
        
        queHoraEs = Time.time; 

    }

 
    void Update()
    {
        
        if (bolaDerecha){
            transform.Translate(speedBala * Time.deltaTime,0 ,0,Space.World); 
        }else{
            transform.Translate((speedBala * Time.deltaTime)*-1, 0, 0,Space.World); 
        }

        if(Time.time >= queHoraEs+tiempoDestruccion){
            Destroy(this.gameObject); 
         }

    
    }

      void OnTriggerEnter2D(Collider2D col){

        if(col.gameObject.tag == "Enemigo"){
            Destroy(col.gameObject);

             GameManager.muertes+=1;
             
             Destroy(this.gameObject);

        }
    }

}
