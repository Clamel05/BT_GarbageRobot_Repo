using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class TrashRespawnAT : ActionTask {

        private int randomSpawn;

        public GameObject spawner01;
        public GameObject spawner02;
        public GameObject spawner03;
        public GameObject spawner04;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            randomSpawn = Random.Range(1, 4);

            if (randomSpawn == 1)
            {
                agent.transform.position = spawner01.transform.position;
            }
            else if (randomSpawn == 2)
            {
                agent.transform.position = spawner02.transform.position;
            }
            else if (randomSpawn == 3)
            {
                agent.transform.position = spawner03.transform.position;
            }
            else
            {
                agent.transform.position = spawner04.transform.position;

            }

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