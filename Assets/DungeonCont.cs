using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DungeonCont : MonoBehaviour
{
    public GameObject vic;
    public GameObject canvas;
    public GameObject g;
    public GameObject sold;
    public UnityEngine.UI.Text label;
    float time2;
    float n;
    float time3;
    // Start is called before the first frame update
    void Start()
    {        
        n = 0;
        time2 = Time.time;
        label.text = "Командующий!Мы получили снимок с одного из оставшихся спутников.На данном объекте остались секретные военные разработки.";
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - time2 > 10)
        {
            label.text = "Это место не затронуло война.Но эта независимая группировка людей может передать технологии как нам,так и роботам.";
        }
        if (Time.time - time2 > 20)
        {
            label.text = "Мы ДОЛЖНЫ захватить эту лабораторию.Зачистите территорию от противника!";
        }
        if (Time.time - time2 > 30)
        {
            canvas.SetActive(false);
        }        
        GameObject[] arr;
        arr= GameObject.FindGameObjectsWithTag("Robots");
        if ((arr.Length == 1) && (n == 0))
        {
            n = 1;
            Instantiate(sold, g.transform.position, Quaternion.identity);
            Instantiate(sold, g.transform.position, Quaternion.identity);
            Instantiate(sold, g.transform.position, Quaternion.identity);
            Instantiate(sold, g.transform.position, Quaternion.identity);
            Instantiate(sold, g.transform.position, Quaternion.identity);
        }
        arr = GameObject.FindGameObjectsWithTag("Robots");
        if ((arr.Length == 1)&&(n==1))
        {
            vic.SetActive(true);
            time3 = Time.time + 5;
            Statistics stat = GameObject.Find("Stat").GetComponent<Statistics>();
            stat.t = 0;
            n = 2;            
        }
        if (n == 2)
        {
            if (time3 <= Time.time)
            {
                SceneManager.LoadScene("Sc5");
            }
        }
        arr = GameObject.FindGameObjectsWithTag("Allies");
        if (arr.Length == 0)
        {            
            Application.LoadLevel(2);
        }
    }
}
