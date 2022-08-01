using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProject.Models
{
    public class SelectableBranch
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public ImageSource Image { get; set; }
        public SelectableBranch(int Id, string name, ImageSource imageSource)
        {
            this.ID = Id;
            this.Name = name;
            this.Image = imageSource;
        }

        public static List<SelectableBranch> BranchesToSelectableBranches(List<Branch> branches)
        {
            List<SelectableBranch> selectableBranches = new List<SelectableBranch>();

            foreach (Branch br in branches) // make SelectableBranch from each Branch pulled from DataReader -- same as Branch, but with the imageData converted to image
            {
                ImageSource imageSource = null;

                if (br.ImageData != null)
                {
                    imageSource = ConvertImageDataToImageSource(br.ImageData);
                }

                SelectableBranch newSelectableBranch = new SelectableBranch(br.ID, br.BranchName, imageSource);
                selectableBranches.Add(newSelectableBranch);

            }
            return selectableBranches;
        }

        public static ImageSource ConvertImageDataToImageSource(byte[] imageData)
        {
            Stream ms = new MemoryStream(imageData);
            ImageSource imageSource = ImageSource.FromStream(() => ms);

            return imageSource;
        }
    }
}
