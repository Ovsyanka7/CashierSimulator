using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Camera m_OrthographicCamera;
    void Start()
    {
        m_OrthographicCamera.orthographicSize = Screen.height/2;
    }
}
