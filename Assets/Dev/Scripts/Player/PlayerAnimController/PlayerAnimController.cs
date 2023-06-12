using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
   public Animator anim;

   public void SetAnimBool(string key,bool val)
   {
      anim.SetBool(key, val);
   }
}
