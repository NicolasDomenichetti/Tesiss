using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MushroomDesicion : MonoBehaviour
{
    public bool canInteract;
    public GameObject MColor1; 
    public GameObject MColor2; 
    public GameObject uibutton; 
    public GameObject uibutton2; 
    public GameObject eyeUI;
    public GameManager CrisalidaManager;
    public CustomFPController player;
    public PlayerProgress progress;
    
    // Start is called before the first frame update
    void Start()
    {
        player.canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void Color1 ()
    {
       MColor1.SetActive(false);
       uibutton.SetActive(false);
       uibutton2.SetActive(false);
       progress.eyeProgress = true;
       eyeUI.SetActive(progress.eyeProgress);
       player.canMove = true;
    }

     public void Color2 ()
    {
       MColor2.SetActive(false);
       uibutton.SetActive(false);
       uibutton2.SetActive(false);
       progress.eyeProgress = true;
       eyeUI.SetActive(progress.eyeProgress);
       player.canMove = true;
    }
     void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
           uibutton.SetActive(true);
           uibutton2.SetActive(true);
           player.canMove = false;
           
        }    
    }
    
    void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
           uibutton.SetActive(false);
           uibutton2.SetActive(false);
        }
    }


}
