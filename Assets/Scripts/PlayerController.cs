using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float hoverDistance, hoverSpeed,force;

    private bool isStart;
    private float y,time;

    private Rigidbody2D rb;
    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (!isStart)
        {
            time += Time.deltaTime;
            y= hoverDistance* Mathf.Sin(time* hoverSpeed);

            transform.position  =new Vector3 (transform.position.x, y, 0);

            if (Input.GetMouseButtonDown(0))
            {
                isStart = true;
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.velocity = Vector3.zero;
            }
        }
        else
        {
            Click();
        }

        
    }

    private void Click()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(Vector3.up*force,ForceMode2D.Impulse);
        }
    }
}
