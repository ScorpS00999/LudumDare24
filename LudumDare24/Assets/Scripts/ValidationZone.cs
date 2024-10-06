using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidationZone : MonoBehaviour
{
    static ValidationZone instance;

    public static ValidationZone Instance
    {
        get
        {
            // Si l'instance n'existe pas encore, on la crée
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void Validation()
    {
        CharacterDisplay.indexDia = 1;
    }

}
