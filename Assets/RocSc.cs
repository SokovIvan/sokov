using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocSc : MonoBehaviour
{
    public GameObject exp;
    GameObject target;
    float time2;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        time2 = Time.time + 10;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);   
    }

    // Update is called once per frame
    void Update()
    {
        float hod = 0;
        GameObject[] goArray;
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        goArray = GameObject.FindGameObjectsWithTag("Allies");
        for (int i = 0; i < goArray.Length; i++)
        {
            if ((goArray[i].transform.position - transform.position).sqrMagnitude <= 4200)
            {

                hod = hod + 1;
                if (hod == 1)
                {
                    target = goArray[i];
                    angle = Mathf.Atan2(transform.position.y - target.transform.position.y, transform.position.x - target.transform.position.x) * Mathf.Rad2Deg;
                  var targetRotationS = Quaternion.Euler(new Vector3(0f, 0f, angle));
                  transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationS, 1);                     
                      Robot.velocity = (target.transform.position - transform.position).normalized * 25;     
                }

            }
        }

        if (time2 <= Time.time)
        {
            //Instantiate(exp, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Allies")
        {
        Instantiate(exp,transform.position,transform.rotation);
        Destroy(gameObject);
        }

    }
}
