using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    //Player number of this player
    public int playerNumber;

    public GameObject prefab;

    //List of player materials used in the jam
    public List<Material> playerMaterials;
    private ParticleSystem partsys;


    public AudioClip freezeSound;
    public AudioClip jumpSound;

    //Velocities to be set in the inspector
    public float jumpVelocity;
    public float movementForce = 20;
    public float movementMaxVelocity;

    private float distToGround;

    private static float[] lastFreeze = new float[4];

    void Start()
    {
        distToGround = collider.bounds.extents.y;
        partsys = GetComponent<ParticleSystem>();
        
    }

    void FixedUpdate()
    {
        HandleInput();

        //Tell progress handler where this player is.
        Progress.instance.IAmNowHere(transform.position, playerNumber);
    }

    void HandleInput()
    {
        //Jumping
        if (IsGrounded() && (ChainJam.GetButtonJustPressed(
            (ChainJam.PLAYER)(playerNumber - 1), ChainJam.BUTTON.A) || ChainJam.GetButtonJustPressed(
            (ChainJam.PLAYER)(playerNumber - 1), ChainJam.BUTTON.UP)))
        {
            audio.PlayOneShot(jumpSound);
            //Debug.Log("Jump!");
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpVelocity, rigidbody.velocity.z);
        }

        //Freeze
        if (ChainJam.GetButtonPressed((ChainJam.PLAYER)(playerNumber - 1), ChainJam.BUTTON.B) && (Time.time - lastFreeze[playerNumber-1] > 1f))
        {
            //Debug.Log("Freeze!");
            lastFreeze[playerNumber - 1] = Time.time;

            audio.PlayOneShot(freezeSound);

            rigidbody.isKinematic = true;
            enabled = false;
            partsys.Play();

            SpawnNewPlayer();
        }


        //Movement Left
        if (ChainJam.GetButtonPressed((ChainJam.PLAYER)(playerNumber - 1), ChainJam.BUTTON.LEFT))
        {
            //Debug.Log("Left!");
            rigidbody.AddForce(new Vector3(-movementForce, 0, 0));
        }
        //Movement Right
        if (ChainJam.GetButtonPressed((ChainJam.PLAYER)(playerNumber - 1), ChainJam.BUTTON.RIGHT))
        {
            //Debug.Log("Right!");
            rigidbody.AddForce(new Vector3(movementForce, 0, 0));
            
        }

        //Cap sideways movement speed
        if (Mathf.Abs(rigidbody.velocity.x) > movementMaxVelocity)
        {
            rigidbody.velocity = 
                rigidbody.velocity.x > 0 ? new Vector3(movementMaxVelocity, rigidbody.velocity.y, rigidbody.velocity.z)
                : new Vector3(-movementMaxVelocity, rigidbody.velocity.y, rigidbody.velocity.z);
        }
    }


    /// <summary>
    /// Spawn a new player with the same playerNumber.
    /// </summary>
    void SpawnNewPlayer()
    {
        GameObject o = (GameObject) Instantiate(prefab);


        //Somewhat random spawnpoint
        o.transform.position = new Vector3(Random.Range(-8f, 8f), 0, 0f);

        


        ////Set right player number and material
        o.GetComponent<Player>().playerNumber = playerNumber;
        o.renderer.material = playerMaterials[playerNumber - 1];
        o.rigidbody.isKinematic = false;
        o.GetComponent<Player>().enabled = true;

        //Give it a random rotation and movement.
        o.transform.Rotate(Vector3.forward, Random.Range(0f, 360f));
        o.rigidbody.AddForce(new Vector3(Random.Range(-360f, 360f), 180f, 0));

        //Tell the camera about this new player (and make it forget about the old one).
        CameraScript.instance.players[playerNumber - 1] = o.transform;
    }

    /// <summary>
    /// Duct-tape solution for checking whether the cube is grounded.
    /// </summary>
    /// <returns></returns>
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.3f) || 
            Physics.Raycast(transform.position + new Vector3(0.35f,0,0), -Vector3.up, distToGround + 0.3f) ||
            Physics.Raycast(transform.position + new Vector3(-0.35f, 0, 0), -Vector3.up, distToGround + 0.3f);
    }

}
