using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using KinematicMovementSystem;

namespace KinematicMovementSystemEditor
{
    [CustomEditor(typeof(KinematicCharacterMotor))]
	[CanEditMultipleObjects]
    public class KinematicCharacterMotorEditor : Editor
    {
        protected virtual void OnSceneGUI()
        {            /*
            KinematicCharacterMotor motor = (target as KinematicCharacterMotor);
            if (motor)
            {
                Vector3 characterBottom = motor.transform.position + (motor._capsule.center + (-Vector3.up * (motor.Capsule.height * 0.5f)));

                Handles.color = Color.yellow;
                Handles.CircleHandleCap(
                    0, 
                    characterBottom + (motor.transform.up * motor.MaxStepHeight), 
                    Quaternion.LookRotation(motor.transform.up, motor.transform.forward), 
                    motor.Capsule.radius + 0.1f, 
                    EventType.Repaint);
            }*/
        }

        VisualElement _root;

		SerializedObject so => serializedObject;

		string[] _stepHandlingLabels = { "None", "Standard", "Extra" };



		public override void OnInspectorGUI()
		{

			so.Update();

			float leftSpace = 2;
			float inBetweenSpace = 6;

			Color lineColor = new Color(1, 1, 1, 0.1f);



			float lineSpaceBefore = 4f;
			float lineSpaceAfter = 2f;


			GUILayout.Space(2);

			if (so.Foldout("_capsuleFoldout", "Capsule"))
			{

				so.Property("_capsuleRadius", "Radius", leftSpace);
				so.Property("_capsuleHeight", "Height", leftSpace);
				so.Property("_capsuleYOffset", "Y Offset", leftSpace);
				so.Property("_capsulePhysicsMaterial", "Physics Material", leftSpace);

				//UIExtensions.DrawLine(lineColor, 1, lineSpaceBefore, lineSpaceAfter);

			}




			//GUILayout.Space(inBetweenSpace);
			UIExtensions.DrawLine(lineColor, 1, lineSpaceBefore, lineSpaceAfter);


			if (so.Foldout("_groundingSettingsFoldout", "Grounding Settings"))
			{
				so.Property("GroundDetectionExtraDistance", "Detection Extra Distance", leftSpace);
				so.Property("MaxStableSlopeAngle", "Max Stable Slope Angle", leftSpace);
				so.Property("StableGroundLayers", "Stable Ground Layers", leftSpace);
				so.Property("DiscreteCollisionEvents", "Discrete Collision Events", leftSpace);

				//UIExtensions.DrawLine(lineColor, 1, lineSpaceBefore, lineSpaceAfter);
			}

			//GUILayout.Space(inBetweenSpace);
			UIExtensions.DrawLine(lineColor, 1, lineSpaceBefore, lineSpaceAfter);

			if (so.Foldout("_stepsFoldout", "Step Handling"))
			{
				so.Property("StepHandling", "Step Handling Method", leftSpace);

				int step = so.FindProperty("StepHandling").intValue;

				EditorGUI.BeginDisabledGroup(step == 0);

				so.Property("MaxStepHeight", leftSpace);
				so.Property("AllowSteppingWithoutStableGrounding", leftSpace);
				so.Property("MinRequiredStepDepth", leftSpace);

				EditorGUI.EndDisabledGroup();

				//UIExtensions.DrawLine(lineColor, 1, lineSpaceBefore, lineSpaceAfter);
			}



			//GUILayout.Space(inBetweenSpace);
			UIExtensions.DrawLine(lineColor, 1, lineSpaceBefore, lineSpaceAfter);

			if (so.Foldout("_ledgeFoldout", "Ledge Handling"))
			{
				so.Property("LedgeAndDenivelationHandling", "Handle Ledge And Denivelation", leftSpace);


				EditorGUI.BeginDisabledGroup(!so.FindProperty("LedgeAndDenivelationHandling").boolValue);


				so.Property("MaxStableDistanceFromLedge", leftSpace);
				so.Property("MaxVelocityForLedgeSnap", leftSpace);
				so.Property("MaxStableDenivelationAngle", leftSpace);

				EditorGUI.EndDisabledGroup();


				//UIExtensions.DrawLine(lineColor, 1, lineSpaceBefore, lineSpaceAfter);
			}




			//GUILayout.Space(inBetweenSpace);
			UIExtensions.DrawLine(lineColor, 1, lineSpaceBefore, lineSpaceAfter);

			if (so.Foldout("_rigidbodyFoldout", "Rigidbody Settings"))
			{
				so.Property("InteractiveRigidbodyHandling", "Enable Rigidbody Interaction", leftSpace);


				EditorGUI.BeginDisabledGroup(!so.FindProperty("InteractiveRigidbodyHandling").boolValue);

				so.Property("RigidbodyInteractionType", leftSpace);
				so.Property("SimulatedCharacterMass", leftSpace);
				so.Property("PreserveAttachedRigidbodyMomentum", leftSpace);

				EditorGUI.EndDisabledGroup();



				//UIExtensions.DrawLine(lineColor, 1, lineSpaceBefore, lineSpaceAfter);
			}



			//GUILayout.Space(inBetweenSpace);

			UIExtensions.DrawLine(lineColor, 1, lineSpaceBefore, lineSpaceAfter);


			if (so.Foldout("_constraintsFoldout", "Planar Constraint"))
			{
				so.Property("HasPlanarConstraint", "Enable Constraint", leftSpace);

				EditorGUI.BeginDisabledGroup(!so.FindProperty("HasPlanarConstraint").boolValue);


				so.Property("PlanarConstraintAxis", "Constraint Axis", leftSpace);

				EditorGUI.EndDisabledGroup();
				//UIExtensions.DrawLine(lineColor, 1, lineSpaceBefore, lineSpaceAfter);
			}


			//GUILayout.Space(inBetweenSpace);

			UIExtensions.DrawLine(lineColor, 1, lineSpaceBefore, lineSpaceAfter);

			if (so.Foldout("_otherSettingsFoldout", "Other Settings"))
			{



				so.Property("CheckMovementInitialOverlaps", leftSpace);



				so.Property("MaxDecollisionIterations", leftSpace);


				so.Property("MaxMovementIterations", leftSpace);

				EditorGUILayout.BeginHorizontal();

				GUILayout.Space(leftSpace);

				EditorGUILayout.LabelField(new GUIContent("If Max Movement Iterations Exceeded:"), GUILayout.Width(EditorGUIUtility.labelWidth));

				float width = EditorGUIUtility.labelWidth;

				EditorGUIUtility.labelWidth = 100;

				so.ToggleLeft("KillVelocityWhenExceedMaxMovementIterations", " Kill Velocity", 110);
				so.ToggleLeft("KillRemainingMovementWhenExceedMaxMovementIterations", " Kill Remaining Movement", 200);

				EditorGUILayout.EndHorizontal();

				EditorGUIUtility.labelWidth = width;




				//UIExtensions.DrawLine(lineColor, 1, lineSpaceBefore, lineSpaceAfter);

			}



			so.ApplyModifiedProperties();
		}



