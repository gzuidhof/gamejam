using UnityEngine;
using System.Collections;

public class PlayerMovementController : MonoBehaviour {

    public PlayerInput player;
    public Transform character;
    public MovementMotor motor;

    Plane playerMovementPlane;

    private Quaternion screenMovementSpace;
    private Vector3 screenMovementForward;
    private Vector3 screenMovementRight;
    private Transform mainCameraTransform;

    // Use this for initialization
    void Start()
    {

        if (!motor)
            transform.GetComponent<MovementMotor>();

        motor.movementDirection = Vector2.zero;
        motor.movementDirection = Vector2.zero;

        mainCameraTransform = Camera.main.transform;

        if (!character)
            character = transform;

        playerMovementPlane = new Plane(character.up, character.position + character.up /** cursorPlaneHeight*/);

    }

    // Update is called once per frame
    void Update()
    {

        //Handle movement

        screenMovementSpace = Quaternion.Euler(0f, mainCameraTransform.eulerAngles.y, 0f);
        screenMovementForward = screenMovementSpace * Vector3.forward;
        screenMovementRight = screenMovementSpace * Vector3.right;

        motor.movementDirection = player.GetHorizontalInput() * screenMovementRight + player.GetVerticalInput() * screenMovementForward;

        if (motor.movementDirection.sqrMagnitude > 1)
            motor.movementDirection.Normalize();

        playerMovementPlane.normal = character.up;
        playerMovementPlane.distance = -character.position.y;

        motor.facingDirection.y = 0.0f;

    }



    public static Vector3 ScreenPointToWorldPointOnPlane(Vector3 screenPoint, Plane plane, Camera camera)
    {
        // Set up a ray corresponding to the screen position
        //var ray : Ray = camera.ScreenPointToRay (screenPoint);

        // Find out where the ray intersects with the plane
        //return PlaneRayIntersection (plane, camera.ScreenPointToRay (screenPoint));
        return PlaneRayIntersection(plane, camera.ScreenPointToRay(screenPoint));
    }

    public Vector3 ScreenPointToWorldPoint(Vector3 screenPoint, Plane plane, Camera camera)
    {

        RaycastHit hit;
        if (Physics.Raycast(camera.ScreenPointToRay(screenPoint), out hit))
        {
            return hit.point;
        }
        return ScreenPointToWorldPointOnPlane(screenPoint, plane, camera);
    }


    public static Vector3 PlaneRayIntersection(Plane plane, Ray ray)
    {
        float dist;
        plane.Raycast(ray, out dist);
        return ray.GetPoint(dist);
    }
	
}
