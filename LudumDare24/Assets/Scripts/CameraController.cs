using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    static CameraController instance;

    public static CameraController Instance
    {
        get
        {
            // Si l'instance n'existe pas encore, on la crée
            if (instance == null)
            {
                instance = new CameraController();
            }
            return instance;
        }
    }


    [SerializeField] float duree = 3f;
    [SerializeField] float power = 5f;

    [SerializeField] float vibrationDuration = 2f;

    [SerializeField] CinemachineVirtualCamera virtualCamera;

    [SerializeField] float decalageCam = 1.5f;


    public void shakeCamera()
    {
        StartCoroutine(shakeCam());
    }

    private IEnumerator shakeCam()
    {
        float temps = duree;

        while (temps > 0)
        {
            transform.position = new Vector2(Random.Range(-1, 1) * power, Random.Range(-1, decalageCam) * power);
            temps -= Time.deltaTime;
        
            yield return null;
        }
        transform.localPosition = new Vector3(0, decalageCam, 0);
        
        yield return null;
    }



    public void shakeVibrate()
    {
        StartCoroutine(shakeCam());
        StartCoroutine(vibrate());
    }


    
    private IEnumerator vibrate()
    {
        var gamepad = Gamepad.current;
        print("bien rentré dans vibrate");

        float temps = vibrationDuration;

        if (gamepad != null)
        {
            while (temps > 0)
            {
                gamepad.SetMotorSpeeds(0.5f, 0.5f);  // Lancer la vibration avec 50% de puissance
                temps -= Time.deltaTime;

                yield return null;
            }
            gamepad.SetMotorSpeeds(0, 0);

            yield return null;
        }
    }

    private void Start()
    {
        shakeVibrate();
        shakeCamera();
    }
}
