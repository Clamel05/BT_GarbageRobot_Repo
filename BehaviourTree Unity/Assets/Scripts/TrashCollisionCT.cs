using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class TrashCollisionCT : ConditionTask {

        public LayerMask laserLayer;
        int collidersFound;

        Collider[] collidersInsideOverlap = new Collider[1];

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
            //Overlap box to test if the player collides with the laser
            collidersFound = Physics.OverlapBoxNonAlloc(agent.transform.position, agent.transform.localScale, collidersInsideOverlap, Quaternion.identity, laserLayer);

            //Returns when the player has collided with the laser
            return collidersFound > 0;
        }
	}
}