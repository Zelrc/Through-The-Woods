using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    //public GameObject dialogueScreen;

    public void Start()
    {
        DialogueManager.Instance.StartDialogue(dialogue);
    }

    public void TriggerNext()
    {
        DialogueManager.Instance.DisplayNextSentence();
    }

    public void EndDialogue()
    {
        //dialogueScreen.SetActive(false);
    }
}
