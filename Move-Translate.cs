// Translate overides the physics continues but not effected by gravity


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translate : MonoBehaviour {
    public float speed = 10.0f;

    // Update is called once per frame
    void Update () {
        moveCharacter(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

    }
    void moveCharacter(Vector2 direction){
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
