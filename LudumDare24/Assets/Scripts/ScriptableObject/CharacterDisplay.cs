using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterDisplay : MonoBehaviour
{
    public List<CharacterData> interactiveCharacters;
    [SerializeField] TextMeshProUGUI dialog;

    // Assigner le prefab d'un objet PNG pour maintenir la structure et les composants
    public GameObject pngPrefab;

    void Start()
    {
        if (interactiveCharacters != null && interactiveCharacters.Count > 0)
        {
            foreach (CharacterData interactiveCharacter in interactiveCharacters)
            {
                if (interactiveCharacter != null && interactiveCharacter.characterSprite != null)
                {
                    // Instancie un nouvel objet à partir du prefab PNG
                    GameObject obj = Instantiate(pngPrefab, transform.position, Quaternion.identity);
                    obj.name = interactiveCharacter.characterName;
                    obj.tag = "interactiv";

                    // Récupère les composants déjà présents dans le prefab
                    SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
                    CircleCollider2D circleCollider2D = obj.GetComponent<CircleCollider2D>();

                    // Assigner le sprite du personnage à ce PNG
                    if (spriteRenderer != null)
                    {
                        spriteRenderer.sprite = interactiveCharacter.characterSprite;
                    }

                    // S'assurer que le collider est trigger
                    if (circleCollider2D != null)
                    {
                        circleCollider2D.isTrigger = true;
                    }

                    // Configurer le dialogue via l'enfant "Panel" dans la hiérarchie
                    Transform panelTransform = obj.transform.Find("Canvas/Panel");
                    if (panelTransform != null)
                    {
                        TextMeshProUGUI dialogText = panelTransform.GetComponentInChildren<TextMeshProUGUI>();
                        if (dialogText != null)
                        {
                            dialogText.text = interactiveCharacter.sentences.Length > 0 ? interactiveCharacter.sentences[0] : "No Dialog";
                        }
                    }
                    else
                    {
                        Debug.LogWarning("Panel child not found in the prefab structure.");
                    }
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
            if (objData != null && objData.sentences != null && objData.characterName == obj)
            {
                dialog.text = $"{obj}: {objData.sentences[0]}"; // Affiche la première phrase par exemple
                //Debug.Log(objData.characterName + " : " + objData.sentences[0]);
            }
            else
            {
                Debug.Log("No data found");
            }
        }
    }
}
