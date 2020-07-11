using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Group_Power : MonoBehaviour
{
   public float numberInGroup = 0;

   public void AddGroup()
   {
       numberInGroup++;
   }

   public void RemoveGroup()
   {
       numberInGroup--;
   }
}
