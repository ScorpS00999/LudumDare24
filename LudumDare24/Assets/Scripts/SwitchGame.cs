using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGame : MonoBehaviour
{
    static SwitchGame instance;

    public static SwitchGame Instance
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



    [SerializeField] GameObject jeuMignon;

    [SerializeField] GameObject jeuCannibal;

    [SerializeField] GameObject murInvisible;

    private void Start()
    {
        jeuMignon.SetActive(true);
        jeuCannibal.SetActive(false);
    }

    public void finJeu()
    {
        murInvisible.SetActive(false);

        jeuMignon.SetActive(false);

        jeuCannibal.SetActive(true);
    }
}
