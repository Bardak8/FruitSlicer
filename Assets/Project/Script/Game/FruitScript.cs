using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{
    public ParticleSystem particles;
    public void OnSliced()
    {
        // Add your logic here to handle the fruit being sliced
        // For example, you can destroy the fruit object:

        Vector3 pos = gameObject.transform.position;
        Instantiate(particles, pos, gameObject.transform.rotation);
        particles.Play();
        
        Destroy(gameObject);
    }
}
