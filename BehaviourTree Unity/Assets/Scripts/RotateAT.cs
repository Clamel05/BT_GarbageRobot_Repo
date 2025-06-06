using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class RotateAT : ActionTask {

		public BBParameter<Transform> targetRobot;

		public LayerMask layerMask;

		public float rotateSpeed;

		public float raycastRange;

        public GameObject laser;



        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//direction of the target
			Vector3 targetDirection = targetRobot.value.position - agent.transform.position;

			//rotation speed
			float rotation = rotateSpeed * Time.deltaTime;

			//Rotates towards the target (the player)
            float distanceToTarget = Vector3.Distance(agent.transform.position, targetRobot.value.position);
            Vector3 newDirection = Vector3.RotateTowards(agent.transform.forward, targetDirection, rotation, distanceToTarget);
			agent.transform.rotation = Quaternion.LookRotation(newDirection);

			//Shows the line of sight of the ray - for testing purposes
			Debug.DrawRay(agent.transform.position, newDirection, Color.red);

			//sets the direction of the raycast
			Vector3 forward = agent.transform.TransformDirection(Vector3.forward);

			//raycast to search for the player
            if (Physics.Raycast(agent.transform.position, forward, raycastRange, layerMask))
			{
				//Debug.Log("hit");

				EndAction(true);
			}

        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}