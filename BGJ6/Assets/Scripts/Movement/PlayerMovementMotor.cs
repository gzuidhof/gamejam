using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementMotor : MovementMotor {

    public float walkingSpeed = 5f;
    public float walkingAcceleration = 3f;
    public float turningSpeed = 5f;

    private float vSpeed;
    private float gravity = 9.81f;

    private CharacterController control;

    void Start()
    {
        control = GetComponent<CharacterController>();
    }


    void Update()
    {
        Vector3 targetVelocity = movementDirection * walkingSpeed /* Time.deltaTime*/;
        //Vector3 deltaVelocity = targetVelocity - rigidbody.velocity;

        Vector3 vel = Vector3.Lerp(control.velocity, targetVelocity, Time.deltaTime * walkingAcceleration);

        //control.velocity = targetVelocity;

        //rigidbody.AddForce(deltaVelocity * walkingSnappyness, ForceMode.Acceleration);

        // Setup player to face facingDirection, or if that is zero, then the movementDirection
        Vector3 faceDir = facingDirection;
        if (faceDir == Vector3.zero)
            faceDir = movementDirection;

        if (faceDir != Vector3.zero)
        transform.Rotate(transform.up, Mathf.Lerp(AngleAroundAxis(transform.forward, transform.forward, Vector3.up), 
            AngleAroundAxis(transform.forward, faceDir, Vector3.up), Time.deltaTime * turningSpeed));

        if (control.isGrounded)
        {
            vSpeed = 0; // grounded character has vSpeed = 0...
        }
        // apply gravity acceleration to vertical speed:
        vSpeed -= gravity * Time.deltaTime;
        vel.y = vSpeed; // include vertical speed in vel
        // convert vel to displacement and Move the character:
        control.Move(vel * Time.deltaTime);


    }

    // The angle between dirA and dirB around axis
    static float AngleAroundAxis(Vector3 dirA, Vector3 dirB, Vector3 axis)
    {
        // Project A and B onto the plane orthogonal target axis
        dirA = dirA - Vector3.Project(dirA, axis);
        dirB = dirB - Vector3.Project(dirB, axis);

        // Find (positive) angle between A and B
        float angle = Vector3.Angle(dirA, dirB);

        // Return angle multiplied with 1 or -1
        return angle * (Vector3.Dot(axis, Vector3.Cross(dirA, dirB)) < 0f ? -1f : 1f);
    }
}
