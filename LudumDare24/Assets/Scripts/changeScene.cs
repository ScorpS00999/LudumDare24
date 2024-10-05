using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public void ChangeSceneJeu()
    {
        SceneManager.LoadScene("JeuMargot");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
