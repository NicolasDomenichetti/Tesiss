using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CrisalidaManager : MonoBehaviour
{
    public CustomFPController player;
    public TMP_InputField inputField;
    public GameObject taglineContainer;

    public GameObject eyeUI;
    public GameObject bodyUI;
    public GameObject wingUI;

    public PlayerProgress progress;

    // Start is called before the first frame update
    void Start()
    {
        //Esto va a prender y apagar los iconos en la UI de las partes del cuerpo
        //Segun si estan desbloqueadas en la "partida"
        eyeUI.SetActive(progress.eyeProgress);
        bodyUI.SetActive(progress.bodyProgress);
        wingUI.SetActive(progress.wingProgress);
        player.canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Llamamos a esta funcion cuando clickeamos al InputField
    public void FreezePlayer()
    {
        player.canMove = false;
    }

    public void CheckPhrase()
    {
        if(inputField.textComponent.text.Contains("nos adaptamos"))
        {
            taglineContainer.SetActive(false);
            progress.bodyProgress = true;
            bodyUI.SetActive(progress.bodyProgress);
            //Aca iria el codigo relevante
            Debug.Log("ganaste");
            player.canMove = true;
        }
    }
}
