using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

    public GameObject cameraOne;
    public GameObject cameraTwo;

    void Start()
    {
        cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            int viewCounter = PlayerPrefs.GetInt("CameraPosition");
            viewCounter++;
            cameraPositionChange(viewCounter);
        }
    }

    void cameraPositionChange(int cameraPosition)
    {
        cameraPosition = cameraPosition % 2;
        PlayerPrefs.SetInt("CameraPosition", cameraPosition);

        if (cameraPosition == 0)
        {
            cameraOne.SetActive(true);
            cameraTwo.SetActive(false);
        }

        if (cameraPosition == 1)
        {
            cameraTwo.SetActive(true);
            cameraOne.SetActive(false);
        }

    }
}