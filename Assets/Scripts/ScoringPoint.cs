using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringPoint : MonoBehaviour
{
    [SerializeField] int scoreValue;
    [SerializeField] GameUI gameUI;

    private void Start()
    {
        gameUI = FindObjectOfType<GameUI>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Scoring Ball"))
        {
            gameUI.playerScore += scoreValue;
        }
        else if(other.CompareTag("Non Scoring Ball"))
        {
            gameUI.playerScore -= scoreValue * .5f;
        }
    }
}
