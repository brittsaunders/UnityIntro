using UnityEngine;

public class LeftSpaceShip : MonoBehaviour
{

    private float moveInc = 0.1f;
    public GameObject Ammo;
    public Transform Spawn;
    private float AmmoPower = 15;
    private float MorePower = 25;
    private float Angle = 20;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            transform.root.position -= new Vector3(moveInc, 0, 0);

        if (Input.GetKey(KeyCode.D))
            transform.root.position += new Vector3(moveInc, 0, 0);

        if (Input.GetKey(KeyCode.W))
            transform.root.position += new Vector3(0, moveInc, 0);

        if (Input.GetKey(KeyCode.S))
            transform.root.position -= new Vector3(0, moveInc, 0);

        if (Input.GetKeyUp(KeyCode.F1))
        {
            ShootAmmo(AmmoPower);
        }

        if (Input.GetKeyUp(KeyCode.F2))
        {
            ShootAmmo(MorePower);
        }
    }

    public void ShootAmmo(float Power)
    {
        GameObject AmmoLazer = Instantiate(Ammo, Spawn.position, Quaternion.identity);

        Vector3 velocity = (Quaternion.Euler(0, 0, Angle) * Vector3.right);

        velocity *= Power;

        Rigidbody2D shipRidge = AmmoLazer.GetComponent<Rigidbody2D>();
        shipRidge.velocity = velocity;

        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
