﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControls : MonoBehaviour
{
    private int laserSpeed = 6;
    void Start()
    {
        
    }


    void Update()
    {
        transform.Translate(Vector3.up * laserSpeed * Time.deltaTime);

        if (transform.position.y >= 6.5)
        {
            Destroy(this.gameObject, 1);
        }

        //private void OnTriggerEnter2D(Collider2D collision)
       // {
        //    if (collision.tag == "Enemy")
        //    {
         //       Destroy(collision.gameObject);
         //       Destroy(this.gameObject);
        //    }
      //  }
    }
}
