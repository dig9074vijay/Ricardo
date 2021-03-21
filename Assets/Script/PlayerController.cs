using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Transform player;
    public float rotationSpeed = 10.0f;
    public float speed = 5f;
    Animator playerAnim;
    Rigidbody m_Rigidbody;
    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
        //Stop the Rigidbody from rotating
        m_Rigidbody.freezeRotation = true;
        player = this.gameObject.GetComponent<Transform>();
        playerAnim = this.gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //player.Rotate(Vector3.up, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
        player.Rotate(Vector3.up, joystick.Horizontal * rotationSpeed * Time.deltaTime);

        Vector3 playerDirection = player.forward.normalized;
        playerAnim.SetFloat("PlayerMove", joystick.Vertical);
        player.Translate(playerDirection * speed * Time.deltaTime * joystick.Vertical, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(0);
        }
    }
}
