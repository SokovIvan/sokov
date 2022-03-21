using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScBase1 : MonoBehaviour
{
    public GameObject robot;
    public GameObject soldier;
    public GameObject allie;
    public UnityEngine.UI.Button button0;
    public UnityEngine.UI.Button button1;
    float timel;
    float life;
    float h;
    float tim;
    float z;
    float time2;
    Vector3 posit;
    public GameObject flag;
    float hod = 0;
    // Start is called before the first frame update
    void Start()
    {
        flag = Instantiate(flag, transform.position, Quaternion.identity);
        life = 1000;
        timel = 0;
        h = 0;
        allie.SetActive(false);
        z = 0;
        timel = Time.time+15;
        time2 = Time.time;
        posit = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        
        transform.position = posit;
        hod = 1;
        if (Input.GetKeyDown(KeyCode.Tab) && hod == 1)
        {
            flag.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hod = 0;
        }
        else if (Input.anyKeyDown)
        {
            hod = 0;
        }
        button0.onClick.AddListener(delegate
        {
            z = 0;
        });
        button1.onClick.AddListener(delegate
        {
            z = 1;
        });
        if (life == 999)
        {
            tim = Time.time;
            allie.SetActive(true);
        }
        if ((Time.time - time2) - tim > 10) 
        {
            allie.SetActive(false);
        }
        if (life<=0)
        {
            Destroy(gameObject);
            Application.LoadLevel(2);            
        }
        GameObject[] a = GameObject.FindGameObjectsWithTag("Allies");
        if ((timel <= Time.time)&&(a.Length<53))
        {
            timel = Time.time+15;
            if (z==0)
            {
                Instantiate(robot, transform.position, Quaternion.identity);
                Instantiate(robot, transform.position, Quaternion.identity);
                Instantiate(robot, transform.position, Quaternion.identity);
            }
            if (z == 1)
            {
            Instantiate(soldier, transform.position, Quaternion.identity);
            Instantiate(soldier, transform.position, Quaternion.identity);
            Instantiate(soldier, transform.position, Quaternion.identity);
            Instantiate(soldier, transform.position, Quaternion.identity);
            Instantiate(soldier, transform.position, Quaternion.identity);
            }
            
            if (((Time.time - time2) > 200) && (z == 0))
            {
                Instantiate(robot, transform.position, Quaternion.identity);
                Instantiate(robot, transform.position, Quaternion.identity);
            }
            if (((Time.time - time2) > 500) && (z == 0))
            {
                Instantiate(robot, transform.position, Quaternion.identity);
                Instantiate(robot, transform.position, Quaternion.identity);
            }
            if (((Time.time - time2) > 300) && (z == 1))
            {
                Instantiate(soldier, transform.position, Quaternion.identity);
                Instantiate(soldier, transform.position, Quaternion.identity);
                Instantiate(soldier, transform.position, Quaternion.identity);
            }
            if (((Time.time - time2) > 500) && (z == 1))
            {
                Instantiate(soldier, transform.position, Quaternion.identity);
                Instantiate(soldier, transform.position, Quaternion.identity);
                Instantiate(soldier, transform.position, Quaternion.identity);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
    ScB2.AdjustCurrentValue(-1);
            life -= 1;
        }
    }
}
