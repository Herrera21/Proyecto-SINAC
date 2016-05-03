using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for VariablesSeccionControl
/// </summary>
public class ImageControl
{
    public ImageControl()
    {
    }

    public static byte[] fileInpTObyteVec(FileUpload fileinpID)
    {
        BinaryReader br = new BinaryReader(fileinpID.PostedFile.InputStream);

        //Se inicializa un arreglo de Bytes del tamaño de la imagen
        byte[] temp = br.ReadBytes(fileinpID.PostedFile.ContentLength);

        if (temp.Length > 0)
        {
            return temp;
        }
        else
        {
            return null;
        }

    }

    public static string byteVecToIMG(byte[] byteVec)
    {
        return "data:image/png;base64," + Convert.ToBase64String(byteVec);
    }
}