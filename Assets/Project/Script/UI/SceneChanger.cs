using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int difficulty;
    public void ChangeScene(string name)
    {
        PlayerPrefs.SetInt("difficulty", difficulty );
        SceneManager.LoadScene(name);
    }

    
}