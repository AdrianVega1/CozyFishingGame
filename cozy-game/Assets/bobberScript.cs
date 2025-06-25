using UnityEngine;

public class bobberScript : MonoBehaviour
{
    public bool gameIsOver;
    public Animator bobberAnim;
    public float bobberTime;

    void Start()
    {

    }


    void Update()
    {
        bobberTime += Time.deltaTime;
        if (bobberTime >= 3)
        {
            bobberAnim.Play("bobberFish");
        }
        if (Input.GetKeyDown(KeyCode.P) && bobberTime <= 3)
        {
            Destroy(gameObject);
        }
        if (gameIsOver == true)
        {
            Destroy(gameObject, 0.5f);
        }
    }

    public void gameOver()
    {
        gameIsOver = true;
    }
}
