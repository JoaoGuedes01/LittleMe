using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class OrthoGraphicCamaraScript : MonoBehaviour
{
    public SpriteRenderer rink;
    public CinemachineVirtualCamera vcam;
    // Start is called before the first frame update
    void Start()
    {
        float orthoSize = rink.bounds.size.x * Screen.height / Screen.width * 0.5f;

        vcam.m_Lens.OrthographicSize = orthoSize;
    }
}
