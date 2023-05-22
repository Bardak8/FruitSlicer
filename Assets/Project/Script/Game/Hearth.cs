using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearth : MonoBehaviour
{
    public ObjectSpawner objectSpawner;
    public int totalSprites = 6;
    private int currentSprites;

    void Start()
    {
        currentSprites = totalSprites;
    }

    public void RemoveSprite()
    {
        currentSprites--;
        Debug.Log("Remaining sprites: " + currentSprites);

        if (currentSprites <= 0)
        {
            // Game over logic
            Debug.Log("Game Over");
        }
    }
}
