using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    MouseLook mouselook;
    Killable killable;

    public CanvasGroup tutorialGroup;
    public float tutorialShowTime = 8f;
    public bool tutorialEnded = false;

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

        tutorialEnded = false;

        //Hide subtitle
        subtitleGroup.alpha = 0;

        //Fade tutorial
        StartCoroutine(FadeTutorialAway());
    }

    // Update is called once per frame
    void Update()
    {
        //Score text
        scoreText.text = "Earnings: " + GameManager.game.score;

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

    IEnumerator FadeTutorialAway()
    {
        yield return new WaitForSeconds(tutorialShowTime);

        while (tutorialGroup.alpha > 0)
        {
            tutorialGroup.alpha -= Time.deltaTime;
            yield return null;
        }

        tutorialEnded = true;
    }
}
