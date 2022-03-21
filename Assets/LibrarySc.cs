using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LibrarySc : MonoBehaviour
{
    public int i;
    public GameObject libSold;
    public GameObject libBuild;
    public GameObject libRSold;
    public GameObject libBuggy;
    public GameObject libArm;
    public GameObject libInc;
    public GameObject libSalvo;
    public GameObject libEmpty;
    public GameObject abst;
    public Button libSoldB;
    public Button libBuildB;
    public Button libRSoldB;
    public Button libBuggyB;
    public Button libArmB;
    public Button libIncB;
    public Button libSalvoB;
    public Button Menu;
    static float otk;
    // Start is called before the first frame update
    void Start()
    {
        otk = PlayerPrefs.GetInt("LibC");
    }

    // Update is called once per frame
    void  Update()
    {
        Menu.onClick.AddListener(delegate
        {
            SceneManager.LoadScene("ScSr");
        });
        libSoldB.onClick.AddListener(delegate
        {
            abst.SetActive(true);
            if (otk>= 1)
            {
                
                libSold.SetActive(true);
                libBuild.SetActive(false);
                libRSold.SetActive(false);
                libBuggy.SetActive(false);
                libArm.SetActive(false);
                libInc.SetActive(false);
                libSalvo.SetActive(false);
                libEmpty.SetActive(false);
            }
            else
            {
                libSold.SetActive(false);
                libBuild.SetActive(false);
                libRSold.SetActive(false);
                libBuggy.SetActive(false);
                libArm.SetActive(false);
                libInc.SetActive(false);
                libSalvo.SetActive(false);
                libEmpty.SetActive(true);
            }
        });
        libBuggyB.onClick.AddListener(delegate
        {
            abst.SetActive(true);
            if (otk >= 2)
            {
                libSold.SetActive(false);
                libBuild.SetActive(false);
                libRSold.SetActive(false);
                libBuggy.SetActive(true);
                libArm.SetActive(false);
                libInc.SetActive(false);
                libSalvo.SetActive(false);
                libEmpty.SetActive(false);
            }
            else
            {
                libSold.SetActive(false);
                libBuild.SetActive(false);
                libRSold.SetActive(false);
                libBuggy.SetActive(false);
                libArm.SetActive(false);
                libInc.SetActive(false);
                libSalvo.SetActive(false);
                libEmpty.SetActive(true);
            }
        });
        libBuildB.onClick.AddListener(delegate
        {
            abst.SetActive(true);
            if (otk >= 5)
            {
                libSold.SetActive(false);
                libBuild.SetActive(true);
                libRSold.SetActive(false);
                libBuggy.SetActive(false);
                libArm.SetActive(false);
                libInc.SetActive(false);
                libSalvo.SetActive(false);
                libEmpty.SetActive(false);
            }
            else
            {
                libSold.SetActive(false);
                libBuild.SetActive(false);
                libRSold.SetActive(false);
                libBuggy.SetActive(false);
                libArm.SetActive(false);
                libInc.SetActive(false);
                libSalvo.SetActive(false);
                libEmpty.SetActive(true);
            }
        });
        libArmB.onClick.AddListener(delegate
        {
            abst.SetActive(true);
            if (otk >= 5)
            {
                libSold.SetActive(false);
                libBuild.SetActive(false);
                libRSold.SetActive(false);
                libBuggy.SetActive(false);
                libArm.SetActive(true);
                libInc.SetActive(false);
                libSalvo.SetActive(false);
                libEmpty.SetActive(false);
            }
            else
            {
                libSold.SetActive(false);
                libBuild.SetActive(false);
                libRSold.SetActive(false);
                libBuggy.SetActive(false);
                libArm.SetActive(false);
                libInc.SetActive(false);
                libSalvo.SetActive(false);
                libEmpty.SetActive(true);
            }
        });
        libRSoldB.onClick.AddListener(delegate
        {
            abst.SetActive(true);
            if (otk >= 5)
            {
                libSold.SetActive(false);
                libBuild.SetActive(false);
                libRSold.SetActive(true);
                libBuggy.SetActive(false);
                libArm.SetActive(false);
                libInc.SetActive(false);
                libSalvo.SetActive(false);
                libEmpty.SetActive(false);
            }
            else
            {
                libSold.SetActive(false);
                libBuild.SetActive(false);
                libRSold.SetActive(false);
                libBuggy.SetActive(false);
                libArm.SetActive(false);
                libInc.SetActive(false);
                libSalvo.SetActive(false);
                libEmpty.SetActive(true);
            }
        });
        libIncB.onClick.AddListener(delegate
        {
            abst.SetActive(true);
            if (otk >= 8)
            {
                libSold.SetActive(false);
                libBuild.SetActive(false);
                libRSold.SetActive(false);
                libBuggy.SetActive(false);
                libArm.SetActive(false);
                libInc.SetActive(true);
                libSalvo.SetActive(false);
                libEmpty.SetActive(false);
            }
            else
            {
                libSold.SetActive(false);
                libBuild.SetActive(false);
                libRSold.SetActive(false);
                libBuggy.SetActive(false);
                libArm.SetActive(false);
                libInc.SetActive(false);
                libSalvo.SetActive(false);
                libEmpty.SetActive(true);
            }
        });
        libSalvoB.onClick.AddListener(delegate
        {
            abst.SetActive(true);
            if (otk >= 8)
            {
                libSold.SetActive(false);
                libBuild.SetActive(false);
                libRSold.SetActive(false);
                libBuggy.SetActive(false);
                libArm.SetActive(false);
                libInc.SetActive(false);
                libSalvo.SetActive(true);
                libEmpty.SetActive(false);
            }
            else
            {
                libSold.SetActive(false);
                libBuild.SetActive(false);
                libRSold.SetActive(false);
                libBuggy.SetActive(false);
                libArm.SetActive(false);
                libInc.SetActive(false);
                libSalvo.SetActive(false);
                libEmpty.SetActive(true);
            }
        });
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            abst.SetActive(false);
            libSold.SetActive(false);
            libBuild.SetActive(false);
            libRSold.SetActive(false);
            libBuggy.SetActive(false);
            libArm.SetActive(false);
            libInc.SetActive(false);
            libSalvo.SetActive(false);
            libEmpty.SetActive(false);
        }
    }
    public static void otkN(float plus)
    {
        otk += plus;
    }
}
