using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groupDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump = true;

    [Header("Keyblinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Gropu check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    public Vector3 moveOrientation;

    Rigidbody rb;

    [Header("Canvas")]

    public Text textObject;
    public Image panelObject;

    GameObject[] teamOfRed;
    GameObject[] teamOfBlue;

    bool isRedTeam;
    bool isBlueTeam;

    public Transform SpawnPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        /*
        teamOfRed = GameObject.FindGameObjectsWithTag("RED_TEAM");
        teamOfBlue = GameObject.FindGameObjectsWithTag("BLUE_TEAM");

        foreach (GameObject teamObject in teamOfRed)
        {
            teamObject.SetActive(false);
        }
        foreach (GameObject teamObject in teamOfBlue)
        {
            teamObject.SetActive(false);
        }*/
    }

    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        //SpeedControl();

        if (grounded)
            rb.drag = groupDrag;
        else
            rb.drag = 0;
        textChange();
        //ShowTeam();

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ReserJump), jumpCooldown);
        }
    }

    public void MovePlayer()
    {
        moveOrientation = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (grounded)
            rb.AddForce(moveOrientation.normalized * moveSpeed * 10f, ForceMode.Force);
        else if (!grounded)
            rb.AddForce(moveOrientation.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        /*
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }*/
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0)
        {
            rb.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ReserJump()
    {
        readyToJump = true;
    }

    private void textChange()
    {
        if (Input.GetKey(KeyCode.R))
        {
            transform.position = SpawnPoint.position;
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            textObject.text = "gravity orientation: x";
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            textObject.text = "gravity orientation: -x";
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            textObject.text = "gravity orientation: y";
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            textObject.text = "gravity orientation: -y";
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            textObject.text = "gravity orientation: z";
        }
        else if (Input.GetKey(KeyCode.Alpha6))
        {
            textObject.text = "gravity orientation: -z";
        }
        /*
        else if (Input.GetKey(KeyCode.Alpha7))
        {
            if (isBlueTeam)
            {
                textObject.text = "";
                panelObject.color = new Color(0f, 0f, 0f, 0f);
            }

            if (!isRedTeam)
            {
                textObject.text = "show team: red";
                panelObject.color = new Color(255f, 0f, 0f, 0.35f);
            }
            else
            {
                textObject.text = "";
                panelObject.color = new Color(0f, 0f, 0f, 0f);
            }
        }
        else if (Input.GetKey(KeyCode.Alpha8))
        {
            if (isRedTeam)
            {
                textObject.text = "";
                panelObject.color = new Color(0f, 0f, 0f, 0f);
            }

            if (!isBlueTeam)
            {
                textObject.text = "show team: blue";
                panelObject.color = new Color(0f, 0f, 255f, 0.35f);
            }
            else
            {
                textObject.text = "show team: blue";
                panelObject.color = new Color(0f, 0f, 255f, 0.35f);
            }
        }
        else if (Input.GetKey(KeyCode.Alpha9))
        {
            if (isRedTeam)
            {
                textObject.text = "";
                panelObject.color = new Color(0f, 0f, 0f, 0f);
            }
            if (isBlueTeam)
            {
                textObject.text = "";
                panelObject.color = new Color(0f, 0f, 0f, 0f);
            }
        }*/
    }

    private void ShowTeam()
    {
        if (Input.GetKey(KeyCode.Alpha7))
        {
            if (isBlueTeam)
            {
                foreach (GameObject teamObject in teamOfBlue)
                {
                    teamObject.SetActive(false);
                }
                isBlueTeam = false;
            }

            if (!isRedTeam)
            {
                foreach (GameObject teamObject in teamOfRed)
                {
                    teamObject.SetActive(true);
                }
                isRedTeam = true;
            }
            else
            {
                foreach (GameObject teamObject in teamOfRed)
                {
                    teamObject.SetActive(false);
                }
                isRedTeam = false;
            }
        }
        else if (Input.GetKey(KeyCode.Alpha8))
        {
            if (isRedTeam)
            {
                foreach (GameObject teamObject in teamOfRed)
                {
                    teamObject.SetActive(false);
                }
                isRedTeam = false;
            }

            if (!isBlueTeam)
            {
                foreach (GameObject teamObject in teamOfBlue)
                {
                    teamObject.SetActive(true);
                }
                isBlueTeam = true;
            }
            else
            {
                foreach (GameObject teamObject in teamOfBlue)
                {
                    teamObject.SetActive(false);
                }
                isBlueTeam = false;
            }
        }
        else if (Input.GetKey(KeyCode.Alpha9))
        {
            if (isRedTeam)
            {
                foreach (GameObject teamObject in teamOfRed)
                {
                    teamObject.SetActive(false);
                }
                isRedTeam = false;
            }
            if (isBlueTeam)
            {
                foreach (GameObject teamObject in teamOfBlue)
                {
                    teamObject.SetActive(false);
                }
                isBlueTeam = false;
            }
        }
    }
}
