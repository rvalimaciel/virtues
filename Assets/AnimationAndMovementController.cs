using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationAndMovementController : MonoBehaviour
{
    PlayerInput playerInput;

    private void Awake() {
        playerInput = new PlayerInput();

        playerInput.CharacterControls.Move.started += context => { Debug.Log(context.ReadValue<Vector2>()); };
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

    }
}
