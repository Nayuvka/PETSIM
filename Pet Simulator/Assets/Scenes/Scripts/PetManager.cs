using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    public PetController pet;
    public float petMoveTimer, originalpetMoveTimer;
    public Transform[] waypoints;
    
     private void Awake()
    {
        originalpetMoveTimer = petMoveTimer;
    }
    // Update is called once per frame
    void Update()
    {
        if(petMoveTimer > 0)
        {
            petMoveTimer -= Time.deltaTime;
        }
        else
        {
            MovePetToRandomWaypoint();
            petMoveTimer = originalpetMoveTimer;
        }
    }

    private void MovePetToRandomWaypoint()
    {
        int randomWaypoint = Random.Range(0, waypoints.Length);
        Vector3 destination = waypoints[randomWaypoint].position;

        // Lock Y to current pet position to keep pet on the ground
        destination.y = pet.transform.position.y;
        destination.z = pet.transform.position.z; // Optional for 2D
        pet.Move(destination);
    }




}
