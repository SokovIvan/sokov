using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Csc2 : MonoBehaviour
{
    public GameObject butttons;
    float podtv;
    bool pause;
    // Start is called before the first frame update
    void Start()
    {
        podtv = 0;
        pause = false;
    }
    // Update is called once per frame
    void Update()
    {
    
    }
    public void onClick()
    {
        PlayerPrefs.SetInt("LibC",  1);
        Application.LoadLevel(4);
    }
    public void onClickQ()
    {
        butttons.SetActive(true);
       podtv = 2;
        //Application.Quit();
    }
    public void onClickL()
    {
        Application.LoadLevel(12);
    }
    public void onClickB()
    {
        if (Random.Range(0, 2) == 1) 
        { 
            Application.LoadLevel(8);
        }
        else
        {
            SceneManager.LoadScene("Battle2");
        }
       
    }
    public void onClick—()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("curL"));

    }
    public void onClickM()
    {
        butttons.SetActive(true);
        podtv = 1;
        //Application.LoadLevel(7);
    }
    public void onClickP()
    {
        if (pause == false)
        {
        Time.timeScale = 0;
            pause = true;
        }
        else
        {
            Time.timeScale = 1;
            pause = false;
        }
    }
    public void OnClickPodt()
    {
        if (podtv == 1)
        {
            Application.LoadLevel(7);
            podtv = 0;

        }
        else if (podtv == 2)
        {
            Application.Quit();
            podtv = 0;
        }
    }
    public void OnClickOtr()
    {
            podtv = 0;
        butttons.SetActive(false);
    }
    public void OnClickTitres()
    {
        SceneManager.LoadScene("Test");
    }
}
