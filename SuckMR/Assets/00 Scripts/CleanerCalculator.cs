using UnityEngine;

namespace _00_Scripts
{
	public class CleanerCalculator
	{
		
		
		public void PaintOnTexture(RaycastHit raycastHit,Texture2D paintMaskTexture2D, Texture2D dirtBrush, float dirtAmount)
		{
			Vector2 textureCoord = raycastHit.textureCoord;

			int pixelX = (int)(textureCoord.x * paintMaskTexture2D.width);
			int pixelY = (int)(textureCoord.y * paintMaskTexture2D.height);

//        Vector2Int paintPixelPosition = new Vector2Int(pixelX, pixelY);

			// Paint Square in Dirt Mask
			int squareSize   = 32;
			int pixelXOffset = pixelX - (dirtBrush.width  / 2);
			int pixelYOffset = pixelY - (dirtBrush.height / 2);

			for (int x = 0; x < squareSize; x++)
			{
				for (int y = 0; y < squareSize; y++)
				{
					Color pixelDirt     = dirtBrush.GetPixel(x, y);
					Color pixelDirtMask = paintMaskTexture2D.GetPixel(pixelXOffset + x, pixelYOffset + y);

					float removedAmount = pixelDirtMask.a - (pixelDirtMask.g * pixelDirt.g);
					dirtAmount -= (removedAmount * 10f);
					//TODO magic number

					paintMaskTexture2D.SetPixel(
					                            pixelXOffset + x,
					                            pixelYOffset + y,
					                            Color.black
					                           );
				}
			}

			paintMaskTexture2D.Apply();
		}
		
		
	}
}