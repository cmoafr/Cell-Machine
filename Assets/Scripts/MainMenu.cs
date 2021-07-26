using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu: MonoBehaviour {
    public void Editor() {
        SceneManager.LoadScene("Editor");
    }

    public void Quit() {
        Application.Quit();
    }
}
