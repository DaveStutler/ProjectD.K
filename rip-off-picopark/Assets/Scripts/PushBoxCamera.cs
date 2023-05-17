using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <citing>
/// reference from exercise 2, from dr. McKoy
/// </citing>


namespace CameraMovement
{
    public class PushBoxCamera : AbstractCamera
    {
        /// <topLeft>
        /// x = -15 y = 7
        /// </topLeft>
        /// <bottomRight>
        /// x = 15 y = -7
        /// </bottomRight>
        [SerializeField] public Vector2 topLeft;
        [SerializeField] public Vector2 bottomRight;
       
        private Camera managedCamera;
        private LineRenderer cameraLineRenderer;


        private void Awake()
        {
            managedCamera = gameObject.GetComponent<Camera>();
            cameraLineRenderer = gameObject.GetComponent<LineRenderer>();
            // players starting position
            this.Target1.transform.position = new Vector3(18f, 3f, 0f);
            this.Target2.transform.position = new Vector3(15f, 3f, 0f);
            this.Target3.transform.position = new Vector3(12f, 3f, 0f);
            // Set camera to perspective
            Camera.main.orthographic = false;
            managedCamera.transform.position = new Vector3(15f, 8f, -30f);
        }


        //Use the LateUpdate message to avoid setting the camera's position before
        //GameObject locations are finalized.
        void Update()
        {
            var target1Position = this.Target1.transform.position; // pink
            var target2Position = this.Target2.transform.position; // yellow
            var target3Position = this.Target3.transform.position; // blue
            // saving old camera position
            var cameraPosition = managedCamera.transform.position;

            var cameraRightEdge = cameraPosition.x + bottomRight.x;
            var cameraLeftEdge = cameraPosition.x + topLeft.x;
           
            // right side movement
            if (target1Position.x >= cameraRightEdge)
            {
                // Debug.Log("target1Position.x " + target1Position.x);
                if (( target2Position.x > cameraLeftEdge ) && ( target3Position.x > cameraLeftEdge ))
                {    
                    // Debug.Log("2 inside");
                    cameraPosition = new Vector3(target1Position.x - bottomRight.x, cameraPosition.y, cameraPosition.z);
                }
                else if (!(( target2Position.x > cameraLeftEdge ) && ( target3Position.x > cameraLeftEdge )))
                {
                    // Debug.Log("1 is locked");
                    Target1.transform.position = new Vector3(cameraRightEdge, Target1.transform.position.y, Target1.transform.position.z);
                }
            }
            if (target2Position.x >= cameraRightEdge)
            {
                // Debug.Log("target2Position.x " + target2Position.x);
                if (( target1Position.x > cameraLeftEdge ) && ( target3Position.x > cameraLeftEdge ))
                {    
                    // Debug.Log("2 inside");
                    cameraPosition = new Vector3(target2Position.x - bottomRight.x, cameraPosition.y, cameraPosition.z);
                }
                else if (!(( target1Position.x > cameraLeftEdge ) && ( target3Position.x > cameraLeftEdge )))
                {
                    // Debug.Log("2 is locked");
                    Target2.transform.position = new Vector3(cameraRightEdge, Target2.transform.position.y, Target2.transform.position.z);
                }
            }
            if (target3Position.x >= cameraRightEdge)
            {
                // Debug.Log("target3Position.x " + target3Position.x);
                if (( target1Position.x > cameraLeftEdge ) && ( target2Position.x > cameraLeftEdge ))
                {    
                    // Debug.Log("2 inside");
                    cameraPosition = new Vector3(target3Position.x - bottomRight.x, cameraPosition.y, cameraPosition.z);
                }
                else if (!(( target1Position.x > cameraLeftEdge ) && ( target2Position.x > cameraLeftEdge )))
                {
                    // Debug.Log("3 is locked");
                    Target3.transform.position = new Vector3(cameraRightEdge, Target3.transform.position.y, Target3.transform.position.z);
                }
            }
            if (target1Position.x <= cameraLeftEdge)
            {
                // Debug.Log("target 1 Position.x less " + target1Position.x);
                if (( target2Position.x < cameraRightEdge ) && ( target3Position.x < cameraRightEdge ))
                {    
                    // Debug.Log("2 inside");
                    cameraPosition = new Vector3(target1Position.x - topLeft.x, cameraPosition.y, cameraPosition.z);
                }
                else if (!(( target2Position.x < cameraRightEdge ) && ( target3Position.x < cameraRightEdge )))
                {
                    // Debug.Log("1 is locked");
                    Target1.transform.position = new Vector3(cameraLeftEdge, Target1.transform.position.y, Target1.transform.position.z);
                }
            }
            if (target2Position.x <= cameraLeftEdge)
            {
                // Debug.Log("target 2 Position.x less " + target2Position.x);
                if (( target1Position.x < cameraRightEdge ) && ( target3Position.x < cameraRightEdge ))
                {    
                    // Debug.Log("2 inside");
                    cameraPosition = new Vector3(target2Position.x - topLeft.x, cameraPosition.y, cameraPosition.z);
                }
                else if (!(( target1Position.x < cameraRightEdge ) && ( target3Position.x < cameraRightEdge )))
                {
                    // Debug.Log("1 is locked");
                    Target2.transform.position = new Vector3(cameraLeftEdge, Target2.transform.position.y, Target2.transform.position.z);
                }
            }
            if (target3Position.x <= cameraLeftEdge)
            {
                // Debug.Log("target 3 Position.x less " + target3Position.x);
                if (( target1Position.x < cameraRightEdge ) && ( target2Position.x < cameraRightEdge ))
                {    
                    // Debug.Log("2 inside");
                    cameraPosition = new Vector3(target3Position.x - topLeft.x, cameraPosition.y, cameraPosition.z);
                }
                else if (!(( target1Position.x < cameraRightEdge ) && ( target2Position.x < cameraRightEdge )))
                {
                    // Debug.Log("1 is locked");
                    Target3.transform.position = new Vector3(cameraLeftEdge, Target3.transform.position.y, Target3.transform.position.z);
                }
            }
           


            managedCamera.transform.position = cameraPosition;


            if (this.DrawLogic)
            {
                cameraLineRenderer.enabled = true;
                DrawCameraLogic();
            }
            else
            {
                cameraLineRenderer.enabled = false;
            }
        }


        public override void DrawCameraLogic()
        {
            var z = this.Target1.transform.position.z - this.managedCamera.transform.position.z;


            cameraLineRenderer.positionCount = 5;
            cameraLineRenderer.useWorldSpace = false;
            cameraLineRenderer.SetPosition(0, new Vector3(topLeft.x, topLeft.y, z));
            cameraLineRenderer.SetPosition(1, new Vector3(bottomRight.x, topLeft.y, z));
            cameraLineRenderer.SetPosition(2, new Vector3(bottomRight.x, bottomRight.y, z));
            cameraLineRenderer.SetPosition(3, new Vector3(topLeft.x, bottomRight.y, z));
            cameraLineRenderer.SetPosition(4, new Vector3(topLeft.x, topLeft.y, z));
        }
    }
}
