using UnityEngine;
using System.Collections;

public class Rocket_Player : MonoBehaviour {
    //Class handles the rocket and how the player controls it

    public Rigidbody RocketBody;
    public float RocketUPForce;
    public float RocketSIDEForce;
    
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RocketUpwards();
        }

        RocketSidewards(Input.GetAxisRaw("Horizontal"));
	}

    void RocketUpwards()//Adds force to the bottom of the craft
    {
        RocketBody.AddForce(0,RocketUPForce,0,ForceMode.Impulse);
    }
    
    void RocketSidewards(float SideToMoveTo = 0) //SideToMoveTo = 0 will do nothing, 1 will move to right, -1 will move to the left
    {
        RocketBody.AddForce(RocketSIDEForce * SideToMoveTo, 0, 0,ForceMode.Force);
    }
}
