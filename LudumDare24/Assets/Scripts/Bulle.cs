using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bulle : MonoBehaviour
{
    [SerializeField] int xPosTransport;
    [SerializeField] int yPosTransport;

    [SerializeField] float speed = 2f;
    

    bool dansTriger = false;

    Vector2 posTransport;
    Vector2 posDebut;

    GameObject player;

    private Animator bubbleAnimator;

    private void Start()
    {
        posTransport = new Vector2(xPosTransport, yPosTransport);
        posDebut = transform.position;
    }

    private void Update()
    {
        if (dansTriger)
        {
            transform.position = Vector2.MoveTowards(transform.position, posTransport, speed * Time.deltaTime);
            player.transform.position = Vector2.MoveTowards(transform.position, posTransport, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, posTransport) < 0.02f)
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                this.gameObject.GetComponent<Collider2D>().enabled = false;
                transform.position = posDebut;
                player.transform.position = posTransport;

                //player.SetActive(true);

                player.GetComponent<SpriteRenderer>().enabled = true;
                player.GetComponent<PlayerController>().enabled = true;

                Transform enfant = player.transform.Find("CameraController");
                GameObject gameObjectEnfant = enfant.gameObject;

                changementCam.Instance.changeFollow(gameObjectEnfant);

                dansTriger = false;
                bubbleAnimator.SetBool("shouldBop", true);
                StartCoroutine(retourBulle());
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Transform enfant = this.gameObject.transform.Find("CamFollow");
            GameObject gameObjectEnfant = enfant.gameObject;

            changementCam.Instance.changeFollow(gameObjectEnfant);

            player = collision.gameObject;

            //player.GetComponent<SpriteRenderer>().enabled = true;
            player.GetComponent<PlayerController>().enabled = false;

            //player.SetActive(false);


            dansTriger = true;
        }
    }


    IEnumerator retourBulle()
    {
        bubbleAnimator.SetBool("shouldBop", false);
        //peut etre plus tard remplacer par time.deltaTime ?
        yield return new WaitForSeconds(5);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        this.gameObject.GetComponent<Collider2D>().enabled = true;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.2f);
        Gizmos.DrawSphere(new Vector2(xPosTransport, yPosTransport), 0.2f);
        Gizmos.DrawLine(transform.position, new Vector2(xPosTransport, yPosTransport)); // Dessiner une ligne entre les deux points

        //SceneView.RepaintAll();
    }
}
