using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;

namespace HoursWorked
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Staff> logs;
        public MainWindow()
        {
            InitializeComponent();
            this.logs = new List<Staff>();

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
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                // Read each line
                while ((line = reader.ReadLine()) != null)
                {
                    // Split the line by spaces
                    string[] elements = line.Split(' ');
                    ushort id = ushort.Parse(elements[0]);
                    List<Staff> currentUserLogs = this.logs.FindAll(log => log.Id == id);
                    if(currentUserLogs.Count > 0)
                    {
                        Staff lastLog = currentUserLogs[currentUserLogs.Count - 1];

                        // Print each element
                        foreach (string element in elements)
                        {
                            Console.WriteLine(element);
                        }
                    } 
                    else
                    {

                    }
                }
            }
        }
    }
}
