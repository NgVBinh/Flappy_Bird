using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacleSpawner;
    [SerializeField] private float speed,timeSpawner;

    private float timer;


    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.start && !GameManager.Instance.die)
        {
            timer += Time.deltaTime;

            if (timer > timeSpawner)
            {
                timer = 0;
                GameObject obstacle = Instantiate(obstacleSpawner, transform.position,transform.rotation);
                obstacle.transform.parent = transform;
                obstacle.transform.position = new Vector3(obstacle.transform.position.x, obstacle.transform.position.y + Random.Range(-1, 2.5f), 0);
                
                Destroy(obstacle,8f);
            }
        }
    }
}
