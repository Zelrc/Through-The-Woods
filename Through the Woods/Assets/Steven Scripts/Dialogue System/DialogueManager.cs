using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : Singleton<DialogueManager>
{
    Queue<string> sentences = new Queue<string>();
    Queue<string> names = new Queue<string>();

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public void StartDialogue(Dialogue dialogue)
    {
        
        //sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            names.Enqueue(dialogue.name);
            
            sentences.Enqueue(sentence);
            //Debug.Log(sentence);
        }

        //DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count <= 0)
        {
            EndDialogue();
            return;
        }

        
        string name = names.Dequeue();
        string sentence = sentences.Dequeue();
        Debug.Log(sentence);

        StopAllCoroutines();
        StartCoroutine(TypingAnim(sentence, name));
    }

    void EndDialogue()
    {
        nameText.transform.parent.gameObject.SetActive(false);
    }

    IEnumerator TypingAnim (string sentence, string name)
    {
        nameText.text = name;

        dialogueText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }
    
    
}
