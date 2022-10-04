using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public GameObject dBox;
    public Text dText;
    private PlayerController thePlayer;

    public bool dialogueActive;

    public string[] dialogueLines;
    public int currentLine;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueActive && Input.GetKeyDown(KeyCode.Space)) 
        {
            
            currentLine++;

        }

        if (currentLine >= dialogueLines.Length) 
        {
            dBox.SetActive(false);
            dialogueActive = false;
            currentLine = 0;
            thePlayer.canMove = true;
        }

        dText.text = dialogueLines[currentLine];
    }

    /* Testing singular dialogue
    public void ShowBox(string dialogue) 
    {
        dialogueActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;

    }
    */

    public void ShowDialogue() 
    {
        dialogueActive = true;
        dBox.SetActive(true);
        thePlayer.canMove = false;

    }
}
