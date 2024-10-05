using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDisplay : MonoBehaviour
{
    public List<CharacterData> interactiveCharacters;
    // [SerializeField] GameObject dialog;

    void Start()

    {
        if (interactiveCharacters != null && interactiveCharacters.Count > 0)
        {
            foreach (CharacterData interactiveCharacter in interactiveCharacters)
            {
                if (interactiveCharacter != null && interactiveCharacter.characterSprite != null)
                {
                    GameObject obj = new GameObject(interactiveCharacter.characterName);

                    SpriteRenderer spriteRenderer = obj.AddComponent<SpriteRenderer>();
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
}