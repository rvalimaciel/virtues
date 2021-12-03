using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentStoryManager : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public GameObject panel;
    public Player player;
    public bool isFragment;

    public string path;

    private bool inTrigger = false;
    private bool dialogueLoaded = false;

    
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        if (!isFragment) gameObject.SetActive(false); 
    }
    
    private void runDialogue(string path){
        if (inTrigger){
            Debug.Log(inTrigger);

            if(!dialogueLoaded){
                Debug.Log("entrou no run");
                panel.SetActive(true);
                Debug.Log(panel.active);
                dialogueLoaded = dialogueManager.loadDialogue(path);
            }
                Debug.Log(panel.active);

            if(dialogueLoaded){
                Debug.Log(panel.active);
                dialogueLoaded = dialogueManager.printLine();
                Debug.Log(panel.active);
            }
                Debug.Log(panel.active);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isFragment) {
            player.hasMapObject = true;
        }
        inTrigger = true;
        player.hasMapObject = true;
        runDialogue(path);
                Debug.Log(panel.active);
        player.hasMapObject = true;
                Debug.Log(panel.active);
        // gameObject.SetActive(false);
                Debug.Log(panel.active);
    }
    // Update is called once per frame
    void Update()
    {
        if (panel.activeSelf && Input.GetMouseButtonDown(0)) {
            // Debug.Log("NTROU");

            inTrigger = false;
            panel.SetActive(false);
            gameObject.SetActive(false);
            Debug.Log("NTROU");
        }
    }
}
