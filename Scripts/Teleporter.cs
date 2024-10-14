using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject applePrefab;
    public Transform spawnPoint;
    public Animator[] teleporterArms;

    public GameObject uiButton;
    public GameManager gm;

    //Usamos esta variable para que solo se puedan crear manzanas cuando el jugador esta con la computadora
    bool canInteract;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(canInteract)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                //Cuando llamamos a una funcion, es como si hubieramos escrito su codigo en ese lugar
                //Mover el codigo de spawneo a una funcion va a ser relevante en otra clase
                SpawnObject();
            }
        }

        //Con esto hacemos que el boton aparezca y desaparezca sin usar ifs, en una sola linea
        uiButton.SetActive(canInteract);
    }

    public void SpawnObject()
    {
        //Creamos una nueva instancia ("copia") del prefab de la manzana
        GameObject obj = Instantiate(applePrefab);

        //Le decimos que su posicion va a ser la misma que la del objeto vacio "Spawn Point"
        obj.transform.position = spawnPoint.position;

        //Destruimos a la instancia que acabamos de crear, dentro de 5 segundos
        Destroy(obj, 5);
    }

    //Chequeamos que el player este tocando la computadora, habilitamos que se instancien manzanas y animamos los brazos
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canInteract = true;
            gm.SetCameraLock(true);

            foreach (Animator anim in teleporterArms)
            {
                anim.SetBool("Active", true);
            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Press enter to teleport a box");
        }
    }

    //Hacemos lo contrario a lo que hicimos en OnCollisionEnter
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canInteract = false;
            gm.SetCameraLock(false);

            foreach (Animator anim in teleporterArms)
            {
                anim.SetBool("Active", false);
            }
        }
    }
}
