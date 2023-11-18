using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using BNG;
using TRavljen.UnitFormation.Demo;

public class HPManager : MonoBehaviour
{
    public float HP;
   // public Text hpText;
   // public int DefaultHP;

    public UnityEvent GameOver;
    public DeadeyeUnit UnitGuy;
  //  public TimeController time;
    public GameObject[] Lasers;
    public GameObject KillSpawner;
    public GameObject[] Drones;
    public GameObject BatteryFull;
    public GameObject BatteryTopThird;
    public GameObject BatteryHalf; 
    public GameObject BatteryLow;
    public GameObject BatteryGone;
    public GameObject SKULL;
    public GameObject NULL;
  
    public bool ifArcade;
   /*  public bool Waiting;
    public float WaitingTime;
  
     */
    private void Awake()
    {   
       // hpText = this.GetComponent<Text>();
       // if (ifArcade = false)
       // {
        HP = 5f;
      //  }
      //  else {
    //        HP = 10000;
      //  }
        HPUpdate();
       /*  Waiting = false; */
    
    }

    public void HPUpdate()
    {

      if (ifArcade)
      {
        BatteryFull.SetActive(false);
          BatteryTopThird.SetActive(false);
          BatteryHalf.SetActive(false);
          BatteryLow.SetActive(false);
          BatteryGone.SetActive(false);
          SKULL.SetActive(false);
          NULL.SetActive(true);

      }

       // hpText.text = ("");
        else if (HP >= 5)
        {
          BatteryFull.SetActive(true);
          BatteryTopThird.SetActive(false);
          BatteryHalf.SetActive(false);
          BatteryLow.SetActive(false);
          BatteryGone.SetActive(false);
          SKULL.SetActive(false);
          NULL.SetActive(false);

        }
       else if (HP == 4)
        {
          BatteryFull.SetActive(false);
          BatteryTopThird.SetActive(true);
          BatteryHalf.SetActive(false);
          BatteryLow.SetActive(false);
          BatteryGone.SetActive(false);
           SKULL.SetActive(false);
          NULL.SetActive(false);

        }
        else if (HP == 3)
        {
          BatteryFull.SetActive(false);
          BatteryTopThird.SetActive(false);
          BatteryHalf.SetActive(true);
          BatteryLow.SetActive(false);
          BatteryGone.SetActive(false);
           SKULL.SetActive(false);
          NULL.SetActive(false);

        }
        else if (HP == 2)
        {
          BatteryFull.SetActive(false);
          BatteryTopThird.SetActive(false);
          BatteryHalf.SetActive(false);
          BatteryLow.SetActive(true);
          BatteryGone.SetActive(false);
           SKULL.SetActive(false);
          NULL.SetActive(false);

        }

         else if (HP == 1)
        {
          BatteryFull.SetActive(false);
          BatteryTopThird.SetActive(false);
          BatteryHalf.SetActive(false);
          BatteryLow.SetActive(false);
          BatteryGone.SetActive(true);
           SKULL.SetActive(false);
          NULL.SetActive(false);

        }

        else if (HP<=0)
        {  BatteryFull.SetActive(false);
          BatteryTopThird.SetActive(false);
          BatteryHalf.SetActive(false);
          BatteryLow.SetActive(false);
          BatteryGone.SetActive(false); 
          SKULL.SetActive(true);
          NULL.SetActive(false);

            GameOver.Invoke();
            GameOverGuy();
        }
    }

    public void Hit() {
 /*    if (!Waiting){ */
       /* Waiting = true; */
      
        Lasers = GameObject.FindGameObjectsWithTag("ActualLaser");
        foreach (GameObject obj in Lasers)
        {
            Destroy(obj);
        }
        if(!ifArcade){
                HP--;
        HPUpdate();
        }
       // time.ResumeTime();
     /*    WaitingTimeActivate(); */
    }

    public void GameOverGuy()
    {   
         KillSpawner = GameObject.FindWithTag("EnemySpawner");
        Drones = GameObject.FindGameObjectsWithTag("DRONE");
        //UnitGuy = GameObject.FindWithTag("UnitFormationController").GetComponent<DeadeyeUnit>();
        GameObject.Destroy(KillSpawner);
        foreach (GameObject unit in Drones)
        {
            Destroy(unit);
        }
       // if (ifArcade = false){
        HP = 0;
       // GameOver.Invoke();
       // }
      //  else { HP = 10000;}
       // Drones.Clear(); // Clear the list after destroying all units

       // UnitGuy.DestroyAllUnits();
    }

    public void ArcadeMode()
    {
        ifArcade = true;
        HPUpdate();
    }

    public void LivesMode()
    
    {
        ifArcade = false;
        HPUpdate();
    }

    public void GameStartGuy()
    {
        
         
        HP = 5;
        
        //else{ HP = 10000;}
        HPUpdate();
    }
}

   /* public  System.Collections.IEnumerator WaitingTimeActivate()
    {
         yield return new WaitForSeconds(WaitingTime);
         Waiting = false;
         
    }     */
    
