//Name : Amanjot Singh Sandhu
//Section : A01
//Submission code : CMPE2800_1232_Lab01
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Review_Lab1
{
    public abstract class BaseBitmapManip
    {
        /// <summary>
        /// Custom Constructor for base class
        /// </summary>
        /// <param name="bm"> Bitmap of the supplied image</param>
        /// <param name="error"></param>
        public BaseBitmapManip(Bitmap bm, Action<string> error)
        {
            //Checking the bitmap
            try
            {
                if (bm == null)
                {
                    throw new ArgumentException("Supplied file is Null");
                }
                BitmapOriginal = new Bitmap(bm);
            }
            catch (Exception ex)
            {
                error?.Invoke(ex.Message);
            }
        }

        //Property  to get the supplied image's bitmap
        public Bitmap BitmapOriginal { get; private set; }

        /// <summary>
        /// Method to create a dictionary with every single color found in the bitmap with its relative count
        /// </summary>
        /// <returns>Returns a Dictionary with unique colors as keys and its count as value in descending order</returns>
        public Dictionary<Color, int> BuildColourTable()
        {
            //Dictionary for info about the image colors
            Dictionary<Color, int> dict = new Dictionary<Color, int>();

            //Going through the whole Bitmap to figure out unique colors and respective counts for it
            for (int i = 0; i < BitmapOriginal.Width; i++)
            {
                for (int j = 0; j < BitmapOriginal.Height; j++)
                {
                    //Color of every pixel in the bitmap
                    Color pixelColor = BitmapOriginal.GetPixel(i, j);
                    //If the color is not in the dictionary add it
                    if (!dict.ContainsKey(pixelColor))
                    {
                        dict.Add(pixelColor, 0);
                    }
                    //Increase the count 
                    else
                    {
                        dict[pixelColor] += 1;
                    }
                }
            }
            return dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }
        /// <summary>
        /// Method to get the absolute value difference between 2 supplied colors
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns> int - difference between the RGB color values of the  </returns>
        public static int GetColourDifference(Color A, Color B)
        {
            int iR = Math.Abs(A.R - B.R);
            int iG = Math.Abs(A.G - B.G);
            int iB = Math.Abs(A.B - B.B);
            
            return iR + iG + iB;
        }
  
        public abstract Bitmap ReduceImage(int Threshold);
    }

    /// <summary>
    /// Derived Class from BaseBitManip for reducing the image using the abstract method from the base class
    /// </summary>
    public class ImageReducer : BaseBitmapManip
    {
        //Constructor to init the base class
        public ImageReducer(Bitmap bm, Action<string> error) : base(bm, error)
        {

        }
        /// <summary>
        /// Method to reduce the threshold colors to the most popular color
        /// *********IT USES THE ORIGNAL BITMAP FROM THE PICBOX FOR EVERY REDUCTION*******
        /// </summary>
        /// <param name="threshold">The threshold value to find similar colors</param>
        /// <returns>Modified Bitmap</returns>
        public override Bitmap ReduceImage(int threshold)
        {
            //Most popular color in the dictionary(Highest Count)
            Color mostPopColor;
            //Dictionary with the colors
            Dictionary<Color, int> dict = new Dictionary<Color, int>();
            //Create the lists
            dict = BuildColourTable();

            //Keep changing colors till theres no colors left in the bitmap dictionary to swap
            while (dict.Count > 0)
            {
                //Getting the most popular color after every reduction
                mostPopColor = dict.First().Key;

                //Collection to hold the colors under the threshold value
                HashSet<Color> thresholdColors = dict.Keys.Where(x => GetColourDifference(x, mostPopColor) <= threshold).ToHashSet();

                //Going through the Bitmap and switching the colors which fall under threshold value with most popular color
                for (int i = 0; i < BitmapOriginal.Width; i++)
                {
                    for (int j = 0; j < BitmapOriginal.Height; j++)
                    {
                        //Current Bit/pixel to check and swap
                        Color pixelColor = BitmapOriginal.GetPixel(i, j);
                        //Checking the color with the 
                        if (thresholdColors.Contains(pixelColor))
                        {
                            BitmapOriginal.SetPixel(i, j, mostPopColor);
                        }
                    }
                }

                //Remove the most popular color after every run
                dict.Remove(mostPopColor);
                //Remove the colors which are under the threshold value from the dictionary 
                foreach (Color color in thresholdColors)
                {
                    if (dict.ContainsKey(color))
                    {
                        dict.Remove(color);
                    }
                }
            }
            //Return the modified bitmap
            return BitmapOriginal;
        }
    }
}
