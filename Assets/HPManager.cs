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
    public int HP;
    public Text hpText;
    public int DefaultHP;

    public UnityEvent GameOver;
    public DeadeyeUnit UnitGuy;
  //  public TimeController time;
    public GameObject[] Lasers;
    public GameObject KillSpawner;
    public GameObject[] Drones;
    public bool ifArcade;
   /*  public bool Waiting;
    public float WaitingTime;
  
     */
    private void Awake()
    {   
        hpText = this.GetComponent<Text>();
       // if (ifArcade = false)
       // {
        HP = DefaultHP;
      //  }
      //  else {
    //        HP = 10000;
      //  }
        HPUpdate();
       /*  Waiting = false; */
    
    }

    public void HPUpdate()
    {
    
        hpText.text = ("");

        if (HP<=0)
        { 
            GameOver.Invoke();
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
                HP--;
        HPUpdate();
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
        HP = DefaultHP;
       // }
      //  else { HP = 10000;}
       // Drones.Clear(); // Clear the list after destroying all units

       // UnitGuy.DestroyAllUnits();
    }

    public void ArcadeMode()
    {
        ifArcade = true;
    }

    public void LivesMode()
    
    {
        ifArcade = false;
    }

    public void GameStartGuy()
    {
      //  if (ifArcade = false){
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
    
