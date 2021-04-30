using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Player : MonoBehaviour
{
    SerialPort sp = new SerialPort("COM3", 9600);
    private Rigidbody rb;

    [SerializeField]
    private bool isGrounded;

    [SerializeField]
    private bool canJump = false;
    public float forceConst;

    void Start()
    {
        //Run the code to open the serial port
        OpenSerialPort();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (sp.IsOpen)
        {
            try
            {
                //while the serialport is open move execute the movement function and pass the line that the Arduino is printing
                JumpWasPressed(sp.ReadByte());
            }
            catch (System.Exception)
            {

            }
        }
        //JUMP TEST WITHOUT ARDUINO
        //JumpWasPressed();
    }

    private void FixedUpdate()
    {
        if (canJump)
            Jump();
    }

    void OpenSerialPort()
    {
        //Open the serial port
        sp.Open();
        sp.ReadTimeout = 100;
    }

    void JumpWasPressed(int isPressed)
    {
        //Check what direction the arduino has passed on
        if (isPressed == 1 && isGrounded)
        { 
            //JUMP
            canJump = true;
        }
    }

    /// <summary>
    /// JUMP TEST WITHOUT ARDUINO
    /// </summary>
    void JumpWasPressed()
    {
        //Check what direction the arduino has passed on
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //JUMP
            canJump = true;
        }
    }

    public void Jump()
    {
        isGrounded = false;
        canJump = false;
        rb.AddForce(0, forceConst, 0, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
