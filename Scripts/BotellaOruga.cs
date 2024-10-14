using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BotellaOruga : MonoBehaviour
{
    public GameManager OrugaManager;
    public GameObject uiButton;
    public bool canInteract;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangetoCrisalida()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene(2);
        }
        uiButton.SetActive(canInteract);
    }

     void OnTriggerEnter(Collider collision)
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