		/*

        public override VisualElement CreateInspectorGUI()
        {
            SerializedProperty Prop(string name)
            {
                return so.FindProperty(name);
            }



            var root = new VisualElement();

            root.style.flexGrow = 0f;


            var box = new VisualElement();




            Label testLabel = new Label();
            testLabel.text = "Test";
			
 


            Foldout capsuleFoldout = so.CreateFoldout("_capsuleFoldout", "Capsule");

			Length length1 = new Length();

			length1.value = capsuleFoldout.style.fontSize.value.value;
			length1.unit = capsuleFoldout.style.fontSize.value.unit;


			float length = capsuleFoldout.style.fontSize.value.value;

			//capsuleFoldout.contentContainer.SetBorder(1, 5, Color.white);

			//capsuleFoldout.style.paddingLeft = -10;
			//capsuleFoldout.style.marginLeft = 10f;


			//capsuleFoldout.style.left = 0f;

			StyleLength height = new StyleLength();

			height.value = capsuleFoldout.style.fontSize.value;
			height.keyword = capsuleFoldout.style.fontSize.keyword;


			capsuleFoldout.style.fontSize = EditorGUIUtility.singleLineHeight;



			PropertyField capsuleRadius = so.CreateProperty("_capsuleRadius", "Radius");
			PropertyField capsuleHeight = so.CreateProperty("_capsuleHeight", "Height");
			PropertyField capsuleYOffset = so.CreateProperty("_capsuleYOffset", "Y Offset");
			PropertyField capsulePhysicsMaterial = so.CreateProperty("_capsulePhysicsMaterial", "Physics Material");

            
			VisualElement capsuleElement = new VisualElement();

			capsuleElement.style.fontSize = height;


			capsuleElement.Add(capsuleRadius);
			capsuleElement.Add(capsuleHeight);
			capsuleElement.Add(capsuleYOffset);
			capsuleElement.Add(capsulePhysicsMaterial);

			capsuleFoldout.Add(capsuleElement);

			box.Add(capsuleFoldout);

			root.Add(box);

            return root;
		}

		*/


	}



    public static class UIExtensions
    {

		public static bool Foldout(this SerializedObject so, string propertyName, string label)
		{
			SerializedProperty prop = so.FindProperty(propertyName);

			GUIStyle style = new GUIStyle(EditorStyles.foldout);
			style.fontSize += 1;
			style.fontStyle = FontStyle.Bold;

			prop.boolValue = EditorGUILayout.Foldout(prop.boolValue, label, true, style);

			//GUILayout.Space(1);


			return prop.boolValue;
		}

		public static bool HeaderFoldout(this SerializedObject so, string propertyName, string label)
		{
			SerializedProperty prop = so.FindProperty(propertyName);

			GUIStyle style = new GUIStyle(EditorStyles.foldoutHeader);
			style.fontSize += 0;
			style.fontStyle = FontStyle.Bold;
			

			prop.boolValue = EditorGUILayout.BeginFoldoutHeaderGroup(prop.boolValue, label, style);
			EditorGUILayout.EndFoldoutHeaderGroup();

			GUILayout.Space(1);


			return prop.boolValue;
		}



