using UnityEngine;

public class playerScript : MonoBehaviour
{
    public Animator playerAnimator;
    public bool isFishing;
    public bool poleBack;
    public bool throwBobber;
    public Transform fishingPoint;
    public GameObject bobberPrefab;

    public float moveSpeed = 1.5f;
    private Vector2 input;
    private string facingDirection = "Down"; // Default

    public float targetTime = 0.0f;
    public float savedTargetTime;
    public float extraBobberDistance;

    public GameObject fishGame;

    public float timeTillCatch = 0.0f;
    public bool winnerAnimation;

    private Rigidbody2D rb;

    private bool isTouchingPiedras = false;

    void Start()
    {
        isFishing = false;
        fishGame.SetActive(false);
        throwBobber = false;
        targetTime = 0.0f;
        savedTargetTime = 0.0f;
        extraBobberDistance = 0.0f;

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMovement();

        if (Input.GetKeyDown(KeyCode.Space) && !isFishing && !winnerAnimation)
        {
            if (isTouchingPiedras)
            {
                poleBack = true;
                Debug.Log("Fishing pole pulled back.");
            }
            else
            {
                Debug.Log("Can't fish: not touching piedras.");
            }
        }

        if (isFishing)
        {
            timeTillCatch += Time.deltaTime;
            if (timeTillCatch >= 3)
            {
                fishGame.SetActive(true);
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) && !isFishing && !winnerAnimation)
        {
            if (isTouchingPiedras)
            {
                poleBack = false;
                isFishing = true;
                throwBobber = true;

                if (targetTime >= 3)
                {
                    extraBobberDistance += 3;
                }
                else
                {
                    extraBobberDistance += targetTime;
                }
            }
        }

        Vector3 temp = new Vector3(extraBobberDistance, 0, 0);
        fishingPoint.transform.position += temp;

        if (poleBack)
        {
            playerAnimator.Play("playerSwingBack" + facingDirection);
            savedTargetTime = targetTime;
            targetTime += Time.deltaTime;
        }

        if (isFishing)
        {
            if (throwBobber)
            {
                Vector3 offset = GetFishingOffset();
                fishingPoint.position = transform.position + offset;

                Instantiate(bobberPrefab, fishingPoint.position, Quaternion.identity, transform);
                fishingPoint.transform.position -= temp;

                throwBobber = false;
                targetTime = 0.0f;
                savedTargetTime = 0.0f;
                extraBobberDistance = 0.0f;
            }

            playerAnimator.Play("playerFishing" + facingDirection);
        }

        if (Input.GetKeyDown(KeyCode.P) && timeTillCatch <= 3)
        {
            playerAnimator.Play("playerStill" + facingDirection);
            poleBack = false;
            throwBobber = false;
            isFishing = false;
            timeTillCatch = 0;
        }
    }

    void HandleMovement()
    {
        if (isFishing || poleBack || winnerAnimation) return;

        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (input != Vector2.zero)
        {
            rb.MovePosition(rb.position + input * moveSpeed * Time.deltaTime);

            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
                facingDirection = input.x > 0 ? "Right" : "Left";
            else
                facingDirection = input.y > 0 ? "Up" : "Down";

            playerAnimator.Play("walk" + facingDirection);
        }
        else
        {
            playerAnimator.Play("playerStill" + facingDirection);
        }
    }

    Vector3 GetFishingOffset()
    {
        switch (facingDirection)
        {
            case "Left": return Vector3.left * 2;
            case "Right": return Vector3.right * 2;
            case "Up": return Vector3.up * 2;
            case "Down": return Vector3.down * 2;
            default: return Vector3.zero;
        }
    }

    public void fishGameWon()
    {
        playerAnimator.Play("playerFished" + facingDirection);
        ResetFishing();
    }

    public void fishGameLossed()
    {
        playerAnimator.Play("playerStill" + facingDirection);
        ResetFishing();
    }

    void ResetFishing()
    {
        fishGame.SetActive(false);
        poleBack = false;
        throwBobber = false;
        isFishing = false;
        timeTillCatch = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piedras"))
        {
            isTouchingPiedras = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piedras"))
        {
            isTouchingPiedras = false;
        }
    }

}
