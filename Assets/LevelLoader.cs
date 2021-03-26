using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public void LoadNextLevel()
    {
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
            transition.SetTrigger("Start");

            yield return new WaitForSeconds(1);
            SceneManager.LoadScene("DaytimeDaNang");
    }
}
