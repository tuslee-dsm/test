using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
namespace DEMO3AxisFss
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            _isMouseDown = true;
            _lastLocation = e.Location;
        }
        private bool _isMouseDown = false;
        private Point _lastLocation;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - _lastLocation.X) + e.X,
                    (this.Location.Y - _lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btHide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            axDBCommManager1.Peer = "USB";
            try
            {
                axDBCommManager1.Connect();
                // Hiển thị hộp thoại MessageBox với biểu tượng thông báo (Information)
                timer1.Start();
                timer2.Start();
                axDBTriggerManager1.Active = true;
            }
            catch
            {
                // Hiển thị hộp thoại MessageBox với biểu tượng lỗi (Error)
                MessageBox.Show("Error: Connection failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string filePath = @"C:\Users\ADMIN\Desktop\BCFR\Data1\selectedFilePath.txt";

            if (File.Exists(filePath))
            {
                lbAspath.Text = File.ReadAllText(filePath);
            }
            else
            {
                MessageBox.Show("Tệp không tồn tại!");
            }


        }

        private void btReadpoint1_Click(object sender, EventArgs e)
        {
            txtPoint1X.Text = lbToadoX.Text;
            txtPoint1Y.Text = lbToadoY.Text;

            float floatvaluePoint1X;
            if (float.TryParse(txtPoint1X.Text, out floatvaluePoint1X))
            {
                float multipliedValuePoint1X = floatvaluePoint1X * 100;
                int intValuepoint1X = Convert.ToInt32(multipliedValuePoint1X);
                if (axDBCommManager1.Active)
                {
                    axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_DM, "2000", intValuepoint1X);
                }
            }
            else
            {
            }

        }

        private void btReadpoint2_Click(object sender, EventArgs e)
        {
            txtPoint2X.Text = lbToadoX.Text;
            txtPoint2Y.Text = lbToadoY.Text;
            float floatvaluePoint2X;
            if (float.TryParse(txtPoint2X.Text, out floatvaluePoint2X))
            {
                float multipliedValuePoint2X = floatvaluePoint2X * 100;
                int intValuepoint2X = Convert.ToInt32(multipliedValuePoint2X);
                if (axDBCommManager1.Active)
                {
                    axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_DM, "2020", intValuepoint2X);
                }
            }
            else
            {
            }
        }

        private void btReadpoint3_Click(object sender, EventArgs e)
        {
            txtPoint3X.Text = lbToadoX.Text;
            txtPoint3Y.Text = lbToadoY.Text;
            float floatvaluePoint3X;
            if (float.TryParse(txtPoint3X.Text, out floatvaluePoint3X))
            {
                float multipliedValuePoint3X = floatvaluePoint3X * 100;
                int intValuepoint3X = Convert.ToInt32(multipliedValuePoint3X);
                if (axDBCommManager1.Active)
                {
                    axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_DM, "2044", intValuepoint3X);
                }
            }
            else
            {
            }
        }



        private void btOptions_Click(object sender, EventArgs e)
        {
            axDBCommManager1.CommPeer();
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            axDBCommManager1.Peer = "USB";
            try
            {
                axDBCommManager1.Connect();
                // Hiển thị hộp thoại MessageBox với biểu tượng thông báo (Information)
                MessageBox.Show("Connected successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                axDBTriggerManager1.Active = true;
                timer1.Start();
            }
            catch
            {
                // Hiển thị hộp thoại MessageBox với biểu tượng lỗi (Error)
                MessageBox.Show("Error: Connection failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btDisconect_Click(object sender, EventArgs e)
        {
            if (axDBCommManager1.Active)
            {
                axDBCommManager1.Disconnect();
                MessageBox.Show("Disconnected successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // Chạyy jog XỶZR


        //


        private void btCwY_MouseUp(object sender, MouseEventArgs e)
        {
            if (axDBCommManager1.Active)
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "300", 0);
            }
        }
        private void btCwY_MouseDown(object sender, MouseEventArgs e)
        {
            if (axDBCommManager1.Active)
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "300", 1);
            }
        }

        private void btCcwY_MouseDown(object sender, MouseEventArgs e)
        {
            if (axDBCommManager1.Active)
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "301", 1);
            }
        }

        private void btCcwY_MouseUp(object sender, MouseEventArgs e)
        {
            if (axDBCommManager1.Active)
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "301", 0);
            }
        }

        private void btCcwX_MouseDown(object sender, MouseEventArgs e)
        {
            if (axDBCommManager1.Active)
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "500", 1);
            }
        }

        private void btCcwX_MouseUp(object sender, MouseEventArgs e)
        {
            if (axDBCommManager1.Active)
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "500", 0);
            }
        }

        private void btCwX_MouseDown(object sender, MouseEventArgs e)
        {
            if (axDBCommManager1.Active)
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "501", 1);
            }
        }

        private void btCwX_MouseUp(object sender, MouseEventArgs e)
        {
            if (axDBCommManager1.Active)
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "501", 0);
            }
        }

        private void btCwZ_MouseDown(object sender, MouseEventArgs e)
        {
            if (axDBCommManager1.Active)
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "700", 1);
            }
        }

        private void btCwZ_MouseUp(object sender, MouseEventArgs e)
        {
            if (axDBCommManager1.Active)
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "700", 0);
            }
        }

        private void btCcwZ_MouseDown(object sender, MouseEventArgs e)
        {
            if (axDBCommManager1.Active)
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "701", 1);
            }
        }

        private void btCcwZ_MouseUp(object sender, MouseEventArgs e)
        {
            if (axDBCommManager1.Active)
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "701", 0);
            }
        }

        private void axDBDeviceManager1_BeforeRead(object sender, EventArgs e)
        {
            if (axDBCommManager1.Active)
            {// Đọc tọa độ trục Y
                string dec16ValueStringY = axDBDeviceManager1.Devices[2].ValueRead.ToString();  // Đọc giá trị từ axDBDeviceManager1.Devices[3].ValueRead và chuyển đổi
                ushort dec16ValueFromPLCY = ushort.Parse(dec16ValueStringY);
                short signedValueY;

                if (dec16ValueFromPLCY <= 32767)
                {
                    signedValueY = (short)dec16ValueFromPLCY; // Giá trị dec16-bit chưa vượt quá phạm vi
                }
                else
                {
                    signedValueY = (short)(dec16ValueFromPLCY - 65536); // Giá trị dec16-bit vượt quá phạm vi, điều chỉnh giá trị
                }

                float dividedValueY = signedValueY / 100.0f;


                lbToadoY.Text = dividedValueY.ToString();



                // Đọc tọa độ trục X


                string dec16ValueStringX = axDBDeviceManager1.Devices[3].ValueRead.ToString();  // Đọc giá trị từ axDBDeviceManager1.Devices[3].ValueRead và chuyển đổi
                ushort dec16ValueFromPLCX = ushort.Parse(dec16ValueStringX);
                short signedValueX;

                if (dec16ValueFromPLCX <= 32767)
                {
                    signedValueX = (short)dec16ValueFromPLCX; // Giá trị dec16-bit chưa vượt quá phạm vi
                }
                else
                {
                    signedValueX = (short)(dec16ValueFromPLCX - 65536); // Giá trị dec16-bit vượt quá phạm vi, điều chỉnh giá trị
                }

                float dividedValueX = signedValueX / 100.0f;


                lbToadoX.Text = dividedValueX.ToString();

                // Đọc tọa độ trục Z

                string dec16ValueStringZ = axDBDeviceManager1.Devices[4].ValueRead.ToString();  // Đọc giá trị từ axDBDeviceManager1.Devices[3].ValueRead và chuyển đổi
                ushort dec16ValueFromPLCZ = ushort.Parse(dec16ValueStringZ);
                short signedValueZ;

                if (dec16ValueFromPLCZ <= 32767)
                {
                    signedValueZ = (short)dec16ValueFromPLCZ; // Giá trị dec16-bit chưa vượt quá phạm vi
                }
                else
                {
                    signedValueZ = (short)(dec16ValueFromPLCZ - 65536); // Giá trị dec16-bit vượt quá phạm vi, điều chỉnh giá trị
                }

                float dividedValueZ = signedValueZ / 100.0f;


                lbToadoZ.Text = dividedValueZ.ToString();



                // 
                string baoviet = axDBDeviceManager1.Devices[5].ValueRead.ToString();
                if (baoviet == "1")
                {
                    btSpeedZ.Text = "Hight";
                }
                else
                {
                    btSpeedZ.Text = "Low";

                }
                string baovie1 = axDBDeviceManager1.Devices[6].ValueRead.ToString();
                if (baovie1 == "1")
                {
                    btSpeedXY.Text = "Hight";
                }
                else
                {
                    btSpeedXY.Text = "Low";

                }
            }
        }

        private void btSaveparameter_Click(object sender, EventArgs e)
        {
            //Hight Speed Xy
            float floatvalueSpeedXY;
            if (float.TryParse(txtHightspeedXY.Text, out floatvalueSpeedXY))
            {
                float multipliedValueSpeedXY = floatvalueSpeedXY * 100;
                int intValueSpeedXY = Convert.ToInt32(multipliedValueSpeedXY);
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_DM, "560", intValueSpeedXY);
            }
            else
            {
            }
            // Low speed XY


            float floatvalueSpeedlowXY;
            if (float.TryParse(txtHightlowXY.Text, out floatvalueSpeedlowXY))
            {
                float multipliedValueSpeedlowXY = floatvalueSpeedlowXY * 100;
                int intValueSpeedlowXY = Convert.ToInt32(multipliedValueSpeedlowXY);
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_DM, "570", intValueSpeedlowXY);
            }
            else
            {
            }



        }

        private void btSpeedXY_MouseUp(object sender, MouseEventArgs e)
        {
            if (axDBCommManager1.Active)
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "800", 0);

            }
        }

        private void btSpeedXY_MouseDown(object sender, MouseEventArgs e)
        {
            if (axDBCommManager1.Active)
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "800", 1);

            }
        }

        private void btSpeedZ_MouseDown(object sender, MouseEventArgs e)
        {
            if (axDBCommManager1.Active)
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "900", 1);

            }
        }

        private void btSpeedZ_MouseUp(object sender, MouseEventArgs e)
        {
            if (axDBCommManager1.Active)
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "900", 0);

            }
        }

        private void btOrigin_MouseDown(object sender, MouseEventArgs e)
        {
            if (axDBCommManager1.Active)
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "502", 1);

            }
        }

        private void btOrigin_MouseUp(object sender, MouseEventArgs e)
        {
            if (axDBCommManager1.Active)
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "502", 0);

            }
        }

        private void btOriginZR_MouseDown(object sender, MouseEventArgs e)
        {
            if (axDBCommManager1.Active)
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "702", 1);

            }
        }

        private void btOriginZR_MouseUp(object sender, MouseEventArgs e)
        {
            if (axDBCommManager1.Active)
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "702", 0);

            }
        }

        private void btGopoint1_MouseDown(object sender, MouseEventArgs e)
        {
            if (axDBCommManager1.Active)
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "3000", 1);

            }
        }

        private void btGopoint1_MouseUp(object sender, MouseEventArgs e)
        {
            if (axDBCommManager1.Active)
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "3000", 0);

            }
        }

        private void btGopoint2_MouseDown(object sender, MouseEventArgs e)
        {
            if (axDBCommManager1.Active)
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "3001", 1);

            }
        }

        private void btGopoint2_MouseUp(object sender, MouseEventArgs e)
        {
            if (axDBCommManager1.Active)
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "3001", 0);

            }
        }

        private void btGopoint3_MouseDown(object sender, MouseEventArgs e)
        {
            if (axDBCommManager1.Active)
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "3002", 1);

            }
        }

        private void btGopoint3_MouseUp(object sender, MouseEventArgs e)
        {
            if (axDBCommManager1.Active)
            {
                axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_MR, "3002", 0);

            }
        }

        private void btSavepoint_Click(object sender, EventArgs e)
        {
            float floatvaluePoint1X;
            if (float.TryParse(txtPoint1X.Text, out floatvaluePoint1X))
            {
                float multipliedValuePoint1X = floatvaluePoint1X * 100;
                int intValuepoint1X = Convert.ToInt32(multipliedValuePoint1X);
                if (axDBCommManager1.Active)
                {
                    axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_DM, "2000", intValuepoint1X);
                }
            }
            else
            {
            }
            float floatvaluePoint2X;
            if (float.TryParse(txtPoint2X.Text, out floatvaluePoint2X))
            {
                float multipliedValuePoint2X = floatvaluePoint2X * 100;
                int intValuepoint2X = Convert.ToInt32(multipliedValuePoint2X);
                if (axDBCommManager1.Active)
                {
                    axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_DM, "2020", intValuepoint2X);
                }
            }
            else
            {
            }
            float floatvaluePoint3X;
            if (float.TryParse(txtPoint3X.Text, out floatvaluePoint3X))
            {
                float multipliedValuePoint3X = floatvaluePoint3X * 100;
                int intValuepoint3X = Convert.ToInt32(multipliedValuePoint3X);
                if (axDBCommManager1.Active)
                {
                    axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_DM, "2044", intValuepoint3X);
                }
            }
            else
            {
            }

        }
        private Stopwatch stopWatch = new Stopwatch();
        private void btAnalysis_Click(object sender, EventArgs e)
        {



            




        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            float floatvaluePoint1X;
            if (float.TryParse(txtPoint1X.Text, out floatvaluePoint1X))
            {
                float multipliedValuePoint1X = floatvaluePoint1X * 100;
                int intValuepoint1X = Convert.ToInt32(multipliedValuePoint1X);
                if (axDBCommManager1.Active)
                {
                    axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_DM, "3000", intValuepoint1X);
                }
            }
            else
            {
            }
            float floatvaluePoint2X;
            if (float.TryParse(txtPoint2X.Text, out floatvaluePoint2X))
            {
                float multipliedValuePoint2X = floatvaluePoint2X * 100;
                int intValuepoint2X = Convert.ToInt32(multipliedValuePoint2X);
                if (axDBCommManager1.Active)
                {
                    axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_DM, "3020", intValuepoint2X);
                }
            }
            else
            {
            }
            float floatvaluePoint3X;
            if (float.TryParse(txtPoint3X.Text, out floatvaluePoint3X))
            {
                float multipliedValuePoint3X = floatvaluePoint3X * 100;
                int intValuepoint3X = Convert.ToInt32(multipliedValuePoint3X);
                if (axDBCommManager1.Active)
                {
                    axDBCommManager1.WriteDevice(DATABUILDERAXLibLB.DBPlcDevice.DKVNano_DM, "3040", intValuepoint3X);
                }
            }
            else
            {
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Đóng phần mềm 
            var processes = System.Diagnostics.Process.GetProcessesByName("WindowsFormsApplication5");
            if (processes.Length > 0)
            {
                processes[0].CloseMainWindow();
            }
            else
            {
                // Không có phần mềm "DSMver14.09" đang chạy
            }
        }

        private void btAnalysis_MouseDown(object sender, MouseEventArgs e)
        {

            string filePathcode = @"C:\Users\ADMIN\Desktop\BCFR\Dulieu\data.txt";
            File.WriteAllText(filePathcode, "1");



        }

        private void btAnalysis_MouseUp(object sender, MouseEventArgs e)
        {
            string filePathcode = @"C:\Users\ADMIN\Desktop\BCFR\Dulieu\data.txt";
            File.WriteAllText(filePathcode, "0");

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lbToadoX.Text) && !string.IsNullOrEmpty(lbToadoY.Text))
            {
                // Lấy giá trị từ TextBox1 và TextBox2 và nhân với 1.7
                float x = float.Parse(lbToadoX.Text) * 1.4f;
                float y = float.Parse(lbToadoY.Text) * 1.4f;
                pictureBox4.Location = new Point((int)(x + 134), (int)(y + 134));
            }
        }

        private void btSelectmnst_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "MNST files (*.mnt)|*.mnt";
                openFileDialog.Title = "Select a MNT file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Lấy đường dẫn tệp
                    string selectedFilePath = openFileDialog.FileName;

                    // Gán đường dẫn vào label1
                    lbAspath.Text = selectedFilePath;
                    // Đường dẫn để lưu tệp
                    string saveFilePath = @"C:\Users\ADMIN\Desktop\BCFR\Data1\selectedFilePath.txt";
                    
                    // Lưu nội dung của label1
                    System.IO.File.WriteAllText(saveFilePath, lbAspath.Text);
                }
            }
        }
    } 
}
