using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private Animator animator;

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);
    }

    public void ChangeSceneGame()
    {
        animator.SetTrigger("fadein");
        StartCoroutine(StartGame());
    }
}
