using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{
    public void OnSliced()
    {
        // Add your logic here to handle the fruit being sliced
        // For example, you can destroy the fruit object:
        Destroy(gameObject);
    }
}
