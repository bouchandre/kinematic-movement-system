using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KinematicMovementSystem
{
    public interface ICharacterController
    {
        /// <summary>
        /// This is called when the motor wants to know what its rotation should be right now
        /// </summary>
        
        void UpdateRotation(ref Quaternion currentRotation, float deltaTime);
        
        /// <summary>
        /// This is called when the motor wants to know what its velocity should be right now
        /// </summary>
        void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime);
        
        /// <summary>
        /// This is called when the motor's ground probing detects a ground hit
        /// </summary>
        //void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport);

		void OnGroundHit(GroundReport ground);




		/// <summary>
		/// This is called when the motor's movement logic detects a hit
		/// </summary>
		void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport);
        
    }
}