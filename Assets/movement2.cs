using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement2 : MonoBehaviour {

    public CharacterController controller2D;

    public float runspeed = 40f;

    float horizontalMove = 0f;
    
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runspeed;
        
        {
           
        }


    }
    private void FixedUpdate()
    {
       controller2D.Move(new Vector3( horizontalMove * Time.fixedDeltaTime, 0, 0));
       
        //controller2D.Move()
    }
}

