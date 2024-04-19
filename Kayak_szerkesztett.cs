using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class BoatController : MonoBehaviour

{

    public float speed = 5f;

    public float syncedSpeedMultiplier = 2f;

    public KeyCode leftKey = KeyCode.A;

    public KeyCode rightKey = KeyCode.L;

    public KeyCode upKey = KeyCode.Z;

    public KeyCode downKey = KeyCode.M;



    private Rigidbody boatRigidbody;

    private bool leftKeyPressed = false;

    private bool rightKeyPressed = false;

    private bool upKeyPressed = false;

    private bool downKeyPressed = false;

    private void Start()

    {

        boatRigidbody = GetComponent<Rigidbody>();

    }

    private void Update()

    {

        // Check for left and right key presses

        if (Input.GetKeyDown(leftKey))

            leftKeyPressed = true;

        if (Input.GetKeyDown(rightKey))

            rightKeyPressed = true;

        // Check for key releases

        if (Input.GetKeyUp(leftKey))

            leftKeyPressed = false;

        if (Input.GetKeyUp(rightKey))
            rightKeyPressed = false;

        // Move the boat if keys are pressed in sync

        if (leftKeyPressed && rightKeyPressed)

            boatRigidbody.velocity = transform.forward * speed * syncedSpeedMultiplier;
        else

            boatRigidbody.velocity = Vector3.zero;

        if (Input.GetKeyDown(upKey))

            upKeyPressed = true;

        if (Input.GetKeyDown(downKey))

            downKeyPressed = true;


        if (Input.GetKeyUp(upKey))

            upKeyPressed = false;

        if (Input.GetKeyUp(downKey))

            downKeyPressed = false;

        // Move the boat if keys are pressed in sync

        if (upKeyPressed && leftKeyPressed)
            //transform.Rotate(Vector3.right * speed * Time.deltaTime);
            transform.Rotate(0, -speed * syncedSpeedMultiplier * Time.deltaTime, 0);
        if (rightKeyPressed && downKeyPressed)
            //transform.Rotate(Vector3.right * speed * Time.deltaTime);
            transform.Rotate(0, speed * syncedSpeedMultiplier * Time.deltaTime, 0);

    }

}
