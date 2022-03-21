using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GenSc : MonoBehaviour
{
    public Animator animator;
    public Slider slider;
    public GameObject Vzriv;
    float life;
    float td;
    float dx;
    // Start is called before the first frame update
    void Start()
    {
        dx = 0;
        life = 500;
        slider.maxValue = 500;
        GameCon.urgN(1);
        td = -1;
    }

    // Update is called once per frame
    void Update()
    {        
        slider.value = life;
        if ((life <= 0)&&(dx==0))
        {
            animator.SetBool("New Bool", true);
            GameCon.urgN(-1);
            td = Time.time + 1;
            dx = 1;
        }
        if ((td-Time.time<0.1)&&(dx==1))
        {
            Instantiate(Vzriv, new Vector3(transform.position.x+Random.Range(-3,3), transform.position.y + Random.Range(-3, 3), transform.position.z), Quaternion.identity);
            Instantiate(Vzriv, new Vector3(transform.position.x + Random.Range(-3, 3), transform.position.y + Random.Range(-3, 3), transform.position.z), Quaternion.identity);
            Instantiate(Vzriv, new Vector3(transform.position.x + Random.Range(-3, 3), transform.position.y + Random.Range(-3, 3), transform.position.z), Quaternion.identity);
            Instantiate(Vzriv, new Vector3(transform.position.x + Random.Range(-3, 3), transform.position.y + Random.Range(-3, 3), transform.position.z), Quaternion.identity);
            Instantiate(Vzriv, new Vector3(transform.position.x + Random.Range(-3, 3), transform.position.y + Random.Range(-3, 3), transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            life -= 1;
        }
        if (collision.tag == "Robots")
        {
            life = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            life -= 1;
        }
        if (collision.tag == "Robots")
        {
            life -= 1;
        }
    }
}