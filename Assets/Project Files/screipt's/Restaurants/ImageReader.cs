using UnityEngine;
public class ImageReader
{
	public byte[] Loadedimg;
	public int Img_Height;
	public int Img_Width;

	public ImageReader(Texture2D RawImage)
	{
		this.Loadedimg = RawImage.GetRawTextureData();
		this.Img_Height = RawImage.height;
		this.Img_Width = RawImage.width;
	}

	public ImageReader(int width, int height, byte[] loadedimg)
	{
		this.Loadedimg = loadedimg;
		this.Img_Height = height;
		this.Img_Width = width;
	}

	public Texture2D Load()
	{
		Texture2D Image = new Texture2D(Img_Width, Img_Height, TextureFormat.PVRTC_RGBA4, false);
		Image.LoadRawTextureData(Loadedimg);
		Image.Apply();
		return Image;
	}
}
