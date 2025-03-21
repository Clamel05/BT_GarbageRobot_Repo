using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SetTrashValuesAT : ActionTask {

		public BBParameter<int> compostPercent;
        public BBParameter<int> garbagePercent;
        public BBParameter<int> recyclePercent;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			garbagePercent.value = Random.Range(0, 100);
			recyclePercent.value = Random.Range(0, garbagePercent.value);
			compostPercent.value = 100 - garbagePercent.value - recyclePercent.value;

			Debug.Log("Garbage Percent " + garbagePercent);
            Debug.Log("Recycling Percent " + recyclePercent);
            Debug.Log("Compost Percent " + compostPercent);

            EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}