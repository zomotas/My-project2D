using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPersonaje : MonoBehaviour
{
    public float velocidad = 5f;
    public float multiplicador = 5f;
    public float multiplicadorSalto = 5f;

    float MovTeclas;

    public static bool miraDerecha = true;
    
    private bool puedoSaltar = true;
    
    private bool activaSaltoFixed = false;

    private Rigidbody2D rb; 
    private Animator animatorController;
   
    GameObject respawn; 

    bool soyAzul;
   


    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Hola Mundo");  
        rb = GetComponent<Rigidbody2D>();
        
        animatorController = this.GetComponent<Animator>();
       
        respawn = GameObject.Find("Respawn");
        transform.position = respawn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.estoyMuerto) return; 


        float miDeltaTime = Time.deltaTime; 
       
        //movimiento personaje 
        MovTeclas = Input.GetAxis("Horizontal"); //(a -1f - d 1f)
        // float MovTeclasy = Input.GetAxis("Vertical"); //(a -1f - d 1f)

        rb.velocity = new Vector2(MovTeclas*multiplicador,rb.velocity.y);

        //izquierda derecha 
        if (MovTeclas < 0) {
            this.GetComponent<SpriteRenderer>().flipX = true;
            animatorController.SetBool("activaCamina", true);
            miraDerecha =false;
        } else if (MovTeclas > 0) {
            this.GetComponent<SpriteRenderer>().flipX = false;
            animatorController.SetBool("activaCamina", true);
            miraDerecha =true;
        } else {
            animatorController.SetBool("activaCamina", false); 
        }
    
        //animacion    
        /*if(MovTeclas! = 0){
            animatorController.SetBool("activacamina0", true);
        }else{ 
            animatorController.SetBool("activacamina0", false);
        }*/

        //salto
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f);
        Debug.DrawRay(transform.position, Vector2.down, Color.magenta);

        if(hit){
            puedoSaltar = true;
         Debug.Log(hit.collider.name);
        } else {
            puedoSaltar = false; 
        }
        
        if(Input.GetKeyDown(KeyCode.Space) && puedoSaltar){
            activaSaltoFixed = true;

           //PuedoSaltarFixed
            /*
            rb.AddForce(
                new Vector2(0,multiplicadorSalto),
                ForceMode2D.Impulse
                );
            
            //puedoSaltar = false;*/

        }
        
        //comprobar caida de la pantalla 
        if(transform.position.y <=-7){
            AudioManager.Instance.SonarClipUnaVez(AudioManager.Instance.fxDead);
             Respawnear();
        }
       

            


//0vidas
   if(GameManager.vidas <= 0)
   {
     GameManager.estoyMuerto = true;
   }

 }

    void FixedUpdate(){


    rb.velocity = new Vector2(MovTeclas*multiplicador,rb.velocity.y);

    if(activaSaltoFixed == true){
     rb.AddForce(
         new Vector2(0,multiplicadorSalto),
         ForceMode2D.Impulse
      );
      activaSaltoFixed = false; 
    } 
    
}
    public void Respawnear(){

     Debug.Log("vidas:"+GameManager.vidas);
     GameManager.vidas = GameManager.vidas -1;
     Debug.Log("vidas:"+GameManager.vidas);

      transform.position = respawn.transform.position;
    }


    public void CambiarColor(){
        if(soyAzul){
        this.GetComponent<SpriteRenderer>().color = Color.white;
        soyAzul = false;
         }else{
            this.GetComponent<SpriteRenderer>().color = Color.blue;
        soyAzul = true;
        }
}


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Tunel"){ 
            AudioManager.Instance.IniciarEfectoTunel();
        }
        if(col.gameObject.name == "Burbuja"){ 
            AudioManager.Instance.IniciarEfectoBurbuja();
        }
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.name =="Tunel"){
            AudioManager.Instance.IniciarEfectoDefault();
        }
        if(col.gameObject.name =="Burbuja"){
            AudioManager.Instance.IniciarEfectoDefault();
            
        }
        if(col.name == "Burbuja"){
           // Destroy(col.gameObject);
        }
    }
}