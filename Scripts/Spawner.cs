using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject applePrefab;
    public Transform spawnPoint;  
    public GameObject uiButton;
    public GameManager OrugaManager;
    // Start is called before the first frame update
    public bool canInteract;
     
      void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canInteract == true && Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("a");
            SpawnObject();
        }
        uiButton.SetActive(canInteract);
    }

    public void SpawnObject()
    {
        //Creamos una nueva instancia ("copia") del prefab de la manzana
        GameObject newapple = Instantiate(applePrefab);

        //Le decimos que su posicion va a ser la misma que la del objeto vacio "Spawn Point"
        newapple.transform.position = spawnPoint.position;

        //Destroy(gameObject);
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
