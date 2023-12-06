using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KinematicMovementSystem
{
	public interface ICharacterExtra
	{

		/// <summary>
		/// This is called before the motor does anything
		/// </summary>
		void BeforeCharacterUpdate(float deltaTime);

		/// <summary>
		/// This is called after the motor has finished its ground probing, but before PhysicsMover/Velocity/etc.... handling
		/// </summary>
		void PostGroundingUpdate(float deltaTime);

		/// <summary>
		/// This is called after the motor has finished everything in its update
		/// </summary>
		void AfterCharacterUpdate(float deltaTime);

		/// <summary>
		/// This is called after when the motor wants to know if the collider can be collided with (or if we just go through it)
		/// </summary>
		bool IsColliderValidForCollisions(Collider coll);

		/// <summary>
		/// This is called after every move hit, to give you an opportunity to modify the HitStabilityReport to your liking
		/// </summary>

		void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, Vector3 atCharacterPosition, Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport);
		/// <summary>
		/// This is called when the character detects discrete collisions (collisions that don't result from the motor's capsuleCasts when moving)
		/// </summary>
		void OnDiscreteCollisionDetected(Collider hitCollider);
	}
}