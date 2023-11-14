using UnityEngine;
using TMPro;
using UnityEngine.Events;
using TinyGiantStudio.Text;

public class CountdownTimerMine : MonoBehaviour
{
    public Modular3DText countdownText;
    public float timeLimit = 10f;
    public UnityEvent onGameStop;

    private float currentTime;

    private void Start()
    {
        countdownText = this.GetComponent<Modular3DText>();
        countdownText.UpdateText(timeLimit.ToString());
        if (countdownText == null)
        {
            Debug.LogError("CountdownText not assigned!");
       }
    }

    public void StartTimer()
    {   if (gameObject.activeSelf)
    {
        currentTime = timeLimit;
        // Start the countdown
        StartCoroutine(Countdown());
    }
    }
    private System.Collections.IEnumerator Countdown()
    {
        

        while (currentTime > 0f)
        {
            // Update the countdown text
            UpdateCountdownText();

            // Wait for a short duration before decrementing time
            yield return new WaitForSeconds(1f);

            // Decrement the time
            currentTime -= 1f;
        }

        // Ensure the countdown text displays '0' at the end
        UpdateCountdownText();

        // Fire the Unity event for game stop
        if (onGameStop != null)
        {
            onGameStop.Invoke();
        }
    }

    private void UpdateCountdownText()
    {
        // Update the TextMeshProUGUI component with the current time
         countdownText.UpdateText(timeLimit.ToString());
    }
}