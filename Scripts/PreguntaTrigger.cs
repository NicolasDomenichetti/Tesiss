using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class startcrysalida : MonoBehaviour

{
    public bool canInteract;
    public GameObject taglineContainer; 
    public GameManager CrisalidaManager;
    public CustomFPController player;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

     
      void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            taglineContainer.SetActive(true);
           
        }    
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            taglineContainer.SetActive(false);
        }
    }
}
