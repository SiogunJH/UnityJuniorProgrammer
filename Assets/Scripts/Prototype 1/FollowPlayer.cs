using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private int cameraPosID = 0;

    void Start()
    {

    }

    void LateUpdate()
    {
        //Pre mods
        float offsetX = 1.2f * Mathf.Sin(player.transform.eulerAngles.y / 180 * Mathf.PI);
        float offsetZ = 1.2f * Mathf.Cos(player.transform.eulerAngles.y / 180 * Mathf.PI);

        //Switch camera view
        if (Input.GetKeyDown(KeyCode.C) && name == "Camera 1")
            ChangeCameraPos();
        else if (Input.GetKeyDown(KeyCode.V) && name == "Camera 2")
            ChangeCameraPos();

        //Update camera position
        switch (cameraPosID)
        {
            case 0:
                transform.position = player.transform.position + new Vector3(0, 5, -7);
                transform.rotation = Quaternion.Euler(20, 0, 0);
                break;
            case 1:
                //transform.position = player.transform.position + new Vector3(0, 1.7f, 1.2f);
                transform.position = new Vector3(
                    player.transform.position.x + offsetX,
                    player.transform.position.y + 1.7f,
                    player.transform.position.z + offsetZ
                    );
                transform.rotation = player.transform.rotation;
                break;
            case 2:
                transform.position = player.transform.position + new Vector3(0, 25, 0);
                transform.rotation = Quaternion.Euler(90, 0, 0);
                break;
        }

        //Post mods
    }

    public void ChangeCameraPos()
    {
        cameraPosID = (cameraPosID + 1) % 3;
    }
}
