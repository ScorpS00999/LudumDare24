using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/Character", order = 1)]
public class CharacterData : ScriptableObject
{
    [Header("Character Info")]
    public string characterName;
    public Sprite characterSprite;

    [TextArea(3, 10)]
    [Header("Dialogues")]
    public string[] sentences;
}