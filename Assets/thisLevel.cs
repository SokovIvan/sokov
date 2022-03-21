using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class thisLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("curL",SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("LibC", PlayerPrefs.GetInt("LibC")+1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
