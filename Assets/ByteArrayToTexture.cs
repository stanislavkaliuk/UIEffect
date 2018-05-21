using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ByteArrayToTexture : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{
		Test2 ();
	}

	Color[] colorArray = new Color[2048*2048];
//	public Texture2D texture;
//	public int resolution;
//	public Vector2 dimension;

//	public void FloatTexture (Color[] array)
//	{
//		resolution = (int)Utils.GetNearestPowerOfTwo (Mathf.Sqrt (array.Length));
//		texture = new Texture2D (resolution, resolution, TextureFormat.RGBAFloat, false);
//		texture.filterMode = FilterMode.Point;
//		colorArray = new Color[resolution * resolution];
//		dimension = new Vector2 (resolution, resolution);
//		PrintColor (array);
//	}
//
//	public void PrintColor (Color[] array)
//	{
//		if (texture != null) {
//			for (int i = 0; i < array.Length; ++i) {
//				colorArray [i].r = array [i].r;
//				colorArray [i].g = array [i].g;
//				colorArray [i].b = array [i].b;
//				colorArray [i].a = array [i].a;
//			}
//			texture.SetPixels (colorArray);
//			texture.Apply ();
//		}
//	}


	public RenderTexture rt;
	public Texture2D t;
	public Camera cam;

	public RawImage tag;

	CommandBuffer buf;

	public Mesh m;

	public void hoge()
	{
		for (int i = 0; i < colorArray.Length; ++i) {
			colorArray [i].r = Random.value;
			colorArray [i].g = Random.value;
			colorArray [i].b = Random.value;
			colorArray [i].a = 1;
		}
	}

	public void Test2 ()
	{
		hoge ();

		if (t == null) {
			t = new Texture2D (2048, 2048, TextureFormat.ARGB32, false, false);
		}

		for (int i = 0; i < colorArray.Length; ++i) {
			colorArray [i].r = colorArray [i].r;
			colorArray [i].g = colorArray [i].g;
			colorArray [i].b = colorArray [i].b;
			colorArray [i].a = colorArray [i].a;
		}
		t.SetPixels (colorArray);
		t.Apply ();

		tag.texture = t;
	}

	public void PrintColor (Color[] array)
	{
		
	}


	public void Test ()
	{
		hoge ();

		if (buf != null)
			return;



		rt = new RenderTexture (1024, 1, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default);

		rt.filterMode = FilterMode.Point;
		rt.useMipMap = false;
		rt.wrapMode = TextureWrapMode.Clamp;
		rt.hideFlags = HideFlags.HideAndDontSave;

		var rtId = new RenderTargetIdentifier (rt);

		tag.texture = rt;

		buf = new CommandBuffer ();

//		m = new Mesh ();
//
//		m.ver


		cam.AddCommandBuffer (CameraEvent.BeforeForwardOpaque, buf);

	}
}
