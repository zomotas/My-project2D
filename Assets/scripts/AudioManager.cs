using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    public AudioClip bandaSonora; 
    public AudioClip fxButton;
    public AudioClip fxCoin;
    public AudioClip fxDead; 
    public AudioClip fxFire;

    public GameObject musicObj; 

   public AudioMixerSnapshot defaultSnapshot;
    public AudioMixerSnapshot tunelSnapshot;
    public AudioMixerSnapshot submarineSnapshot;


    AudioSource _audioSource;
    AudioSource audioMusic;

    public static AudioManager Instance;

   void Awake()
    {
        if (Instance != null && Instance != this){
            Destroy(gameObject);
        }else{
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       _audioSource = this.GetComponent<AudioSource>();
      
    
       audioMusic = musicObj.GetComponent<AudioSource>();
       audioMusic.clip = bandaSonora;
       audioMusic.loop = true;  
       audioMusic.volume = 0.2f;
       audioMusic.Play();

    }

    // Update is called once per frame
    void Update(){

       /* if (Input.GetKeyDown(KeyCode.T))
        {
            _audioSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            _audioSource.Play();
        }*/

    }
    
    //metodo para hacer sonar clips de audio 
     public  void SonarClipUnaVez(AudioClip ac){
       _audioSource.PlayOneShot(ac);
    }

    public void IniciarEfectoTunel(){
        defaultSnapshot.TransitionTo(0.5f);

    }

    public void IniciarEfectoBurbuja(){
        submarineSnapshot.TransitionTo(1f);

    }
    
    public void IniciarEfectoDefault(){
        defaultSnapshot.TransitionTo(0.5f);

    }

}
