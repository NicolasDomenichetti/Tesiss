using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //OnTriggerEnter y afines funcionan en objetos que tienen Rigidbody y tienen hijos con Colliders
    //Aun si los objetos en si mismos no tienen Collider
    //Solo aplica si los hijos con collider no tienen Rigidbody
    //No funciona a la inversa, a la hora de activar los OnTrigger y OnCollision de otros srcipts
    void OnTriggerEnter(Collider other)
    {
        //Se pueden usar otros medios como GetComponent<Character>() para chequear si es el player
        if (other.gameObject.CompareTag("Player"))
        {
            gm.collectibles++;
            Destroy(gameObject);
        }
    }
}
