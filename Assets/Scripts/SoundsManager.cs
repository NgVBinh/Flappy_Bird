using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    private AudioSource m_AudioSource;

    public static SoundsManager Instance;

    [SerializeField] private AudioClip[] m_AudioClip;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        m_AudioSource=GetComponent<AudioSource>();

    }


    public void PlaySound(string soundName)
    {
       switch (soundName)
        {
            case "click":
                m_AudioSource.PlayOneShot(m_AudioClip[0]);
                break;
            case "point":
                m_AudioSource.PlayOneShot(m_AudioClip[1]);
                break;
            case "die":
                m_AudioSource.PlayOneShot(m_AudioClip[2]);
                break;
        }
    }
}
