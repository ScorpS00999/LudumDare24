using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGame : MonoBehaviour
{
    [SerializeField] List<Sprite> spritesApresChangement = new List<Sprite>();

    [SerializeField] List<GameObject> gameObjectsChanger = new List<GameObject>();

    [SerializeField] GameObject murInvisible;

    //public bool finJeu = false;

    int indexObjectChanger = 0;

    public void finJeu()
    {
        murInvisible.SetActive(false);

        foreach (var sprite in spritesApresChangement)
        {
            gameObjectsChanger[indexObjectChanger].GetComponent<SpriteRenderer>().sprite = sprite;
            indexObjectChanger++;
        }
    }
}
