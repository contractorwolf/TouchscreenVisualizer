using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace Touchscreen_Visualizer
{
    public partial class DisplayForm : Form
    {
        //arduino as a serial device at 9600
        public static SerialPort arduino = null;
        private int serialSpeed = 9600;
        private Color BackgroundColor = Color.Black;

        private StringBuilder buffer = new StringBuilder();//incoming serial data        
        public static byte[] rx_data;//serial data

        //touchscreen hardcoded values, used to convert to more usable values
        private const int touchscreenMinimumX = 120;
        private const int touchscreenMinimumY = 170;
        private const int touchscreenMaxWidth = 920;
        private const int touchscreenMaxHeight = 860;

        //touchscreen touch values
        private int x = 0;
        private int y = 0;
        private int pressure = 0;

        private Bitmap b;//for drawing dots
        private Graphics g;//for drawing dots

        public DisplayForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            b = new Bitmap(this.Width, this.Height, PixelFormat.Format24bppRgb);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //load visible com ports
            cbPorts.DataSource = SerialPort.GetPortNames();
            cbPorts.Update();

            lStatus.Text = "started";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (cbPorts.SelectedValue != null)
            {
                //start communication with arduino
                arduino = new SerialPort(cbPorts.SelectedValue.ToString(), serialSpeed);
                arduino.Open();
                arduino.DataReceived += new SerialDataReceivedEventHandler(arduino_DataReceived);

                pSerialIndicator.BackColor = Color.Green;

                //clear screen
                g.Clear(BackgroundColor);
                pbTouchPanel.Image = b;

                lStatus.Text = "waiting...";
                lTranslated.Text = "touch screen";
            }
            else
            {
                MessageBox.Show("ERROR: No COM Port selected");
            }
        }

        private void arduino_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {//serial data comes in from the arduino
            try
            {
                rx_data = new byte[arduino.BytesToRead];

                arduino.Read(rx_data, 0, rx_data.Length);

                //add current serial data to buffer
                buffer.Append(Encoding.ASCII.GetString(rx_data));

                //message blocks are readings from the arduino
                string[] messageBlocks = buffer.ToString().Split('*');

                if (messageBlocks.Length>=3)
                {//wait for 3 readings to ensure that one will be whole
                    this.Invoke(new EventHandler(WriteData));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void WriteData(object sender, EventArgs e)
        {
            //clear prev drawn points
            g.Clear(BackgroundColor);

            //load and clear buffer
            string current = buffer.ToString();
            buffer.Clear();

            //split into message blocks
            string[] messageBlocks = current.Split('*');

            //get second messageBlock, split into values
            string[] dataPoints = messageBlocks[1].Split(',');

            if (dataPoints.Length == 3)
            {
                //show incoming reading
                txtMessage.Text = messageBlocks[1];

                //conert string data to int
                int.TryParse(dataPoints[0], out x);
                int.TryParse(dataPoints[1], out y);
                int.TryParse(dataPoints[2], out pressure);

                //conert touchscreen point to something relating to the output sizes
                Point output  = ConvertTouchscreen(new Point { X = x, Y = y },pressure);

                //convert the reverse pressure value
                int pressureConverted = (int)(100 - (int)(pressure / 8));

                //draw touchpoint
                //subtraacking the pressure over 2 corrects for the size of the circle
                //at the top left point, not needed but means the center of circle is where 
                //the point actually is, as opposed to the top left of the circle
                int localX = output.X- ((int)(pressureConverted/2));
                int localY = output.Y- ((int)(pressureConverted/2));

                g.DrawEllipse(new Pen(Color.White, 20), localX, localY, pressureConverted, pressureConverted);

                //show that data has been received
                pSerialIndicator.BackColor = Color.Blue;
                lStatus.Text = "receiving";

                //start countdown to switch the indicator back
                timer1.Enabled = true;
                timer1.Start();
            }

            //load drawn points
            pbTouchPanel.Image = b;    
        }

        private Point ConvertTouchscreen(Point touchscreen, int pressure)
        {//convert the incoming touchscreen data into more sensible values
            Point output = new Point();
            StringBuilder debugMessage = new StringBuilder();

            //calculations
            float dx = touchscreen.X - touchscreenMinimumX;
            float ratioX = dx / (touchscreenMaxWidth-touchscreenMinimumX);

            float dy = touchscreen.Y - touchscreenMinimumY;
            float ratioY = dy / (touchscreenMaxHeight-touchscreenMinimumY);

            int pressureConverted = (int)(100 - (int)(pressure / 7));

            output.X = this.Width - (int)(ratioX * this.Width);
            output.Y =  (int)(ratioY * this.Height);



            //output all the calculated data, to check the math, can be commented out
            debugMessage.Append("touchscreenx:");
            debugMessage.Append(touchscreen.X);
            debugMessage.Append(Environment.NewLine);

            debugMessage.Append("touchscreeny:");
            debugMessage.Append(touchscreen.Y);
            debugMessage.Append(Environment.NewLine);
            debugMessage.Append(Environment.NewLine);

            debugMessage.Append("pressure:");
            debugMessage.Append(pressure);
            debugMessage.Append(Environment.NewLine);

            debugMessage.Append("pressure converted:");
            debugMessage.Append(pressureConverted);
            debugMessage.Append(Environment.NewLine);
            debugMessage.Append(Environment.NewLine);

            debugMessage.Append("ratiox:");
            debugMessage.Append(ratioX);
            debugMessage.Append(Environment.NewLine);

            debugMessage.Append("ratioy:");
            debugMessage.Append(ratioY);
            debugMessage.Append(Environment.NewLine);
            debugMessage.Append(Environment.NewLine);

            debugMessage.Append("outputx:");
            debugMessage.Append(output.X);
            debugMessage.Append(Environment.NewLine);

            debugMessage.Append("outputy:");
            debugMessage.Append(output.Y);
            debugMessage.Append(Environment.NewLine);

            //show calculated values
            lTranslated.Text = debugMessage.ToString();

            return output;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {//switch the indicator back if more than 200ms have elapsed since last reading
            pSerialIndicator.BackColor = Color.Green;
            lStatus.Text = "waiting";
            timer1.Enabled = false;

            //clear last reading
            g.Clear(BackgroundColor);
            pbTouchPanel.Image = b;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {//when form size has changed, must update bitmap and graphics
            b = new Bitmap(this.Width, this.Height, PixelFormat.Format24bppRgb);
            g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }
    }
}
