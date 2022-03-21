using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoldiersEnemy : MonoBehaviour
{
    public GameObject togo;
    float maxValue;
    public Color color = Color.red;
    public int width;
    public Slider slider;
    public GameObject goL1;
    public GameObject Laser;
    public GameObject F;
    float life;
    float px;
    float py;
    float hod;
    float firet;
    float zam;
    float u;
    float n;
    Vector3 startpos;
    // Start is called before the first frame update
    void UpdateUI()
    {
        RectTransform rect = slider.GetComponent<RectTransform>();
        int rectDeltaX = Screen.width / width;
        float rectPosX = 0;
        rectPosX = rect.position.x + (rectDeltaX - rect.sizeDelta.x) / 2;
        slider.direction = Slider.Direction.LeftToRight;
        rect.sizeDelta = new Vector2(rectDeltaX, rect.sizeDelta.y);
        rect.position = new Vector3(rectPosX, rect.position.y, rect.position.z);
    }
    void Start()
    {
        startpos.x = transform.position.x;
        startpos.y = transform.position.y;
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        life = 75;
        slider.fillRect.GetComponent<Image>().color = color;
        maxValue = life / 100;
        slider.maxValue = maxValue;
        slider.minValue = 0;
        UpdateUI();
        px = togo.transform.position.x;
        py = togo.transform.position.y;
        hod = 0;
        firet = 0;
        zam = 0;
        u = 1;
        n = 1;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = life / 50;
        if((transform.position- togo.transform.position).sqrMagnitude < 10)
        {
            px = startpos.x;
            py = startpos.y;
        }
        else if ((transform.position - startpos).sqrMagnitude < 10)
        {
            px = togo.transform.position.x;
            py = togo.transform.position.y;            
        }
        if (life <= 0)
        {
            Instantiate(F, transform.position, Quaternion.Slerp(transform.rotation, transform.rotation, 1));
            Destroy(gameObject);
        }
        float angle;
        hod = 0;
        GameObject[] goArray;
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        goArray = GameObject.FindGameObjectsWithTag("Allies");
        for (int i = 0; i < goArray.Length; i++)
        {
            if ((goArray[i].transform.position - transform.position).sqrMagnitude <= 500)
            {
                GameObject cur;
                hod = hod + 1;
                if ((hod == 1) && (Time.time - firet > 0.5))
                {
                    firet = Time.time;
                    angle = Mathf.Atan2(transform.position.y - goArray[i].transform.position.y, transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg;
                    var targetRotationF = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationF, 1);
                    angle = Mathf.Atan2(goL1.transform.position.y - goArray[i].transform.position.y, goL1.transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg;
                    var targetRotationL1 = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    goL1.transform.rotation = Quaternion.Slerp(goL1.transform.rotation, targetRotationL1, 1);
                    cur = Instantiate(Laser, goL1.transform.position, Quaternion.Slerp(goL1.transform.rotation, targetRotationL1, 1));
                    cur.GetComponent<Rigidbody2D>().velocity = (new Vector3(goArray[i].transform.position.x, goArray[i].transform.position.y, 0) - cur.transform.position).normalized * 30;
                    Robot.velocity = new Vector3(0, 0, 0);
                }

            }
        }
        if (hod < 1)
        {
            if ((transform.position - new Vector3(px, py, 0)).sqrMagnitude >= 1)
            {
                angle = Mathf.Atan2(transform.position.y - py, transform.position.x - px) * Mathf.Rad2Deg;
                var targetRotationS = Quaternion.Euler(new Vector3(0f, 0f, angle));
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationS, 1);
            }
            if (zam < Time.time)
            {
                if ((transform.position - new Vector3(px, py, 0)).sqrMagnitude >= 1)
                {
                    Robot.velocity = (new Vector3(px, py, 0) - transform.position).normalized * 10;
                }
                else
                {
                    Robot.velocity = new Vector3(0, 0, 0);
                }
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Snar")
        {
            life -= 25;
        }
        // if (other.tag == "Allies")
        // {
        //     float x = transform.position.x + Random.Range(-2, 2);
        //     float y = transform.position.y + +Random.Range(-2, 2);
        //    transform.position = new Vector3(x, y, 0);
        //}
        if (other.tag == "River")
        {
            float x = transform.position.x;
            float y = transform.position.y + 1;
            transform.position = new Vector3(x, y, 0);
        }
        if (other.tag == "Bag")
        {
            zam = Time.time + 2;
            GetComponent<Rigidbody2D>().velocity = (new Vector3(px, py, 0) - transform.position).normalized * 10;
        }

    }
}