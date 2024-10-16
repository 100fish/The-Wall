using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //JACK CODE


    bool isHit = false;
    public int points = 1;

    public bool IsHit()
    {
        return isHit;
    }


    public int Damage()
    {
        isHit = true;
        Destroy(gameObject, 1f);
        return points;
    }

}