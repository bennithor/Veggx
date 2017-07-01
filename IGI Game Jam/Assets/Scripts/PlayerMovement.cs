using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 10.0F;
    public float rotationSpeed = 400.0f;
    public float bulletSpeed = 50.0f;
    public Transform bullet;
    

    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {
        float verticalTranslation = Input.GetAxis("Vertical") * speed;
        float horizontalTranslation = Input.GetAxis("Horizontal") * speed;
        float verticalRotation = Input.GetAxis("VerticalRotation");
        float horizontalRotation = Input.GetAxis("HorizontalRotation");
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(-horizontalRotation,-verticalRotation) * 180 / Mathf.PI);


        verticalTranslation *= Time.deltaTime;
        horizontalTranslation *= Time.deltaTime;
        transform.Translate(0, verticalTranslation, 0, Space.World);
        transform.Translate(horizontalTranslation, 0, 0, Space.World);

        if(Input.GetAxisRaw("Fire1") != 0)
        {
            Transform newBullet = Instantiate(bullet);

            newBullet.position = gameObject.transform.position;
            newBullet.rotation = gameObject.transform.rotation;
            newBullet.Translate(newBullet.forward * bulletSpeed * Time.deltaTime);
        }
        


    }
}
