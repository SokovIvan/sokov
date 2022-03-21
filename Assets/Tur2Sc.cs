using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tur2Sc : MonoBehaviour
{
    public GameObject goL1;
    public GameObject goL2;
    public GameObject F;
    public GameObject Laser;
    float life;
    Vector3 posit;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        life = 200;
        posit = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = posit;
        if (life <= 0)
        {
            GameCon.turB();
            Instantiate(F, transform.position, Quaternion.Slerp(transform.rotation, transform.rotation, 1));
            Destroy(gameObject);
        }
        float angle;
        GameObject[] goArray;
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        goArray = GameObject.FindGameObjectsWithTag("Allies");
        for (int i = 0; i < goArray.Length; i++)
        {
            if ((goArray[i].transform.position - transform.position).sqrMagnitude <= 450)
            {
                GameObject cur;
                angle = Mathf.Atan2(goL1.transform.position.y - goArray[i].transform.position.y, goL1.transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg;
                var targetRotationL1 = Quaternion.Euler(new Vector3(0f, 0f, angle));
                goL1.transform.rotation = Quaternion.Slerp(goL1.transform.rotation, targetRotationL1, 1);
                angle = Mathf.Atan2(goL2.transform.position.y - goArray[i].transform.position.y, goL2.transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg;
                var targetRotationL2 = Quaternion.Euler(new Vector3(0f, 0f, angle));
                goL2.transform.rotation = Quaternion.Slerp(goL2.transform.rotation, targetRotationL2, 1);
                cur = Instantiate(Laser, goL1.transform.position, Quaternion.Slerp(goL1.transform.rotation, targetRotationL1, 1));
                cur.GetComponent<Rigidbody2D>().velocity = (new Vector3(goArray[i].transform.position.x, goArray[i].transform.position.y, 0) - cur.transform.position).normalized * 60;
                cur = Instantiate(Laser, goL2.transform.position, Quaternion.Slerp(goL2.transform.rotation, targetRotationL2, 1));
                cur.GetComponent<Rigidbody2D>().velocity = (new Vector3(goArray[i].transform.position.x, goArray[i].transform.position.y, 0) - cur.transform.position).normalized * 60;

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Snar")
        {
            life -= 25;
        }
        if (other.tag == "Explosion")
        {
            life -= 50;
            Destroy(other);
        }
    }
    
}