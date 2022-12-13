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
using WebBrowser.ImageService;
using System.Drawing.Imaging;
using System.Runtime.InteropServices.ComTypes;
using System.Xml.Linq;
using System.Reflection.Emit;

namespace WebBrowser
{
    public partial class Form1 : Form
    {
        string myStr;   //assignment 2: Global Variable for the correct code 

        //assignment 1
        public Form1()
        {
            InitializeComponent();
            webBrowser1.Navigate("www.google.com"); //Navigate Google when initialization
        }

        // button1 for go back
        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();   
        }

        // button2 for go forward
        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();    
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // button3 for refresh
        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();  
        }

        // button4 for navigate website
        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textBox1.Text);    
        }

        // button5 for go back to home page
        private void button5_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("www.google.com");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //assignment 2 Question 4
        
        
        // button7 for verify code
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == myStr)
            {
                label3.Text = "Congratulation! The code you entered is correct!";
            }
            else
            {
                label3.Text = "the string you entered is unmatched, please try again.";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // button6 for refresh code picture
        private void button6_Click(object sender, EventArgs e)
        {
            ImageService.ServiceClient fromService = new ImageService.ServiceClient();
            // Prevent empty input: if no code length input ->warning
            //textBox3: code length

            try
            {
                if (textBox3.Text == "")
                {
                    label9.Text = "Please enter image string length";   //label9 for warning
                }
                else
                {
                    label9.Text = "";
                    myStr = fromService.GetVerifierString(textBox3.Text);   //get code picture
                    Stream myStream = fromService.GetImage(myStr);
                    pictureBox1.Image = Image.FromStream(myStream);     //show code picture
                }
            }
            catch (Exception ec) { label9.Text = ec.Message.ToString(); }

            fromService.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        //assignment 2 Question 2
        // button8 for encrypt strings
        private void button8_Click(object sender, EventArgs e)
        {
            Crypto.ServiceClient myclient = new Crypto.ServiceClient();

            // Prevent empty input: if no strings input ->warning
            // textBox4: strings input
            if (textBox4.Text != "")
            {
                try
                {
                    label5.Text = myclient.Encrypt(textBox4.Text);      //calling method in service to encrypt
                }
                catch (Exception ec) { label5.Text = ec.Message.ToString(); }

                try
                {
                    label6.Text = myclient.Decrypt(label5.Text);    //calling method in service to decrypt
                }
                catch (Exception ec) { label6.Text = ec.Message.ToString(); }
            }
            else
            {
                textBox4.Text = "Please enter your message!";
            }
            
         

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
