using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class FlashAT : ActionTask {

        public MeshRenderer meshRenderer;
        public Color flashColour;
        public Color baseColour;

        public float chargeTime;
		private float timer = 0;

        public float maxFlashTimer;
        private float flashTimer;

		private bool turnBlue;
		private bool turnWhite = false;

		public BBParameter <float> chargeSpeed;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            meshRenderer.material.color = flashColour;

			chargeSpeed.value = 2;
            
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			

			/*flashTimer = maxFlashTimer;
			flashTimer -= Time.deltaTime;
			if(flashTimer == 0 )
			{
				if (turnWhite == false)
                    turnWhite = true;
                else
                    turnWhite = false;
            }*/

            if (turnWhite == false)
                turnWhite = true;
            else
                turnWhite = false;

            if (turnWhite == true)
            {
                meshRenderer.material.color = flashColour;
            }
            else
                meshRenderer.material.color = baseColour;






            timer += Time.deltaTime;
            if (timer >= chargeTime)
			{
                EndAction(false);
            }
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
            meshRenderer.material.color = baseColour;
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}