using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Object Spawner Variables")]
    public float spawnRate;
    public float xSpeedRange;
    public float ySpeedRange;

    
    private int difficulty;
    private ObjectSpawner _objectSpawner;
    private ObjectSpawner _bombSpawner;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
           Debug.LogError(
                    "GameManager: There can only be one GameManager. " +
                    "Destroying the new one named " + gameObject.name + ".");
                Destroy(gameObject);
        }

        // Obtenir la référence à l'ObjectSpawner dans la scène Game
       difficulty = PlayerPrefs.GetInt("difficulty");
       Level1();
    }

    public void SetObjectSpawnerVariables(float spawnRate, float xSpeedRange, float ySpeedRange)
    {
        _objectSpawner = GameObject.Find("FruitSpawner").GetComponent<ObjectSpawner>();
        _bombSpawner = GameObject.Find("BombSpawner").GetComponent<ObjectSpawner>();
        this.spawnRate = spawnRate;
        this.xSpeedRange = xSpeedRange;
        this.ySpeedRange = ySpeedRange;

        // Appliquer les nouvelles valeurs à l'ObjectSpawner
        if (_objectSpawner != null)
        {
            _objectSpawner.spawnRate = spawnRate;
            _objectSpawner.xSpeedRange = xSpeedRange;
            _objectSpawner.ySpeedRange = ySpeedRange;
        } else if (_bombSpawner != null)
        {
            _bombSpawner.spawnRate = spawnRate - 0.2f;
            _bombSpawner.xSpeedRange = xSpeedRange;
            _bombSpawner.ySpeedRange = ySpeedRange;
        }
    }
    


    public float GetSpawnRate()
    {
        return spawnRate;
    }

    public float GetXSpeedRange()
    {
        return xSpeedRange;
    }

    public float GetYSpeedRange()
    {
        return ySpeedRange;
    }

    public void Level1()
    {
        if (difficulty == 1)
        {
           SetObjectSpawnerVariables(1f, 50f, 50f);
        } else if (difficulty == 2)
        {
            SetObjectSpawnerVariables(0.5f, 60f, 60f);
        } else if (difficulty == 3)
        {
            SetObjectSpawnerVariables(0.3f, 70f, 70f);
        }

        Debug.Log("bouyag");
        Debug.Log(GetSpawnRate());
    }
}