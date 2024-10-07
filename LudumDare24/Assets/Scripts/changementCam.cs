using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class changementCam : MonoBehaviour
{
    static changementCam instance;

    public static changementCam Instance
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

    public void changeFollow(GameObject followCam)
    {
        print(CameraController.Instance.decalageCam);
        this.gameObject.GetComponent<CinemachineVirtualCamera>().Follow = followCam.transform;
        this.gameObject.GetComponent<CinemachineVirtualCamera>().LookAt = followCam.transform;
        this.transform.position = new Vector3(0, CameraController.Instance.decalageCam, 0);
    }
}
