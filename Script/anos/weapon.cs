using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform barrelTip;

    public GameObject bullet;

    private Vector2 lookDirection;
    private float lookAngle, timebtwshots;
    public float offset, starttimebtwshots;
    private Quaternion Cona;
    public Animator camanim;
    public bool nerfOn;
    public GameObject nerf;
    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz+ offset);

        if (timebtwshots<=0)
        {
            if (Input.GetMouseButton(0) && nerfOn == true)
            {
                StartCoroutine(FireBullet());
                timebtwshots = starttimebtwshots;
                camanim.SetTrigger("shake");
            }
        }
        else
        {
            timebtwshots -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            nerfOn = true;
            nerf.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            nerfOn = false;
            nerf.SetActive(false);
        }
    }

    private IEnumerator FireBullet() 
    {
        GameObject firedBullet = Instantiate(bullet, barrelTip.position, transform.rotation);
        firedBullet.transform.Rotate(0f, 0f, offset);
        firedBullet.GetComponent<Rigidbody2D>().velocity = barrelTip.up * 50f ;
        yield return new WaitForSeconds(1.5f);
        Destroy(firedBullet);

    }
    
}
