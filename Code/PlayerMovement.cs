using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private AudioSource audioSource;
    public TextMeshProUGUI scoreText;
    private int score = 0;
    public int winScore = 3;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0f, moveZ);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("ชนแล้ว");

        if (other.CompareTag("Item"))
        {
            audioSource.PlayOneShot(audioSource.clip);

            score++;
            scoreText.text = "Score: " + score;

            Destroy(other.gameObject);

            if (score >= winScore)
            {
                WinGame();
            }
        }
    }
    void WinGame()
    {
        scoreText.text = "YOU WIN!";
    }
}