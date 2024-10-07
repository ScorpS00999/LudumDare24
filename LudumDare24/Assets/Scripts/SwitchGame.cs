using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] AudioClip audioJour;
    [SerializeField] AudioClip audioNuit;

    [SerializeField] ChangementSon changeSon;


    private void Start()
    {
        
        jeuMignon.SetActive(true);
        jeuCannibal.SetActive(false);

        startTransi = false;
        transparence = fondu.color;
        transparence.a = 0f;
        fondu.color = transparence;

        timeStart = timer;
        timeEnd = timer;

        changeSon.changementSon(audioJour);
    }

    public void finJeu()
    {
        print("uuuuuuuuuuuuuuuuu");
        StartCoroutine(changer());
        
    }


    [SerializeField] Image fondu;
    Color transparence;

    float timer = 3f;

    [SerializeField] AnimationCurve fade;

    bool startTransi;
    bool stopTransi;


    float timeStart;
    float timeEnd;


    private void Update()
    {
        if (startTransi)
        {
            timeStart -= Time.deltaTime;

            float pourcentageTransparence = (3f - timeStart) / 3f;
            transparence.a = fade.Evaluate(pourcentageTransparence);
            fondu.color = transparence;

            if (pourcentageTransparence >= 1)
            {
                startTransi = false;
            }
        }

        if (stopTransi)
        {
            timeEnd -= Time.deltaTime;

            float pourcentageTransparence = timeEnd / 3f;
            transparence.a = fade.Evaluate(pourcentageTransparence);
            fondu.color = transparence;

            if (pourcentageTransparence <= 0)
            {
                stopTransi = false;
            }
        }
    }

    IEnumerator changer()
    {
        yield return new WaitForSeconds(0.5f);
        CameraController.Instance.shakeVibrate();
        startTransi = true;
        yield return new WaitForSeconds(timer);

        changeSon.changementSon(audioNuit);

        murInvisible.SetActive(false);

        jeuMignon.SetActive(false);

        jeuCannibal.SetActive(true);
        stopTransi = true;
    }

}
