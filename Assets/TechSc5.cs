using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TechSc5 : MonoBehaviour
{
    float maxValue;
    public Color color = Color.red;
    public int width;
    public Slider slider;
    public GameObject robot;
    public GameObject soldier;
    public UnityEngine.UI.Button button0;
    public UnityEngine.UI.Button button1;
    public UnityEngine.UI.Button button2;
    public UnityEngine.UI.Button button3;
    public UnityEngine.UI.Button selfB;
    float timel;
    float life;
    float h;
    float tim;
    float z;
    float time2;
    Vector3 posit;
    float zak1;
    float zak2;
    float zakch3;
    float zakch1;
    float zakch2;
    void UpdateUI()
    {
        RectTransform rect = slider.GetComponent<RectTransform>();
        int rectDeltaX = Screen.width / width;
        float rectPosX = 0;
        rectPosX = rect.position.x + (rectDeltaX - rect.sizeDelta.x) / 2;
        slider.direction = Slider.Direction.LeftToRight;
        rect.sizeDelta = new Vector2(rectDeltaX, rect.sizeDelta.y);
        rect.position = new Vector3(rectPosX, rect.position.y, rect.position.z);
    }
    // Start is called before the first frame update
    void Start()
    {
        life = 1000;
        slider.fillRect.GetComponent<Image>().color = color;
        maxValue = life / 1000;
        slider.maxValue = maxValue;
        slider.minValue = 0;
        timel = Time.time + 35;
        h = 0;
        z = 0;
        time2 = Time.time;
        posit = transform.position;
        zak1 = -1;
        zak2 = -1;
        zakch1 = -1;
        zakch2 = -1;
        zakch3 = -1;
        GameConSc5.ureN(3);
    }


    // Update is called once per frame
    void Update()
    {
        slider.value = life / 1000;
        selfB.onClick.AddListener(delegate
        {
            GameConSc5.trcanN(2);
        });
        button0.onClick.AddListener(delegate
        {
            if ((GameConSc5.resa() >= 5) && (zakch1 == -1))
            {
                GameConSc5.otA();
                GameConSc5.otA();
                GameConSc5.otA();
                GameConSc5.otA();
                GameConSc5.otA();
                zak1 = Time.time + 60;
                zakch1 = 1;
                button0.interactable = false;
            }
        });
        button1.onClick.AddListener(delegate
        {
            if ((GameConSc5.resa() >= 5) && (zakch2 == -1))
            {
                GameConSc5.otA();
                GameConSc5.otA();
                GameConSc5.otA();
                GameConSc5.otA();
                GameConSc5.otA();
                zak2 = Time.time + 30;
                zakch2 = 1;
                button1.interactable = false;
            }
        });
        button2.onClick.AddListener(delegate
        {
            if ((GameConSc5.resa() >= 5) && (zakch3 == -1))
            {
                GameConSc5.up1N();
                zakch3 = 1;
                GameConSc5.otA();
                GameConSc5.otA();
                GameConSc5.otA();
                GameConSc5.otA();
                GameConSc5.otA();
                button2.interactable = false;
                button3.interactable = false;
            }

        });
        button3.onClick.AddListener(delegate
        {
            if ((GameConSc5.resa() >= 5) && (zakch3 == -1))
            {
                GameConSc5.up2N();
                zakch3 = 1;
                GameConSc5.otA();
                GameConSc5.otA();
                GameConSc5.otA();
                GameConSc5.otA();
                GameConSc5.otA();
                button2.interactable = false;
                button3.interactable = false;
            }

        });
        if ((zak2 <= Time.time) && (zakch2 == 1))
        {
            zakch2 = -1;
            button1.interactable = true;
            Instantiate(soldier, transform.position, Quaternion.identity);
            Instantiate(soldier, transform.position, Quaternion.identity);
            Instantiate(soldier, transform.position, Quaternion.identity);
        }
        if ((zak1 <= Time.time) && (zakch1 == 1))
        {
            zakch1 = -1;
            button0.interactable = true;
            Instantiate(robot, transform.position, Quaternion.identity);
        }
        if (life <= 0)
        {
            GameConSc5.techcb();
            GameConSc5.ureN(-3);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            life -= 1;
        }
        if (other.tag == "Explosion")
        {
            life -= 25;
            Destroy(other);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            life -= 1;
        }
    }
}