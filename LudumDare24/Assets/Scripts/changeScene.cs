using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class changeScene : MonoBehaviour
{
    [SerializeField] GameObject PlayMenuButton;

    private void Update()
    {
        if (Gamepad.all.Count > 0)
        {
            EventSystem.current.SetSelectedGameObject(PlayMenuButton);
        }
    }

    public void ChangeSceneJeu()
    {
        SceneManager.LoadScene("Jeu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
