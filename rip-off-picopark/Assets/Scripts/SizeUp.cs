using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player;

namespace Player
{
    public class SizeUp : ScriptableObject, IPlayerController
    {
        // declare variables
        private float Growth = 0.1f;
        private bool flip = false;
        public void Execute(GameObject gameObject)
        {
            // get the scale of object. 
            // If <1.5f, special will increase size, using flip increase
            var TargetScale = gameObject.transform.localScale;
            if(!(flip))
            {
                TargetScale = new Vector3(TargetScale.x + Growth, TargetScale.y + Growth, TargetScale.z);
                gameObject.transform.localScale = TargetScale;
                if (gameObject.transform.localScale.x >= 10.0f)
                {
                    flip = true;
                }
            }
            // If >10f, special will decrease size, using flip decrease
            if(flip)
            {
                TargetScale = new Vector3(TargetScale.x - Growth, TargetScale.y - Growth, TargetScale.z);
                gameObject.transform.localScale = TargetScale;
                if (gameObject.transform.localScale.x <= 1.5f)
                {
                    flip = false;
                }
            }
        }
    }
}
