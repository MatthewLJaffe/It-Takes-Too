using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Node", menuName = "Dialogue Node")]
public class DialogueNode : ScriptableObject
{
    public CharacterProfile character;
    [TextArea(3, 5)]
    public string dialogue;
    public float textShowInterval = 0.02f;
    public DialogueNode next;
}
