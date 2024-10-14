using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class OrugaManager : MonoBehaviour
{
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
    }

    

    // Update is called once per frame
    void Update()
    {
        //Test de UI
        if(Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene(2);
        }
    }
}
