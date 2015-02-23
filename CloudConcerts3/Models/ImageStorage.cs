using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CloudConcerts3.Models
{
    public class ImageStorage
    {
        public static CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=cloudconcerts;AccountKey=fi05r3Bzd6PJvAiJGXZxcnVr28F+U4j4em5LaLl9vX5aWUQqBzl0K/wWmL3Zeqt4ZRkQ0FWCfogaBybdsNQJFA==");
        public static CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
        public static CloudBlobContainer container = blobClient.GetContainerReference("images");

        public static string UploadBlob(string currentURL, HttpPostedFileBase imagefile)
        {
            string imageName = null;

            //Create a new unique name for the image if no existing image
            if (currentURL == null)
            {
                imageName = String.Format("task-photo-{0}{1}",
                        Guid.NewGuid().ToString(),
                        Path.GetExtension(imagefile.FileName));
            }
            else
            {
                //Get the image name from the URL
                Uri uri = new Uri(currentURL);
                imageName = Path.GetFileName(uri.LocalPath);
            }
            
            // Upload the file to Azure Blob Storage
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(imageName);
            blockBlob.Properties.ContentType = imagefile.ContentType;
            blockBlob.UploadFromStream(imagefile.InputStream);
            var uriBuilder = new UriBuilder(blockBlob.Uri);
            return uriBuilder.ToString();
        }

        public static void DeleteBlob(string blobURL)
        {
            Uri uri = new Uri(blobURL);
            string imageName = Path.GetFileName(uri.LocalPath);

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(imageName);

            blockBlob.Delete();
        }
    }
}