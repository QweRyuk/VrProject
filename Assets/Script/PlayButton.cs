using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void ButtonPlay()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void MAINPlay()
    {
        SceneManager.LoadScene("Main");
    }
    public void BUTTONCLOSEEEEEEEE()
    {
        Application.Quit();
    }
}
