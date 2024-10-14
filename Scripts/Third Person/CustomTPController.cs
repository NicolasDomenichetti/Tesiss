using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTPController : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float rotSpeed;

    [Header("Animation")]
    public Animator anim;
    bool fidgetting;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Tomamos la misma logica de las clases 1 a 3 y las separamos en funciones
        //Hacemos esto para mantener el codigo prolijo, lo cual es importante a medida que se complejiza
        AxisMovement();
        AnimationControls();
    }

    void AxisMovement()
    {
        #region Explicacion de Movimiento e Input
        //Accedemos al componente Transform de este objeto a traves de la variable transform, que viene con los MonoBehaviours (o sea todo)
        //transform.position es la variable que vemos en Inspector, un Vector3 (3 floats "empaquetados" para X, Y, Z)
        //Para modificar la posicion debemos sumarle otro Vector3, de esa manera lo movemos hacia alla

        //Vector3.up/right/forward valen 1 en el eje correspondiente y 0 en los demas
        //Es literalmente lo mismo que escribir new Vector3(1, 0, 0) etc.
        //Sirven como direcciones universales

        //transform.up/right/forward es lo mismo pero relativo al objeto
        //Si el objeto gira, su definicion de "adelante" tambien cambia

        //Time.deltaTime es una variable que marca cuanto tiempo paso desde el ultimo frame
        //Lo usamos para distribuir cosas en el tiempo (Ej: 1 metro por frame -> 1 metro por segundo)
        //Tambien nos ayuda a compensar por cambios en el framerate / FPS del juego

        //Usamos Input.GetAxis e Input.GetAxisRaw para detectar un joystick o simularlo con dos teclas
        //Nos da un valor que va entre -1 y 1
        //Input.GetAxis devuelve valores intermedios (Ej: 0.75) y GetAxisRaw no
        //Uno es mas "sensible" y el otro es mas inmediato, especialmente en teclado
        //Cual usar depende del tipo de juego que quieran hacer, y para que hardware
        #endregion

        //Tomamos el numero que nos devuelve Input.GetAxisRaw(-1, 0 o 1) y lo multiplicamos por el movimiento
        //Si multiplico por -1 va para atras, por 1 adelante y 0 no se mueve
        transform.position += transform.forward * Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;

        //Lo mismo con la rotacion, 1 a la derecha, -1 a la izquierda y 0 no rota
        transform.Rotate(Vector3.up * 360 * Input.GetAxisRaw("Horizontal") * rotSpeed * Time.deltaTime);
    }

    void AnimationControls()
    {
        #region Explicacion de Animator
        //Accedemos al Animator a traves de la variable anim, que asignamos en Start

        //Para cambiar los Parameters de Animator (que usamos para pasar de una animacion a la otra tenemos:
        //SetBool, SetTrigger, SetFloat y SetInteger
        //Todas nos van a pedir primero el Parameter (un string, con el mismo nombre que en la ventana Animator) y un valor
        //Ej: anim.SetBool("Walking", true) donde "Walking" es el Parameter y quiero que sea true 

        //SetTrigger funciona parecido a SetBool, pero no necesitamos aclarar true o false
        //Un Trigger es un pseudo bool que siempre esta en false hasta que lo triggereamos
        //Y cuando se reproduce la animacion correspondiente se pone solo en false otra vez
        //Usamos triggers para animaciones que se reproducen una vez, como saltos
        //Ej: anim.SetTrigger("Aca iria un Parameter Trigger");
        #endregion

        //Uso el GetAxisRaw para preguntar si estoy caminando. Si alguno de los dos ejes no es 0 es que lo estoy moviendo.
        if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        //Al apretar espacio fidgetting vale lo contrario a lo que valia antes
        if (Input.GetKeyDown(KeyCode.Space)) fidgetting = !fidgetting;

        //Seteamos los otros Parameters del Animator
        anim.SetBool("Fidgetting", fidgetting);
        anim.SetFloat("Direction", Input.GetAxisRaw("Vertical")); //De nuevo, 1 = adelante, -1 = atras, 0 = nada (sirve para girar)
    }
}
