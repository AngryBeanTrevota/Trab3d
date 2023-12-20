using System.Threading;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 0.1f;
    public float movementSpeed = 5f;
    public Transform target;
    public Camera mainCamera;

    private Vector3 dir;
   
    private float mouseX, mouseY;


    private bool isMoving = false;


    public Animator animator;

    private bool isCollidingWithTerrain = false;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (player == null)
        {
            player = transform; // If no player is assigned, assume the script is on the player.
        }

        mainCamera.transform.LookAt(target);
    }

    void Update()
    {
   
        HandleOrbitCamera();

    }

    private void LateUpdate()
    {
        HandleMovementInput();
        AnimationUpdate();

    }



    void HandleMovementInput()
    {
  
        //Handling the direction
        dir = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {

            player.rotation = Quaternion.Euler(0, mainCamera.transform.eulerAngles.y, 0);
            dir = player.transform.forward;
           
            
        }
        else
        {
            //For other keys, the movement is relative to the current looking position, need rotation lerp
            if (Input.GetKey(KeyCode.A))
            {

                player.rotation = Quaternion.Euler(0, mainCamera.transform.eulerAngles.y-90, 0);
                dir = player.transform.forward;

            }
            if (Input.GetKey(KeyCode.D))
            {

                player.rotation = Quaternion.Euler(0, mainCamera.transform.eulerAngles.y + 90, 0);
                dir = player.transform.forward;


            }

            if (Input.GetKey(KeyCode.S))
            {
                player.rotation = Quaternion.Euler(0, mainCamera.transform.eulerAngles.y + 180, 0);
                dir = player.transform.forward;

            }


        }


        if (isCollidingWithTerrain)
        {
            return;
        }



        //Debug.Log("Player Foward: (" + dir.x.ToString() +","+ dir.y.ToString() +","+ dir.z.ToString() + ")");
        Vector3 pos = new Vector3(0, 0, 0);
        pos.x += dir.x * movementSpeed*Time.deltaTime + player.transform.position.x;
        pos.z += dir.z * movementSpeed*Time.deltaTime + player.transform.position.z;
        pos.y = player.transform.position.y;


        player.transform.position = pos;


    }

    void HandleOrbitCamera()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;


        mouseY = Mathf.Clamp(mouseY, -8f, 60f);


        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);
        mainCamera.transform.position = target.position - rotation * Vector3.forward * 10f;
        mainCamera.transform.LookAt(target);
    }



    void AnimationUpdate()
    {
        isMoving = (dir == Vector3.zero) ? false : true;



        if (isMoving)
        {
            animator.SetFloat("Speed", 1.0f);

        }
        else
        {
            animator.SetFloat("Speed", 0.0f);
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Terrain")
        {
            isCollidingWithTerrain = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Terrain")
        {
            isCollidingWithTerrain = false;
        }

    }



}
