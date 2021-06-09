using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogues dialogue;
    //NPC나 story element.. 즉 그냥 게임에 대화를 덧씌우는 느낌임. 

    public void Start()
    {
            TriggerDialouge();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }
    }
    public void TriggerDialouge()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
