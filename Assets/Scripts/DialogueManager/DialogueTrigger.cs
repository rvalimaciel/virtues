using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public GameObject panel;
    public Player player;
    public string beforeQuest;
    public string afterQuest;
    private bool inTrigger = false;
    private bool dialogueLoaded = false;
    public GameObject fragment;
    public bool shouldDrop;

    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("player: " + player.name);
        // Debug.Log("ok");
        // Debug.Log(dialogueManager == null);
        panel.SetActive(false);
        if(dialogueManager == null){
            dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        } 
    }

    private void OnTriggerEnter(Collider collision){
        // Debug.Log("Colidiu");
        inTrigger = true;
        
    }

    private void OnTriggerExit(Collider collision){
        // Debug.Log("Descolidiu");
        inTrigger = false;
        panel.SetActive(false);
        
    }

    private void runDialogue(bool keyTrigger, string path){
        
        if(keyTrigger){
            if(inTrigger && !dialogueLoaded){
                panel.SetActive(true);
                dialogueLoaded = dialogueManager.loadDialogue(path);
            }

            if(dialogueLoaded){
                dialogueLoaded = dialogueManager.printLine();
            }
        }
    }

    private string selectAndRunDialog() {
        if (player.hasQuestObject) {
            dialogueManager.shouldDrop = true;
            dialogueManager.fragment = fragment;
            return afterQuest;
        } else {
            return beforeQuest;
        }
    }
    // Update is called once per frame
    void Update()
    {
        string selectedPath = selectAndRunDialog();
        // Debug.Log(selectedPath);
        runDialogue(Input.GetMouseButtonDown(0), selectedPath);
        // Debug.Log("-----------------");
    }
}
