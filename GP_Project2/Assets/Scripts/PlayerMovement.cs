using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float currentTime = 0f;
    public float startingTime = 12f;
    public Text timer;
    public Transform teleportDestination;
    public bool Hit;
    public bool Diamond;
    public bool Player;

    void Start()
    {
        currentTime = startingTime;
        Hit = false;
        Diamond = true;
        Player = false;
    }



    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        currentTime -= 1 * Time.deltaTime;
        timer.text = currentTime.ToString("0");
        if (currentTime <= 0)
        {
            currentTime = 0f;
            SceneManager.LoadScene("LossEnd");
            Cursor.lockState = CursorLockMode.None;
        }
        if (currentTime >= 59)
        {
            currentTime = 59f;
        }
        if (Hit == true)
        {
            transform.position = teleportDestination.position;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Hit = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Hit = false;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Hit = false;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Hit = false;
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Time"))
        {
            Destroy(other.gameObject);
            currentTime += 5;
        }
        if (other.gameObject.CompareTag("PowerUp"))
        {
            speed = 24f;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit!");
            speed = 12f;
            currentTime -= 5;
            Hit = true;
            Diamond = true;
            Player = false;
        }
        if (other.gameObject.CompareTag("Diamond"))
        {
            SceneManager.LoadScene("WinEnd");
            Cursor.lockState = CursorLockMode.None;
        }
        if (other.gameObject.CompareTag("Dangerzone"))
        {
            Diamond = false;
            Player = true;
        }

    }
}