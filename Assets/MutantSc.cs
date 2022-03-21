using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantSc : MonoBehaviour
{
    public GameObject Laser;
    public GameObject F;
    public Animator anim;
    float life;
    float px;
    float py;
    float hod;
    float zam;
    public AudioSource attack;
    public AudioSource roar;    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        life = 100;
        px = transform.position.x + Random.Range(0,3);
        py = transform.position.y + Random.Range(0, 3);
        hod = 0;
        zam = 0;
        GameCon.Rsplus();
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            GameCon.Rsminus();
            Instantiate(F, transform.position, Quaternion.Slerp(transform.rotation, transform.rotation, 1));
            Destroy(gameObject);
        }
        float angle;
        
        GameObject[] goArray;
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        hod = 0;
        goArray = GameObject.FindGameObjectsWithTag("Allies");
        for (int i = 0; i < goArray.Length; i++)
        {
            if ((goArray[i].transform.position - transform.position).sqrMagnitude <= 900)
            {
                angle = Mathf.Atan2(transform.position.y - goArray[i].transform.position.y, transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg;
                var targetRotationF = Quaternion.Euler(new Vector3(0f, 0f, angle));
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationF, 1);
                hod = hod + 1;
                if (hod == 1)
                {
                    if (roar.isPlaying == false)
                    {
                    roar.Play();
                    }
                    
                    anim.SetBool("Go", true);
                    px = goArray[i].transform.position.x;
                    py = goArray[i].transform.position.y;
                }
            }
        }
        hod = 0;
        goArray = GameObject.FindGameObjectsWithTag("Allies");
        for (int i = 0; i < goArray.Length; i++)
        {
            if ((goArray[i].transform.position - transform.position).sqrMagnitude <= 10)
            {                
                hod = hod + 1;
                if (hod == 1)
                {
                    attack.Play();
                    anim.SetBool("Attack", true);
                    anim.SetBool("Go", false);
                    angle = Mathf.Atan2(transform.position.y - goArray[i].transform.position.y, transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg;
                    var targetRotationF = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationF, 1);
                    Robot.velocity = new Vector3(0, 0, 0);
                }
            }
        }


        if (hod < 1)
        {
            angle = Mathf.Atan2(transform.position.y - py, transform.position.x - px) * Mathf.Rad2Deg;
            var targetRotationS = Quaternion.Euler(new Vector3(0f, 0f, angle));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationS, 1);
            if (zam < Time.time)
            {
                Robot.velocity = (new Vector3(px, py, 0) - transform.position).normalized * 25;
            }

        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Snar")
        {
            life -= 25;
        }
        if (other.tag == "Bag")
        {
            zam = Time.time + 2;
            GetComponent<Rigidbody2D>().velocity = (new Vector3(px, py, 0) - transform.position).normalized * 5;
        }
        if (other.tag == "Explosion")
        {
            life -= 75;
            Destroy(other);
        }

    }

}
