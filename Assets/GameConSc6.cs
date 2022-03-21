using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameConSc6 : MonoBehaviour
{
    public GameObject MesA;
    public Text labelM;
    public UnityEngine.UI.Text label;
    public UnityEngine.UI.Text label2;
    public UnityEngine.UI.Text label3;
    public UnityEngine.UI.Button button1;
    public UnityEngine.UI.Button button2;
    public UnityEngine.UI.Button button3;
    public GameObject tc1;
    public GameObject tc2;
    public GameObject tc3;
    public GameObject tc4;
    public GameObject techcentre;
    public GameObject sciencecentre;
    public GameObject gen;
    static int trcan;
    static int stratR;
    static int turr;
    static int Fact;
    static float resC;
    static float resA;
    static float BuildersR;
    static float Robots;
    static int Spiders;
    static int techb;
    static GameObject buidt;
    static int scienb;
    static int turAs;
    static int okohAs;
    static bool up1;
    static bool up2;
    static bool up3;
    static bool up4;
    static int urg;
    static int ure;
    static int electricity;
    float tttt;
    float timev = 0;
    // Start is called before the first frame update
    void Start()
    {
        BuildersR = 1;
        Robots = 0;
        Spiders = 0;
        Fact = 0;
        resC = 5;
        stratR = Random.Range(1, 3);
        resA = 5;
        if (Random.Range(1, 9) > 6)
        {
            stratR = 3;
        }
        turr = 2;
        trcan = 1;
        techb = 0;
        scienb = 0;
        turAs = 0;
        okohAs = 0;
        up1 = false;
        up2 = false;
        up3 = false;
        up4 = false;
        urg = 3;
        ure = 0;
        electricity = 0;
        tttt = 0;
        labelM.text = "Вам поручена важная миссия: необходимо прервать поставку нечто важного.Для этого необходимо заминировать центр приёма робопоездов.Подведите сапёров к зданию.Острегайтесь патрулей.";
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > 10&&timev==0)
        {
            MesA.SetActive(false);
        }
        if (turAs >= 20&&timev==0)
        {
            labelM.text = "Командир,возьмите это с собой.Поспешите скоро сюда прибудет целая армия роботов.";
            MesA.SetActive(true);
            timev=Time.timeSinceLevelLoad;
            Statistics stat = GameObject.Find("Stat").GetComponent<Statistics>();
            stat.t = 0;
        }
        if (Time.timeSinceLevelLoad - timev > 20 && timev > 0)
        {
SceneManager.LoadScene("Sc7");
        }
        
        if (turAs >= 3)
        {
            label3.gameObject.SetActive(true);
            label3.text = "\n" +
                "Бомба заложена!";
        }

            if (turAs <= -1)
        {
            SceneManager.LoadScene("ScSc");
        }
        electricity = urg - ure;
        button1.onClick.AddListener(delegate
        {
            if ((resA >= 10) && (techb == 0) && electricity >= 3)
            {
                resA -= 10;
                button1.interactable = false;
                techb = 1;
                GameObject cur;
                cur = Instantiate(techcentre, buidt.transform.position, Quaternion.identity);
                Destroy(techcentre);
                techcentre = cur;
            }
        });
        button2.onClick.AddListener(delegate
        {
            if ((resA >= 20) && (scienb == 0) && electricity >= 5)
            {
                resA -= 20;
                button2.interactable = false;
                scienb = 1;
                GameObject cur;
                cur = Instantiate(sciencecentre, buidt.transform.position, Quaternion.identity);
                Destroy(sciencecentre);
                sciencecentre = cur;
            }
        });
        button3.onClick.AddListener(delegate
        {
            if (resA >= 5)
            {
                tttt = Time.time + 2;
                resA -= 5;
                Instantiate(gen, buidt.transform.position, Quaternion.identity);
                button3.interactable = false;
            }

        });
        if (Time.time > tttt)
        {
            button3.interactable = true;
        }
        label.text = "Рес: " + resA;
        label2.text = "Эл: " + electricity;
        if (trcan == 1)
        {
            tc1.SetActive(true);
            tc2.SetActive(false);
            tc3.SetActive(false);
            tc4.SetActive(false);
        }
        if (trcan == 2)
        {
            tc1.SetActive(false);
            tc2.SetActive(true);
            tc3.SetActive(false);
            tc4.SetActive(false);
        }
        if (trcan == 3)
        {
            tc1.SetActive(false);
            tc2.SetActive(false);
            tc3.SetActive(true);
            tc4.SetActive(false);
        }
        if (trcan == 4)
        {
            tc1.SetActive(false);
            tc2.SetActive(false);
            tc3.SetActive(false);
            tc4.SetActive(true);
        }
    }
    public static void techcb()
    {
        techb = 0;
    }
    public static void sciencecb()
    {
        scienb = 0;
    }
    public static void urgN(int scn)
    {
        urg += scn;
    }
    public static void ureN(int scn)
    {
        ure += scn;
    }
    public static int urgY()
    {
        return urg;
    }
    public static int elY()
    {
        return electricity;
    }
    public static int ureY()
    {
        return ure;
    }
    public static void up1N()
    {
        up1 = true;
    }
    public static void up3N()
    {
        up3 = true;
    }
    public static void up4N()
    {
        up4 = true;
    }
    public static bool up1Y()
    {
        return up1;
    }
    public static bool up3Y()
    {
        return up3;
    }
    public static bool up4Y()
    {
        return up4;
    }
    public static void up2N()
    {
        up2 = true;
    }
    public static bool up2Y()
    {
        return up2;
    }
    public static void turAsN(int scn)
    {
        turAs += scn;
    }
    public static int turAsY()
    {
        return turAs;
    }
    public static void okohAsN(int scn)
    {
        okohAs += scn;
    }
    public static int okohAsY()
    {
        return okohAs;
    }
    public static void trcanN(int scn)
    {
        trcan = scn;
    }
    public static void techbN(GameObject ggb)
    {
        buidt = ggb;
    }
    public static void Ssplus()
    {
        Spiders = Spiders + 1;
    }
    public static void Ssminus()
    {
        Spiders = Spiders - 1;
    }
    public static int strar()
    {
        return stratR;
    }
    public static void turA()
    {
        turr = turr + 1;
    }
    public static void turB()
    {
        turr = turr - 1;
    }
    public static int tur()
    {
        return turr;
    }
    public static void FactP()
    {
        Fact = Fact + 1;
    }
    public static void FactM()
    {
        Fact = Fact - 1;
    }
    public static int Factt()
    {
        return Fact;
    }
    public static int spiders()
    {
        return Spiders;
    }
    public static void BsRplus()
    {
        BuildersR = BuildersR + 1;
    }
    public static void BsRminus()
    {
        BuildersR = BuildersR - 1;
    }
    public static void Rsplus()
    {
        Robots = Robots + 1;
    }
    public static void Rsminus()
    {
        Robots = Robots - 1;
    }
    public static void pr()
    {
        resC = resC + 1;
    }
    public static void ot()
    {
        resC = resC - 1;
    }
    public static float ress()
    {
        return resC;
    }
    public static float buils()
    {
        return BuildersR;
    }
    public static float robs()
    {
        return Robots;
    }
    public static void prA()
    {
        resA = resA + 1;
    }
    public static void otA()
    {
        resA = resA - 1;
    }
    public static float resa()
    {
        return resA;
    }
}