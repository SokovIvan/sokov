using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBSc : MonoBehaviour
{
    public GameObject Laser;
    public GameObject Kor;
    public GameObject KorJ;
    float hod;    
    Quaternion stangle;
    // Start is called before the first frame update
    void Start()
    {        
        hod = 0;             
        stangle = transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        //transform.position = KorJ.transform.position;
        float angle;
        hod = 0;
        GameObject[] goArray;
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        goArray = GameObject.FindGameObjectsWithTag("Allies");
        for (int i = 0; i < goArray.Length; i++)
        {
            if ((goArray[i].transform.position - transform.position).sqrMagnitude <= 500)
            {                
                hod = hod + 1;
                if (hod == 1)
                {
                    angle = Mathf.Atan2(transform.position.y - goArray[i].transform.position.y, transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg;
                    var targetRotationF = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationF, 1);
                    Laser.SetActive(true);
                    //Robot.velocity = new Vector3(0, 0, 0);
                    //Robot.angularVelocity = 0;
                }

            }
        }
        if (hod < 1)
        {
            Laser.SetActive(false);
            transform.rotation = Kor.transform.rotation;
        }
    }
}

