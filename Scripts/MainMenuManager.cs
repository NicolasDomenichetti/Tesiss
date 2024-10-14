using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
     public GameObject uiButton;
     public GameObject eyeUI;
     public GameObject bodyUI;
     public GameObject wingUI;

     public PlayerProgress progress;
    // Start is called before the first frame update
    void Start()
    {
        eyeUI.SetActive(progress.eyeProgress);
        bodyUI.SetActive(progress.bodyProgress);
        wingUI.SetActive(progress.wingProgress);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene(1);
        }
    }
    public void NextScene()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene(1);
        }
    }
}
