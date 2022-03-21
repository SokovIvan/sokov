using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Statistics : MonoBehaviour
{
    public float t = 0;
    float enemies;
    float allies;
    float score1;
    float score2;
    public string message;
    float score;
    public GameObject pan;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        score1 = 0;
        score2 = 0;
        t = -1;        
        StartCoroutine(Example2());
        pan.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.anyKeyDown && t == 0)
        {
            pan.SetActive(true);
            Time.timeScale = 0;
            t = 1;
            message += "Статистика:|||";
            message += "Уничтожено: " + score1 + "||";
            message += "Потеряно: " + score2 + "||";
            message += "Счёт: " + score + "||";
            StartCoroutine(Example());
        }
        else if (Input.anyKeyDown && t == 1)
        {
            t = 0;
            Time.timeScale = 1;
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

    }
    IEnumerator Example()
    {
        if (t == 1)
        {
            transform.Find("Panel/Text").GetComponent<Text>().text = "";
            foreach (char i in message)
            {
                yield return new WaitForSecondsRealtime(1 / 2);
                transform.Find("Panel/Text").GetComponent<Text>().alignment = TextAnchor.UpperLeft;
                transform.Find("Panel/Text").GetComponent<Text>().fontSize = 40;
                transform.Find("Panel/Text").GetComponent<Text>().resizeTextForBestFit = false;
                if (i == '|')
                {
                    transform.Find("Panel/Text").GetComponent<Text>().text += "\n";
                }
                else
                {
                    transform.Find("Panel/Text").GetComponent<Text>().text += i;
                }
            }
        }

    }
    IEnumerator Example2()
    {
        while (t==-1)
        {
            GameObject[] goArray;
            goArray = GameObject.FindGameObjectsWithTag("Allies");
            allies = goArray.Length;
            goArray = GameObject.FindGameObjectsWithTag("Robots");
            enemies = goArray.Length;
            yield return new WaitForSecondsRealtime(1/4);
            if(GameObject.FindGameObjectsWithTag("Robots").Length - enemies < 0)
            {
                score += (GameObject.FindGameObjectsWithTag("Robots").Length - enemies) * (1+1/3)*1000;
                score1 +=  enemies-GameObject.FindGameObjectsWithTag("Robots").Length ;
            }
            if (GameObject.FindGameObjectsWithTag("Allies").Length - allies < 0)
            {
                score -= (GameObject.FindGameObjectsWithTag("Allies").Length - enemies) * (1 - 1 / 3)*500;
                score2 += allies -GameObject.FindGameObjectsWithTag("Allies").Length ;
            }
            score += 100; 
        }

    }

}
