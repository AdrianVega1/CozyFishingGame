using UnityEngine;

public class fishingBarScript : MonoBehaviour
{
    public Rigidbody rb;
    public bool atTop;
    public float targetTime = 4.0f;
    public float savedTargetTime;

    public GameObject p1, p2, p3, p4, p5, p6, p7, p8;

    public bool onFish;
    public playerScript playerS;
    public GameObject bobber;

    public float topLimit = 2.04f;
    public float bottomLimit = -1.5f;
    public float moveSpeed = 4.0f;

    void FixedUpdate()
    {
        // Limitar posici�n Y
        /*float clampedY = Mathf.Clamp(transform.position.y, bottomLimit, topLimit);
        rb.MovePosition(new Vector3(transform.position.x, clampedY, transform.position.z));*/
    }

    void Start()
    {
    }

    void Update()
    {
        if (onFish)
        {
            targetTime += Time.deltaTime;
        }
        if (!onFish)
        {
            targetTime -= Time.deltaTime;
        }

        if (targetTime <= 0.0f)
        {
            transform.localPosition = new Vector3(-0.196f, -0.942f, 0);
            onFish = false;
            playerS.fishGameLossed();
            Destroy(GameObject.Find("bobber(Clone)"));
            targetTime = 4.0f;
        }
        if (targetTime >= 8.0f)
        {
            transform.localPosition = new Vector3(-0.196f, -0.942f, 0);
            onFish = false;
            playerS.fishGameWon();
            Destroy(GameObject.Find("bobber(Clone)"));
            targetTime = 4.0f;
        }

        if (targetTime >= 0.0f)
        {
            p1.SetActive(false);
            p2.SetActive(false);
            p3.SetActive(false);
            p4.SetActive(false);
            p5.SetActive(false);
            p6.SetActive(false);
            p7.SetActive(false);
            p8.SetActive(false);
        }
        if (targetTime >= 1.0f)
        {
            p1.SetActive(true);
            p2.SetActive(false);
            p3.SetActive(false);
            p4.SetActive(false);
            p5.SetActive(false);
            p6.SetActive(false);
            p7.SetActive(false);
            p8.SetActive(false);
        }
        if (targetTime >= 2.0f)
        {
            p1.SetActive(true);
            p2.SetActive(true);
            p3.SetActive(false);
            p4.SetActive(false);
            p5.SetActive(false);
            p6.SetActive(false);
            p7.SetActive(false);
            p8.SetActive(false);
        }
        if (targetTime >= 3.0f)
        {
            p1.SetActive(true);
            p2.SetActive(true);
            p3.SetActive(true);
            p4.SetActive(false);
            p5.SetActive(false);
            p6.SetActive(false);
            p7.SetActive(false);
            p8.SetActive(false);
        }
        if (targetTime >= 4.0f)
        {
            p1.SetActive(true);
            p2.SetActive(true);
            p3.SetActive(true);
            p4.SetActive(true);
            p5.SetActive(false);
            p6.SetActive(false);
            p7.SetActive(false);
            p8.SetActive(false);
        }
        if (targetTime >= 5.0f)
        {
            p1.SetActive(true);
            p2.SetActive(true);
            p3.SetActive(true);
            p4.SetActive(true);
            p5.SetActive(true);
            p6.SetActive(false);
            p7.SetActive(false);
            p8.SetActive(false);
        }
        if (targetTime >= 6.0f)
        {
            p1.SetActive(true);
            p2.SetActive(true);
            p3.SetActive(true);
            p4.SetActive(true);
            p5.SetActive(true);
            p6.SetActive(true);
            p7.SetActive(false);
            p8.SetActive(false);
        }
        if (targetTime >= 7.0f)
        {
            p1.SetActive(true);
            p2.SetActive(true);
            p3.SetActive(true);
            p4.SetActive(true);
            p5.SetActive(true);
            p6.SetActive(true);
            p7.SetActive(true);
            p8.SetActive(false);
        }
        if (targetTime >= 8.0f)
        {
            p1.SetActive(true);
            p2.SetActive(true);
            p3.SetActive(true);
            p4.SetActive(true);
            p5.SetActive(true);
            p6.SetActive(true);
            p7.SetActive(true);
            p8.SetActive(true);
        }
        /*if (Input.GetKey(KeyCode.Mouse0))
        {
            rb.AddForce(Vector3.up, ForceMode.Impulse);
        }*/
        float verticalInput = Input.GetKey(KeyCode.Mouse0) ? 1 : -1;
        rb.linearVelocity = new Vector3(0, verticalInput * moveSpeed, 0);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("fish"))
        {
            onFish = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("fish"))
        {
            onFish = false;
        }
    }
}
