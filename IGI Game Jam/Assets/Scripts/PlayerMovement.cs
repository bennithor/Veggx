using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 10.0F;
    public float rotationSpeed = 400.0f;
    public float bulletSpeed = 10.0f;
    public Transform bullet;
    public int playerNr;
    

    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {
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
            Transform newBullet = Instantiate(bullet);
            newBullet.position = gameObject.transform.position;
            newBullet.rotation = gameObject.transform.rotation;
			newBullet.GetComponent<Bullet>().Init(bulletSpeed);

        }
        


    }
}
