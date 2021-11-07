using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndMenu : MonoBehaviour
{
    AudioSource audioSrc;

    public AudioClip dontHitSound;
    public AudioClip punchSound;

    public TextMeshProUGUI scoreText;

    public int playSceneIndex = 1;
    public int mainMenuIndex = 0;
    public bool isWinScreen;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        audioSrc = GetComponent<AudioSource>();
        if (audioSrc != null && !isWinScreen)
            StartCoroutine(PlayLoseAudio());

        if (scoreText != null)
            scoreText.text = "You earned " + PlayerPrefs.GetInt("Score") + " euros!";
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

    IEnumerator PlayLoseAudio()
    {
        audioSrc.PlayOneShot(dontHitSound);

        yield return new WaitForSeconds(0.5f);

        audioSrc.PlayOneShot(punchSound);
    }
}
