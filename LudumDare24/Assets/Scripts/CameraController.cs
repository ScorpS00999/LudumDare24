using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField] CinemachineVirtualCamera virtualCamera;


    public void shakeCamera()
    {
        StartCoroutine(shakeCam());
    }

    private IEnumerator shakeCam()
    {
        float temps = duree;

        while (temps > 0)
        {
            transform.localPosition = new Vector2(Random.Range(-1, 1) * power, Random.Range(-1, 1) * power);
            temps -= Time.deltaTime;
        
            yield return null;
        }
        transform.localPosition = Vector3.zero;
        
        yield return null;
    }
}
