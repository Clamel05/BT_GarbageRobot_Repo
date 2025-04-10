using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class NavigateDashAT : ActionTask {

        public BBParameter<Vector3> velocity;
        public BBParameter<Vector3> acceleration;


        public float maxDashSpeed;

        public BBParameter<Transform> target;
        public float stoppingDistance;


        //private bool pause = false;
        //public float maxPauseTimer;
        //private float pauseTimer = 0;

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





                velocity.value += acceleration.value;
                float groundSpeed = Mathf.Sqrt(velocity.value.x * velocity.value.x + velocity.value.z * velocity.value.z);
                if (maxDashSpeed < groundSpeed)
                {
                    float cappedX = velocity.value.x / groundSpeed * maxDashSpeed;
                    float cappedZ = velocity.value.z / groundSpeed * maxDashSpeed;
                    velocity = new Vector3(cappedX, velocity.value.y, cappedZ);
                }
                agent.transform.position += velocity.value * Time.deltaTime;

                acceleration.value = Vector3.zero;

            float distanceToTarget = Vector3.Distance(agent.transform.position, target.value.position);
            if (distanceToTarget < stoppingDistance)
            {
                EndAction(false);
                return;
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