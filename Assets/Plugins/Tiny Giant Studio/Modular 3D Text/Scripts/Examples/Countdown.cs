using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace TinyGiantStudio.Text.Example
{
    public class Countdown : MonoBehaviour
    {
        [SerializeField] bool startCountdownOnStart = true;
        [Space]
        [SerializeField] Modular3DText modular3DText = null;
        [Space]
        [SerializeField] string textAfterCountdownEnds = "";
        [Space]
        [SerializeField] int duration = 10;
        [Tooltip("How fast the duration goes down.\nValue of 1 = normal time.")]
        [SerializeField] float timeStep = 1;
        public UnityEvent CountdownEndings;

        void Start()
        {
            if (startCountdownOnStart && modular3DText)
                StartCoroutine(CountdownRoutine());
        }

        public void StartTimer() 
        {
            StartCoroutine(CountdownRoutine());
        }
        
        IEnumerator CountdownRoutine()
        {
            if (timeStep == 0)
                timeStep = 0.01f;

            modular3DText.UpdateText(duration.ToString());

            for (int i = duration - 1; i > 0; i--)
            {
                yield return new WaitForSeconds(timeStep);
                modular3DText.UpdateText(i.ToString());
                
            }
            yield return new WaitForSeconds(1);
            modular3DText.UpdateText(textAfterCountdownEnds);
        }
    }
}