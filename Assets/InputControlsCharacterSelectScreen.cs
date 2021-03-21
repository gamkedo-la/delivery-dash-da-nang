using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputControlsCharacterSelectScreen : MonoBehaviour
{
    Scene currentScene;

    public GameObject mainMenuCamera;
    MainMenu mainMenuScript;
    public void Awake()
    {
        mainMenuScript = mainMenuCamera.GetComponent<MainMenu>();
        currentScene = SceneManager.GetActiveScene();
        Debug.Log(currentScene.name);
    }

    
}
