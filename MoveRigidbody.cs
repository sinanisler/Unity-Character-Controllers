using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbmovement : MonoBehaviour {
    public float speed = 10.0f;
    public Rigidbody rb;
    public Vector2 movement;

    // Use this for initialization
    void Start () {
        rb = this.GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update () {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    void FixedUpdate(){
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction){
        //insert one of the 3 types of movement here
    }
}



// Alternative  AddForce
// AddForce gives Force to the Object like Engine doest good for racing or similar concepts.
// Usefull if you need physics but useless if you are controlling character
void moveCharacter(Vector2 direction){
    rb.AddForce(direction * speed);
}



// Alternative  Velocity
// Velocity gives speed to the object. Alters gravity but works with collisions.
void moveCharacter(Vector2 direction){
    rb.velocity = direction * speed;
}



// Alternative  MovePosition
// MovePosition works like translate continues movement and speed. Works with gravity and collisions. 
// Best for rigid character movement.

void moveCharacter(Vector2 direction){
    rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
}

