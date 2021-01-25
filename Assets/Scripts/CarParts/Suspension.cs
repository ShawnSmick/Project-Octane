using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


    [Serializable]
    public class SpringsAndWheels //TODO: Break out more things into the sub classes, its annoying while writing but I feel makes the code more readable as well as make the inspector more useful
    {
        public Transform springBR, springBL, springFL, springFR;//suspension spring locations
        public Transform wheelBR, wheelBL, wheelFL, wheelFR; // public Transform wheelBR, wheelBL, wheelFL, wheelFR;//Wheel positions
    }
    //[RequireComponent(typeof(CarController))]
    public class Suspension : MonoBehaviour
    {
        // Start is called before the first frame update

        public SpringsAndWheels springsandwheels;
        public TrailRenderer brTrail, blTrail, flTrail, frTrail;
        [Tooltip("How much force the spring exerts while fully compressed")]
        public float suspensionForce = 60000f; //how much force the springs impart when fully compressed

        [Tooltip("How long the suspension springs are")]
        public float springDistance = .3f;//Length of springs

        [Tooltip("How far from the ground you can be and still be considered grounded")]
        public float groundDistance = .6f;//How from the ground the car still does car things

        [SerializeField]
        [Tooltip("How much the force pushing down on the suspention when moving forward or back.")]
        private float thrustSpringFactor = 6f;
        [SerializeField]
        [Tooltip("How much the force pushing down on the suspention when turning.")]
        private float turnSpringFactor = 8f;

        public Transform centerOfMass; //where the custom center of mass THIS NEEDS TO BE IN THE CENTER POINT OF SPRINGS...
                                        //TODO: think of a better way to implement center or mass, might be able to calc the xz center based
                                        //on the position of all the springs!
        private Rigidbody carRigidbody;
        // private CarController _car;
        //[Tooltip("How much the force pushing down on the suspention when moving forward or back.")]
        public float wheelOffset = .2f;

        private RaycastHit _springBR, _springBL, _springFR, _springFL;

        void Start()
        {
            brTrail = springsandwheels.wheelBR.GetComponentInChildren<TrailRenderer>();
            blTrail = springsandwheels.wheelBL.GetComponentInChildren<TrailRenderer>();
            flTrail = springsandwheels.wheelFL.GetComponentInChildren<TrailRenderer>();
            frTrail = springsandwheels.wheelFR.GetComponentInChildren<TrailRenderer>();
            carRigidbody = GetComponent<Rigidbody>();
            carRigidbody.centerOfMass = centerOfMass.localPosition;
    }
        public void Update()
        {
            _Suspension();
         }
        public void FixedUpdate()
        {
            //Applies the suspention force to all of the springs!
            SpringForce(springsandwheels.springBL,out _springBL);
            SpringForce(springsandwheels.springBR,out _springBR);
            SpringForce(springsandwheels.springFL,out _springFL);
            SpringForce(springsandwheels.springFR,out _springFR);
        }
        private void SpringForce(Transform spring,out RaycastHit springcast)
        {

            //Check if the spring is contacting the ground
            if (Physics.Raycast(spring.position,-spring.up,out springcast,springDistance))
            {
                Debug.DrawRay(spring.position,-spring.transform.up,Color.green);
                /*
                 * Added force at the position of the spring based on how compressed the spring is
                 * (suspensionForce * (1 - bl.distance / springDistance)) this line is probably jank math
                */
                carRigidbody.AddForceAtPosition(spring.up * (suspensionForce * (1.0f - springcast.distance / springDistance)),spring.position);
                //  wheel.localPosition = new Vector3(wheel.localPosition.x,-(springcast.distance - wheelOffset),wheel.localPosition.z); //Makes the wheel match the spring position
            }
            else
            {
                Debug.DrawRay(spring.position,-spring.transform.up,Color.red);
                //   wheel.localPosition = new Vector3(wheel.localPosition.x,-(springDistance - wheelOffset),wheel.localPosition.z);// if the spring doesn't connect assume the wheel is a full... uh spring
            }
        }
    public void AnimateMovement(float inputx,float inputy,bool boosting)
        {
            /*
             * This code basically just pushes on the springs when you move or turn
            */
            if (inputy > 0)
            {
                SpringPush(springsandwheels.springFL,springsandwheels.springFR,thrustSpringFactor,inputy * (boosting ? 1.25f : 1)); //Push front springs
            }
            if (inputy < 0)
            {
                SpringPush(springsandwheels.springBL,springsandwheels.springBR,thrustSpringFactor,-inputy * (boosting ? 1.25f : 1));//Push back springs
            }
            if (inputx > 0)
            {
                SpringPush(springsandwheels.springBR,springsandwheels.springFR,turnSpringFactor,inputx);//push right springs

            }
            if (inputx < 0)
            {
                SpringPush(springsandwheels.springBL,springsandwheels.springFL,turnSpringFactor,-inputx);//push... you guessed it left springs
            }

        }
        public void SpringPush(Transform spring1,Transform spring2,float springfactor,float input)
        {
            /*
             * Divided the suspension force by a preset number and pushes down on two springs
             * Should theoretically make the animation scale regardless of vehicles... I hope
            */
            carRigidbody.AddForceAtPosition((-spring1.up * suspensionForce / springfactor) * input,spring1.position);
            carRigidbody.AddForceAtPosition((-spring2.up * suspensionForce / springfactor) * input,spring2.position);
        }

        private void _Suspension()
        {
            //Applies the suspention force to all of the springs!
            _SpringForce(springsandwheels.springBL,springsandwheels.wheelBL,blTrail,out _springBL);
            _SpringForce(springsandwheels.springBR,springsandwheels.wheelBR,brTrail,out _springBR);
            _SpringForce(springsandwheels.springFL,springsandwheels.wheelFL,flTrail,out _springFL);
            _SpringForce(springsandwheels.springFR,springsandwheels.wheelFR,frTrail,out _springFR);
        }

        private void _SpringForce(Transform spring,Transform wheel,TrailRenderer trail,out RaycastHit springcast)
        {

            //Check if the spring is contacting the ground
            if (Physics.Raycast(spring.position,-spring.up,out springcast,springDistance))
            {
                Debug.DrawRay(spring.position,-spring.transform.up,Color.green);
            /*
             * Added force at the position of the spring based on how compressed the spring is
             * (suspensionForce * (1 - bl.distance / springDistance)) this line is probably jank math
            */
            //_rb.AddForceAtPosition(spring.up * (suspensionForce * (1.0f - springcast.distance / springDistance)),spring.position);
            float offset = -(springcast.distance - wheelOffset);
            offset = (offset > 0.01f) ? 0.01f : offset;
            wheel.localPosition = new Vector3(wheel.localPosition.x,offset,wheel.localPosition.z); //Makes the wheel match the spring position
            trail.emitting = true;
        }
            else
            {
            trail.emitting = false;
            Debug.DrawRay(spring.position,-spring.transform.up,Color.red);
                wheel.localPosition = new Vector3(wheel.localPosition.x,-(springDistance - wheelOffset),wheel.localPosition.z);// if the spring doesn't connect assume the wheel is a full... uh spring
            }
        }
    }

