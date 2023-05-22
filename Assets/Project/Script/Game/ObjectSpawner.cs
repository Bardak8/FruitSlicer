using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Target variable")] public GameObject prefab;

    [Header("Gameplay")] public float interval;
    public float Y;

    [Header("Visuals")] public Sprite[] sprites;

    [Header("Sound")] public AudioSource slash_sound;
    
    private int hearthCount;

    void Start()
    {
        InvokeRepeating("Spawns", interval, interval);
    }

    private void Spawns()
    {
        // Permet de créer un objet
        GameObject clone = Instantiate(prefab);

        // Récupère la position X de l'objet de fond (Background)
        // Récupère la position X de l'objet de fond (Background)
        float minX = 400;
        float maxX = 500;

        // Génère une position X aléatoire entre les positions min et max de X du fond
        float randomX = Random.Range(minX, maxX);

        // Permet de positionner l'objet
        clone.transform.position = new Vector3(
            randomX,
            Y,
            260
        );
        clone.transform.SetParent(transform);

        // Permet de changer le sprite de l'objet
        Sprite randomSprite = sprites[Random.Range(0, sprites.Length)];
        clone.GetComponent<SpriteRenderer>().sprite = randomSprite;
    }

    public void HandleFruitCollision(GameObject fruit)
    {
        if (fruit.CompareTag("Bomb"))
        {
            GameObject[] hearthObjects = GameObject.FindGameObjectsWithTag("Hearth");
            if (hearthObjects.Length - 1 >= 0)
            {
                Destroy(hearthObjects[hearthObjects.Length - 1]);
            }

            slash_sound.Play();
            fruit.GetComponent<FruitScript>().OnSliced();
        }
        else if (fruit.CompareTag("Fruit"))
        {
            // Add your desired logic here, such as increasing score, destroying the fruit, etc.
            // For example, you can call a method on the fruit's script to handle its destruction:
            fruit.GetComponent<FruitScript>().OnSliced();
            slash_sound.Play();
        }


    }
}
