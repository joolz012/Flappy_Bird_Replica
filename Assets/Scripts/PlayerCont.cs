using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCont : MonoBehaviour
{
    [Header("Bird Settings")]
    public float upwardVelocity;
    public float rotationSpeed;
    private Rigidbody2D rb;

    private AudioSource audioSource;
    public AudioClip[] clips;
    public GameObject gameOverObj;

    private PlayerCont playerCont;

    // Start is called before the first frame update
    void Start()
    {
        playerCont = GetComponent<PlayerCont>();
        audioSource = GetComponent<AudioSource>();
        gameOverObj.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(clips[0]);
            rb.velocity = Vector2.up * upwardVelocity;
        }
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            audioSource.PlayOneShot(clips[1]);
            Time.timeScale = 0;

            //death
            gameOverObj.SetActive(true);

            playerCont.enabled = false;
        }
    }
}
