using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    MouseLook mouselook;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;    
    public GameObject pickUpText;
    public Image timerFill;

    // Start is called before the first frame update
    void Start()
    {
        mouselook = transform.parent.GetComponentInChildren<MouseLook>();
    }

    // Update is called once per frame
    void Update()
    {
        //Score text
        scoreText.text = "Score: " + Score.score;

        //Update pick up text
        pickUpText.SetActive(mouselook.IsLookingObject());
    }
}
