using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject readyPanel;
    [SerializeField] private GameObject endGamePanel;

    public bool start, ready,die;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        start = false;
        ready = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetReady();
        EndGame();
    }

    public void GetReady()
    {
        if (ready)
        {
            readyPanel.SetActive(false);
        }
    }

    public void EndGame()
    {
        if (die)
        {
            endGamePanel.SetActive(true);
        }
    }
}
