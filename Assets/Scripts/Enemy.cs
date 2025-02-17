﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Spawner spawner;
    [SerializeField]
    public static float enemySpeed = 0.5f;
    // Update is called once per frame

    void Start(){
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
    }
    void FixedUpdate()
    {
        gameObject.transform.Translate(Vector3.left * enemySpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D col){
    if (col.gameObject.tag == "Player"){
            ScoreVidas.vidas--;
            spawner.SpawnInimigo();
            Destroy (this.gameObject);
            //reduzir a vida do Player
        }
    }
}
