using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExpo : MonoBehaviour
{
    public GameObject particleEffectPrefab;

    private void Start()
    {
        Invoke("Explode", 4f); 
    }

    private void Explode()
    {
        Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
