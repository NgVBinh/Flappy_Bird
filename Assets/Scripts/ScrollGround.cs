using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollGround : MonoBehaviour
{
    private MeshRenderer m_MeshRenderer;

    [SerializeField] private float scrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
        m_MeshRenderer= GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        m_MeshRenderer.material.mainTextureOffset= new Vector2 ( Time.time*scrollSpeed,0);
    }
}
