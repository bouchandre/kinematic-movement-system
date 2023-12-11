using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using KinematicMovementSystem;

namespace KinematicMovementSystemEditor
{

	[CustomEditor(typeof(TerrainMover))]
	[CanEditMultipleObjects]
	public class TerrainMoverEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			TerrainMover physicsMover = (TerrainMover)target;

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
