using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{

    public class NavigateAT : ActionTask
    {


        public BBParameter<SteeringData> steeringData;
        
        public float maxGroundSpeed;

        public BBParameter<Transform> target;


        private bool pause = false;
        public float maxPauseTimer;
        private float pauseTimer = 0;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit()
        {
            return null;
        }

        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
        protected override void OnExecute()
        {
            //maxGroundSpeed = 20;
        }

        //Called once per frame while the action is active.
        protected override void OnUpdate()
        {
            pauseTimer += Time.deltaTime;
            if(pauseTimer >= maxPauseTimer)
            {
                if (pause == false)
                    pause = true;
                else
                    pause = false;

                pauseTimer = 0;
               steeringData.value.acceleration = Vector3.zero;
            }


            if(pause == false)
            {
                steeringData.value.velocity += steeringData.value.acceleration;
                float groundSpeed = Mathf.Sqrt(steeringData.value.velocity.x + steeringData.value.velocity.z);
                if (maxGroundSpeed < groundSpeed)
                {
                    float cappedX = steeringData.value.velocity.x / groundSpeed * maxGroundSpeed;
                    float cappedZ = steeringData.value.velocity.z / groundSpeed * maxGroundSpeed;
                    steeringData.value.velocity = new Vector3(cappedX, steeringData.value.velocity.y, cappedZ);
                }
                agent.transform.position += steeringData.value.velocity * Time.deltaTime;

                steeringData.value.acceleration = Vector3.zero;
            }

            float distanceToTarget = Vector3.Distance(agent.transform.position, target.value.position);
            if (distanceToTarget < steeringData.value.stopDistance)
            {
                EndAction(true);
                return;
            }

        }

        //Called when the task is disabled.
        protected override void OnStop()
        {
            
        }

        //Called when the task is paused.
        protected override void OnPause()
        {

        }
    }
}