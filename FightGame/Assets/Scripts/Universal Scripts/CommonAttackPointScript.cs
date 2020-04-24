﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonAttackPointScript : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask collisionLayer;
    private float radius = 1f;
    private float damage = 2f;

    public bool is_Player, is_Enemy;
    public GameObject hit_FX_Prefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectCollison();
    }

    private void DetectCollison()
    {
        //throw new NotImplementedException();
        Collider[] hit = Physics.OverlapSphere(transform.position,radius,collisionLayer);
        if (hit.Length > 0) {

            if (is_Player) {

                Vector3 hitFX_Pos = hit[0].transform.position;
                hitFX_Pos.y += 1.3f;

                if (hit[0].transform.forward.x > 0)
                {
                    hitFX_Pos.x += 0.3f;
                }

                else if (hit[0].transform.forward.x < 0)
                {
                    hitFX_Pos.x -= 0.3f;
                }
                Instantiate(hit_FX_Prefab, hitFX_Pos, Quaternion.identity);

               


                if (gameObject.CompareTag(Tags.LEFT_ARM_TAG) || gameObject.CompareTag(Tags.LEFT_LEG_TAG)) {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, true);
                }
                else
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);

                }
            } //if is Player
            if (is_Enemy)
            {
                hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
            }



            gameObject.SetActive(false);
        }
       


    }
}