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
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = collecteGlands[nbrGlands].sprite;
            collecteGlands[nbrGlands].color = Color.white;
            nbrGlands++;
        }
    }
}
