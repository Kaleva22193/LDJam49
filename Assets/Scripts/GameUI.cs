using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] float unstableValue;

    [SerializeField] Image topRedImage;
    [SerializeField] Image bottomRedImage;
    [SerializeField] Image leftRedImage;
    [SerializeField] Image rightRedImage;

    [SerializeField] TMP_Text scoreText;

    [SerializeField] GameObject playingBall;
    public float playerScore;

    bool rightRedIncrease;
    bool leftRedIncrease;
    bool topIncrease;
    bool bottomIncrease;

    float rightTimer = 1;
    float leftTimer = 1;
    float topTimer = 1;
    float bottomTimer = 1;

    private void Start()
    {
        List<Image> redImages = new List<Image>();
        redImages.Add(topRedImage);
        redImages.Add(bottomRedImage);
        redImages.Add(leftRedImage);
        redImages.Add(rightRedImage);

        foreach (Image image in redImages)
        {
            image.gameObject.SetActive(false);
        }
        
    }
    private void Update()
    {
        ScoreUpdate();
        if (rightRedIncrease)
        {            
            rightTimer += Time.deltaTime;
            rightRedImage.gameObject.TryGetComponent<RectTransform>(out RectTransform height);
            height.localScale = new Vector3(rightTimer, 1, 0);
            leftTimer -= Time.deltaTime;
            leftTimer = TimerCheck(leftTimer);

        }
        else if (leftRedIncrease)
        {
            leftTimer += Time.deltaTime;
            leftRedImage.gameObject.TryGetComponent<RectTransform>(out RectTransform height);
            height.localScale = new Vector3(leftTimer, 1, 0);
            rightTimer -= Time.deltaTime;
            rightTimer = TimerCheck(rightTimer);
        }
        else if (topIncrease)
        {
            topTimer += Time.deltaTime;
            topRedImage.gameObject.TryGetComponent<RectTransform>(out RectTransform height);
            height.localScale = new Vector3(1, topTimer, 0);
            bottomTimer -= Time.deltaTime;
            bottomTimer = TimerCheck(bottomTimer);
        }
        else if (bottomIncrease)
        {
            bottomTimer += Time.deltaTime;
            RectTransform height = bottomRedImage.gameObject.GetComponent<RectTransform>();
            height.localScale = new Vector3(1, bottomTimer, 0);
            topTimer -= Time.deltaTime;
            topTimer = TimerCheck(topTimer);
        }
        

    }
    void ScoreUpdate()
    {
        scoreText.text = playerScore.ToString("0.0");
    }
    float TimerCheck(float timerValue)
    {
        if (timerValue <= 1)
        {
            return 1f;
        }
        else return timerValue;
    }
    public void UnstableXAxis(float value)
    {
        if(value >= unstableValue)
        {    
            Debug.LogWarning("Critical Failure!!!");
            rightRedImage.gameObject.SetActive(true);
            rightRedIncrease = true;
        }
        else
        {
            Debug.Log("That Was close!!");
            rightRedImage.gameObject.SetActive(false);
            rightRedIncrease = false;
        }
        if (value <= -unstableValue)
        {
            Debug.LogWarning("Critical Failure!!!");
            leftRedImage.gameObject.SetActive(true);
            leftRedIncrease = true;
        }
        else
        {
            Debug.Log("That Was close!!");
            leftRedImage.gameObject.SetActive(false);
            leftRedIncrease = false;
        }
    }
    public void UnstableZAxis(float value)
    {
        if (value <= -unstableValue)
        {
            Debug.LogWarning("Critical Failure!!!");
            topRedImage.gameObject.SetActive(true);
            topIncrease = true;
        }
        else
        {
            Debug.Log("That Was close!!");
            topRedImage.gameObject.SetActive(false);
            topIncrease = false;
        }
        if (value >= unstableValue)
        {
            bottomRedImage.gameObject.SetActive(true);
            bottomIncrease = true;
        }
        else
        {
            bottomRedImage.gameObject.SetActive(false);
            bottomIncrease = false;
        }
        Debug.Log("Z Axis value " + value);
    }
    public void LetMeOffTheRide()
    {
        float highScore = PlayerPrefs.GetFloat("High_Score");
        float lowestScore = PlayerPrefs.GetFloat("Lowest_Score");
        if (playerScore > highScore)
        {
            PlayerPrefs.SetFloat("High_Score", playerScore);
        }
        else if(lowestScore > playerScore)
        {
            PlayerPrefs.SetFloat("Lowest_Score", playerScore);
        }
        SceneManager.LoadScene(0);
    }
}
