using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearOnTouch : MonoBehaviour
{
    public Player player;
    public bool isFragment;
    public bool isQuestItem;
    void Update()
    {
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isFragment) {
            player.hasMapObject = true;
        }
        
        if (isQuestItem) {
            player.hasQuestObject = true;
        }

        gameObject.SetActive(false);
        Debug.Log(player);
    }
}
