using PaintDotNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BsImFileExtensions
{
    public sealed class BsImFileExtensionsFactory : IFileTypeFactory
    {
        public FileType[] GetFileTypeInstances()
        {
            return new[] { new BsImFileExtensionsPlugin() };
        }
    }

    [PluginSupportInfo(typeof(PluginSupportInfo))]
    internal class BsImFileExtensionsPlugin : FileType
    {
        internal BsImFileExtensionsPlugin()
            : base(
                "Bs Image Format",
                new FileTypeOptions
                {
                    LoadExtensions = new string[] { ".bsim" },
                    SaveExtensions = new string[] { ".bsim" },
                    SupportsCancellation = true,
                    SupportsLayers = false
                })
        {
        }

        protected override void OnSave(Document input, Stream output, SaveConfigToken token, Surface scratchSurface, ProgressEventHandler progressCallback)
        {
            RenderArgs ra = new RenderArgs(new Surface(input.Size));
            input.Render(ra, true);

            Bitmap image = ra.Bitmap;

            SaveConfig saveConfig = new SaveConfig();
            saveConfig.bitDepth.SelectedIndex = 0;
            saveConfig.intbitDepth = 32;
            saveConfig.imageHeight = image.Height;
            saveConfig.imageWidth = image.Width;

            DialogResult dialogResult = saveConfig.ShowDialog();
            
            if(dialogResult != DialogResult.OK)
            {
                MessageBox.Show("Save Failed");
                return;
            }

            BinaryWriter binwriter = new BinaryWriter(output);
            binwriter.Write((uint)image.Width);
            binwriter.Write((uint)image.Height);
            if (saveConfig.bitDepth.SelectedIndex == 0)
            {
                binwriter.Write((uint)32);
                binwriter.Write((uint)((image.Width * image.Height) * 32));
            }
            else
            {
                binwriter.Write((uint)24);
                binwriter.Write((uint)((image.Width * image.Height) * 24));
            }
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    if (saveConfig.bitDepth.SelectedIndex == 0)
                    {
                        binwriter.Write(image.GetPixel(x, y).A);
                    }
                    binwriter.Write(image.GetPixel(x, y).R);
                    binwriter.Write(image.GetPixel(x, y).G);
                    binwriter.Write(image.GetPixel(x, y).B);
                }
            }

        }

        protected override Document OnLoad(Stream input)
        {
            try
            {
                byte[] buffer = new byte[input.Length];
                int width;
                int height;
                int bitDepth;
                int imagesize;
                input.Read(buffer, 0, (int)input.Length);

                byte[] tempbuffer = new byte[4];
                tempbuffer[0] = buffer[0];
                tempbuffer[1] = buffer[1];
                tempbuffer[2] = buffer[2];
                tempbuffer[3] = buffer[3];

                width = BitConverter.ToInt32(tempbuffer, 0);
                tempbuffer[0] = buffer[4];
                tempbuffer[1] = buffer[5];
                tempbuffer[2] = buffer[6];
                tempbuffer[3] = buffer[7];

                height = BitConverter.ToInt32(tempbuffer, 0);
                tempbuffer[0] = buffer[8];
                tempbuffer[1] = buffer[9];
                tempbuffer[2] = buffer[10];
                tempbuffer[3] = buffer[11];

                bitDepth = BitConverter.ToInt32(tempbuffer, 0);
                tempbuffer[0] = buffer[12];
                tempbuffer[1] = buffer[13];
                tempbuffer[2] = buffer[14];
                tempbuffer[3] = buffer[15];

                imagesize = BitConverter.ToInt32(tempbuffer, 0);

                if(bitDepth != 32 && bitDepth != 24)
                {
                    throw new BadImageFormatException("Bit Depth Invalid");
                }

                if (!(height > 0) || !(width > 0))
                {
                    throw new BadImageFormatException("Invalid Image Size");
                }

                Bitmap b = new Bitmap(width, height);
                int bytecount = 0;
                int maxpixelcount = imagesize / 32;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if(bitDepth == 32)
                        {
                            Color color = Color.FromArgb(buffer[16 + (bytecount * 4 + 3)], buffer[16 + (bytecount * 4 + 2)], buffer[16 + (bytecount * 4 + 1)], buffer[16 + (bytecount * 4)]);
                            b.SetPixel(x, y, color);
                        }
                        else if (bitDepth == 24)
                        {
                            Color color = Color.FromArgb(255, buffer[16 + (bytecount * 3 + 2)], buffer[16 + (bytecount * 3 + 1)], buffer[16 + (bytecount * 3)]);
                            b.SetPixel(x, y, color);
                        }
                        bytecount++;
                    }
                }

                return Document.FromImage(b);
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception : " + e.Message);

                Bitmap b = new Bitmap(500, 500);
                return Document.FromImage(b);
            }
        }
    }
}
