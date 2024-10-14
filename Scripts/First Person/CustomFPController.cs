using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomFPController : MonoBehaviour
{
    [Header("Camera Controls")]
    public float sensitivity;

    float xRotation;
    float yRotation;

    public float xLimit;

    public GameObject camObj;
    public Transform camPos;

    public bool lockCam;
    public bool canMove;

    [Header("Player")]
    public Animator anim;
    bool fidgetting;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //Seteamos los angulos iniciales para que coincidan con la rotacion del personaje en Inspector
        //Si sus juegos no empiezan mirando hacia el forward global lo van a necesitar
        xRotation = camPos.eulerAngles.x;
        yRotation = camPos.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Igual que en TPCameraController, bloqueamos a la camara cuando aparece el boton de Teleport
        if(!lockCam)
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivity;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivity;

            //La rotacion horizontal es sobre el eje Y
            yRotation += mouseX;
            //La rotacion vertical es sobre el eje X
            xRotation -= mouseY;

            //Clamp es para asegurarnos de que no mire mas abajo ni arriba de cierto limite
            xRotation = Mathf.Clamp(xRotation, -xLimit, xLimit);
        }

        //Aplicamos todas las rotaciones en base a los calculos previos
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
        camObj.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        camObj.transform.position = camPos.transform.position;
        
        AnimationControls();
        Move();
    }

    void Move()
    {
        if (!canMove) return;

        //Multiplicamos los GetAxisRaw por transform.right y forward para que el movimiento varie segun hacia donde miramos
        //A su vez, lo normalizamos para que no se mueva mas rapido cuando va en diagonal
        Vector3 dir = (transform.right * Input.GetAxisRaw("Horizontal") + transform.forward * Input.GetAxisRaw("Vertical")).normalized;
        transform.position += dir * speed * Time.deltaTime;
    }

    void AnimationControls()
    {
        if (!canMove) return;

        //En este caso priorizamos la caminata hacia adelante o hacia atras para decidir la animacion
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            anim.SetFloat("Direction", Input.GetAxisRaw("Vertical"));
            anim.SetBool("Walking", true);
        }
        //Si solamente estamos girando en el lugar, dejamos la direccion en 0
        //Al juntar las animaciones de caminar hacia adelante y atras forma otra que queda bien para girar
        else if (Input.GetAxisRaw("Horizontal") != 0)
        {
            anim.SetFloat("Direction", 0);
            anim.SetBool("Walking", true);
        }
        //Si ninguno de los dos ejes registra nada, walking es false y no camina
        else
        {
            anim.SetBool("Walking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space)) fidgetting = !fidgetting;
        anim.SetBool("Fidgetting", fidgetting);
    }
}
