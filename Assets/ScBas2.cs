using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScBas2 : MonoBehaviour
{
    float maxValue;
    public Color color = Color.red;
    public int width;
    public Slider slider;
    public GameObject robot;
    public GameObject fail;
    public GameObject soldier;
    public GameObject builder;
    public UnityEngine.UI.Button button0;
    public UnityEngine.UI.Button button1;
    public UnityEngine.UI.Button button2;
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
    float zak3;
    float zakch1;
    float zakch2;
    float zakch3;
    public GameObject flag;
    float hod = 0;
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
        flag = Instantiate(flag, transform.position, Quaternion.identity);
        life = 1000;
        slider.fillRect.GetComponent<Image>().color = color;
        maxValue = life / 10;
        slider.maxValue = maxValue;
        slider.minValue = 0;         
        timel = Time.time + 35;
        h = 0;
        z = 0;
        time2 = Time.time;
        posit = transform.position;
        zak1 = -1;
        zak2 = -1;
        zak3 = -1;
        zakch1=-1;
        zakch2=-1;
        zakch3=-1;        
    }


    // Update is called once per frame
    void Update()
    {
        slider.value = life / 10;        
        selfB.onClick.AddListener(delegate
        {
            GameCon.trcanN(1);
            hod = 1;
       });
        if (Input.GetKeyDown(KeyCode.Tab) && hod == 1)
        {
            flag.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hod = 0;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            hod = 0;
        }
        button0.onClick.AddListener(delegate
        {
            if ((GameCon.resa() >= 3) && (zakch1 == -1))
            {
                GameCon.otA();
                GameCon.otA();
                GameCon.otA();
                zak1 = Time.time + 30;
                zakch1 = 1;
                button0.interactable = false;
            }
        });
        button1.onClick.AddListener(delegate
        {
            if ((GameCon.resa() >= 5) && (zakch2 == -1)) 
            {
                GameCon.otA();
                GameCon.otA();
                GameCon.otA();
                GameCon.otA();
                GameCon.otA();
                zak2 = Time.time + 30;
                zakch2 = 1;
                button1.interactable = false;
            }      
        });
        button2.onClick.AddListener(delegate
        {
            if ((GameCon.resa() >= 1)&&(zakch3==-1)) 
            {
                GameCon.otA();
                zak3 = Time.time + 15;
                zakch3 = 1;
                button2.interactable = false;
            }
            
        });
        if ((zak3 <= Time.time) && (zakch3 == 1))
        {
            zakch3 = -1;
            button2.interactable = true;
            Instantiate(builder, transform.position, Quaternion.identity);
        }
        if ((zak2 <= Time.time) && (zakch2 == 1))
        {
            zakch2 = -1;
            button1.interactable = true;
            Instantiate(soldier, transform.position, Quaternion.identity);
            Instantiate(soldier, transform.position, Quaternion.identity);
            Instantiate(soldier, transform.position, Quaternion.identity);
            Instantiate(soldier, transform.position, Quaternion.identity);
            Instantiate(soldier, transform.position, Quaternion.identity);
        }
        if ((zak1 <= Time.time) && (zakch1 == 1))
        {
            zakch1 = -1;
            button0.interactable = true;
            Instantiate(robot, transform.position, Quaternion.identity);
            Instantiate(robot, transform.position, Quaternion.identity);
            Instantiate(robot, transform.position, Quaternion.identity);
        }
        if (life <= 0)
        {
            fail.SetActive(true);
            Destroy(gameObject);
            Application.LoadLevel(7);
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
