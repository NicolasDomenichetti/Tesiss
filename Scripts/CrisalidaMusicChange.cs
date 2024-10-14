using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrisalidaMusicChange : MonoBehaviour
{
    public bool canInteract;
    public GameManager CrisalidaManager;
    public CustomFPController player;
    public GameObject Music;
    public GameObject Music1;
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
            Music.SetActive(false);
            Music1.SetActive(true);
           
        }    
    }
     
}
