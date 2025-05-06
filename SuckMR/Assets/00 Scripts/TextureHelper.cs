using UnityEngine;
using UnityEngine.Rendering;

namespace _00_Scripts
{
	public class TextureHelper
	{
		// TODO
		// Get the texture from the rendertexture
		// convert it to texture2d
		// calculate the dirt left by comparing alpha color to overlay color
		
		/* # header test
		 * 
		 * 
		 */

		
		public RenderTexture OriginalRenderTexture;
		public RenderTexture OverlayRenderTexture;
		
		public Texture2D Original2DTexture;
		public Texture2D MaskOverlay2DTexture;

		public float UncleanedAreaLeft;
		public float OriginalAmountOfAreaToClean;
		
//
//		public void Awake()
//		{
//			// Take a "screenshot" from render texture, and convert it to texture2d to be able to calculate dirt left.
//			CopyRenderTextureToTexture2D(OriginalRenderTexture, Original2DTexture);
//			
//			
//			TransferTextureToMask(Original2DTexture, MaskOverlay2DTexture);
//		}

		
		public void TransferTextureToMask(Texture2D originalTexture2D, Texture2D texture2dToCopyTo) // just copies the original texture to the mask texture	
		{
			texture2dToCopyTo.SetPixels(originalTexture2D.GetPixels());
		}


		public void CopyRenderTextureToTexture2D(RenderTexture renderTexture, Texture2D texture2D)
		{
			RenderTexture.active = renderTexture;
			texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height),0,0);
			texture2D.Apply();
			RenderTexture.active = null;
		}




	}
}