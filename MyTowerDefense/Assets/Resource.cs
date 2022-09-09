using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public int value = 1;
    public float timeToGainMoney = 1f;
    void FixedUpdate()
    {
        Invoke("MakeMoney", timeToGainMoney);
    }
    void MakeMoney()
    {
        PlayerStats.Money += value;

    }

   
       
}
