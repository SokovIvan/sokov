using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameConSc9 : MonoBehaviour
{
    public GameObject wall;
    public GameObject light;
    public GameObject mess;    
    public Text lab;
    public GameObject rob;
    public GameObject spZ;
    public GameObject tile1;
    public GameObject tile2;
    public GameObject mutant;
    public GameObject mutb;
    float time;
    float n = 0;
    public GameObject[] turrets;
    // Start is called before the first frame update
    void Start()
    {
        lab.text = "Вы должны преодолеть оборону комплекса и раньше машин добраться в сердце комплекса.Но доступ туда закрыт.Перезагрузите систему в реакторной комнате.";   
    }

    // Update is called once per frame
    void Update()
    {
        if((Time.timeSinceLevelLoad >=15)&&(n==0))
        {
            mess.SetActive(false);
            n = 1;

        }
        if ((Time.time-time >= 10) && (n == 2))
        {
            mess.SetActive(false);
            n = 3;

        }
        GameObject[] ar = GameObject.FindGameObjectsWithTag("Allies");
        if (ar.Length == 0)
        {
            SceneManager.LoadScene("ScSc");
        }
        if (Time.timeSinceLevelLoad == 120)
        {
            Instantiate(rob,spZ.transform.position,Quaternion.identity);
            Instantiate(rob, spZ.transform.position, Quaternion.identity);
            Instantiate(rob, spZ.transform.position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Allies")
        {
            mess.SetActive(true);
            lab.text = "Доступ открыт,система выключена.Поспешите!";
            if (n==1)
            {
                n = 2;
            Instantiate(mutant, mutb.transform.position, Quaternion.identity);
            Instantiate(mutant, mutb.transform.position, Quaternion.identity);
            Instantiate(mutant, mutb.transform.position, Quaternion.identity);
            Instantiate(mutant, mutb.transform.position, Quaternion.identity);
            Instantiate(mutant, mutb.transform.position, Quaternion.identity);
            Instantiate(mutant, mutb.transform.position, Quaternion.identity);
            Instantiate(mutant, mutb.transform.position, Quaternion.identity);
            time = Time.time;
            }
            foreach(GameObject t in turrets)
            {
                try{
                t.GetComponent<TurNeutr2>().enabled = false;
                    Destroy(t);
                }
                catch
                {

                }
            }
            tile1.SetActive(false);
            tile2.SetActive(true);
            light.SetActive(false);
            wall.SetActive(false);
        }
    }
}
