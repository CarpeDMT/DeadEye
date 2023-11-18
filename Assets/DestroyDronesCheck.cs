using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyDronesCheck : MonoBehaviour
{

    public bool destroyed1;
    public bool destroyed2;
    public UnityEvent DestroyedDrones;
    
    public void Destroy1()
    {
        destroyed1 = true;
        DestroyCheck();
    }

    public void Destroy2()
    {

        destroyed2 = true;
        DestroyCheck();

    }

    public void DestroyCheck()
    {

        if (destroyed1 & destroyed2)
        {
            DestroyedDrones.Invoke();
        }

    }


 
}
