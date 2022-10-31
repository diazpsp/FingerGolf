using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HoleDetect : MonoBehaviour
{
    public AudioSource audio;
    [SerializeField] GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col){
        Debug.Log("HEee");
        panel.SetActive(true);
        audio.Play();
        Time.timeScale = 0;

    }

    public void ButtonMenu(){
        SceneManager.LoadScene("SampleScene");
    }
}
