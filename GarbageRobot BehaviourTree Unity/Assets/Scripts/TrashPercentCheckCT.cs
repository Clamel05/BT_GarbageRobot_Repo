using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class TrashPercentCheckCT : ConditionTask {
		public BBParameter<float> trashCheck;
        public BBParameter<float> greaterThan1;
        public BBParameter<float> greaterThan2;

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
				return trashCheck.value > greaterThan1.value && trashCheck.value > greaterThan2.value;
		}
	}
}