using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Canvas canvas;
    public void DisableCanvas() {
        canvas.GetComponent<Canvas> ().enabled = false;
    }
}
