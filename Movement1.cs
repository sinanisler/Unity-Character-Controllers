//Moving the character

//1st way to move a character overrides the physics of the 3D game and doesn't affect collisions

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translate : MonoBehaviour
{
 public float speed = 10.0f;

 //Use this for initialization
 void Start()
 {
  
 }
 //Update is called once per frame
 //Update runs once per frame so it's ideal for capturing the keyboard input
 {
  moveCharacter(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
 }
 void moveCharacter(Vector2 direction)
 {
  transform.Translate(direction * speed * Time.deltaTime);
 }
}

//2nd way to move a character involes physics in Unity
//*****REMEMBER TO SET "is kinematic" in the inspector to OFF
//kinematic sets the Rigidbody to accept instructions from code and not consider physics

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translate : MonoBehaviour
{
 public float speed = 10.0f;
 public Rigiddoby rb;
 public Vector2 movement;

 //Use this for initialization
 void Start()
 {
  //If your script is a component (just linked to a gameObject with a rigidbody of its own)
  //then call on this and get its rigidbody component
  rb = this.GetComponent<Rigidbody>();
 }
 //Update is called once per frame
 //Update runs once per frame so it's ideal for capturing the keyboard input
 {
  movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
 }
 //FixedUpdate is run every physics step, so once, none, or many times per frame
 //It's the update you want to use for dealing with instructions related to physics
 //Don't use Update for physics... just FixedUpdate
 void FixedUpdate()
 {
  //this fixedUpdate will handle the pace at which the moveCharacter function is called
  moveCharacter(movement);
 }
 //this is the moveCharacter function that takes the direction determined by your keypress in Update
 //Horizontal left (-1) and right (1) and zero (0) for it's point of departure
 //Vertical up (1) and down (-1) and zero (0) again
 void moveCharacter(Vector2 direction)
 {
  //There is more than one way to move the RigidBody (what we've called rb here)
  //We can use the method RigidBody.AddForce(); to add force to the object
  //This will have a sliding effect
  rb.AddForce(direction * speed);
  //We can instead set the RigidBody's velocity this way RigidBody.velocity;
  //Manipulating the velocity will move an object at a constant rate over time
  //Controlling an object this way overrides physics including gravity but will still have collisions
  rb.velocity = direction * speed;
  //Or we can use RidigBody.movePosition;
  //This may be the best option for moving a character because it works with physics & is more easilty controlled
  //In this case we're only concerned with moving on the X axis so we're using Vector2 and convert this to a x 

and y transformation by adding a (Vector2) before transform and don't forget the brackets
  //If on the other hand you want to move the character on all axis including Z then you don't need the Vector2 variable for movement above and you also don't need to convert this code to adjust it with (Vector2) before transform
  rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
 }
