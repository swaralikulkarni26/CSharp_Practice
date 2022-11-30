
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    class csvWrite
    {
        public async Task WriteToFile(StreamWriter writeFile, string[] values)
        {
            if (values.Length != 1)
            {
                writeFile.Write(values[0] + "  ==>  ");
                for (int i = 1; i < values.Length; i++)
                {
                    char[] arr = values[i].ToCharArray();
                    string revStr = "";
                    for (int j = arr.Length - 1; j > -1; j--)
                    {
                        revStr += char.ToString(arr[j]);
                    }
                    await writeFile.WriteAsync(revStr);
                    Logger.WriteLog("Reverse string Completed...! ");
                    //writeFile.Write(revStr);
                    if (i != values.Length - 1)
                        writeFile.Write(",");
                }
                writeFile.WriteLine();
                
            }
            else
            {
                writeFile.Write(values[0] + "  ==>  No Value for this Key");
                writeFile.WriteLine();
            }

        }
        public async void  ReadFromFile()
        {

            string filePath = @"C:\\Users\\Swarali kulkarni\\Downloads\\Revit_Category_And_Layer.csv";
            using (StreamWriter writerFile = new StreamWriter(@"C:\Users\Swarali kulkarni\Downloads\Text5.txt"))

              if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        if (!(String.IsNullOrEmpty(line)))
                        {
                            string[] values = line.Split(',');
                            await WriteToFile(writerFile, values);
                           // Task.Delay(3000).Wait();
                        }
                        else
                            writerFile.WriteLine(line);
                        Logger.WriteLog("Write process completed");
                    }
                    writerFile.Close();
                    Logger.WriteLog("File closed.....!!");
                }
                else
                {
                    Console.WriteLine("File is not exist");
                }
            }
        
        internal class Program
        {
            static void Main(string[] args)
            {
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                csvWrite file = new csvWrite();

                Task t1 = Task.Factory.StartNew(() => file.ReadFromFile());
                //Task t1 = new Task(() => file.ReadFromFile());
                // t1.Start();
                watch.Stop();

                Console.WriteLine($"Execution Time:{watch.ElapsedMilliseconds} m");

                // file.ReadFromFile();

                Logger.WriteLog("read write operation is done Asynchronusly is");
                Console.WriteLine("This is end of program..");
                Console.ReadKey();
            }
        }
    }
}



