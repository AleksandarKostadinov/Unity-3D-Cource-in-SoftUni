using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 10;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = this.transform.position + this.transform.forward * this.bulletSpeed * Time.deltaTime;

        //this.transform.Translate(this.transform.forward * this.bulletSpeed * Time.deltaTime);
    }
}
