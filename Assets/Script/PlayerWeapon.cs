using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform muzzle;
    Transform playerPos;
    public float bulletForce = 350f;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bulletInstance = Instantiate(bullet, muzzle.position, Quaternion.identity);
            Vector3 playerDirection = playerPos.forward.normalized;
            bulletInstance.GetComponent<Rigidbody>().AddForce(playerDirection*bulletForce, ForceMode.Impulse);
        }
    }

    public void Shoot()
    {
        GameObject bulletInstance = Instantiate(bullet, muzzle.position, Quaternion.identity);
        Vector3 playerDirection = playerPos.forward.normalized;
        bulletInstance.GetComponent<Rigidbody>().AddForce(playerDirection * bulletForce, ForceMode.Impulse);
    }
}
