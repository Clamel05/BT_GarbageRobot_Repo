using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class RotateAT : ActionTask {

		public BBParameter<Transform> target;

		public float rotateSpeed = 1.0f;

		private Quaternion lookRotation;
		private Vector3 direction;

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
			/*Vector3 targetDirection = target.value.position - agent.transform.position;

			float singlestep = rotateSpeed * Time.deltaTime;

			Vector3 newDirection = Vector3.RotateTowards(agent.transform.forward, targetDirection, singlestep, 0.0f);

			Debug.DrawRay(agent.transform.position, newDirection, Color.red);

			agent.transform.rotation = Quaternion.LookRotation(newDirection);*/

			direction = (target.value.position - agent.transform.position).normalized;

			lookRotation = Quaternion.LookRotation(direction);

			agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, lookRotation, Time.deltaTime * rotateSpeed);





		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}