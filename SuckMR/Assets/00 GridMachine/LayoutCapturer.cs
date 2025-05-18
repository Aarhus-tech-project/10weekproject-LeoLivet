using System;
using UnityEngine;
using Meta.XR.Util;

public class LayoutCapturer : MonoBehaviour
{

	// TODO Get the texture from the camera and the convert it to a texture2D
	// TODO Get bounds from floor then apply that to the camera size
	
	public Texture2D     OrthoTextureCapture;
	public Camera        OrthoCamera;
	public RenderTexture TheRenderTexture;

	private void Awake()
	{
//		TextureSnapshot();
	}

	// Update is called once per frame
	private void Update()
	{ }



//	public void TextureSnapshot()
//	{
//		
//////		Camera orthoCamera = GameObject.Find("OrthoGraphCamera")
////		OrthoCamera.targetTexture = 
////		OrthoCamera.Render();
////		OrthoCamera.targetTexture = null;
//	}
}