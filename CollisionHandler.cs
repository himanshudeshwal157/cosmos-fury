using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float CrashDelay = 1f;
    [SerializeField] ParticleSystem ExplosionEffect;
    void OnTriggerEnter(Collider other) 
    {
        StartCrashSequence();
        
    }

    void StartCrashSequence()
    {
        ExplosionEffect.Play();

        GetComponent<PlayerController>().enabled = false;
        Invoke("ReloadLevel", CrashDelay );  
    }
    void ReloadLevel()
    {
        int SceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(SceneIndex);
    }
}
