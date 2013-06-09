using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class FreeMovementMotor : MovementMotor
{
	
	
	public float walkingSpeed;
	public float walkingSnappyness;
	public float turningSmoothing;

	void FixedUpdate() 
	{
		Vector3 targetVelocity = movementDirection.normalized * walkingSpeed;
		Vector3 deltaVelocity = targetVelocity - rigidbody.velocity;
		
		//if (rigidbody.useGravity) Noh jumps
			//deltaVelocity.y = 0f;
		rigidbody.AddForce (deltaVelocity * walkingSnappyness, ForceMode.Acceleration);
	
		
		// Setup player to face facingDirection, or if that is zero, then the movementDirection
		Vector3 faceDir = facingDirection;
		if (faceDir == Vector3.zero)
			faceDir = movementDirection;
		
		if (faceDir == Vector3.zero) {
			rigidbody.angularVelocity = Vector3.zero;
		}



		else {
			float rotationAngle = AngleAroundAxis (transform.forward, faceDir, Vector3.up);
			rigidbody.angularVelocity = (Vector3.up * rotationAngle * turningSmoothing);
		}
			
	
	}
	
	
	// The angle between dirA and dirB around axis
	static float AngleAroundAxis (Vector3 dirA, Vector3 dirB, Vector3 axis) {
	    // Project A and B onto the plane orthogonal target axis
	    dirA = dirA - Vector3.Project (dirA, axis);
	    dirB = dirB - Vector3.Project (dirB, axis);
	   
	    // Find (positive) angle between A and B
	    float angle = Vector3.Angle (dirA, dirB);
	   
	    // Return angle multiplied with 1 or -1
	    return angle * (Vector3.Dot (axis, Vector3.Cross (dirA, dirB)) < 0f ? -1f : 1f);
	}
	

}