		public static void Property(this SerializedObject so, string propertyName, float leftSpace = 0)
		{
			EditorGUILayout.BeginHorizontal();

			GUILayout.Space(leftSpace);


			EditorGUILayout.PropertyField(so.FindProperty(propertyName));

			EditorGUILayout.EndHorizontal();
		}



		public static void Property(this SerializedObject so, string propertyName, string label, float leftSpace = 0)
		{
			EditorGUILayout.BeginHorizontal();

			GUILayout.Space(leftSpace);

			EditorGUILayout.PropertyField(so.FindProperty(propertyName), new GUIContent(label));

			EditorGUILayout.EndHorizontal();
		}


        public static Foldout CreateFoldout(this SerializedObject so, string propertyName, string label)
        {
			SerializedProperty prop = so.FindProperty(propertyName);

			Foldout foldout = new Foldout();
			foldout.BindProperty(prop);
			foldout.text = label;

			foldout.contentContainer.style.marginLeft = 0f;
			foldout.contentContainer.style.marginRight = 2f;


			return foldout;
		}



		public static void ToggleLeft(this SerializedObject so, string propertyName, string label)
		{
			SerializedProperty prop = so.FindProperty(propertyName);

			//EditorGUILayout.BeginHorizontal();

			//EditorGUILayout.LabelField(GUIContent.none, GUILayout.Width(EditorGUIUtility.labelWidth));
			prop.boolValue = EditorGUILayout.ToggleLeft(label, prop.boolValue);

			//EditorGUILayout.EndHorizontal();
		}

		public static void ToggleLeft(this SerializedObject so, string propertyName, string label, float layoutWidth)
		{
			SerializedProperty prop = so.FindProperty(propertyName);

			GUIContent labelContent = new GUIContent(label, prop.tooltip);

			//EditorGUILayout.BeginHorizontal();

			//EditorGUILayout.LabelField(GUIContent.none, GUILayout.Width(EditorGUIUtility.labelWidth));
			prop.boolValue = EditorGUILayout.ToggleLeft(labelContent, prop.boolValue, GUILayout.Width(layoutWidth));

			//EditorGUILayout.EndHorizontal();
		}


		public static void Toolbar(this SerializedObject so, string propertyName, string[] labels)
		{
			SerializedProperty prop = so.FindProperty(propertyName);

			EditorGUILayout.BeginHorizontal();

			EditorGUILayout.LabelField(GUIContent.none, GUILayout.Width(EditorGUIUtility.labelWidth));

			prop.intValue = GUILayout.Toolbar(prop.intValue, labels);
			EditorGUILayout.EndHorizontal();

		}


		public static void DrawLine(Color lineColor, float height = 1, float spaceBefore = 0f, float spaceAfter = 0f)
		{
			GUILayout.Space(spaceBefore);

			Rect rect = EditorGUILayout.GetControlRect(GUILayout.Height(height));


			EditorGUI.DrawRect(rect, lineColor);
			GUILayout.Space(spaceAfter);


		}

		public static void DrawFullLine(Color lineColor, float height = 1, float spaceBefore = 0f, float spaceAfter = 0f)
		{
			GUILayout.Space(spaceBefore);

			Rect rect = EditorGUILayout.GetControlRect(GUILayout.Height(height));
			rect.x = 0;
			rect.width += 100;

			EditorGUI.DrawRect(rect, lineColor);
			GUILayout.Space(spaceAfter);


		}


		public static PropertyField CreateProperty(this SerializedObject so, string propertyName)
		{
			PropertyField prop = new PropertyField(so.FindProperty(propertyName));

			return prop;
		}

		public static PropertyField CreateProperty(this SerializedObject so, string propertyName, string label)
		{
			PropertyField prop = new PropertyField(so.FindProperty(propertyName));

			prop.label = label;

			return prop;
		}

		public static PropertyField CreateProperty(this SerializedObject so, string propertyName, string label, string tooltip)
		{
			PropertyField prop = new PropertyField(so.FindProperty(propertyName));

			prop.label = label;
			prop.tooltip = tooltip;

			return prop;
		}








		public static void SetBorder(this VisualElement element, float borderWidth, float borderCornerWidth, Color color)
        {
            element.style.borderBottomColor = color;
			element.style.borderLeftColor = color;
			element.style.borderRightColor = color;
			element.style.borderTopColor = color;

            element.style.borderBottomLeftRadius = borderCornerWidth;
            element.style.borderTopLeftRadius = borderCornerWidth;
			element.style.borderBottomRightRadius = borderCornerWidth;
			element.style.borderTopRightRadius = borderCornerWidth;

			element.style.borderLeftWidth = borderWidth;
			element.style.borderTopWidth = borderWidth;
			element.style.borderBottomWidth = borderWidth;
			element.style.borderRightWidth = borderWidth;



		}
    }

}