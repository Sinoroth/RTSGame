using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        MoveCamera();
	}

    private void MoveCamera()
    {
        float xAxis = 0, yAxis = 0;

        Vector3 movement = Vector3.zero;

        DetermineMovement(ref xAxis,ref yAxis);

        movement = new Vector3(xAxis, yAxis);

        movement = Camera.main.transform.TransformDirection(movement);

        movement.y -= RTS.GameResourceManager.ScrollSpeed * Input.GetAxis("Mouse ScrollWheel");


        Vector3 origin = Camera.main.transform.position;
        Vector3 destination = origin;
        destination.x += movement.x;
        destination.y += movement.y;
        destination.z += movement.z;

        if (destination != origin)
        {
            Camera.main.transform.position = Vector3.MoveTowards(origin, destination, Time.deltaTime * RTS.GameResourceManager.ScrollSpeed);
        }
    }

    private void DetermineMovement(ref float xAxis,ref float yAxis)
    {
        float mousePosX = Input.mousePosition.x;
        float mousePosY = Input.mousePosition.y;

        if (mousePosX >= Screen.width-4)
        {
            //Out of bounds check;
            if(mousePosX<=Screen.width)xAxis += RTS.GameResourceManager.ScrollSpeed;
        }
        else if (mousePosX <= 4)
        {
            //Out of bounds check;
            if(mousePosX >= 0) xAxis -= RTS.GameResourceManager.ScrollSpeed;
        }

        if(mousePosY >= Screen.height - 4)
        {
            if (mousePosY <= Screen.height) yAxis += RTS.GameResourceManager.ScrollSpeed;
        }
        else if(mousePosY<= 4)
        {
            if (mousePosY >= 0) yAxis -= RTS.GameResourceManager.ScrollSpeed;
        }
    }
}
