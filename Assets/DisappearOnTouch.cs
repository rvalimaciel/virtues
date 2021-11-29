using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearOnTouch : MonoBehaviour
{
    public Player player;
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        player.hasQuestObject = true;
        Debug.Log();
    }
}
