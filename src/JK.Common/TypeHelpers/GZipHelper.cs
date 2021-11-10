using System.IO;
using System.IO.Compression;

namespace JK.Common.TypeHelpers;

/// <summary>
/// Class which contains methods for GZip compression.
/// </summary>
public class GZipHelper
{
    /// <summary>Compresses a file using GZip compression.</summary>
    /// <param name="inFileName">File name of original file.</param>
    /// <param name="outFileName">File name to give to compressed file.</param>
    public void GZipCompressFile(string inFileName, string outFileName)
    {
        using (var sourceFile = File.OpenRead(inFileName))
        using (var destFile = File.Create(outFileName))
        using (var compStream = new GZipStream(destFile, CompressionMode.Compress))
        {
            var singleByte = sourceFile.ReadByte();
            while (singleByte != -1)
            {
                compStream.WriteByte((byte)singleByte);
                singleByte = sourceFile.ReadByte();
            }
        }
    }

    /// <summary>Decompresses a file which was compressed using GZip compression.</summary>
    /// <param name="inFileName">File name of compressed file.</param>
    /// <param name="outFileName">File name to give to decompressed file.</param>
    public void GZipDecompressFile(string inFileName, string outFileName)
    {
        using (var sourceFile = File.OpenRead(inFileName))
        using (var destFile = File.Create(outFileName))
        using (var compStream = new GZipStream(sourceFile, CompressionMode.Decompress))
        {
            var singleByte = compStream.ReadByte();
            while (singleByte != -1)
            {
                destFile.WriteByte((byte)singleByte);
                singleByte = compStream.ReadByte();
            }
        }
    }
}
