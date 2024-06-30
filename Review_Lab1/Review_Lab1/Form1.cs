//Name : Amanjot Singh Sandhu
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Review_Lab1
{
    public partial class Form1 : Form
    {
        //Threshold value set by user
        int thresholdVal = 0;

        //Dictionary to save the info about colors of the image
        Dictionary<Color,int> pixelInfo = new Dictionary<Color,int>();

        //Bitmap of the orignal image 
        Bitmap bitMap = null;

        //Object of Image Reducer class
        ImageReducer img = null;

        //Delegate to use threading to use the UI while reducing image
        public delegate void UpdateUI(Bitmap bitmap, string lbl);


        public Form1()
        {
            InitializeComponent();  
        }

        /// <summary>
        /// Binding the events
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            //Events  
            UI_PicBox.DragEnter += UI_PicBox_DragEnter;
            UI_PicBox.DragDrop += UI_PicBox_DragDrop;
            UI_ReduceVal_lbl.MouseWheel += UI_ReduceVal_lbl_MouseWheel;
            UI_PicBox.AllowDrop = true;
            UI_Reduce_Btn.Enabled = false;
        }

        /// <summary>
        /// Get the ThreshHold Val using the scroll
        /// </summary>
        private void UI_ReduceVal_lbl_MouseWheel(object sender, MouseEventArgs e)
        {
            thresholdVal += e.Delta/120 ;
            
            //Limiting the Value between 0 to 256
            if (thresholdVal > 256)
            {
                thresholdVal = 256;
            }
            else if (thresholdVal < 0)
            {
                thresholdVal = 0;
            }
            UI_ReduceVal_lbl.Text = thresholdVal.ToString();
        }

        private void UI_PicBox_DragDrop(object sender, DragEventArgs e)
        {
            
            string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);
            
            //Checking for multiple files
            if(file.Length > 1)
            {
                MessageBox.Show("Dont Drop Multiple Files!");                
            }
            else
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(file[0]);
                    GetPic(fileInfo);
                }
                catch 
                {
                    throw new Exception("Image didnt load");
                }
                
            }
            
        }

        private void UI_PicBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

       
        /// <summary>
        /// Method to parse the file check if its an image and find the total number of colors
        /// </summary>
        /// <param name="file">The file supplied by the user</param>
        public void GetPic(FileInfo file)
        {
            //Try to get the bitmap from the file put it as the picture box image
            try
            {
                UI_PicBox.BackColor = Color.FloralWhite;

                //Getting the bitmap from the file
                Bitmap bitmap = new Bitmap(Bitmap.FromFile(file.FullName));
                //Setting the picbox
                UI_PicBox.Image = bitmap;

                ImageReducer orignalImg = new ImageReducer(bitmap, Console.WriteLine);
                
                //Creating a copy of the bitmap
                bitMap = new Bitmap(bitmap);            
                
                UI_ColorNum.Text = "There are " + orignalImg.BuildColourTable().Count + " colors in this image!";
                
                this.Text = "Image Loaded";
               
                UI_Reduce_Btn.Enabled = true;
            }
            //If anything fails turn the PicBox color red and give user an error
            catch
            {
                UI_Reduce_Btn.Enabled = false;
                UI_PicBox.BackColor = Color.Red;
                UI_ColorNum.Text = "There's no picture to find colors!";
                this.Text = "File Cant be Loaded";
                MessageBox.Show("File Cant Be Loaded");
            }
        }
        /// <summary>
        /// /
        /// </summary>

        private void UI_Reduce_Btn_Click(object sender, EventArgs e)
        {
            //Creating the Class object to reduce the image
            img = new ImageReducer(bitMap, Console.WriteLine);
           
            //Back Ground thread for UI
            Thread UI_Thread = new Thread(DisplayUI);
            UI_Thread.IsBackground = true;
            UI_Thread.Start();

            UI_Reduce_Btn.Enabled = false;
            UI_ReduceVal_lbl.Enabled = false;
            UI_PicBox.Enabled = false;
        }


        /// <summary>
        /// Method for background thread to invoke the delegate to update the UI while reduction is happenening
        /// </summary>
        public void DisplayUI()
        {
            //Invoke(new Action(() => {

            //    UI_PicBox.Enabled = true;
            //    UI_Reduce_Btn.Enabled = true;
            //    UI_ReduceVal_lbl.Enabled = true;
            //    //Update the UI
            //    UI_PicBox.Image = img.ReduceImage(thresholdVal);
            //    UI_ColorNum.Text = "There are " + img.BuildColourTable().Count + " colors in this image!";
            //}));

            //Invoke(new Action(() => InvokeDel(img.ReduceImage(thresholdVal), "There are " + img.BuildColourTable().Count + " colors in this image!")));

            //UI_ColorNum.Invoke(new Action(() => {
            //    UI_ColorNum.Text = "There are " + img.BuildColourTable().Count + " colors in this image!";
            //}));

            //UI_PicBox.Invoke(new Action(() => 
            //{
            //    UI_PicBox.Enabled = true;
             
            //    UI_PicBox.Image = img.ReduceImage(thresholdVal);
            //}));
                UpdateUI UIdelegate= new UpdateUI(InvokeDel);
                Invoke(UIdelegate,img.ReduceImage(thresholdVal) , "There are " + img.BuildColourTable().Count + " colors in this image!");
            }




        /// <summary>
        /// Invoke the delegate to update the UI 
        /// </summary>
        /// <param name="bit">Bitmap for the picture box to update</param>
        /// <param name="updateLbl">The text to update the color count label</param>
        public void InvokeDel(Bitmap bit, string updateLbl)
        {
            //Enable the button and update the UI
            UI_PicBox.Enabled = true;
            UI_Reduce_Btn.Enabled = true;
            UI_ReduceVal_lbl.Enabled = true;
            //Update the UI
            UI_PicBox.Image = bit;
            UI_ColorNum.Text = updateLbl;

        }
    }

}
