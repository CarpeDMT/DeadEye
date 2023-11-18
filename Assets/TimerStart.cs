using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyGiantStudio.Text.Example;

public class TimerStart : MonoBehaviour
{
    public GameObject kiki;
    public Countdown countdown;
    // Start is called  before the first frame update
    void Start()
    {
         
       kiki =  GameObject.FindGameObjectWithTag("TIMER");
        countdown = kiki.GetComponent<Countdown>();
        if (countdown != null)
        {
            countdown.StartTimer();
        }
        // Check if there are subscribers to the event before firing it
      //  AwakeEventing.Invoke();

    }
}
   
