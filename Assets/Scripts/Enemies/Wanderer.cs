using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using Random = UnityEngine.Random;


public class Wanderer : MonoBehaviour
{
    public float speed = 6.0f;

    // Radians/s
    public float turnSpeed = 1.0f;
    public float obstacleRange = 5.0f;

    public int minX = 0;
    public int maxX = 10;
    public int minZ = 0;
    public int maxZ = 10;

    public float seekDistance = 30.0f;

    private float rayRadius = 0.75f;

    private Being being;

    public GameObject targetBall;
    public GameObject wanderTarget;

    public GameObject heldBall;

    public Transform throwFrom;

    public enum WandererMode
    {
        Wandering,
        Targeting,
        Searching,
        Throwing,
        Disabled
    }

    public EnemyManager manager;

    public WandererMode staringMode = WandererMode.Searching;
    private WandererMode mode;

    void Start()
    {
        being = GetComponent<Being>();
        mode = staringMode;
    }

    public void changeMode(WandererMode newMode)
    {
        if (newMode == mode) return;
        // For now
        if (mode == WandererMode.Wandering) return; //throw new Exception("Cannot stop wandering early");

        if (newMode != WandererMode.Wandering)
            GetComponent<AICharacterControl>().target = null;
        switch (newMode)
        {
            case WandererMode.Wandering:
                StartCoroutine(wanderForAWhile());
                break;
            case WandererMode.Targeting:
                break;
            case WandererMode.Searching:
                break;
            case WandererMode.Throwing:
                break;
            case WandererMode.Disabled:
                break;
            default:
                throw new ArgumentOutOfRangeException("newMode", newMode, null);
        }

        //Debug.LogFormat("Changing mode to {0}", newMode);
        mode = newMode;
    }

    public bool TakeBall(Transform ball)
    {
        if (heldBall != null) return false;

        var handLocation = GetComponent<Taker>().handLocation;
        var rigidbody = ball.GetComponent<Rigidbody>();
        targetBall = null;
        ball.tag = "heldball";
        ball.position = handLocation.position;
        rigidbody.isKinematic = false;
        rigidbody.useGravity = false;
        
        heldBall = ball.gameObject;

        GetComponent<AICharacterControl>().target = null;
        
        manager.zone.RemoveBall(ball.gameObject);
        return true;
    }
    

    void debugOutput()
    {
        Debug.LogFormat("name: {0}", gameObject.name);
        Debug.LogFormat("mode: {0}", mode);
        Debug.LogFormat("wanderTarget: {0}", wanderTarget);
        Debug.LogFormat("targetBall: {0}", targetBall);
        Debug.LogFormat("heldBall: {0}", heldBall);
        Debug.Log("--------------------------------");
    }

    void die()
    {
        manager.removeEnemy(gameObject);
    }
    
    void Update()
    {
        //debugOutput();
        if (being && !being.Alive)
        {
            die();        
        }

        var controller = GetComponent<AICharacterControl>();
        if (heldBall != null && mode != WandererMode.Throwing)
        {
            heldBall.transform.position = GetComponent<Taker>().handLocation.position;
            changeMode(WandererMode.Targeting);
            controller.target = null;
            targetBall = null;
        }

        switch (mode)
        {
            case WandererMode.Disabled:
                // Probably bad practice
                return;
            case WandererMode.Wandering:
                // Wandering Complete(ish)
                if (wanderTarget == null)
                    getNextWanderPoint();


                controller.target = wanderTarget.transform;
                 
                break;

            case WandererMode.Searching:
                if (targetBall == null)
                {
                    // There aren't any valid balls in play
                    if (!getNextBall())
                    {
                       changeMode(WandererMode.Wandering); 
                    }
                }
                else
                {
                    // Balls being picked up by other ai when
                    controller.target = targetBall.transform;
                }

                break;

            case WandererMode.Targeting:
                var target = GameObject.FindGameObjectWithTag("Player").transform;

                var ray = new Ray(throwFrom.position, throwFrom.forward);
                var hitObject = new RaycastHit();
                var hit = Physics.Raycast(ray, out hitObject);

                // Looking at player
                if (hit && hitObject.transform.gameObject.CompareTag("Player"))
                {
                    Debug.Log("Hit player, calling throw");
                    if(heldBall != null)
                        throwBall();
                    //else
                    //    changeMode(WandererMode.Wandering);
                }
                else // Turn to look at player
                {
                    Vector3 direction = target.position - transform.position;
                    float step = turnSpeed * Time.deltaTime;
                    Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, step, 0.0f);

                    transform.rotation = Quaternion.LookRotation(newDirection);

                }
                
                break;
            case WandererMode.Throwing:
                if(heldBall != null)
                    throwBall();
                else
                    changeMode(WandererMode.Wandering);
                break;
        }
    }

    private IEnumerator wanderForAWhile(int maxTime = 5)
    {
        yield return new WaitForSeconds(Random.Range(0, maxTime));

        mode = WandererMode.Searching;
    }

    private void throwBall()
    {
        // Move to chest
        heldBall.transform.position = throwFrom.position;
        heldBall.transform.rotation = throwFrom.rotation;

        // Get ball physics component
        var rigidbody = heldBall.GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        rigidbody.useGravity = true;

        // Calculate force
        var force = new Vector3(0, 0.2f, 1);
        force = Vector3.Scale(force, throwFrom.forward);
        var throwForce = 25.0f;
        force *= throwForce;

        //Throw
        rigidbody.velocity = force;

        heldBall.tag = "ball";
        heldBall.GetComponent<Ball>().taken = false;
        heldBall.GetComponent<Damage>().onThrown();
        heldBall = null;

        changeMode(WandererMode.Wandering);
    }

    private IEnumerator turnAndThrow()
    {
        var target = GameObject.FindGameObjectWithTag("Player").transform;
        while (true)
        {
            // Check if close to player, wait a short time if not, and throw when close
        }
    }

    private bool getNextBall()
    {
        var balls = GameObject.FindGameObjectsWithTag("ball");

        if (balls.Length > 0)
        {
            // Random could be outside the map
            //targetBall = balls[Random.Range(0, balls.Length)];
            targetBall = manager.zone.getRandomBall();
            if (targetBall == null) return false;
            
            targetBall.tag = "claimedball";
            
            return true;
        }
        else
        {
            return false;
        }

    }

    private void getNextWanderPoint()
    {
        GameObject obj = new GameObject();
        var collider = obj.AddComponent<BoxCollider>();
        collider.isTrigger = true;
        collider.size = new Vector3(1, 5, 1);

        obj.AddComponent<WanderTarget>();

        obj.transform.position = new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
        wanderTarget = obj;
    }
}
