using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class CollectableManager : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _particleSystem.Emit(10);

        }
    }
}
