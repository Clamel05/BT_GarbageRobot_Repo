using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


namespace NodeCanvas.Tasks.Actions {

	public class DashAT : ActionTask {

        

        public LayerMask trashLayer;
        public float detectionRadius;
        public BBParameter<Transform> detectionTarget;

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
            Transform bestTarget = null;
            float bestValue = Mathf.Infinity;

            Collider[] detectedTrashColliders = Physics.OverlapSphere(agent.transform.position, detectionRadius, trashLayer);
            foreach (Collider detectedTrash in detectedTrashColliders)
            {
                float distanceToThief = Vector3.Distance(detectedTrash.transform.position, agent.transform.position);

                if (bestValue > distanceToThief)
                {
                    bestTarget = detectedTrash.transform;
                    bestValue = distanceToThief;

                }

            }
            detectionTarget.value = bestTarget;
            EndAction(true);
 
        }

        //Called when the task is disabled.
		protected override void OnStop() {
            Object.Destroy(detectionTarget.value);
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}