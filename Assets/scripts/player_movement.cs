using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
  
   public float m_speed = 0.7;
   private void Awake()
   {
       m_controller = GetComponent<CharacterController>();
   }

   private void FixedUpdate()
   {
       float horizontal = Input.GetAxisRaw("Horizontal");
       float vertical = Input.GetAxisRaw("Vertical");
       Vector3 move_dir = (horizontal*transform.right) + (vertical * transform.forward);
       m_controller.Move(move_dir * m_speed);
   }
}
