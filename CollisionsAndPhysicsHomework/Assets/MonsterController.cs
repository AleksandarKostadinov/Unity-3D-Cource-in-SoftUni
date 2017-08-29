using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour
{
    public float aimSpeed = 1.5f;
    public GameObject player;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = this.player.transform.position - this.transform.position;

        this.rb.rotation = Quaternion.Slerp(this.rb.rotation, Quaternion.LookRotation(direction), this.aimSpeed * Time.deltaTime);
    }
}
