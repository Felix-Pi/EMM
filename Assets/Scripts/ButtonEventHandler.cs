using System;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class ButtonEventHandler : MonoBehaviour
{
    public float movementSteps = 0.5f;
    public float angleSteps = 1f;

    private GameObject[] player;
    private float angle = 0;

    private VirtualButtonBehaviour activeButton;
    private bool activeButtonState = false;
    private Player _player;

    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");

        Debug.Log(GameObject.FindGameObjectsWithTag("Player"));

        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; ++i)
        {
            vbs[i].RegisterOnButtonPressed(OnButtonPressed);
            vbs[i].RegisterOnButtonReleased(OnButtonReleased);
            Debug.Log("Button registered: " + vbs[i]);
        }
    }


    private void Update()
    {
        if (player.Length == 0)
        {
            player = GameObject.FindGameObjectsWithTag("Player");

            if (player.Length == 0)
            {
                Debug.Log("Player not found. Updating canceled!");
            }
        }

        _player = player[0].GetComponent<Player>();

        if (activeButtonState && activeButton != null)
        {
            Debug.Log("updating: " + activeButton.name);
            switch (activeButton.name)
            {
                case "up":
                    _player.Move(movementSteps);
                    return;
                case "down":
                    _player.Move(-movementSteps);
                    return;
                case "left":
                    _player.angle -= angleSteps;
                    Debug.Log(_player.angle);
                    return;
                case "right":
                    _player.angle += angleSteps;
                    return;
            }
        }
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        print("OnButtonPressed: " + vb.name);
        activeButton = vb;
        activeButtonState = true;
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        print("OnButtonReleased: " + vb.name);
        activeButton = null;
        activeButtonState = false;
    }
}