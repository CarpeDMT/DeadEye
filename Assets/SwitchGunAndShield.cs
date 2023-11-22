using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGunAndShield : MonoBehaviour
{   


    public float switchingRate = 1f;
    public float blueNextSwitch = 0f; // Initialize nextSwitch to 0 to allow immediate switching
    public float redNextSwitch = 0f; // Initialize nextSwitch to 0 to allow immediate switching
    public GameObject redRayGun;
    public GameObject redShield;
    public GameObject blueRayGun;
    public GameObject blueShield;
    

    public bool redIsGun;
    public bool blueIsGun;
    
    // Start is called before the first frame update
    void Start()
    {
        redIsGun = true;
        blueIsGun = true;
    }

    // Update is called once per frame


    private void OnCollisionStay(Collision other)
    {
        // Check if the collider is tagged as "shield"
        if (other != null && other.collider.CompareTag("BLUE SHIELD"))
        {
            BlueCheckIfSwitch();
            // Perform actions specific to the shield collider
            Debug.Log("Gun is colliding with a blue shield");
        }

        if (other != null && other.collider.CompareTag("RED SHIELD"))
        {
            RedCheckIfSwitch();
            // Perform actions specific to the shield collider
            Debug.Log("Gun is colliding with a red shield");
        }
    }

    public void BlueCheckIfSwitch()
    {
        // Check if enough time has passed since the last switch
        if (Time.time > blueNextSwitch)
        {
            // Switch between gun and shield
            if (blueIsGun)
            {
                // Switch to shield
                BlueSwitchToShield();            }
            else
            {
                // Switch back to gun
                BlueSwitchToGun();
            }

            // Set the nextSwitch time to prevent rapid switching
            blueNextSwitch = Time.time + switchingRate;
        }
    }
 public void RedCheckIfSwitch()
    {
        // Check if enough time has passed since the last switch
        if (Time.time > redNextSwitch)
        {
            // Switch between gun and shield
            if (redIsGun)
            {
                // Switch to shield
                redSwitchToShield();
            }
            else
            {
                // Switch back to gun
                RedSwitchToGun();
            }

            // Set the nextSwitch time to prevent rapid switching
            redNextSwitch = Time.time + switchingRate;
        }
    }
    private void BlueSwitchToGun()
    {
        // Activate gun, deactivate shield
        blueRayGun.SetActive(true);
        blueShield.SetActive(false);
        blueIsGun = true;
    }

    private void RedSwitchToGun()
    {
        // Activate gun, deactivate shield
        redRayGun.SetActive(true);
        redShield.SetActive(false);
        redIsGun = true;
    }
    private void BlueSwitchToShield()
    {
        // Activate shield, deactivate gun
        blueRayGun.SetActive(false);
        blueShield.SetActive(true);
        blueIsGun = false;
    }

     private void redSwitchToShield()
    {
        // Activate shield, deactivate gun
        redRayGun.SetActive(false);
        redShield.SetActive(true);
        redIsGun = false;
    }
}
