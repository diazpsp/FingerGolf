using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallKnockSound : MonoBehaviour
{
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.tag == "Ball"){
            audio.Play();
        }
    }
}
