using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text scoreText;
    public Text winText;

    private int score;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetScoreText();
        winText.text = "";
    }
	
    // giving the flow movement. Fixing the update iteractions
    private void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            score++;
            SetScoreText();
        }
    }

    private void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= 9)
        {
            winText.text = "You Win!";
        }
    }
}
