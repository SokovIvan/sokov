using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameConSc7 : MonoBehaviour
{
    public GameObject message;
    public Text text;
    bool n;
    float timev=0;
    // Start is called before the first frame update
    void Start()
    {
        n = false;
        text.text = "Командующий!Необходимо доставить это энергоядро для изучения.Но машины перегородили дорогу своей заставой.Как можно скорее освободите проведите инжинера до базы.";
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > 25 && n == false)
        {
            text.text = "Рекомндуем построить танки Армагеддон перед аттакой на позиции машин.";
        }
        if (Time.timeSinceLevelLoad > 35&&n==false)
        {
            message.SetActive(false);
        }
        if (n&&timev==0)
        {
            message.SetActive(true);
            text.text = "Поздравляю!Мы займёмся исследования ядра для того,чтобы узнать ,что же замышляли машины.";
            timev = Time.timeSinceLevelLoad;
            Statistics stat = GameObject.Find("Stat").GetComponent<Statistics>();
            stat.t = 0;

        }
        if (Time.timeSinceLevelLoad - timev > 20 && timev > 0)
        {
            SceneManager.LoadScene("Sc8"); 
        }            
        GameObject[] a=GameObject.FindGameObjectsWithTag("River");
        if (a.Length==0)
        {
            SceneManager.LoadScene("ScSc");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag=="River")
        {
            n = true;
        }
    }
}
