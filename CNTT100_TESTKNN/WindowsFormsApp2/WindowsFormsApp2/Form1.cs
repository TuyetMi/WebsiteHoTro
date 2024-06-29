using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private List<StudentData> trainingData;
        private int k = 5;
        
        string connectionString = "Data Source=DESKTOP-0LTD4GL;Initial Catalog=mii;User Id=sa;Password=123;Integrated Security=True;";
        public Form1()
        {
            InitializeComponent();
            LoadDataToDataGridView();

        }
        private void LoadDataToDataGridView()
        {

            string storedProcedureName = "GetSinhVienData2";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedureName, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private string LoadDataForKNN()
        {

            string storedProcedureName = "GetSinhVienData2";

            trainingData = new List<StudentData>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(storedProcedureName, connection))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();

                        adapter.Fill(dataTable);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            string maCN = row["MaCN"].ToString();
                            string maSV = row["MaSV"].ToString();
                            double[] scores;

                            if (maCN == "CNPM")
                            {
                                scores = new double[]
                                {
            Convert.ToDouble(row["Nhập môn lập trình"]),
            Convert.ToDouble(row["Cấu trúc dữ liệu và giải thuật"]),
            Convert.ToDouble(row["Lập trình hướng đối tượng"]),
            Convert.ToDouble(row["Công nghệ NET"])
                                };
                            }
                            else if (maCN == "HTTT")
                            {
                                scores = new double[]
                                {
            Convert.ToDouble(row["Nhập môn lập trình"]),
            Convert.ToDouble(row["Cơ sở dữ liệu"]),
            Convert.ToDouble(row["Lập trình hướng đối tượng"]),
            Convert.ToDouble(row["Hệ quản trị cơ sở dữ liệu"])
                                };
                            }
                            else if (maCN == "KHPTDL")
                            {
                                scores = new double[]
                                {
                        Convert.ToDouble(row["Nhập môn lập trình"]),
                        Convert.ToDouble(row["Cấu trúc dữ liệu và giải thuật"]),
                        Convert.ToDouble(row["Lập trình hướng đối tượng"]),
                        Convert.ToDouble(row["Trí tuệ nhân tạo"])
                                };
                            }
                            else if (maCN == "MMT")
                            {
                                scores = new double[]
                                {
                        Convert.ToDouble(row["Nhập môn lập trình"]),
                        Convert.ToDouble(row["Mạng máy tính"]),
                        Convert.ToDouble(row["Hệ điều hành"]),
                        Convert.ToDouble(row["Kiến trúc máy tính"])
                                };
                            }
                            else
                            {
                                // Handle other majors if needed
                                continue;
                            }

                            StudentData studentData = new StudentData
                            {
                                MaCN = maCN,
                                MaSV = maSV,
                                Scores = scores
                            };

                            trainingData.Add(studentData);
                        }
                        return "Data loaded successfully!";
                    }


                    catch (Exception ex)
                    {
                        // Handle exceptions (you might want to log the exception details)
                        return "Error loading data: " + ex.Message;
                    }

                }
            }
        }

        public StudentData CreateStudentDataForCNPM(Control.ControlCollection controls)
        {
            try
            {

                double[] scores = new double[4];

                // Lấy từng TextBox cụ thể
                TextBox txt_1 = controls.Find("txt_NM", true).OfType<TextBox>().FirstOrDefault();
                TextBox txt_2 = controls.Find("txt_CT", true).OfType<TextBox>().FirstOrDefault();
                TextBox txt_3 = controls.Find("txt_LT", true).OfType<TextBox>().FirstOrDefault();
                TextBox txt_4 = controls.Find("txt_NET", true).OfType<TextBox>().FirstOrDefault();
                TextBox txt_5 = controls.Find("txt_ma", true).OfType<TextBox>().FirstOrDefault(); // Added TextBox for MaSV


                // Kiểm tra null để tránh lỗi nếu không tìm thấy TextBox
                if (txt_1 != null && txt_2 != null && txt_3 != null && txt_4 != null && txt_5 != null)
                {
                    // Lấy điểm từ từng TextBox
                    scores[0] = double.Parse(txt_1.Text);
                    scores[1] = double.Parse(txt_2.Text);
                    scores[2] = double.Parse(txt_3.Text);
                    scores[3] = double.Parse(txt_4.Text);
                    string maSV = txt_5.Text;

                    StudentData studentData = new StudentData
                    {
                        MaCN = "CNPM1",
                        MaSV = maSV,
                        Scores = scores
                    };

                    trainingData.Add(studentData);
                    return studentData;
                }
                else
                {
                    // Xử lý lỗi nếu không tìm thấy TextBox
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi trong quá trình đọc dữ liệu từ TextBox
                return null;
            }
        }
        public StudentData CreateStudentDataForHTTT(Control.ControlCollection controls)
        {
            try
            {
                double[] scores = new double[4];

                // Lấy từng TextBox cụ thể
                TextBox txt_1 = controls.Find("txt_NM", true).OfType<TextBox>().FirstOrDefault();
                TextBox txt_2 = controls.Find("txt_CS", true).OfType<TextBox>().FirstOrDefault();
                TextBox txt_3 = controls.Find("txt_LT", true).OfType<TextBox>().FirstOrDefault();
                TextBox txt_4 = controls.Find("txt_HQT", true).OfType<TextBox>().FirstOrDefault();
                TextBox txt_5 = controls.Find("txt_ma", true).OfType<TextBox>().FirstOrDefault();

                // Kiểm tra null để tránh lỗi nếu không tìm thấy TextBox
                if (txt_1 != null && txt_2 != null && txt_3 != null && txt_4 != null && txt_5 != null)
                {
                    // Lấy điểm từ từng TextBox
                    scores[0] = double.Parse(txt_1.Text);
                    scores[1] = double.Parse(txt_2.Text);
                    scores[2] = double.Parse(txt_3.Text);
                    scores[3] = double.Parse(txt_4.Text);
                    string maSV = txt_5.Text;

                    StudentData studentData = new StudentData
                    {
                        MaCN = "HTTT1",
                        MaSV = maSV,
                        Scores = scores
                    };


                    trainingData.Add(studentData);
                    return studentData;
                }
                else
                {
                    // Xử lý lỗi nếu không tìm thấy TextBox
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi trong quá trình đọc dữ liệu từ TextBox
                return null;
            }
        }
        public StudentData CreateStudentDataForKHPTDL(Control.ControlCollection controls)
        {
            try
            {
                double[] scores = new double[4];

                // Lấy từng TextBox cụ thể
                TextBox txt_1 = controls.Find("txt_NM", true).OfType<TextBox>().FirstOrDefault();
                TextBox txt_2 = controls.Find("txt_CT", true).OfType<TextBox>().FirstOrDefault();
                TextBox txt_3 = controls.Find("txt_LT", true).OfType<TextBox>().FirstOrDefault();
                TextBox txt_4 = controls.Find("txt_TT", true).OfType<TextBox>().FirstOrDefault();
                TextBox txt_5 = controls.Find("txt_ma", true).OfType<TextBox>().FirstOrDefault();

                // Kiểm tra null để tránh lỗi nếu không tìm thấy TextBox
                if (txt_1 != null && txt_2 != null && txt_3 != null && txt_4 != null && txt_5 != null)
                {
                    // Lấy điểm từ từng TextBox
                    scores[0] = double.Parse(txt_1.Text);
                    scores[1] = double.Parse(txt_2.Text);
                    scores[2] = double.Parse(txt_3.Text);
                    scores[3] = double.Parse(txt_4.Text);
                    string maSV = txt_5.Text;

                    StudentData studentData = new StudentData
                    {
                        MaCN = "KHPTDL1",
                        MaSV = maSV,
                        Scores = scores
                    };

                    trainingData.Add(studentData);
                    return studentData;

                }
                else
                {
                    // Xử lý lỗi nếu không tìm thấy TextBox
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi trong quá trình đọc dữ liệu từ TextBox
                return null;
            }
        }
        public StudentData CreateStudentDataForMMT(Control.ControlCollection controls)
        {
            try
            {
                double[] scores = new double[4];

                // Lấy từng TextBox cụ thể
                TextBox txt_1 = controls.Find("txt_NM", true).OfType<TextBox>().FirstOrDefault();
                TextBox txt_2 = controls.Find("txt_MMT", true).OfType<TextBox>().FirstOrDefault();
                TextBox txt_3 = controls.Find("txt_HDH", true).OfType<TextBox>().FirstOrDefault();
                TextBox txt_4 = controls.Find("txt_KT", true).OfType<TextBox>().FirstOrDefault();
                TextBox txt_5 = controls.Find("txt_ma", true).OfType<TextBox>().FirstOrDefault();

                // Kiểm tra null để tránh lỗi nếu không tìm thấy TextBox
                if (txt_1 != null && txt_2 != null && txt_3 != null && txt_4 != null && txt_5 != null)
                {
                    // Lấy điểm từ từng TextBox
                    scores[0] = double.Parse(txt_1.Text);
                    scores[1] = double.Parse(txt_2.Text);
                    scores[2] = double.Parse(txt_3.Text);
                    scores[3] = double.Parse(txt_4.Text);
                    string maSV = txt_5.Text;

                    StudentData studentData = new StudentData
                    {
                        MaCN = "MMT1",
                        MaSV = maSV,
                        Scores = scores
                    };


                    trainingData.Add(studentData);
                    return studentData;
                }
                else
                {
                    // Xử lý lỗi nếu không tìm thấy TextBox
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi trong quá trình đọc dữ liệu từ TextBox
                return null;
            }
        }



        private void btn_load_Click_1(object sender, EventArgs e)
        {
            foreach (StudentData student in trainingData)
            {
                listBox.Items.Add($"Chuyên ngành: {student.MaCN}, Mã sinh viên: {student.MaSV}, Điểm: [{string.Join(", ", student.Scores)}]");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string result = LoadDataForKNN();

            if (result.StartsWith("Data loaded successfully!"))
            {
                MessageBox.Show("Dữ liệu đã được tải thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lỗi khi tải dữ liệu:\n" + result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_TimCN_Click_1(object sender, EventArgs e)
        {
            ////// Assuming there's only one student with department code CNPM1 in the training data

            StudentData newStudent1 = trainingData.FirstOrDefault(student => student.MaCN == "CNPM1");
            StudentData newStudent2 = trainingData.FirstOrDefault(student => student.MaCN == "HTTT1");
            StudentData newStudent3 = trainingData.FirstOrDefault(student => student.MaCN == "MMT1");
            StudentData newStudent4 = trainingData.FirstOrDefault(student => student.MaCN == "KHPTDL1");


            // Call the function to calculate distances
            Dictionary<StudentData, double> distances1 = CalculateDistancesForNewStudent1(newStudent1);
            DisplayResults1(distances1);

            Dictionary<StudentData, double> distances2 = CalculateDistancesForNewStudent2(newStudent2);
            DisplayResults2(distances2);

            Dictionary<StudentData, double> distances3 = CalculateDistancesForNewStudent3(newStudent3);
            DisplayResults3(distances3);

            Dictionary<StudentData, double> distances4 = CalculateDistancesForNewStudent4(newStudent4);
            DisplayResults4(distances4);

            //
            Dictionary<StudentData, double> mergedDistances = MergeDistances(distances1, distances2, distances3, distances4);
            //
            List<StudentData> top5Neighbors = GetTop5NearestNeighbors(mergedDistances);
            //
            DisplayResults(txt_top5, top5Neighbors);
            //
            // Count occurrences of each department in the top 5 neighbors
            Dictionary<string, int> departmentCounts = CountDepartmentOccurrences(top5Neighbors);

            // Find the department with the maximum count
            string mostFrequentDepartment = FindMostFrequentDepartment(departmentCounts);

            // Display a message based on the most frequent department
            MessageBox.Show($"Sinh viên mới nên thuộc chuyên ngành: {mostFrequentDepartment}");



        }
        private Dictionary<StudentData, double> MergeDistances(params Dictionary<StudentData, double>[] dictionaries)
        {
            // Merge dictionaries into a single dictionary
            Dictionary<StudentData, double> mergedDistances = new Dictionary<StudentData, double>();

            foreach (var distances in dictionaries)
            {
                foreach (var kvp in distances)
                {
                    // If the student is already in the merged dictionary, update the distance if the new distance is smaller
                    if (mergedDistances.TryGetValue(kvp.Key, out double existingDistance))
                    {
                        if (kvp.Value < existingDistance)
                        {
                            mergedDistances[kvp.Key] = kvp.Value;
                        }
                    }
                    else
                    {
                        // If the student is not in the merged dictionary, add them
                        mergedDistances.Add(kvp.Key, kvp.Value);
                    }
                }
            }

            return mergedDistances;
        }
        private List<StudentData> GetTop5NearestNeighbors(Dictionary<StudentData, double> distances)
        {
            // Order the distances by value in ascending order
            var orderedDistances = distances.OrderBy(d => d.Value);

            // Take the top 5 elements from the ordered distances
            var top5Neighbors = orderedDistances.Take(5).Select(d => d.Key).ToList();

            return top5Neighbors;
        }
        private Dictionary<string, int> CountDepartmentOccurrences(List<StudentData> neighbors)
        {
            // Count occurrences of each department in the given list of neighbors
            Dictionary<string, int> departmentCounts = new Dictionary<string, int>();

            foreach (var neighbor in neighbors)
            {
                if (departmentCounts.ContainsKey(neighbor.MaCN))
                {
                    departmentCounts[neighbor.MaCN]++;
                }
                else
                {
                    departmentCounts[neighbor.MaCN] = 1;
                }
            }

            return departmentCounts;
        }

        private string FindMostFrequentDepartment(Dictionary<string, int> departmentCounts)
        {
            // Find the department with the maximum count
            string mostFrequentDepartment = null;
            int maxCount = 0;

            foreach (var kvp in departmentCounts)
            {
                if (kvp.Value > maxCount)
                {
                    mostFrequentDepartment = kvp.Key;
                    maxCount = kvp.Value;
                }
            }

            return mostFrequentDepartment;
        }
        private void DisplayResults(Label resultLabel, List<StudentData> neighbors)
        {
            // Display the results in the resultLabel or any other UI element
            resultLabel.Text = "Top 5 Nearest Neighbors:\n";

            foreach (var neighbor in neighbors)
            {
                resultLabel.Text += $"{neighbor.MaSV} (MaCN={neighbor.MaCN})\n";
            }
        }

        private double CalculateEuclideanDistance(double[] vector1, double[] vector2)
        {
            if (vector1.Length != vector2.Length)
            {
                throw new ArgumentException("Vector dimensions must be the same.");
            }

            double distancee = 0;
            for (int i = 0; i < vector1.Length; i++)
            {
                distancee += Math.Pow(vector1[i] - vector2[i], 2);


            }
            double distance = Math.Round(Math.Sqrt(distancee), 3);
            return distance;
        }
        private Dictionary<StudentData, double> CalculateDistancesForNewStudent1(StudentData newStudent1)
        {
            // Dictionary to store distances, where the key is the student and the value is the Euclidean distance
            Dictionary<StudentData, double> distances1 = new Dictionary<StudentData, double>();

            // Calculate distances with all students having different department codes
            foreach (var student in trainingData.Where(s => s.MaCN == "CNPM"))
            {

                double distance = CalculateEuclideanDistance(newStudent1.Scores, student.Scores);
                if (distance < 5)
                {
                    distances1.Add(student, distance);
                }
            }

            return distances1;
        }
        private Dictionary<StudentData, double> CalculateDistancesForNewStudent2(StudentData newStudent2)
        {
            // Dictionary to store distances, where the key is the student and the value is the Euclidean distance
            Dictionary<StudentData, double> distances2 = new Dictionary<StudentData, double>();

            // Calculate distances with all students having different department codes
            foreach (var student in trainingData.Where(s => s.MaCN == "HTTT"))
            {

                double distance = CalculateEuclideanDistance(newStudent2.Scores, student.Scores);
                if (distance < 5)
                {
                    distances2.Add(student, distance);
                }
            }

            return distances2;
        }
        private Dictionary<StudentData, double> CalculateDistancesForNewStudent3(StudentData newStudent3)
        {
            // Dictionary to store distances, where the key is the student and the value is the Euclidean distance
            Dictionary<StudentData, double> distances3 = new Dictionary<StudentData, double>();

            // Calculate distances with all students having different department codes
            foreach (var student in trainingData.Where(s => s.MaCN == "MMT"))
            {
                double distance = CalculateEuclideanDistance(newStudent3.Scores, student.Scores);
                if (distance < 5)
                {
                    distances3.Add(student, distance);
                }
            }

            return distances3;
        }
        private Dictionary<StudentData, double> CalculateDistancesForNewStudent4(StudentData newStudent4)
        {
            // Dictionary to store distances, where the key is the student and the value is the Euclidean distance
            Dictionary<StudentData, double> distances4 = new Dictionary<StudentData, double>();

            // Calculate distances with all students having different department codes
            foreach (var student in trainingData.Where(s => s.MaCN == "KHPTDL"))
            {
                double distance = CalculateEuclideanDistance(newStudent4.Scores, student.Scores);
                if (distance < 5)
                {
                    distances4.Add(student, distance);
                }
            }

            return distances4;
        }
        
        private void DisplayResults1(Dictionary<StudentData, double> distances1)
        {
            // Display the results in the resultLabel or any other UI element
            resultLabel1.Text = "Ngành CNPM:\n";

            foreach (var entry in distances1)
            {
                resultLabel1.Text += $"{entry.Key.MaSV} (MaCN={entry.Key.MaCN}): {entry.Value}\n";
            }
        }
        private void DisplayResults2(Dictionary<StudentData, double> distances2)
        {
            // Display the results in the resultLabel or any other UI element
            resultLabel2.Text = "Ngành HTTT:\n";

            foreach (var entry in distances2)
            {
                resultLabel2.Text += $"{entry.Key.MaSV} (MaCN={entry.Key.MaCN}): {entry.Value}\n";
            }
        }
        private void DisplayResults3(Dictionary<StudentData, double> distances3)
        {
            // Display the results in the resultLabel or any other UI element
            resultLabel3.Text = "Ngành MMT:\n";

            foreach (var entry in distances3)
            {
                resultLabel3.Text += $"{entry.Key.MaSV} (MaCN={entry.Key.MaCN}): {entry.Value}\n";
            }
        }
        private void DisplayResults4(Dictionary<StudentData, double> distances4)
        {
            // Display the results in the resultLabel or any other UI element
            resultLabel4.Text = "Ngành KHPTDL:\n";

            foreach (var entry in distances4)
            {
                resultLabel4.Text += $"{entry.Key.MaSV} (MaCN={entry.Key.MaCN}): {entry.Value}\n";
            }
        }

        private void btn_themSV_Click(object sender, EventArgs e)
        {

            // Pass the ControlCollection of your form to the function
            StudentData studentData1 = CreateStudentDataForCNPM(this.Controls);
            StudentData studentData2 = CreateStudentDataForHTTT(this.Controls);
            StudentData studentData3 = CreateStudentDataForMMT(this.Controls);
            StudentData studentData4 = CreateStudentDataForKHPTDL(this.Controls);

            if (studentData1 != null && studentData2 != null && studentData3 != null && studentData4 != null)
            {
                // Data creation successful, you can do further processing or display a message
                MessageBox.Show("Student data created successfully!");
            }
            else
            {
                // Handle the case where data creation fails
                MessageBox.Show("Error creating student data. Please check input values.");
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {

            // Specify the major codes to be deleted
            List<string> majorCodesToDelete = new List<string> { "CNPM1", "MMT1", "HTTT1", "KHPTDL1" };

            // Filter the trainingData list to exclude students with specified major codes
            trainingData = trainingData.Where(student => !majorCodesToDelete.Contains(student.MaCN)).ToList();

            // Display a message indicating that students have been deleted
            MessageBox.Show("Students with specified major codes have been deleted.");

        }
    }
}

