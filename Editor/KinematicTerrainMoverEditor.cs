using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using KinematicMovementSystem;

namespace KinematicMovementSystem.Editor
{

	[CustomEditor(typeof(KinematicPhysicsMover))]
	[CanEditMultipleObjects]
	public class TerrainMoverEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			KinematicPhysicsMover physicsMover = (KinematicPhysicsMover)target;

			serializedObject.Update();

			serializedObject.Property("MoveWithPhysics");

			serializedObject.ApplyModifiedProperties();

			UnityEditor.Editor rbEditor = new UnityEditor.Editor();

			UIExtensions.DrawLine(new Color(1, 1, 1, 0.1f), 1 , 3f, 3f);

			CreateCachedEditor(physicsMover.Rigidbody, null, ref rbEditor);

			rbEditor.DrawDefaultInspector();	

		}
	}


}
