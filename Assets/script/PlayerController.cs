using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text countText;
    public GameObject winPoster; // 🖼️ Assign your poster Image UI
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;

    private int count = 0;
    private CharacterController controller;
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        count = 0;
        SetCountText();

        if (winPoster != null)
            winPoster.SetActive(false); // 🔒 Hide poster at start
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 input = new Vector3(horizontal, 0f, vertical);
        Vector3 direction = input.normalized;

        if (animator != null)
            animator.SetBool("moving", direction.magnitude > 0.1f);

        if (direction.magnitude > 0.1f)
        {
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            Quaternion targetRot = Quaternion.Euler(0f, angle, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
        }

        controller.Move(direction * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("diamonds"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        if (countText != null)
            countText.text = count.ToString(); // Update count UI

        if (count >= 10 && winPoster != null)
        {
            winPoster.SetActive(true); // ✅ Show win poster only
        }
    }
}
