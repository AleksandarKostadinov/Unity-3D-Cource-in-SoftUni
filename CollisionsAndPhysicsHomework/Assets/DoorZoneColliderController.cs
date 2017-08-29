using UnityEngine;
using System.Collections;

public class DoorZoneColliderController : MonoBehaviour
{
    public GameObject door;

    private SphereCollider zoneCollider;
    private bool hasToOpen;
    private bool enter;

    // Use this for initialization
    void Start()
    {
        //this.hasToOpen = false;
        this.zoneCollider = this.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && this.enter)
        {
            this.hasToOpen = true;
        }

        if (!this.enter)
        {
            this.hasToOpen = false;
        }

        if (this.hasToOpen)
        {
            var dooRigidbody = this.door.GetComponent<Rigidbody>();
            dooRigidbody.AddForce(0, 0, 70, ForceMode.Acceleration);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.gameObject.tag == "Player")
        {
            this.enter = true;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        //var distance = Vector3.Distance(this.zoneCollider.transform.position, collider.transform.gameObject.transform.position);
        //if (distance > 5f)
        //{
        //    this.hasToOpen = false;
        //}
        ////
        /// 
        if (collider.transform.gameObject.tag == "Player")
        {
            this.enter = false;
        }
        
    }
}
