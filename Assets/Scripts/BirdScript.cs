using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;

    public bool isBirdAlive = true;

    public float flapStrength;
    public LogicScript logic;
    public SFXScript sfx;

    public const float roofDeadZone = 20;
    public const float floorDeadZone = -20;

    private Animator birdAnimator;

    // Start is called before the first frame update
    void Start()
    {
        birdAnimator = GetComponent<Animator>();
        // logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        // sfx = GameObject.FindGameObjectWithTag("SFX").GetComponent<SFXScript>();
        sfx.playBackgroundMusic(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isBirdAlive)
        {
            if (myRigidbody.position.y > roofDeadZone || myRigidbody.position.y < floorDeadZone)
            {
                Debug.Log(myRigidbody.position.y);
                Debug.Log(roofDeadZone);
                setBirdGameOver();
            }

            // if (Input.GetKeyDown(KeyCode.Space))
            // Input.GetTouch(0).phase == TouchPhase.Ended
            // if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                myRigidbody.velocity = Vector2.up * flapStrength;
                birdAnimator.SetBool("FlyingUp", true);
                sfx.playBirdJumpSound();
            }
            else
            {
                if (myRigidbody.velocity.y < flapStrength / 2)
                {
                    birdAnimator.SetBool("FlyingUp", false);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBirdAlive)
        {
            setBirdGameOver();
        }
    }

    private void setBirdGameOver()
    {
        isBirdAlive = false;
        sfx.playBirdHitSound();
        sfx.playBackgroundMusic(false);
        logic.gameOver();
    }
}
