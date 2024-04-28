using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

   public float parallaxSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Camera.main.transform.position);
       
    
    }
    
    void FixedUpdate(){
         transform.position = new Vector3(Camera.main.transform.position.x/parallaxSpeed, Camera.main.transform.position.y,0);
        
        }

}
