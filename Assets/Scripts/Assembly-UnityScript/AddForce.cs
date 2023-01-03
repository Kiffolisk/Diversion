using System;
using UnityEngine;

[Serializable]
public class AddForce : MonoBehaviour
{
	public float forceToAdd;

	public AddForce()
	{
		forceToAdd = 4000f;
	}

	public virtual void OnTriggerEnter(Collider triggerObject)
	{
		float x = triggerObject.attachedRigidbody.velocity.x * 0.5f;
		Vector3 velocity = triggerObject.attachedRigidbody.velocity;
		float num = (velocity.x = x);
		Vector3 vector2 = (triggerObject.attachedRigidbody.velocity = velocity);
		float z = triggerObject.attachedRigidbody.velocity.z * 0.5f;
		Vector3 velocity2 = triggerObject.attachedRigidbody.velocity;
		float num2 = (velocity2.z = z);
		Vector3 vector4 = (triggerObject.attachedRigidbody.velocity = velocity2);
		triggerObject.attachedRigidbody.AddForce(transform.up * forceToAdd);
	}

	public virtual void Main()
	{
	}
}
