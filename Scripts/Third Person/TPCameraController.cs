using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPCameraController : MonoBehaviour
{
    public Transform character;
    public float verticalOffset;
    public float minCharacterDistance;
    public float maxCharacterDistance;
    float characterDistance;
    public float zoomSpeed;

    public float xLimit;

    public float sensitivity;

    float xRotation;
    float yRotation;

    [Header("Detector Settings")]
    //Estos detectores sirven para saber si acercarse al jugador, alejarse o quedarse quieta
    public float innerRadius;
    public float outerRadius;
    public LayerMask wallMask;

    public bool lockCam;

    // Start is called before the first frame update
    void Start()
    {
        characterDistance = maxCharacterDistance;
    }

    // Update is called once per frame
    void Update()
    {
        //Esto es casi igual a la version de First Person, lo que cambia es que no afecta al personaje y la camara se controla sola
        if (!lockCam)
        {
            //Si quisieran controlar la camara con joystick o axis de teclado, reemplazan MouseX y MouseY por los ejes que quieran
            //Tendrian que agregar tambien una velocidad en vez de sensitivity, y Time.deltaTime
            xRotation -= Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivity;
            xRotation = Mathf.Clamp(xRotation, -xLimit, xLimit);
            yRotation += Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivity;

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

            //Aca ubicamos a la camara teniendo un offset vertical absoluto, y un offset horizontal que depende de donde mira la camara
            transform.position = character.position + Vector3.up * verticalOffset - transform.forward * characterDistance;
        }

        //Physics.OverlapSphere crea una especie de "trigger falso" y se fija con que otros colliders esta colisionando
        //Vamos a usar dos, para controlar que la camara no atraviese paredes e ir haciendo zoom

        //Si el detector interno toca una pared, es señal de que esta demasiado cerca de esa pared
        //En ese caso la camara se acerca al personaje para evitar incrustarse en la pared
        if (Physics.OverlapSphere(transform.position, innerRadius, wallMask).Length > 0)
        {
            if (characterDistance > minCharacterDistance) characterDistance -= Time.fixedDeltaTime * zoomSpeed;
        }

        //Si ninguno de los dos detectores toca una pared, es señal de que hay suficiente lugar para alejarse mas
        //(Si solo el externo toca una pared la camara no se mueve, para evitar que "vibre" entre alejarse y acercarse)
        else if (Physics.OverlapSphere(transform.position, outerRadius, wallMask).Length == 0)
        {
            if (characterDistance < maxCharacterDistance) characterDistance += Time.fixedDeltaTime * zoomSpeed;
        }
    }

    #region FixedUpdate + por que
    //FixedUpdate es un Update paralelo al que conocemos, que se ejecuta a una cierta cantidad de tiempo fija
    //A diferencia de Update, que varía según el framerate
    //La fisica de Unity por defecto se calcula en FixedUpdate
    //Si tenemos el movimiento en Update y la Fisica en FixedUpdate, los personajes van a "vibrar" al chocarse con una pared
    //Podemos poner la logica de movimiento en FixedUpdate, o cambiar en Project Settings > Physics para que calcule en Update
    //En proyectos como este no hay problema, pero si tienen fisicas complejas o ponen FPS altos tipo 120+, es menos optimo
    /*
    void FixedUpdate()
    {
        
        if (Physics.OverlapSphere(transform.position, innerRadius, wallMask).Length > 0)
        {
            if (characterDistance > minCharacterDistance) characterDistance -= Time.fixedDeltaTime * zoomSpeed;
        }

        else if (Physics.OverlapSphere(transform.position, outerRadius, wallMask).Length == 0)
        {
            if (characterDistance < maxCharacterDistance) characterDistance += Time.fixedDeltaTime * zoomSpeed;
        }
        
    }
    */
    #endregion

    //Esto nos permite visualizar los "colliders" de Physics.OverlapSphere
    //Primero les damos un color y despues dibujamos una esfera con los mismos parametros que la de los "colliders"
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, innerRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, outerRadius);
    }
}
