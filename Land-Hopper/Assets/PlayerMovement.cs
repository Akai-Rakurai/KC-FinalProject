using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Vessel SO;

    public HeaalthBar Bar;
    public Text HealthAmount;

    public CharacterController controller;
    public float speed = 12f;
    Vector3 velocity;
    public float gravity = -9.81f;
    public float JumpHeight = 3f;
    public Transform GroundCheck;
    public float grounddistance = 0.4f;
    public LayerMask groundMask;
    bool isgrounded;

    void Start()
    {
        if(SO.Health == 0)
        SO.Health = SO.MaxHealth;

        Bar.SetMaxHealth(SO.MaxHealth);
        Bar.SetHealth(SO.Health);
        HealthAmount.text = SO.Health.ToString();
    }

    void Update()
    {
        isgrounded = Physics.CheckSphere(GroundCheck.position, grounddistance, groundMask);

        if(isgrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * X + transform.forward * Z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isgrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (SO.Health < 0)
        {
            SO.SetData();
            SceneManager.LoadScene(2);
        }    
            

    }
}
