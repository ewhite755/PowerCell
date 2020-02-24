using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public float speed = 10.0f;

    public Vector3 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;
    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Powercell"))
        {
            SceneManager.LoadScene("Win");
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
