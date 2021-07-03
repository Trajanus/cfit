using System;
using System.Threading;
using System.Timers;
using UnityEngine;
using UnityLibrary;

public class Player : MonoBehaviour
{
    public int speed;
    public Sprite explosion;
    public double millisecondsUntilDetectionReset;

    private Rigidbody2D rb2d;
    private int numParticleStrikes = 0;
    private System.Timers.Timer particleStrikeResetTimer;

    private void Awake()
    {
        particleStrikeResetTimer = new System.Timers.Timer(millisecondsUntilDetectionReset) { AutoReset = true };
        particleStrikeResetTimer.Elapsed += ParticleStrikeResetElapsed;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float throttle = Input.GetAxisRaw(InputAxisNames.Throttle);
        float verticalAxis = Input.GetAxisRaw(InputAxisNames.Vertical);

        if (verticalAxis > 0)
        {
            transform.Rotate(Vector3.forward);
        }
        else if (verticalAxis < 0)
        {
            transform.Rotate(Vector3.back);
        }

        float acceleration = throttle * speed;

        Vector3 throwaway = new Vector3();
        float angle;
        transform.rotation.ToAngleAxis(out angle, out throwaway);

        if (transform.rotation.z < 0)
            angle *= -1;

        float radianAngle = (float)(Math.PI / 180) * angle;

        Vector2 accelerationVector = new Vector2(Mathf.Cos(radianAngle), Mathf.Sin(radianAngle));

        accelerationVector.x = (accelerationVector.x * acceleration) - (rb2d.velocity.x * 2);
        accelerationVector.y = (accelerationVector.y * acceleration) - (rb2d.velocity.y * 2);

        rb2d.AddForce(accelerationVector);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        SpriteRenderer playerRender = GetComponent<SpriteRenderer>();
        playerRender.sprite = explosion;
    }

    void OnParticleCollision(GameObject other)
    {
        if (particleStrikeResetTimer != null && !particleStrikeResetTimer.Enabled)
        {
            particleStrikeResetTimer.Start();
        }
        numParticleStrikes++;
        Debug.Log($"Strikes: {numParticleStrikes}");
    }

    private void ParticleStrikeResetElapsed(object sender, ElapsedEventArgs eventArgs)
    {
            numParticleStrikes = 0;
    }
}
