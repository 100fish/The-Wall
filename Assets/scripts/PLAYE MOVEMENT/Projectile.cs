using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileLife = 1.0f;
    public int damageAmount = 1;



    private void Start()
    {
        Destroy(gameObject, projectileLife);
        
    }

  
   
}
