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
using System.Security.Cryptography;

namespace sod_gamepad
{
    public partial class Main : Form
    {
        string selectedPath = "";
        string original_md5 = "6e789355853093cacee88b87f7726751";
        string expected_md5 = "4e030c0e6f9ea800753c4c4e69229111";
        public Main()
        {
            InitializeComponent();
        }

        private void btn_select_dir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();

            if (dialog.SelectedPath == "")
            {
                MessageBox.Show("No folder was selected!", "Select game folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dialog.SelectedPath != "")
            {
                textBox_path.Text = dialog.SelectedPath;
                richTextBox_log.Text += "Selected path to game folder: " + textBox_path.Text + "\n";

                selectedPath = dialog.SelectedPath;
            }
        }

        private void btn_patch_Click(object sender, EventArgs e)
        {
            if (selectedPath == "")
            {
                MessageBox.Show("No game folder was selected!", "Patch file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (selectedPath != "")
            {
                PatchFile(textBox_path.Text + @"\UnityPlayer.dll");
            }
        }

        private void btn_revert_Click(object sender, EventArgs e)
        {
            if (selectedPath == "")
            {
                MessageBox.Show("No game folder was selected!", "Patch file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (selectedPath != "")
            {
                RevertFile(textBox_path.Text + @"\UnityPlayer.dll");
            }
        }

        private void label_about_Click(object sender, EventArgs e)
        {
            About about_dialog = new About();
            about_dialog.Show();
        }

        void PatchFile(string path)
        {
            
            richTextBox_log.Text += "Opening file: " + path + "\n";

            string tmp_md5 = HashingCompute.GetMD5HashFromFile(path);
            if (tmp_md5 == original_md5)
            {
                richTextBox_log.Text += "DLL md5 matches original!" + "\n";

                //patching UnityPlayer.dll
                BinaryWriter data = new BinaryWriter(File.OpenWrite(path));

                //workaround axis conflict
                //103946c2: f3 0f 10 50 04          MOVSS XMM2, dword ptr [EAX+4]
                data.BaseStream.Position = 0x393ac3;
                uint axis_1 = 0x0450100f;
                data.Write(axis_1);

                //103946cf: f3 0f 10 00 90          MOVSS XMM0, dword ptr [EAX]
                data.BaseStream.Position = 0x393ad0;
                uint axis_2 = 0x9000100f;
                data.Write(axis_2);

                //fixing swapped axis
                //1068187a: f3 0f 11 40 74          MOVSS dword ptr [EAX+0x74], XMM0
                data.BaseStream.Position = 0x680c7b;
                uint swap_1 = 0x7440110f;
                data.Write(swap_1);

                //106818a3: f3 0f 11 40 70          MOVSS dword ptr [EAX+0x70], XMM0
                data.BaseStream.Position = 0x680ca4;
                uint swap_2 = 0x7040110f;
                data.Write(swap_2);

                data.Close();

                string patched_md5 = HashingCompute.GetMD5HashFromFile(path);
                if (patched_md5 == expected_md5)
                {
                    richTextBox_log.Text += "Patched MD5 match!" + "\n";
                }

                MessageBox.Show("Done!", "Patch file", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void RevertFile(string path)
        {

            richTextBox_log.Text += "Opening file: " + path + "\n";

            string tmp_md5 = HashingCompute.GetMD5HashFromFile(path);
            if (tmp_md5 == expected_md5)
            {
                richTextBox_log.Text += "DLL md5 matches patched!" + "\n";

                //reverting UnityPlayer.dll to original code
                BinaryWriter data = new BinaryWriter(File.OpenWrite(path));

                //103946c2: f3 0f 10 14 88          MOVSS XMM2, dword ptr [EAX + this*0x4]
                data.BaseStream.Position = 0x393ac3;
                uint axis_1 = 0x8814100f;
                data.Write(axis_1);

                //103946cf: f3 0f 10 04 88          MOVSS XMM0, dword ptr [EAX + this*0x4]
                data.BaseStream.Position = 0x393ad0;
                uint axis_2 = 0x8804100f;
                data.Write(axis_2);

                //1068187a: f3 0f 11 40 70          MOVSS dword ptr [EAX+0x70], XMM0
                data.BaseStream.Position = 0x680c7b;
                uint swap_1 = 0x7040110f;
                data.Write(swap_1);

                //106818a3: f3 0f 11 40 74          MOVSS dword ptr [EAX+0x74], XMM0
                data.BaseStream.Position = 0x680ca4;
                uint swap_2 = 0x7440110f;
                data.Write(swap_2);

                data.Close();

                string patched_md5 = HashingCompute.GetMD5HashFromFile(path);
                if (patched_md5 == original_md5)
                {
                    richTextBox_log.Text += "Original MD5 match!" + "\n";
                }

                MessageBox.Show("Done!", "Revert file", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        class HashingCompute
        {
            public static String GetMD5HashFromFile(String fileName)
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            public static String GetMD5HashFromStream(MemoryStream mem)
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(mem);


                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            public static String GetMD5HashFromBinary(BinaryReader buf)
            {
                byte[] tmp = buf.ReadBytes((int)buf.BaseStream.Length);
                MemoryStream mem = new MemoryStream();
                mem.Write(tmp, 0, tmp.Length);
                mem.Position = 0;

                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(mem);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            public static String GetSHA1HashFromFile(String fileName)
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                byte[] retVal = sha1.ComputeHash(file);
                file.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        
    }
}
