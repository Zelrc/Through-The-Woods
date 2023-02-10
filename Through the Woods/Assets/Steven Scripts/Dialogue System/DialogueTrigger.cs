using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue[] dialogue;

    //public GameObject dialogueScreen;

    public void Start()
    {
        foreach(Dialogue dialog in dialogue)
        {
            DialogueManager.Instance.StartDialogue(dialog);
        }

        TriggerNext();
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
