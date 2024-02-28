using Composite.Core;
using UnityEngine;

namespace App.Features.CameraFocus
{
	public class CameraFocusView : AbstractView
	{
		[SerializeField] public Camera camera;
		[SerializeField] public float cameraOffsetZ;
		[SerializeField] public float padding;
	}
}