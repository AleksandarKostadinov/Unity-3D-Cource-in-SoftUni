using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public GameObject cameraObj;
    public float rotationSpeed = 3;

    private Rigidbody rb;
    private Vector3 movingVectorHorizontal;
    private Vector3 movingVectorVertical;
    private bool isInAir = false;

    // Use this for initialization
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            this.movingVectorVertical = transform.forward * this.speed * Time.deltaTime;
        }
        else if (Input.GetKey("down") || Input.GetKey("s"))
        {
            this.movingVectorVertical = -transform.forward * this.speed * Time.deltaTime;
        }
        else
        {
            this.movingVectorVertical = Vector3.zero;
        }

        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            this.movingVectorHorizontal = -transform.right * this.speed * Time.deltaTime;
        }
        else if (Input.GetKey("right") || Input.GetKey("d"))
        {
            this.movingVectorHorizontal = transform.right * this.speed * Time.deltaTime;
        }
        else
        {
            this.movingVectorHorizontal = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Jump") > 0 && !this.isInAir)
        {
            this.rb.velocity = new Vector3(0, 8, 0);
            this.isInAir = true;
        }

        Vector3 newMovingVector = this.movingVectorHorizontal + this.movingVectorVertical;
        newMovingVector.y = this.rb.velocity.y;
        this.rb.velocity = newMovingVector;

        this.rb.rotation = Quaternion.Euler(this.rb.rotation.eulerAngles + new Vector3(0, Input.GetAxis("Mouse X"), 0) * this.rotationSpeed * Time.deltaTime);

        this.cameraObj.transform.Rotate(Input.GetAxis("Mouse Y") * -this.rotationSpeed * Time.deltaTime, 0f, 0f);
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            this.isInAir = false;
        }
    }
}
