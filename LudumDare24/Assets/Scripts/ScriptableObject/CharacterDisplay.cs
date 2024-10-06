using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class CharacterDisplay : MonoBehaviour
{
    public List<CharacterData> interactiveCharacters;
    [SerializeField] TextMeshProUGUI dialog;

    public List<string> dialogues;

    int indexDia = 0;

    void Start()
    {
        indexDia = 0;

        if (dialogues.Count == 1)
        {
            dialogues.Add("");
        }

        if (interactiveCharacters != null && interactiveCharacters.Count > 0)
        {
            print(interactiveCharacters);
            foreach (CharacterData interactiveCharacter in interactiveCharacters)
            {
                if (interactiveCharacter != null && interactiveCharacter.characterSprite != null)
                {
                    GameObject obj = new GameObject(interactiveCharacter.characterName);

                    SpriteRenderer spriteRenderer = obj.AddComponent<SpriteRenderer>();
                    CapsuleCollider2D capsuleCollider2D = obj.AddComponent<CapsuleCollider2D>();
                    capsuleCollider2D.isTrigger = true;
                    spriteRenderer.sprite = interactiveCharacter.characterSprite;

                    obj.tag = "interactiv";
                    obj.name = interactiveCharacter.characterName;
                }
                else
                {
                    Debug.LogWarning("One of the interactiveCharacters has a null or missing Sprite. No object instantiated in the scene.");
                }
            }
        }
        else
        {
            Debug.LogError("interactiveCharacters is not defined or empty");
        }
    }



    public void TriggerDialog(string obj)
    {
        print("Dialog started");
        foreach (CharacterData objData in interactiveCharacters)
        {
            if (objData != null)
            {
                if(objData.sentences != null)
                {
                    print("Test");
                }
                if(objData.characterName == obj)
                {
                    print("Test2");
                }
                dialog.text = $"{obj}: {objData.sentences[0]}"; // Affiche la première phrase par exemple
                //Debug.Log(objData.characterName + " : " + objData.sentences[0]);
            }
            else
            {
                Debug.Log("No data found");
            }
        }
    }


    private int changerIndex(int index)
    {
        indexDia = index;
        return indexDia;
    }

}