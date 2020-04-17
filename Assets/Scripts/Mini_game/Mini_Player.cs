using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini_Player : MonoBehaviour
{

    public float tankSpeedVertical = 5.0f;
    public float tankSpeedHorizontal = 5.0f;//tank moving speed
    public float tripeLife = 5;

    

    public GameObject laserPrefab;
    public GameObject tripleShot;

    [SerializeField]
    private float _health = 100;

    public float fireRate = 0.5f;
    private float _cd = 0;

    float boundary_Y;
    float boundary_X;
    bool triple = false;

    float deltaTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        GameObject control = GameObject.Find("GameController");
        boundary_X = control.GetComponent<MiniGame_Controll>().boundarySize_X;
        boundary_Y = control.GetComponent<MiniGame_Controll>().boundarySize_Y;
        transform.position = new Vector3(0, -3, 0);  //Starter position
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        StayIn();

        Shoot();

        deltaTime += Time.deltaTime;

        if (triple && deltaTime >= tripeLife)
        {
            triple = false;
        }

    }

    private void Shoot()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= _cd)
        {
            _cd = Time.time + fireRate;
            if (triple)
            {
                Instantiate(tripleShot, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            }
            else {
                Instantiate(laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity); 
            }

            
        }
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (Mathf.Abs(horizontal) + Mathf.Abs(vertical) == 2.0f)
        {
            transform.Translate(new Vector3(horizontal * tankSpeedHorizontal, Input.GetAxis("Vertical") * tankSpeedVertical) * Time.deltaTime / Mathf.Sqrt(2.0f));  //don't move faster van moving diagonal
        }
        else
        {
            transform.Translate(new Vector3(horizontal * tankSpeedHorizontal, Input.GetAxis("Vertical") * tankSpeedVertical) * Time.deltaTime);
        }
    }

    private void StayIn()  //player dont' move out of the screen
    {
        if (transform.position.x >= boundary_X)
        {
            transform.position = new Vector3(boundary_X, transform.position.y);
        }
        if (transform.position.x <= -boundary_X)
        {
            transform.position = new Vector3(-boundary_X, transform.position.y);
        }
        if (transform.position.y >= boundary_Y)
        {
            transform.position = new Vector3(transform.position.x, boundary_Y);
        }
        if (transform.position.y <= -boundary_Y)
        {
            transform.position = new Vector3(transform.position.x, -boundary_Y);
        }
    }

    public void Damaged(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
     public bool Dead()
    {
        if (_health <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CollectedTripleOrb()
    {
        triple = true;
        deltaTime = 0;
    }
}
