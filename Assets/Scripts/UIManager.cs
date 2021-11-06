using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    MouseLook mouselook;
    Killable killable;

    [Header("Subtitles")]
    public TextMeshProUGUI subtitleText;
    public CanvasGroup subtitleGroup;
    public float subtitleShowTime = 2f;
    float lastTimeSubtitlesShown;

    [Header("Texts")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;  
    public GameObject pickUpText;

    [Header("Fills")]
    public Image timerFill;
    public Image throwBarFill;

    // Start is called before the first frame update
    void Start()
    {
        mouselook = transform.parent.GetComponentInChildren<MouseLook>();
        killable = transform.parent.GetComponentInChildren<Killable>();

        //Hide subtitle
        subtitleGroup.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Score text
        scoreText.text = "Score: " + Score.score;

        //Health text
        healthText.text = "Health: " + killable.health.ToString("F0");

        //Update pick up text
        pickUpText.SetActive(mouselook.IsLookingObject());

        //Update throw fill
        throwBarFill.fillAmount = mouselook.GetThrowMult();

        //Update timer
        timerFill.fillAmount = GameManager.game.GetTimeMultLeft();

        //Hide subtitles after short delay
        if (Time.time >= lastTimeSubtitlesShown + subtitleShowTime)
        {
            subtitleGroup.alpha = Mathf.MoveTowards(subtitleGroup.alpha, 0, 1f * Time.deltaTime);
        }
    }

    public void UpdateSubtitles(string text)
    {
        lastTimeSubtitlesShown = Time.time;
        subtitleGroup.alpha = 1f;

        subtitleText.text = text;
    }
}
