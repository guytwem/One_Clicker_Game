using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Player move stats
    public float velocity = 1;
    public float charger = 0f;
    private bool discharge = false;
    public float jumpForce = 1;
    #endregion


    public int coinValue = 1;
    private int scoreToWin = 0;

    #region game over
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject youWin;
    [SerializeField] private GameObject mainMenuButton;
    #endregion

    private Rigidbody2D rb;
    private Animator anim;

    private ScoreManager scoreManager;

   


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        youWin.SetActive(false);
        gameOver.SetActive(false);
        restartButton.SetActive(false);
        mainMenuButton.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.Space))
        {
            charger += Time.deltaTime;
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }


        if (Input.GetKeyUp(KeyCode.Space))
        {
            discharge = true;
        }

        if (rb.transform.position.x < -10)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            gameOver.SetActive(true);
            restartButton.SetActive(true);
            mainMenuButton.SetActive(true);
            Pause();
        }

        if(scoreToWin == 10)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            youWin.SetActive(true);
            restartButton.SetActive(true);
            mainMenuButton.SetActive(true);
            Pause();
        }

    }

    private void FixedUpdate()
    {


        if (discharge)
        {
            jumpForce = 10 * charger;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            discharge = false;
            charger = 0f;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            ScoreManager.instance.ChangeScore(coinValue);
            scoreToWin++;
        }

    }

    private void Pause()
    {
        Time.timeScale = 0;
    }

}
