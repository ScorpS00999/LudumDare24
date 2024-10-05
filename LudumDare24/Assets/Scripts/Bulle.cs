using System.Collections;
using System.Collections.Generic;
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

            if (Vector2.Distance(transform.position, posTransport) < 0.02f)
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                transform.position = posDebut;
                player.transform.position = posTransport;
                player.SetActive(true);
                dansTriger = false;
                StartCoroutine(retourBulle());
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("et coucou");
            player = collision.gameObject;
            collision.gameObject.SetActive(false);
            dansTriger = true;
        }
    }


    IEnumerator retourBulle()
    {
        //peut etre plus tard remplacer par time.deltaTime ?
        yield return new WaitForSeconds(5);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, 0.2f);
        Gizmos.DrawSphere(posTransport, 0.2f);
        Gizmos.DrawLine(transform.position, posTransport); // Dessiner une ligne entre les deux points
    }
}
