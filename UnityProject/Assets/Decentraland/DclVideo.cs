using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dcl
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(DclCustomNode))]
	public class DclVideo : MonoBehaviour {

		public float width = 1.98f;
		public float height = 1.08f;
		public string src;
		public bool play = true;
		public float volume = 20f;

		private bool sizeChange = false;
		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () {
			if (sizeChange) {
				sizeChange = false;
				SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
				if (spriteRenderer != null) {
					spriteRenderer.size = new Vector2 (1.28f*width / 1.98f, 0.64f*height / 1.08f);
				}
			}
		}

		void OnValidate()
		{
			DclCustomNode node = gameObject.GetComponent<DclCustomNode>();
			if (node == null) {
				return;
			}
			node.setProperty ("width", "{" + width + "}");
			node.setProperty ("height", "{" + height + "}");
			node.setProperty ("src", "\"" + src + "\"");
			node.setProperty ("play", "{" + (play ? "true" : "false") + "}");
			node.setProperty ("volume", "{" + volume + "}");

			sizeChange = true;
		}
	}
}

