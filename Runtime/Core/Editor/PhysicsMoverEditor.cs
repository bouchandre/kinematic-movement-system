using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using KinematicMovementSystem;

namespace KinematicMovementSystemEditor
{

	[CustomEditor(typeof(PhysicsMover))]
	[CanEditMultipleObjects]
	public class PhysicsMoverEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			PhysicsMover physicsMover = (PhysicsMover)target;

			serializedObject.Update();

			serializedObject.Property("MoveWithPhysics");

			serializedObject.ApplyModifiedProperties();

			Editor rbEditor = new Editor();

			UIExtensions.DrawLine(new Color(1, 1, 1, 0.1f), 1 , 3f, 3f);

			CreateCachedEditor(physicsMover.Rigidbody, null, ref rbEditor);

			rbEditor.DrawDefaultInspector();	

		}
	}


}
