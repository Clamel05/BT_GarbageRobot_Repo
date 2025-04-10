using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ShootLaserAT : ActionTask {

        public GameObject laser;

        private GameObject spawnedLaser;

        //How long it takes before the laser shoots
        public float shootTimer;
		private float time;

        public GameObject gameObject;


        public float raycastRange;
        public LayerMask playerMask;
        public LayerMask nibblerMask;

        public GameObject nibblerHit;


        //Nibbler spawners for when they are hit
        public GameObject spawner01;
        public GameObject spawner02;
        public GameObject spawner03;
        public GameObject spawner04;

        private int randomSpawn;

        //How long it takes before nibbler respawns
        public float nibblerRespawnTimer;
        private float spawnTime;


        protected override string OnInit() {
			return null;
		}


		protected override void OnExecute() {

            spawnedLaser = MonoBehaviour.Instantiate(laser, agent.transform.position, agent.transform.rotation);

            time = shootTimer;

            spawnTime = nibblerRespawnTimer;

        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

            Vector3 forward = agent.transform.TransformDirection(Vector3.forward);


            //If the laser hits the player
            if (Physics.Raycast(agent.transform.position, forward, raycastRange, playerMask))
            {
                Debug.Log("Dead");
                Application.Quit(); //Ends the game when in build mode
                UnityEditor.EditorApplication.isPlaying = false; // Ends the game when in the editor play mode

                EndAction(true);
            }

            RaycastHit hit;

            //If the laser hits a nibbler
            if (Physics.Raycast(agent.transform.position, forward, out hit, raycastRange, nibblerMask))
            {

                nibblerHit = hit.transform.gameObject;

                //nibblerHit.transform.position -= new Vector3(0,+20,0);


                //spawnTime -= Time.deltaTime;
                //if(spawnTime < 0)
                
                    randomSpawn = Random.Range(1, 4);
                    Debug.Log("random respawn value set");

                    if (randomSpawn == 1)
                    {
                        nibblerHit.transform.position = spawner01.transform.position;
                    }
                    else if (randomSpawn == 2)
                    {
                        nibblerHit.transform.position = spawner02.transform.position;
                    }
                    else if (randomSpawn == 3)
                    {
                        nibblerHit.transform.position = spawner03.transform.position;
                    }
                    else
                    {
                        nibblerHit.transform.position = spawner04.transform.position;
                    }
                
            }



            time -= Time.deltaTime;
            if (time <= 0)
            {
                MonoBehaviour.DestroyImmediate(spawnedLaser, true);
                EndAction(false);
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