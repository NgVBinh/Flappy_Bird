using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private float speed;
    

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x-speed* Time.deltaTime,transform.position.y,0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
