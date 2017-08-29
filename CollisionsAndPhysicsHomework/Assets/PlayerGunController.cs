using UnityEngine;
using System.Collections;

public class PlayerGunController : MonoBehaviour
{
    public float fireRate = 0.5f;

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
        if (Input.GetMouseButton(0) && this.timePassed > this.fireRate)
        {
            var currentBullet = Instantiate(this.bullet, this.spawnpoint.transform.position, this.spawnpoint.transform.rotation);
            Destroy(currentBullet, 5);

            this.timePassed = 0;

            RaycastHit hit;
            int monsterLayerMask = 1 << 8;
            if (Physics.Raycast(this.spawnpoint.transform.position, this.spawnpoint.transform.forward, out hit,25, monsterLayerMask))
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
