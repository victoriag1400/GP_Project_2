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

    void Start()
    {
        currentTime = startingTime;
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
        }
        if (currentTime >= 59)
        {
            currentTime = 59f;
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
        }
    }
}