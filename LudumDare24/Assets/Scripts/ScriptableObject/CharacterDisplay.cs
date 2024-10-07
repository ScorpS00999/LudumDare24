using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class CharacterDisplay : MonoBehaviour
{
    //public List<CharacterData> interactiveCharacters;
    //[SerializeField] TextMeshProUGUI dialog;

    public List<string> dialogues;

    public static int indexDia = 0;

    [SerializeField] GameObject bulleDialogue;
    [SerializeField] TextMeshProUGUI emplacementDia;

    [SerializeField] CollectGlands collect;

    void Start()
    {
        indexDia = 0;
        bulleDialogue.SetActive(false);

        if (dialogues.Count == 1)
        {
            dialogues.Add("");
        }

        //if (interactiveCharacters != null && interactiveCharacters.Count > 0)
        //{
        //    print(interactiveCharacters);
        //    foreach (CharacterData interactiveCharacter in interactiveCharacters)
        //    {
        //        if (interactiveCharacter != null && interactiveCharacter.characterSprite != null)
        //        {
        //            GameObject obj = new GameObject(interactiveCharacter.characterName);
        //
        //            SpriteRenderer spriteRenderer = obj.AddComponent<SpriteRenderer>();
        //            CapsuleCollider2D capsuleCollider2D = obj.AddComponent<CapsuleCollider2D>();
        //            capsuleCollider2D.isTrigger = true;
        //            spriteRenderer.sprite = interactiveCharacter.characterSprite;
        //
        //            obj.tag = "interactiv";
        //            obj.name = interactiveCharacter.characterName;
        //        }
        //        else
        //        {
        //            Debug.LogWarning("One of the interactiveCharacters has a null or missing Sprite. No object instantiated in the scene.");
        //        }
        //    }
        //}
        //else
        //{
        //    Debug.LogError("interactiveCharacters is not defined or empty");
        //}
    }


    public void EnleverDialogue()
    {
        print("cihudfgjfdvdfhdfh");
        bulleDialogue.SetActive(false);
    }


    bool diaCheck = false;

    public void TriggerDialog()
    {
        bulleDialogue.SetActive(true);

        emplacementDia.text = dialogues[indexDia];

        if (indexDia == 1)
        {
            StartCoroutine(attenteShake());

            this.GetComponentInChildren<ActivationMur>().ActivationZone();
            
        }

        if (this.gameObject.name == "ChampiJail")
        {
            diaCheck = true;
        }



        if (this.gameObject.name == "Champi1")
        {
            if (indexDia == 0)
            {
                collect.AfficherCollecte();
            }
            else if (indexDia == 1)
            {
                collect.EnleverCollecte();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bulleDialogue.gameObject.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.name == "ChampiJail" && collision.gameObject.CompareTag("Player") && diaCheck)
        {
            print("ejnefjbfr");
            SwitchGame.Instance.finJeu();
        }
    }


    public int changerIndex(int index)
    {
        indexDia = index;
        print(indexDia);
        return indexDia;
    }

    IEnumerator attenteShake()
    {
        yield return new WaitForSeconds(1.5f);
        CameraController.Instance.shakeVibrate();
    }

}