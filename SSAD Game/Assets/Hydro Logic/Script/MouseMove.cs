using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveSpeed = 5f;
    Vector3 targetPos;
    [SerializeField] Transform target;
    public bool isMoving;
    bool keepMovingTowardsTarget;
    GameObject background;
    Collider2D goal;
    SpriteRenderer sr;
    //public Canvas gameWinPanel;
    public bool isGround;
    public bool EnterWater;
    public PlayerController pc;

    // Use this for initialization
    void Start()
    {
        //gameWinPanel.gameObject.SetActive(false);
        //Time.timeScale = 1;
        targetPos = transform.position;
        background = GameObject.FindWithTag("background");
        pc = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        keepMovingTowardsTarget = true;
        EnterWater = false;
    }

    // Update is called once per frame
    void Update()
    {
        startMoving();
        if (!isMoving)
        {
            //checkGoalReached();
        }
    }
    //public void checkGoalReached() {
        //if (goal != null)
        //{
            //if (goal.bounds.Contains(transform.position))
            //{
                //Debug.Log("REACHED");
                //modalPanel.Choice("Do you want to spawn this sphere?");
                //gameWinPanel.gameObject.SetActive(true);

                //Time.timeScale = 0;
            //}
        //}
    //}

    void startMoving(){
        if (Input.GetMouseButtonDown(0)) {
            //Prevent additional movement if character is ardy moving
            if(isMoving==false){
                StartCoroutine(move());
            }
        }
    }

    IEnumerator move()
    {
        //get player state
        GameObject player = GameObject.FindWithTag("Player");
        //get mouseclick position
        Vector3 vect3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        targetPos = Camera.main.ScreenToWorldPoint(vect3);
        targetPos.z = 0;
        if (targetPos.y > -5.5) {
            //if state = liquid lock y axis
            if (pc.GetState() == PlayerController.States.STATES_LIQUID || pc.GetState() == PlayerController.States.STATES_GAS || pc.GetState() == PlayerController.States.STATES_SOLID)
            {
                targetPos.y = transform.position.y;
                Vector3 HitVector = CheckIfHitWall(transform.position, targetPos,"x");
                if (transform.position.x > HitVector.x)
                {
                    sr.flipX = true;
                }
                else
                    sr.flipX = false;
                Debug.Log("StartMoving");
                Vector3 vd = HitVector - transform.position;
                float distance = vd.x;
                if (distance != 0)
                {
                    distance = Mathf.Abs(distance);
                }
                while (distance > 1 && (keepMovingTowardsTarget
                    || (pc.GetState() == PlayerController.States.STATES_LIQUID
                        && pc.GetState() == PlayerController.States.STATES_SOLID)))
                {
                    movetowardCoord(transform.position, HitVector);
                    vd = HitVector - transform.position;
                    distance = vd.x;
                    if (distance != 0)
                    {
                        distance = Mathf.Abs(distance);
                    }
                    yield return null;
                }
                Debug.Log("EndMoving");
            }
            else if (pc.GetState() == PlayerController.States.STATES_CLOUD)
            {
                //Move character by Vector Y
                //Fix Vector X position
                SpriteRenderer sr = background.GetComponent<SpriteRenderer>();
                Debug.Log("asdfasdf" + sr.bounds);
                float yLimit = sr.bounds.center.y;
                float limit = (sr.bounds.extents.y) * 0.5f;
                //Debug.Log(limit);
                yLimit = yLimit + limit;
                Vector3 vecty = new Vector3(transform.position.x,targetPos.y, 0);
                if (vecty.y < yLimit)
                {
                    vecty.y = yLimit;
                }

                Vector3 HitVector = CheckIfHitWall(transform.position, vecty,"y");

                Debug.Log(yLimit + "/" + HitVector);
                if (transform.position.x > HitVector.x)
                {
                    sr.flipX = true;
                }
                else
                    sr.flipX = false;
                Vector3 vd = HitVector - transform.position;
                float distance = vd.y;
                if (distance != 0)
                {
                    distance = Mathf.Abs(distance);
                }

                while (distance > 1 && (keepMovingTowardsTarget 
                    || (pc.GetState() == PlayerController.States.STATES_LIQUID
                        && pc.GetState() == PlayerController.States.STATES_SOLID)))
                {
                    movetowardCoord(transform.position, HitVector);
                    vd = HitVector - transform.position;
                    distance = vd.y;
                    if (distance != 0)
                    {
                        distance = Mathf.Abs(distance);
                    }
                    yield return null;
                }
                //Move character by Vector X
                //Fix Vector Y position
                Vector3 vectx = targetPos;
                vectx.y = transform.position.y;
                HitVector = CheckIfHitWall(transform.position, vectx, "x");
                while (transform.position.x != HitVector.x && (keepMovingTowardsTarget
                    || (pc.GetState() == PlayerController.States.STATES_LIQUID
                        && pc.GetState() == PlayerController.States.STATES_SOLID)))
                {
                    movetowardCoord(transform.position, HitVector);
                    yield return null;
                }
            }

            
            isMoving = false;
        }        
        
    }

    public bool getIsMoving()
    {
        return this.isMoving;
    }
    public void setIsMoving(bool moving)
    {
        this.isMoving = moving ;
    }

    public void movetowardCoord(Vector3 position, Vector3 targetPos){
        isMoving = true;
        transform.position = Vector3.MoveTowards(position, targetPos, moveSpeed * Time.deltaTime);
    }

    public Vector3 CheckIfHitWall(Vector3 transform, Vector3 targetpos, string MoveDirection)
    {

        Vector3 dir = targetpos - transform;

        //Debug.Log(targetpos + "/" + transform + "/" + dir);
        Debug.DrawRay(transform, dir, Color.yellow);
        float direction;
        if (dir.x != 0)
        {
            direction = Mathf.Abs(dir.x);
        }
        else
        {
            direction = Mathf.Abs(dir.y);

        }
       
        RaycastHit2D hits = Physics2D.Raycast(transform, dir, direction+2);
        if (hits == true && hits.collider != null && (hits.collider.gameObject.tag == "Wall" || hits.collider.gameObject.tag == "Ground"))
        {
            Vector3 hitVec = new Vector3(hits.point.x, hits.point.y, 0);
            Debug.Log(hitVec);
            float offset = 0f;
            if (MoveDirection == "x")
            {
                if (transform.x < hitVec.x)
                {
                    //Character hits a wall from left
                    hitVec.x = hitVec.x - offset;
                }
                else
                {
                    //Character hits a wall from right
                    hitVec.x = hitVec.x + offset;
                }
            }
            else if (MoveDirection == "y")
            {
                if (transform.y > hitVec.y)
                {
                    //Character hits a wall from top
                    hitVec.y = hitVec.y + offset;
                }
                else
                {
                    //Character hits a wall from bottom
                    hitVec.y = hitVec.y - offset;
                }
            }
            return hitVec;
        }
        else {
            return targetpos;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Goal")
        {
            goal = other;
        }
        if (other.gameObject.tag == "Water")
        {
            EnterWater = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
         
        if (other.gameObject.tag == "Water")
        {
            EnterWater = false;
            PlayerController.States CurrentState = pc.GetState();
            if (CurrentState == PlayerController.States.STATES_GAS || CurrentState == PlayerController.States.STATES_CLOUD) { 

            }
            else
                rb.gravityScale = 1;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGround = true;
            keepMovingTowardsTarget = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("Collision Exit");
        if(other.gameObject.tag=="Ground"){
            if (EnterWater == true)
            {
                if (pc.GetState() == PlayerController.States.STATES_SOLID)
                {
                    keepMovingTowardsTarget = true;
                    rb.gravityScale = 0;
                }
                else 
                    keepMovingTowardsTarget = false;
            }
            else if (pc.GetState() == PlayerController.States.STATES_GAS || pc.GetState() == PlayerController.States.STATES_CLOUD)
                keepMovingTowardsTarget = true;
            else
                keepMovingTowardsTarget = false;
        }
        if (other.gameObject.tag == "Water") {
            EnterWater = false;
        }
        //Debug.Log("Exit");
    }
    public static bool IsPointWithinCollider(Collider collider, Vector3 point)
    {
        return (collider.ClosestPoint(point) - point).sqrMagnitude < Mathf.Epsilon * Mathf.Epsilon;
    }

}
