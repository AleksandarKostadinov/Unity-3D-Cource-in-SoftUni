using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour
{
    public float fireRate = 2;

    public GameObject bullet;

    public GameObject spawnpoint;

    private float timePassed = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.timePassed += Time.deltaTime;
        if (this.timePassed > this.fireRate)
        {
            var currentBullet = Instantiate(this.bullet, this.spawnpoint.transform.position, this.spawnpoint.transform.rotation);
            Destroy(currentBullet, 5);

            this.timePassed = 0;
        }
    }
}
