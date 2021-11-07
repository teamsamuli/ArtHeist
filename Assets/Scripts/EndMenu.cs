using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public int playSceneIndex = 1;
    public int mainMenuIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(playSceneIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuIndex);
    }
}
