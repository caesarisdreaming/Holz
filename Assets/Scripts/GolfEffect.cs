﻿using System.Collections;
using UnityEngine;

public class GolfEffect : MonoBehaviour
{
    [SerializeField] private string playerName = default;
    private GameObject player;
    private Rigidbody2D playerRB;
    [SerializeField] private float golfEffectRadius = 1f;
    [SerializeField] private float forceMultiplier = 1f;
    void Start()
    {
        player = GameObject.Find(playerName);
        playerRB = player.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!GameStatus.InTransition)
        {
            float distance = Vector2.Distance(this.transform.position, player.transform.position);
            if(distance < golfEffectRadius)
            {
                Vector3 direction = transform.position - player.transform.position;
                playerRB.AddForce(direction * forceMultiplier * Mathf.Sqrt(distance));
                //playerRB.velocity += new Vector2((direction * forceMultiplier * 1 / Mathf.Sqrt(distance)).x, 
                //    (direction * forceMultiplier * 1 / Mathf.Sqrt(distance)).y);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, golfEffectRadius);
    }
}
