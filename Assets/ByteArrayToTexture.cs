using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ByteArrayToTexture : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{

		meshFilter = gameObject.GetComponent<MeshFilter>();
		meshRenderer = gameObject.GetComponent<MeshRenderer>();


		mesh = new Mesh();
		mesh.vertices = new Vector3[] {
				new Vector3 (0, 1f),
				new Vector3 (1f, -1f),
				new Vector3 (-1f, -1f),
			};
		mesh.triangles = new int[] {
				0, 1, 2
			};

		// 変更箇所 : 各頂点に色情報を設定
		mesh.colors32 = new Color32[] {
				new Color32((byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)Random.Range(0, 256), 255),
				new Color32((byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)Random.Range(0, 256), 255),
				new Color32((byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)Random.Range(0, 256), 255)
			};

		meshFilter.sharedMesh = mesh;
	}

	// Update is called once per frame
	void Update ()
	{
	}

	Color[] colorArray = new Color[2048];
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

	MeshFilter meshFilter;
	MeshRenderer meshRenderer;

	public RenderTexture rt;
	public Texture2D t;
	public Camera cam;

	public RawImage tag;

	CommandBuffer buf;

	public Mesh m;
	public Mesh mesh;
	public Material material;
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
		//hoge ();

		if (t == null) {
			t = new Texture2D (size, 1, TextureFormat.ARGB32, false, false);
		}

		Profiler.BeginSample("test2 : update color");
		for (int i = 0; i < colorArray.Length; ++i) {
			colorArray[i] = new Color32((byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)Random.Range(0, 256), 255);
		}
		Profiler.EndSample();
		Profiler.BeginSample("test2 : SetPixels");
		t.SetPixels (colorArray);
		Profiler.EndSample();
		Profiler.BeginSample("test2 : Apply");
		t.Apply (false, false);
		Profiler.EndSample();

		tag.texture = t;
	}

	public void PrintColor (Color[] array)
	{
		
	}


	const int size = 4096;
	Vector3[] verts = new Vector3[size * 4];
	Color32[] cols = new Color32[size * 4];
	int[] tris = new int[size * 6];
	public void Test ()
	{
		//mesh.colors32 = new Color32[] {
		//		new Color32((byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)Random.Range(0, 256), 255),
		//		new Color32((byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)Random.Range(0, 256), 255),
		//		new Color32((byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)Random.Range(0, 256), 255)
		//	};
		//return;

		//hoge ();

		//if (buf != null)
		//	return;



		//rt = new RenderTexture (1024, 1, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Default);

		//rt.filterMode = FilterMode.Point;
		//rt.useMipMap = false;
		//rt.wrapMode = TextureWrapMode.Clamp;
		//rt.hideFlags = HideFlags.HideAndDontSave;

		//var rtId = new RenderTargetIdentifier (rt);

		//tag.texture = rt;

		//buf = new CommandBuffer ();
		Profiler.BeginSample("test : update color");

//		Vector3[] vertices = {
//new Vector3(-1f, -1f, 0),
//new Vector3(-1f,  1f, 0),
//new Vector3( 1f,  1f, 0),
//new Vector3( 1f, -1f, 0)
//};
//		Color32[] colors = {
//new Color32(255, 255, 255, 255),
//new Color32(255, 255, 255, 255),
//new Color32(255, 255, 255, 255),
//new Color32(255, 255, 255, 255),
//};
		if(!m)
		{
			m = new Mesh();


			meshFilter.sharedMesh = m;
			//meshRenderer.sharedMaterial = material;

			for (int i = 0; i < size; i++)
			{
				verts[i * 4 + 0] = new Vector3(i / (float)size, 0);
				verts[i * 4 + 1] = new Vector3(i / (float)size, 1);
				verts[i * 4 + 2] = new Vector3((i + 1) / (float)size, 1);
				verts[i * 4 + 3] = new Vector3((i + 1) / (float)size, 0);

				//verts[i * 4 + 0] = new Vector3(-1f, -1f, 0);
				//verts[i * 4 + 1] = new Vector3(-1f, 1f, 0);
				//verts[i * 4 + 2] = new Vector3(1f, 1f, 0);
				//verts[i * 4 + 3] = new Vector3(1f, -1f, 0);

				tris[i * 6 + 0] = i * 4 + 0;
				tris[i * 6 + 1] = i * 4 + 1;
				tris[i * 6 + 2] = i * 4 + 2;
				tris[i * 6 + 3] = i * 4 + 0;
				tris[i * 6 + 4] = i * 4 + 2;
				tris[i * 6 + 5] = i * 4 + 3;

				//	var c = new Color32(255,255,255, 255);
				//cols[i * 4 + 0] = c;
				//	cols[i * 4 + 1] = c;
				//	cols[i * 4 + 2] = c;
				//	cols[i * 4 + 3] = c;
			}
			m.vertices = verts;
			m.triangles = tris;
			//m.colors32 = cols;
		}

		Color32 c;
		for (int i = 0; i < size; i++)
		{
			//c.r = (byte)Random.Range(0, 256);
			//c.g = (byte)Random.Range(0, 256);
			//c.b = (byte)Random.Range(0, 256);
			//c.a = 1;

			c = new Color32((byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)Random.Range(0, 256), 255);
			cols[i * 4 + 0] =
			cols[i * 4 + 1] =
			cols[i * 4 + 2] =
			cols[i * 4 + 3] = c;
		}

		m.colors32 = cols;
		Profiler.EndSample();

		//int[] triangles = { 0, 1, 2, 0, 2, 3 };

		Profiler.BeginSample("test: upload");
		//m.UploadMeshData(false);

		//cam.AddCommandBuffer (CameraEvent.BeforeForwardOpaque, buf);
		Profiler.EndSample();

	}
}
