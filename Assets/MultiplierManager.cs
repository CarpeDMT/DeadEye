using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MultiplierManager : MonoBehaviour
{
    public Text scoreText;
    public Text multiplierText;

    public event Action<bool> OnSuccessfulHit; // true for successful, false for unsuccessful
    public event Action<int> OnMultiplierActivated; // the activated multiplier

    public uint score = 0;
    private int consecutiveHits = 0;
    public int multiplier = 1;
    public uint points; 
    public UnityEvent ReduceMultiplier;
    public UnityEvent IncreaseMultiplier;
    private void Start()
    {
        scoreText = GameObject.FindWithTag("SCORE").GetComponent<Text>();

        UpdateScoreText();
        UpdateMultiplierText();
    }

    public void RegisterHit(bool isSuccessful)
    {
        if (isSuccessful)
        {
            consecutiveHits++;
            if (consecutiveHits == 5)
            {
                multiplier++;
                consecutiveHits = 0;
                OnMultiplierActivated?.Invoke(multiplier);
                UpdateMultiplierText();
                IncreaseMultiplier.Invoke();
            }
            score += (uint)(multiplier * 10);
            OnSuccessfulHit?.Invoke(true);
        }
        else
        {
            consecutiveHits = 0;
            OnSuccessfulHit?.Invoke(false);
            ReduceMultiplier.Invoke();
            multiplier = 1;
            UpdateMultiplierText();
            
        }

        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    public void UpdateMultiplierText()
    {
        multiplierText.text = multiplier > 1 ? multiplier + "X Multiplier" : "";
    }

    public void ReduceMultiplierMethod()
    {
          consecutiveHits = 0;
            OnSuccessfulHit?.Invoke(false);
            ReduceMultiplier.Invoke();
            multiplier = 1;
            UpdateMultiplierText();
    }
}
