using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public void StartButtonPressed()
    {

        SceneManager.LoadScene("Game");

    }

    public void LeaveButtonPressed()
    {

        SceneManager.LoadScene("MainMenu");

    }



    public void ExitButton()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else

        Application.Quit();
#endif


    }

 }