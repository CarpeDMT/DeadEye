using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using BNG;
using TRavljen.UnitFormation.Demo;


public class ArcadeManager : MonoBehaviour
{

    public UnityEvent GameOver;
    public DeadeyeUnit UnitGuy;
    public GameObject[] Lasers;
    public GameObject KillSpawner;
    public GameObject[] Drones;
    public GameObject BatteryFull;
    public GameObject BatteryTopThird;
    public GameObject BatteryHalf; 
    public GameObject BatteryLow;
    public GameObject BatteryGone;
    public GameObject SKULL;
    public GameObject SNULL;
    public bool ifArcade;
    public GameObject multiplier;

    public void GameStartGuy()
    {   
        
        BatteryFull.SetActive(false);
        BatteryTopThird.SetActive(false);
        BatteryHalf.SetActive(false);
        BatteryLow.SetActive(false);
        BatteryGone.SetActive(false);
        SKULL.SetActive(false);
        SNULL.SetActive(true);


 
    
    }

    

    public void Hit() {

      
        Lasers = GameObject.FindGameObjectsWithTag("ActualLaser");
        if(Lasers != null){
        foreach (GameObject obj in Lasers)
        {
            Destroy(obj);
        }
        }
        multiplier.GetComponent<MultiplierManager>().ReduceMultiplierMethod();
        
   
    }

    // public void GameOverGuy()
    // {   
    //      KillSpawner = GameObject.FindWithTag("EnemySpawner");
    //     Drones = GameObject.FindGameObjectsWithTag("DRONE");
    //     GameObject.Destroy(KillSpawner);
    //     foreach (GameObject unit in Drones)
    //     {
    //         Destroy(unit);
    //     }
       
        
     
    // }


    
}


    
