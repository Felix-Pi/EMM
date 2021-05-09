using UnityEngine;
using Vuforia;

public class ButtonEventHandler : MonoBehaviour
{
    private GameObject[] player;
    private float angle = 0;

    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");

        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
        for (int i = 0; i < vbs.Length; ++i)
        {
            vbs[i].RegisterOnButtonPressed(OnButtonPressed);
            Debug.Log("Button registered: " + vbs[i]);
        }
    }


    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        print("BUTTON PRESSED: " + vb.name + vb);
        switch (vb.name)
        {
            case "up":
                player[0].GetComponent<Player>().movement += 10;
                return;
            case "down":
                player[0].GetComponent<Player>().movement -= 10;
                return;
            case "left":
                player[0].GetComponent<Player>().angle -= 20;
                return;
            case "right":
                player[0].GetComponent<Player>().angle += 20;
                return;
        }
    }
}