using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    Animator anim;

    public Transform playerPutaran;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = Vector3.right * move * speed;
        anim.SetFloat("Kecepatan", Mathf.Abs(move), 0.1f, Time.deltaTime);
        playerPutaran.localEulerAngles = new Vector3(0, move * 90, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("virus"))
        {
            Time.timeScale = 0;
            Destroy(gameObject);
        }
    }

}
