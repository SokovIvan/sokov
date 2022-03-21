using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Башня : MonoBehaviour
{
    public GameObject Laserp;
    public GameObject Laser;
    float hod;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Laser.transform.position = Laserp.transform.position;
        float angle;
        hod = 0;
        GameObject[] goArray;
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        goArray = GameObject.FindGameObjectsWithTag("Allies");
        for (int i = 0; i < goArray.Length; i++)
        {
            if ((goArray[i].transform.position - transform.position).sqrMagnitude <= 1000)
            {
                hod = hod + 1;
                if (hod == 1)
                {
                   // angle = Mathf.Atan2(transform.position.y - goArray[i].transform.position.y, transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg-90;
                    //var targetRotationF = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    //Robot.velocity = new Vector3(0, 0, 0);
                    //Robot.angularVelocity = 0;
                    Laser.SetActive(true);

                }

            }
        }
        if (hod < 1)
        {
            Laser.SetActive(false);
        }
    }
}
