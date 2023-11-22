
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
  
  
    public void HPUpdate()
    {

     

       // hpText.text = ("");
         if (HP >= 5)
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
            //GameOverGuy();
        }
    }

    public void Hit() {

        Lasers = GameObject.FindGameObjectsWithTag("ActualLaser");
        foreach (GameObject obj in Lasers)
        {
            Destroy(obj);
        }
      
                HP--;
        HPUpdate();
        }
 

  public void GameOverGuy()
{   
    KillSpawner = GameObject.FindWithTag("EnemySpawner");
    Drones = GameObject.FindGameObjectsWithTag("DRONE");

    // Check if KillSpawner is a parent of any "DRONE" game objects
    bool killSpawnerIsParent = false;
    foreach (GameObject drone in Drones)
    {
        if (drone.transform.IsChildOf(KillSpawner.transform))
        {
            killSpawnerIsParent = true;
            break;
        }
    }

    // Only destroy KillSpawner if it's not a parent of any "DRONE" game objects
    if (!killSpawnerIsParent)
    {
        GameObject.Destroy(KillSpawner);
    }

    // Destroy each "DRONE" game object
    foreach (GameObject unit in Drones)
    {
      
        Destroy(unit);
    }
}


  
    public void GameStartGuy()
    {
        
         
        HP = 5;
        
              HPUpdate();
    }
}


