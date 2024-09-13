using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject CrashEffect;
    [SerializeField] GameObject HitVfx;
    [SerializeField] int scorePerHit = 10;
    [SerializeField] int HitPoints = 4;
    

    ScoreBoard scoreBoard;
    GameObject ParentObject;
    
    


    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        ParentObject = GameObject.FindWithTag("SpawnAtRuntime");

        AddRigidBody();
        
    }
    void AddRigidBody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;

    }
    

   
    
    void OnParticleCollision(GameObject other) 
    {
        ScoreCard();
        if (HitPoints<1)
        {
            KillEnemy();
 
        }
        

        void ScoreCard()
        {   GameObject vfx = Instantiate(HitVfx, transform.position, Quaternion.identity);
            vfx.transform.parent = ParentObject.transform;
            scoreBoard.IncreaseScore(scorePerHit);
            HitPoints= HitPoints-1;

        }

        void KillEnemy()
        {

            
            GameObject vfx = Instantiate(CrashEffect, transform.position, Quaternion.identity);
            vfx.transform.parent = ParentObject.transform;
            Destroy(gameObject);

            
        }
   
       
            
    }
        
}