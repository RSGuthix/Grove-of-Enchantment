using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{

    public string[] dialogueLines;
    private DialogueManager dMan;
    bool talkRange;


    // Start is called before the first frame update
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (talkRange == true)
        {
            if (Input.GetKeyUp(KeyCode.K))
            {
                //dMan.ShowBox(dialogue);
                if (!dMan.dialogueActive)
                {
                    dMan.dialogueLines = dialogueLines;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();

                }

                if(transform.parent.GetComponent<VillagerMovement>() != null) 
                {
                    transform.parent.GetComponent<VillagerMovement>().canMove = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        talkRange = true;
             
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        talkRange = false;
    }
}
