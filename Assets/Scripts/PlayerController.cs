using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody playerRigidBody;
    public float speed = 8f;

    private void Start()
    {
        playerRigidBody = this.GetComponent<Rigidbody>();
    }
    public void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        playerRigidBody.velocity = new Vector3(xSpeed, 0, zSpeed);
    }

    public void Die()
    {
        gameObject.SetActive(false);
        FindObjectOfType<GameManager>().OnPlayerDead();
    }

}
