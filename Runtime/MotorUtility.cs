
using UnityEngine;


namespace KinematicMovementSystem.Utility
{
    public static class MotorUtility
    {

        public static float SlopeAngleGlobal(this Vector3 groundNormal, Vector3 characterUp)
        {
			return Vector3.Angle(groundNormal, characterUp);
		}

        public static float SlopeAngleForward(this Vector3 groundNormal, Vector3 characterUp, Vector3 characterRight)
        {
			return Vector3.Angle(-characterUp, Vector3.Cross(characterRight, groundNormal)) - 90;
		}

        public static float SlopeDirectionGlobal(this Vector3 groundNormal)
		{
			return Mathf.Atan2(-groundNormal.x, -groundNormal.z) * Mathf.Rad2Deg;
		}


		public static void CalculateSlopeValues(ref this GroundReport report, Vector3 characterUp, Vector3 characterRight, Quaternion rotation)
		{
			report.SlopeAngleGlobal = Vector3.Angle(report.CapsuleNormal, characterUp);
			report.SlopeAngleForward = Vector3.Angle(-characterUp, Vector3.Cross(characterRight, report.CapsuleNormal)) - 90;
			report.SlopeDirectionGlobal = Mathf.Atan2(-report.CapsuleNormal.x, -report.CapsuleNormal.z) * Mathf.Rad2Deg;
			report.SlopeDirectionLocal = Mathf.DeltaAngle(rotation.eulerAngles.y, report.SlopeDirectionGlobal);





		}




	}




}

