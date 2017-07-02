using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 10.0F;
    public float rotationSpeed = 400.0f;
    public float bulletSpeed = 20.0f;
    public float fireRate = 0.15f;
    public Transform bullet;
    public int playerNr;
    bool canFire = true;
    float fireTimer = 0.0F;
    int size;

    public AudioClip growth;
    AudioSource growthSoundPlayer;
    public AudioClip hit;

    Color playerCol;

    // Use this for initialization
    void Start () {
        size = 3;
        gameObject.name = "Player" + playerNr;
        playerCol = gameObject.GetComponent<SpriteRenderer>().color;

        growthSoundPlayer = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        fireTimer += Time.deltaTime;
        if(fireTimer >= fireRate )
        {
            canFire = true;
        }

        float verticalTranslation = Input.GetAxis("Vertical" + playerNr) * speed;
        float horizontalTranslation = Input.GetAxis("Horizontal" + playerNr) * speed;
        float verticalRotation = Input.GetAxis("VerticalRotation" + playerNr);
        float horizontalRotation = Input.GetAxis("HorizontalRotation" + playerNr);
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(-horizontalRotation,-verticalRotation) * 180 / Mathf.PI);


        verticalTranslation *= Time.deltaTime;
        horizontalTranslation *= Time.deltaTime;
        transform.Translate(0, verticalTranslation, 0, Space.World);
        transform.Translate(horizontalTranslation, 0, 0, Space.World);



        if(Input.GetAxisRaw("Fire" + playerNr) != 0)
        {
            if (canFire)
            {
                fireRate = 0.15f;
                bulletSpeed = 20.0f;
                Transform newBullet = Instantiate(bullet);
                newBullet.position = gameObject.transform.position;
                newBullet.rotation = gameObject.transform.rotation;
                newBullet.tag = playerNr.ToString();
                Vector3 bulletScale = newBullet.transform.localScale;

                newBullet.GetComponent<SpriteRenderer>().color = playerCol;

                if (size > 3)
                {
                    bulletSpeed -= (size - 3) * 0.2f;
                    bulletScale.x += (size - 3) * 0.1f;
                    bulletScale.y += (size - 3) * 0.1f;
                    bulletScale.z += (size - 3) * 0.1f;
                    //fireRate += (size - 3) * 0.05f;
                }

                newBullet.transform.localScale = bulletScale;
                newBullet.GetComponent<Bullet>().Init(bulletSpeed);
                

                canFire = false;
                fireTimer = 0.0f;
            }
        }

    }

    public void SizeReductionAndDeath()
    {
        growthSoundPlayer.PlayOneShot(hit, 1);
        size -= 1;
        if(size < 1)
        {
            GameObject.Find("ScriptObject").GetComponent<PlayerSpawner>().currentPlayers[playerNr - 1] = true;
            Destroy(gameObject);
        }
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x -= 0.24f;
        currentScale.y -= 0.3f;
        currentScale.z -= 0.3f;
        gameObject.transform.localScale = currentScale;
        speed += 0.5f;
    }

    public void AddSize()
    {
        size += 1;
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x += 0.24f;
        currentScale.y += 0.3f;
        currentScale.z += 0.3f;
        gameObject.transform.localScale = currentScale;
        if(!(speed <= 1))
        {
            speed -= 0.5f;
        }

        //growthSoundPlayer.PlayOneShot(growth, 1);
        

    }

    public int GetSize()
    {
        return size;
    }
}
