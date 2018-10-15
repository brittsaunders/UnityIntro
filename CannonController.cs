using UnityEngine;

public class CannonController : MonoBehaviour
{
    private float moveInc = 0.3f;
    public GameObject CannonBallPrefab;
    public Transform SpawnPoint;
    private float _cannonPower = 25;
    private float _cannonAngle = 0;
    private const float angleInc = 4;

   
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.root.position -= new Vector3(moveInc, 0, 0);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.root.position += new Vector3(moveInc, 0, 0);

        if (Input.GetKeyUp(KeyCode.Space))
            Shoot();

        if (Input.GetKey(KeyCode.UpArrow))
            AngleUp();

        if (Input.GetKey(KeyCode.DownArrow))
            AngleDown();

    }

    public void AngleUp()
    {
        _cannonAngle += angleInc;
        transform.rotation = Quaternion.Euler(0, 0, _cannonAngle);
    }

    public void AngleDown()
    {
        _cannonAngle -= angleInc;
        transform.rotation = Quaternion.Euler(0, 0, _cannonAngle);
    }

    public void Shoot()
    {
        GameObject cannonBall = Instantiate(CannonBallPrefab, SpawnPoint.position, Quaternion.identity);

        Vector3 velocity = (Quaternion.Euler(0, 0, _cannonAngle) * Vector3.right);

        velocity *= _cannonPower;

        Rigidbody2D cannonRidge = cannonBall.GetComponent<Rigidbody2D>();
        cannonRidge.velocity = velocity; 
    }
}
