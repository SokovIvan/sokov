using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShoot : MonoBehaviour
{
    public GameObject rt;
    public GameObject r;
    private LineRenderer lr;
    public GameObject bulletPrefab;
    // Update is called once per frame
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float hod = 0;
        GameObject[] goArray; 
        goArray = GameObject.FindGameObjectsWithTag("Allies");
        for (int i = 0; i < goArray.Length; i++)
        {            
            if ((goArray[i].transform.position - transform.position).sqrMagnitude <= 1000)
            {
                hod++;
                shoot();
            } 
        }
            if(hod==0)
            {
                lr.enabled = false;
                lr.SetPosition(0, rt.transform.position);
                lr.SetPosition(1, rt.transform.position);
            }
    }
    private void shoot()
    {
        lr.enabled = true;
        Ray2D ray = new Ray2D(rt.transform.position, rt.transform.position - r.transform.position);        
        lr.SetPosition(0, rt.transform.position);
        RaycastHit2D hit = Physics2D.Raycast(rt.transform.position, rt.transform.position - r.transform.position);        
        if (hit.collider.tag == "Allies")
        {   
            lr.SetPosition(1, hit.collider.transform.position); 
            for (int i = 0; i < 25; i++)
            {
            Instantiate(bulletPrefab, hit.collider.transform.position, new Quaternion(0, 0, 0, 0));
            } 
        }
        else
        {
            lr.SetPosition(1, ray.GetPoint(25));
        }
        
    }
    private void shoot2()
    {
        lr.enabled = true;
        Ray ray = new Ray(transform.position, r.transform.forward);
        RaycastHit hit;
        lr.SetPosition(0, ray.origin);
        if (Physics.Raycast(ray, out hit, 100))
        {
            lr.SetPosition(1, hit.point);
            Instantiate(bulletPrefab, hit.point, new Quaternion(0, 0, 0, 0));
        }
        else
        {
            lr.SetPosition(1, ray.GetPoint(100));
        }
    }
}
