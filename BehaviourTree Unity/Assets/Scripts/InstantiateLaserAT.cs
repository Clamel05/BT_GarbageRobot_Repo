using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class InstantiateLaserAT : ActionTask {

		public GameObject laser;

		private GameObject spawnedLaser;

        public float chargeTimer;

		private float time;


        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			//Spawns the laser charge-up object
			spawnedLaser = MonoBehaviour.Instantiate(laser, agent.transform.position, agent.transform.rotation);
            time = chargeTimer;


        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            
			//timer for how long it's active for
            time -= Time.deltaTime;
            if (time <= 0)
            {
				//destroys the object when it's done
				MonoBehaviour.DestroyImmediate(spawnedLaser, true);
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