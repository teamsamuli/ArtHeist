using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    MouseLook mouselook;
    Killable killable;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;    
    public GameObject pickUpText;
    public Image timerFill;
    public Image throwBarFill;

    // Start is called before the first frame update
    void Start()
    {
        mouselook = transform.parent.GetComponentInChildren<MouseLook>();
        killable = transform.parent.GetComponentInChildren<Killable>();
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
    }
}
