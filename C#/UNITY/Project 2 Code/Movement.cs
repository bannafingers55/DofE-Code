// MoveToClickPoint.cs
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    [SerializeField][Range(1, 20)]
    private float Speed;

    private Vector3 targetPosition;
    private bool isMoving;

    const int LEFT_MOUSE_BUTTON = 0;

    public Transform Enemy;
    public int MoveSpeed = 4;
    public int MaxDist = 10;
    public int MinDist = 5;

    private int RandomX;
    private int RandomZ;

    [Range(-50, 50)]
    public float UpperBoundX;
    [Range(-50, 50)]
    public float LowerBoundX;
    [Range(-50, 50)]
    public float UpperBoundZ;
    [Range(-50, 50)]
    public float LowerBoundZ;

    public float SpawnHeight;

    public Transform Player;

    Random rnd = new Random();

    [SerializeField]
    Behaviour[] ComponentsToDisableOnDeath;

    [SerializeField]
    ParticleSystem blood;

    void Start()
    {
        targetPosition = transform.position;
        isMoving = false;
        
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, Enemy.position) <= MaxDist)
        {
            Debug.Log("Within shooting range");
            ////ShootPlayer();
            for (int i = 0; i < ComponentsToDisableOnDeath.Length; i++)
            {
                Debug.Log("Dying");
                ComponentsToDisableOnDeath[i].enabled = false;
            }





        }

        if (Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON))
            SetTargetPosition();
        if (isMoving)
            MovePlayer();


        
        
    }

    void SetTargetPosition ()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;

        if (plane.Raycast(ray, out point))
            targetPosition = ray.GetPoint(point);

        isMoving = true;
    }
    void MovePlayer ()
    {
        transform.LookAt(targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);

        if (transform.position == targetPosition)
            isMoving = false;
        Debug.DrawLine(transform.position, targetPosition, Color.red);
    
    }

    void SpawnPlayerRandomPos ()
    {
        RandomX = Random.Range((int)LowerBoundX, (int)UpperBoundX);

        RandomZ = Random.Range((int)LowerBoundZ, (int)UpperBoundZ);

        Vector3 SpawnPostion = new Vector3(RandomX, SpawnHeight, RandomZ);

        Player.Translate(SpawnPostion);



    }



}
