using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueConversation : MonoBehaviour
{
    public DialogueNode beginning;
    public GameObject textBoxContainer;
    public TMP_Text characterName;
    public TMP_Text textBox;
    public Image profileImage;
    public float punctuationDelayMultiplier = 10f;
    public UnityEvent OnConversationStarted;
    public UnityEvent OnConversationFinished;
    public UnityEvent OnCharacterShow;
    private DialogueNode currNode;

    private void Start()
    {
        OnConversationStarted.AddListener(delegate
        {
            Player.instance.GetComponent<PlayerInputProcessor>().Interact.AddListener(advanceConversation);
        });

        OnConversationFinished.AddListener(delegate
        {
            Player.instance.GetComponent<PlayerInputProcessor>().Interact.RemoveListener(advanceConversation);
        });
    }

    public void advanceConversation()
    {
        DialogueNode nextNode;

        if (currNode == null)
        {
            OnConversationStarted.Invoke();
            nextNode = beginning;
        }
        else
        {
            nextNode = currNode.next;
        }
        StopAllCoroutines();
        StartCoroutine(displayNextText(nextNode));
    }

    IEnumerator displayNextText(DialogueNode node)
    {
        currNode = node;
        textBoxContainer.SetActive(node != null);

        if (node != null)
        {
            textBox.text = "";

            string name = CharacterProfileInitializer.getName(node.character);

            characterName.text = name == null ? node.character.ToString() : name;

            setImage(CharacterProfileInitializer.getCharacterIcon(node.character));

            for (int charInd = 0; charInd < node.dialogue.Length; charInd++)
            {
                textBox.text += node.dialogue[charInd];
                OnCharacterShow.Invoke();
                yield return 
                    new WaitForSecondsRealtime(
                        node.textShowInterval + 
                        (char.IsPunctuation(node.dialogue[charInd]) ? node.textShowInterval * punctuationDelayMultiplier : 0));
            }
        }
        else
        {
            OnConversationFinished.Invoke();
        }
    }

    public void setImage(Sprite image)
    {
        profileImage.sprite = image;
    }

}
