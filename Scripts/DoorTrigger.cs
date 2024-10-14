using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Animator doorAnim;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //OnTriggerEnter se llama cuando este objeto toca un trigger o, si el collider del objeto es un trigger, cuando otro collider lo toca
    //Las funciones OnTrigger y OnCollision solamente se llaman si alguno de los dos objetos que se tocaron tiene Rigidbody
    void OnTriggerEnter(Collider other)
    {
        //Se pueden usar otros medios como GetComponent<Character>() para chequear si es el player
        if (other.gameObject.CompareTag("Player"))
        {
            doorAnim.SetBool("Open", true);
        }
    }

    //OnTriggerStay y Exit son iguales a OnTriggerEnter pero cuando el objeto mantiene y pierde contacto respectivamente
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Dale pasa loco");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doorAnim.SetBool("Open", false);
        }
    }
}
