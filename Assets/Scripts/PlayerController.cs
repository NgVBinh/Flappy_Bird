using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float hoverDistance, hoverSpeed,force;
    [SerializeField] private TMP_Text textPoint, textPointEnd, textBestPonit;
    [SerializeField] private float tiltSmooth;

    private Quaternion downRotation, upRotation;

    private Rigidbody2D rb;
    private float y;
    private int point;


    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        downRotation= Quaternion.Euler(0,0,-90);
        upRotation= Quaternion.Euler(0,0,35);
    }
    private void Update()
    {
        if (!GameManager.Instance.start && !GameManager.Instance.die)
        {
            y = hoverDistance*Mathf.Sin(Time.time* hoverSpeed);
            transform.position= new Vector3(transform.position.x,y,0);
        }else if (GameManager.Instance.start && !GameManager.Instance.die)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth*Time.deltaTime);
            transform.rotation = new Quaternion(transform.rotation.x,transform.rotation.y,Mathf.Clamp(transform.rotation.z,downRotation.z,upRotation.z),transform.rotation.w);
        }

        if (Input.GetMouseButtonDown(0) && !GameManager.Instance.die)
        {
            if (!GameManager.Instance.start)
            {
                GameManager.Instance.start = true;
                GameManager.Instance.ready = true;
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.AddForce(Vector3.up * force, ForceMode2D.Impulse);
            }
            else
            {
                SoundsManager.Instance.PlaySound("click");
                rb.velocity = Vector3.zero;
                rb.AddForce(Vector3.up * force, ForceMode2D.Impulse);
                transform.rotation = upRotation;
                //transform.rotation = Quaternion.Lerp(transform.rotation, upRotation, angle * Time.deltaTime);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if(!GameManager.Instance.die)
            SoundsManager.Instance.PlaySound("die");
            GameManager.Instance.die = true;
            GameManager.Instance.start = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Point"))
        {
            SoundsManager.Instance.PlaySound("point");
            point++;
            textPoint.text = point.ToString();
            textPointEnd.text = point.ToString();

            if (point > PlayerPrefs.GetInt("bestPoint"))
            {
                PlayerPrefs.SetInt("bestPoint", point);
            }
            textBestPonit.text = PlayerPrefs.GetInt("bestPoint").ToString();
        }
    }
}
