using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Camera fpsCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera.enabled = true;
        fpsCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchCamera()
    {
        mainCamera.enabled = !mainCamera.enabled;
        fpsCamera.enabled = !fpsCamera.enabled;
        Debug.Log("calýstý");
    }
}
