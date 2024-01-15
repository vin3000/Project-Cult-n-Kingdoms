using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Run : MonoBehaviour
{
    // Start is called before the first frame update
    public float MoveSpeed = 5f;
    public Rigidbody2D RigidBody;
    public bool running = false;

    public Image StaminaBar;

    public float Stamina, MaxStamina;

    public float AttackCost;
    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        direction.Normalize();
      if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            running = true;
        } else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            running = false;
        }
      if(running && (direction.x != 0 || direction.y != 0))
        {
            RigidBody.velocity = direction * MoveSpeed * 1.5f;
        }
      else
        {
            RigidBody.velocity = direction * MoveSpeed;
        }
      if(Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Attack!");

            Stamina = +AttackCost;
            if (Stamina < 0) Stamina = 0;
            StaminaBar.fillAmount = Stamina / MaxStamina;
        }
    }

}
