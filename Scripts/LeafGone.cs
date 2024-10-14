using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafGone : MonoBehaviour
{
    public GameObject uiButton;
    public GameManager OrugaManager;
    public GameObject Hoja;
    public bool canInteract;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
         if (canInteract == true && Input.GetKeyDown(KeyCode.Return))
        {
           Goneleaf();
        }
       uiButton.SetActive(canInteract);
    }

    public void Goneleaf()
    {
        Hoja.SetActive(false);
    }

     public void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
          canInteract = true;
        }    
           
    }
     void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = false;
        }
    }
}
