using UnityEngine;
using System.Collections;

public class Container : MonoBehaviour {
   private Occupant innerObject;
   public Occupant Object { get { return this.innerObject; } }
   public bool IsEmpty () {
	 return innerObject == null;
   }
}
