using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadSceneAsync("bazaar");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ExitToStart()
    {
        SceneManager.LoadScene("startup");
    }

   
}
