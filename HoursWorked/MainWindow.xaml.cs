using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;

namespace WorkLogger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Dictionary<ushort, Staff> staffs;

        public MainWindow()
        {
            InitializeComponent();
            this.staffs = new Dictionary<ushort, Staff>();

        }

        
        public string SelectStaffFile()
        {
            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                FileName = "Document", // Default file name
                DefaultExt = ".txt", // Default file extension
                Filter = "Text documents (.txt)|*.txt" // Filter files by extension
            };
            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
                return dialog.FileName;
            throw new Exception("برنامه فادر به باز کردن فایل انتخابی نبود!");
        }

        void ReadStaffData(string filePath)
        {
            // Open the file
            List<long> invalidLines = new List<long>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                long lineNumber = 0;
                // Read each line
                while ((line = reader.ReadLine()) != null)
                {
                    try
                    {

                    // Split the line by spaces
                    lineNumber++;
                    string[] elements = line.Split(' ');
                    if(elements.Length != 6)
                    {
                        invalidLines.Add(lineNumber);
                        continue;
                    }
                    ushort id = ushort.Parse(elements[0]);
                    string name = elements[1];
                    
                    Staff staff;
                    // Check if staff is previously added to dict or not.
                    try
                    {
                        staff = this.staffs[id];
                    }
                    catch(KeyNotFoundException)
                    {
                        staff = null;
                    }

                    // if not create the new staff.
                    if(staff == null)
                    {
                        staff = new Staff(id, name);
                        this.staffs.Add(id, staff);
                    }

                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        invalidLines.Add(lineNumber);
                        // If for any unpredicted reason the code throws error, add the line as invalid line and continue.
                    }
                }
            }
        }
    }
}
