using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Camera mainCam;
    [SerializeField] private float xMargin = 2;
    [SerializeField] private float shipSpeed = 50;
    private bool canMove;
    public static SpaceshipMovement Instance;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCam = Camera.main;

        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove)
        {
            return;
        }

        int dirX = 0;
        if (Input.touches.Length > 0)
        {
            Vector3 touchPos = Input.touches[0].position;
            touchPos = mainCam.ScreenToWorldPoint(touchPos);

            if (touchPos.x > 0)
            {
                //go right
                dirX = 1;
                transform.rotation = Quaternion.Euler(0, 0, -30);
            }

            else
            {
                dirX = -1;
                transform.rotation = Quaternion.Euler(0, 0, 30);
            }

        }

        rb.velocity = new Vector2(dirX * shipSpeed, 0);

        float posX = transform.position.x;
        posX = Mathf.Clamp(posX, -xMargin, xMargin);
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }

    public void StartScript()
    {
        canMove = true;
    }
}
