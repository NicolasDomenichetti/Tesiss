using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Si no funciona TextMeshPro en DV, usamos UI para Text (explicar ambos)
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text cardsText;
    public int collectibles;

    AudioSource src;

    public TPCameraController tpCam;
    public CustomFPController fpCam;

    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();

        //Arrancamos con la camara desbloqueada, despues la bloqueamos desde Teleport
        SetCameraLock(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Creamos un string para complementar al numero
        //Le sumamos un 0 cuando el numero es menor a 10, asi tenemos siempre 2 digitos (01, 02, etc.)
        string extra = "";
        if (collectibles < 10) extra = "0";

        //Text (o TMP_Text) no es lo mismo que string, pero adentro tiene un string (este .text)
        //Con esto si podemos acceder a la misma variable text que podemos ver en Inspector
        //ToString() convierte otros tipos de dato como int o float a string
        cardsText.text = extra + collectibles.ToString();

        if(Input.GetKeyDown(KeyCode.Y))
        {
            PlayPause();
        }

        if(Input.GetKey(KeyCode.U))
        {
            src.volume -= Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.I))
        {
            src.volume += Time.deltaTime;
        }
    }

    void PlayPause()
    {
        if(src.isPlaying)
        {
            src.Pause();
        }
        else
        {
            src.UnPause();
        }
    }

    //La idea de esta funcion es bloquear la camara y desbloquear la camara
    //La vamos a llamar desde Teleporter, para que no nos moleste cuando clickeamos el boton en la UI
    public void SetCameraLock(bool shouldLock)
    {
        if(shouldLock)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (tpCam) tpCam.lockCam = true;
            if (fpCam) fpCam.lockCam = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (tpCam) tpCam.lockCam = false;
            if (fpCam) fpCam.lockCam = false;
        }
    }
}
