using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectGlands : MonoBehaviour
{
    [SerializeField] GameObject allGlands;

    [SerializeField] private List<Image> collecteGlands = new List<Image>();

    [SerializeField] Collider2D colliderZone;

    private int nbrGlands = 0;

    

    private void Start()
    {
        EnleverCollecte();
    }

    public void AfficherCollecte()
    {
        allGlands.SetActive(true);
    }

    public void EnleverCollecte()
    {
        allGlands.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("glands"))
        {
            
            collecteGlands[nbrGlands].sprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
            collecteGlands[nbrGlands].color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            
            //a mettre quand sprite finaux
            //collecteGlands[nbrGlands].color = Color.white;
            
            nbrGlands++;
            if (nbrGlands >= 3)
            {
                colliderZone.enabled = false;
                ValidationZone.Instance.Validation();
            }
            print(nbrGlands);
            Destroy(collision.gameObject);
        }
        
    }


}
