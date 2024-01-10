using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D myRigidBody;
    [SerializeField]
    Vector2 force = new();
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && myRigidBody.velocity.y == 0)
        {
            myRigidBody.AddForce(new Vector2(0, force.y), ForceMode2D.Impulse);
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            myRigidBody.AddForce(new Vector2(-force.x, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            myRigidBody.AddForce(new Vector2(force.x, 0));
        }
        if (gameObject.transform.position.y < -10)
        {
            gameObject.transform.position = new Vector2(0, (float)0.5);
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            myRigidBody.velocity = new Vector2(0, 0);

        }
    }
}

