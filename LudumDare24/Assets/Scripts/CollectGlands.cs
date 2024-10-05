using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectGlands : MonoBehaviour
{
    [SerializeField] private List<Image> collecteGlands = new List<Image>();

    private int nbrGlands = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("glands"))
        {
            collecteGlands[nbrGlands].sprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
            collecteGlands[nbrGlands].color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            
            //a mettre quand sprite finaux
            //collecteGlands[nbrGlands].color = Color.white;
            
            nbrGlands++;
            Destroy(collision.gameObject);
        }
    }
}
