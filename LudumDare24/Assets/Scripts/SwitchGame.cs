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

    [SerializeField] GameObject audioJour;
    [SerializeField] GameObject audioNuit;

    [SerializeField] ChangementSon changeSon;


    private void Start()
    {
        
        jeuMignon.SetActive(true);
        audioJour.SetActive(true);
        jeuCannibal.SetActive(false);
        audioNuit.SetActive(false);

        startTransi = false;
        transparence = fondu.color;
        transparence.a = 0f;
        fondu.color = transparence;

        timeStart = timer;
        timeEnd = timer;

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

        audioJour.SetActive(false);
        audioNuit.SetActive(true);

        murInvisible.SetActive(false);

        jeuMignon.SetActive(false);

        jeuCannibal.SetActive(true);
        stopTransi = true;
    }

}
