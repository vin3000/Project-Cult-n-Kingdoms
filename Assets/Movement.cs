using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D myRigidBody;
    [SerializeField]
    Vector3 force = new();
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && myRigidBody.velocity.y == 0)
        {
            myRigidBody.AddForce(new Vector3(0, 10, 0), ForceMode2D.Impulse);
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            myRigidBody.AddForce(new Vector3(-force.x, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            myRigidBody.AddForce(new Vector3(force.x, 0, 0));
        }
        if (gameObject.transform.position.y < -10)
        {
            gameObject.transform.position = new Vector3(0, (float)0.5, 0);
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            myRigidBody.velocity = new Vector3(0, 0, 0);

        }
    }
}

