using UnityEngine;

public class RightSpaceShip : MonoBehaviour
{

    private float moveInc = 0.1f;
    public GameObject Ammo;
    public Transform Spawn;
    private float AmmoPower = 15;
    private float MorePower = 25;
    private float Angle = -20;

    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.root.position -= new Vector3(moveInc, 0, 0);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.root.position += new Vector3(moveInc, 0, 0);

        if (Input.GetKey(KeyCode.UpArrow))
            transform.root.position += new Vector3(0, moveInc, 0);

        if (Input.GetKey(KeyCode.DownArrow))
            transform.root.position -= new Vector3(0, moveInc, 0);

        if (Input.GetKeyUp(KeyCode.Comma))
            ShootAmmo(AmmoPower);

        if (Input.GetKeyUp(KeyCode.Period))
        {
            ShootAmmo(MorePower);
        }

    }

    public void ShootAmmo(float Power)
    {
        GameObject AmmoLazer = Instantiate(Ammo, Spawn.position, Quaternion.identity);

        Vector3 velocity = (Quaternion.Euler(0, 0, Angle) * Vector3.left);

        velocity *= Power;

        Rigidbody2D shipRidge = AmmoLazer.GetComponent<Rigidbody2D>();
        shipRidge.velocity = velocity;

        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
