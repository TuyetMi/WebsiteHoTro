using Microsoft.AspNetCore.Mvc;
using WebChuyenNganh.Models;
using System.Data.SqlClient;
using System.Data;
using Accord.MachineLearning;

namespace WebChuyenNganh.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        void ConnectionString()
        {
            con.ConnectionString = "Data Source=LAPTOP-1I64VKT5\\MAYAO;Initial Catalog=DoAnChuyenNganh;User ID=huy;Password=123;TrustServerCertificate=True;";
        }
        static double Distance(double[] vector1, double[] vector2)
        {
            if (vector1.Length != vector2.Length)
            {
                throw new ArgumentException("Vector dimensions must match.");
            }

            double sum = 0.0;
            for (int i = 0; i < vector1.Length; i++)
            {
                sum += Math.Pow(vector1[i] - vector2[i], 2);
            }

            return Math.Sqrt(sum);
        }
        
        
        static int DecideLabel(IEnumerable<(double[] Input, int Label, double Distance)> neighbors)
        {
            // Đếm số lượng xuất hiện của từng nhãn
            Dictionary<int, int> labelCount = new Dictionary<int, int>();
            foreach (var neighbor in neighbors)
            {
                if (labelCount.ContainsKey(neighbor.Label))
                {
                    labelCount[neighbor.Label]++;
                }
                else
                {
                    labelCount[neighbor.Label] = 1;
                }
            }

            // Chọn nhãn có số lượng xuất hiện nhiều nhất làm nhãn dự đoán
            int predictedLabel = labelCount.OrderByDescending(pair => pair.Value).First().Key;

            return predictedLabel;
        }
        static List<(double[] Input, int Label, double Distance)> CalculateDistances(double[] newStudent, double[][] inputs, int[] trainingLabelsInt)
        {
            List<(double[] Input, int Label, double Distance)> distances = new List<(double[], int, double)>();
            for (int i = 0; i < inputs.Length; i++)
            {
                double distance = Distance(newStudent, inputs[i]);
                distances.Add((inputs[i], trainingLabelsInt[i], distance));
            }
            return distances;
        }

        static (int, int) DecideLabels(IEnumerable<(double[] Input, int Label, double Distance)> neighbors)
        {
            Dictionary<int, int> labelCount = new Dictionary<int, int>();
            foreach (var neighbor in neighbors)
            {
                if (labelCount.ContainsKey(neighbor.Label))
                {
                    labelCount[neighbor.Label]++;
                }
                else
                {
                    labelCount[neighbor.Label] = 1;
                }
            }

            var sortedLabels = labelCount.OrderByDescending(pair => pair.Value).ToList();
            int predictedLabel = sortedLabels[0].Key;
            int secondaryLabel = sortedLabels.Count > 1 ? sortedLabels[1].Key : -1;

            return (predictedLabel, secondaryLabel);
        }
        static DataTable LoadDataFromDatabase()
        {
            string connectionString = "Data Source=LAPTOP-1I64VKT5\\MAYAO;Initial Catalog=DoAnChuyenNganh;User ID=huy;Password=123;TrustServerCertificate=True;";
            string storedProcedureName = "GetSinhVienData";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Create a DataTable to store data from the stored procedure
                            DataTable dataTable = new DataTable();

                            // Check and handle the null case
                            if (adapter.Fill(dataTable) > 0)
                            {
                                return dataTable;
                            }
                            else
                            {
                                Console.WriteLine("No data found.");
                                return null;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return null;
                }
            }
        }

        static double[][] GetInputMatrix(DataTable dataTable, params string[] columnNames)
        {
            double[][] result = new double[dataTable.Rows.Count][];
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                result[i] = new double[columnNames.Length];
                for (int j = 0; j < columnNames.Length; j++)
                {
                    result[i][j] = Convert.ToDouble(dataTable.Rows[i][columnNames[j]]);
                }
            }
            return result;
        }

        // Hàm tạo và huấn luyện mô hình KNN
        static KNearestNeighbors TrainKnnModel(double[][] inputs, int[] labels, int k)
        {
            var knn = new KNearestNeighbors(k: k);
            knn.Learn(inputs, labels);
            return knn;
        }
        static List<string> DetermineDiemCaoNhat(Dictionary<string, double> diemMonHoc)
        {
            var diemCaoNhat = diemMonHoc.OrderByDescending(pair => pair.Value).Take(4);
            var tenMonHocCaoNhat = diemCaoNhat.Select(pair => pair.Key).ToList();
            return tenMonHocCaoNhat;
        }

        static int ConvertLabel(Dictionary<string, double> diemMonHoc)
        {
            var tenMonHocCaoNhat = DetermineDiemCaoNhat(diemMonHoc);

            // Kiểm tra điểm cho từng chuyên ngành và trả về chuyên ngành tương ứng
            if (tenMonHocCaoNhat.Contains("Nhập môn lập trình") && tenMonHocCaoNhat.Contains("Cấu truc dữ liệu và giải thuật") &&
                tenMonHocCaoNhat.Contains("Lập trình hướng đối tượng") && tenMonHocCaoNhat.Contains("Công nghệ NET"))
            {
                return 1;
            }
            else if (tenMonHocCaoNhat.Contains("Nhập môn lập trình") && tenMonHocCaoNhat.Contains("Cơ sở dữ liệu") &&
                tenMonHocCaoNhat.Contains("Lập trình hướng đối tượng") && tenMonHocCaoNhat.Contains("Hệ quản trị cơ sở dữ liệu"))
            {
                return 2;
            }

            else if (tenMonHocCaoNhat.Contains("Nhập môn lập trình") && tenMonHocCaoNhat.Contains("Cấu trúc dữ liệu và giải thuật") &&
                tenMonHocCaoNhat.Contains("Lập trình hướng đối tượng") && tenMonHocCaoNhat.Contains("Trí tuệ nhân tạo"))
            {
                return 3;
            }
            else if (tenMonHocCaoNhat.Contains("Nhập môn lập trình") && tenMonHocCaoNhat.Contains("Mạng máy tính") &&
                tenMonHocCaoNhat.Contains("Hệ điều hành") && tenMonHocCaoNhat.Contains("Kiến trúc máy tính"))
            {
                return 4;
            }

            else if (tenMonHocCaoNhat.Contains("Cấu trúc dữ liệu và giải thuật") &&
                tenMonHocCaoNhat.Contains("Lập trình hướng đối tượng") && tenMonHocCaoNhat.Contains("Công nghệ NET"))
            {
                return 1;
            }
            else if (tenMonHocCaoNhat.Contains("Nhập môn lập trình") &&
                tenMonHocCaoNhat.Contains("Lập trình hướng đối tượng") && tenMonHocCaoNhat.Contains("Cấu trúc dữ và liệu giải thuật"))
            {
                return 1;
            }
            else if (tenMonHocCaoNhat.Contains("Nhập môn lập trình") &&
                tenMonHocCaoNhat.Contains("Lập trình hướng đối tượng") && tenMonHocCaoNhat.Contains("Công nghệ NET"))
            {
                return 1;
            }
            else if (tenMonHocCaoNhat.Contains("Nhập môn lập trình") &&
                tenMonHocCaoNhat.Contains("Cấu trúc dữ liệu và giải thuật") && tenMonHocCaoNhat.Contains("Công nghệ NET"))
            {
                return 1;
            }


            else if (tenMonHocCaoNhat.Contains("Cơ sở dữ liệu") &&
                tenMonHocCaoNhat.Contains("Lập trình hướng đối tượng") && tenMonHocCaoNhat.Contains("Hệ quản trị cơ sở dữ liệu"))
            {
                return 2;
            }
            else if (tenMonHocCaoNhat.Contains("Nhập môn lập trình") && tenMonHocCaoNhat.Contains("Cơ sở dữ liệu") &&
                 tenMonHocCaoNhat.Contains("Hệ quản trị cơ sở dữ liệu"))
            {
                return 2;
            }
            else if (tenMonHocCaoNhat.Contains("Nhập môn lập trình") &&
                tenMonHocCaoNhat.Contains("Lập trình hướng đối tượng") && tenMonHocCaoNhat.Contains("Hệ quản trị cơ sở dữ liệu"))
            {
                return 2;
            }
            else if (tenMonHocCaoNhat.Contains("Cơ sở dữ liệu") &&
                tenMonHocCaoNhat.Contains("Nhập môn lập trình") && tenMonHocCaoNhat.Contains("Lập trình hướng đối tượng"))
            {
                return 2;
            }

            else if (tenMonHocCaoNhat.Contains("Cơ sở dữ liệu") && tenMonHocCaoNhat.Contains("Cấu trúc dữ liệu và giải thuật") &&
                 tenMonHocCaoNhat.Contains("Lập trình hướng đối tượng") && tenMonHocCaoNhat.Contains("Hệ điều hành"))
            {
                return 2;
            }
            else if (tenMonHocCaoNhat.Contains("Cấu trúc dữ liệu và giải thuật") &&
                tenMonHocCaoNhat.Contains("Lập trình hướng đối tượng") && tenMonHocCaoNhat.Contains("Trí tuệ nhân tạo"))
            {
                return 3;
            }
            else if (tenMonHocCaoNhat.Contains("Nhập môn lập trình") &&
                tenMonHocCaoNhat.Contains("Lập trình hướng đối tượng") && tenMonHocCaoNhat.Contains("Trí tuệ nhân tạo"))
            {
                return 3;
            }
            else if (
                tenMonHocCaoNhat.Contains("Cấu trúc dữ liệu và giải thuật") && tenMonHocCaoNhat.Contains("Trí tuệ nhân tạo"))
            {
                return 3;
            }
            else if (tenMonHocCaoNhat.Contains("Nhập môn lập trình") &&
                tenMonHocCaoNhat.Contains("Cấu trúc dữ liệu và giải thuật") && tenMonHocCaoNhat.Contains("Trí tuệ nhân tạo"))
            {
                return 3;
            }
            else if (tenMonHocCaoNhat.Contains("Mạng máy tính") &&
                tenMonHocCaoNhat.Contains("Hệ điều hành") && tenMonHocCaoNhat.Contains("Kiến trúc máy tính"))
            {
                return 4;
            }
            else if (tenMonHocCaoNhat.Contains("Nhập môn lập trình") &&
                tenMonHocCaoNhat.Contains("Hệ điều hành") && tenMonHocCaoNhat.Contains("Kiến trúc máy tính"))
            {
                return 4;
            }
            else if (tenMonHocCaoNhat.Contains("Nhập môn lập trình") && tenMonHocCaoNhat.Contains("Mạng máy tính") && tenMonHocCaoNhat.Contains("Kiến trúc máy tính"))
            {
                return 4;
            }
            else if (tenMonHocCaoNhat.Contains("Nhập môn lập trình") && tenMonHocCaoNhat.Contains("Mạng máy tính") &&
                tenMonHocCaoNhat.Contains("Hệ điều hành") && tenMonHocCaoNhat.Contains("Kiến trúc máy tính"))
            {
                return 4;
            }

            else if (tenMonHocCaoNhat.Contains("Trí tuệ nhân tạo") && tenMonHocCaoNhat.Contains("Mạng máy tính") &&
                tenMonHocCaoNhat.Contains("Hệ quản trị cơ sở dữ liệu") && tenMonHocCaoNhat.Contains("Kiến trúc máy tính"))
            {
                return 4;
            }
            else if (tenMonHocCaoNhat.Contains("Công nghệ NET") && tenMonHocCaoNhat.Contains("Mạng máy tính") &&
                tenMonHocCaoNhat.Contains("Lập trình hướng đối tượng") && tenMonHocCaoNhat.Contains("Kiến trúc máy tính"))
            {
                return 4;
            }
            else if (tenMonHocCaoNhat.Contains("Nhập môn lập trình") &&
                tenMonHocCaoNhat.Contains("Cấu trúc dữ liệu và giải thuật") && tenMonHocCaoNhat.Contains("Mạng máy tính"))
            {
                return 4;
            }
            else if (tenMonHocCaoNhat.Contains("Trí tuệ nhân tạo") &&
                tenMonHocCaoNhat.Contains("Lập trình hướng đối tượng") && tenMonHocCaoNhat.Contains("Công nghệ NET"))
            {
                return 1;
            }
            else if (tenMonHocCaoNhat.Contains("Hệ điều hành") && tenMonHocCaoNhat.Contains("Kiến trúc máy tính"))
            {
                return 4;
            }

            else if (tenMonHocCaoNhat.Contains("Mạng máy tính") && tenMonHocCaoNhat.Contains("Kiến trúc máy tính"))
            {
                return 4;
            }
            else if (
                tenMonHocCaoNhat.Contains("Lập trình hướng đối tượng") && tenMonHocCaoNhat.Contains("Nhập môn lập trình"))
            {
                return 1;
            }
            else if (
                tenMonHocCaoNhat.Contains("Lập trình hướng đối tượng") && tenMonHocCaoNhat.Contains("Hệ quản trị cơ sở dữ liệu"))
            {
                return 2;
            }
            else if (
                tenMonHocCaoNhat.Contains("Công nghệ NET") && tenMonHocCaoNhat.Contains("Nhập môn lập trình"))
            {
                return 1;
            }
            else if (tenMonHocCaoNhat.Contains("Cơ sở dữ liệu") &&
                 tenMonHocCaoNhat.Contains("Hệ quản trị cơ sở dữ liệu"))
            {
                return 2;
            }
            else if (tenMonHocCaoNhat.Contains("Cơ sở dữ liệu") &&
                 tenMonHocCaoNhat.Contains("Lập trình hướng đối tượng"))
            {
                return 2;
            }
            else if (
                tenMonHocCaoNhat.Contains("Nhập môn lập trình") && tenMonHocCaoNhat.Contains("Trí tuệ nhân tạo"))
            {
                return 3;
            }
            else if (
                tenMonHocCaoNhat.Contains("Cấu trúc dữ liệu và giải thuật") && tenMonHocCaoNhat.Contains("Trí tuệ nhân tạo"))
            {
                return 3;
            }
            else if (
                tenMonHocCaoNhat.Contains("Nhập môn lập trình") && tenMonHocCaoNhat.Contains("Cơ sở dữ liệu"))
            {
                return 2;
            }
            else if (
                tenMonHocCaoNhat.Contains("Nhập môn lập trình") && tenMonHocCaoNhat.Contains("Hệ điều hành"))
            {
                return 4;
            }
            else if (
                tenMonHocCaoNhat.Contains("Mạng máy tính") && tenMonHocCaoNhat.Contains("Hệ điều hành"))
            {
                return 3;
            }
            else if (
                tenMonHocCaoNhat.Contains("Lập trình hướng đối tượng") && tenMonHocCaoNhat.Contains("Trí tuệ nhân tạo"))
            {
                return 3;
            }
            else if (
                tenMonHocCaoNhat.Contains("Kiến trúc máy tính") && tenMonHocCaoNhat.Contains("Trí tuệ nhân tạo"))
            {
                return 4;
            }
            else if (
                tenMonHocCaoNhat.Contains("Kiến trúc máy tính") && tenMonHocCaoNhat.Contains("Cấu trúc dữ liệu và giải thuật"))
            {
                return 4;
            }
            else if (
                tenMonHocCaoNhat.Contains("Mạng máy tính") && tenMonHocCaoNhat.Contains("Lập trình hướng đối tượng"))
            {
                return 4;
            }
            else if (tenMonHocCaoNhat.Contains("Trí tuệ nhân tạo") &&
                 tenMonHocCaoNhat.Contains("Công nghệ NET"))
            {
                return 1;
            }
            else if (tenMonHocCaoNhat.Contains("Trí tuệ nhân tạo") &&
                 tenMonHocCaoNhat.Contains("Mạng máy tính"))
            {
                return 3;
            }
            else if (tenMonHocCaoNhat.Contains("Cấu trúc dữ liệu và giải thuật") &&
                 tenMonHocCaoNhat.Contains("Mạng máy tính"))
            {
                return 4;
            }

            else
            {
                return 0; // hoặc bất kỳ giá trị khác nếu cần
            }
        }
        static (Dictionary<string, double>[], int[]) GetTrainingLabels()
        {
            string connectionString = "Data Source=LAPTOP-1I64VKT5\\MAYAO;Initial Catalog=DoAnChuyenNganh;User ID=huy;Password=123;TrustServerCertificate=True;";

            List<Dictionary<string, double>> diemMonHocs = new List<Dictionary<string, double>>();
            List<int> labels = new List<int>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetSinhVienData", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Dictionary<string, double> diemMonHoc = new Dictionary<string, double>
                    {
                        { "Nhập môn lập trình", Convert.ToDouble(reader["Nhập môn lập trình"]) },
                        { "Cấu trúc dữ liệu và giải thuật", Convert.ToDouble(reader["Cấu trúc dữ liệu và giải thuật"]) },
                        { "Lập trình hướng đối tượng", Convert.ToDouble(reader["Lập trình hướng đối tượng"]) },
                        { "Công nghệ NET", Convert.ToDouble(reader["Công nghệ NET"]) },
                        { "Cơ sở dữ liệu", Convert.ToDouble(reader["Cơ sở dữ liệu"]) },
                        { "Hệ quản trị cơ sở dữ liệu", Convert.ToDouble(reader["Hệ quản trị cơ sở dữ liệu"]) },
                        { "Trí tuệ nhân tạo", Convert.ToDouble(reader["Trí tuệ nhân tạo"]) },
                        { "Mạng máy tính", Convert.ToDouble(reader["Mạng máy tính"]) },
                        { "Hệ điều hành", Convert.ToDouble(reader["Hệ điều hành"]) },
                        { "Kiến trúc máy tính", Convert.ToDouble(reader["Kiến trúc máy tính"]) }
                    };

                            diemMonHocs.Add(diemMonHoc);
                            int label = ConvertLabel(diemMonHoc); // Implement the ConvertLabel method
                            labels.Add(label);
                        }
                    }
                }
            }

            return (diemMonHocs.ToArray(), labels.ToArray());
        }
        [HttpPost]
        public ActionResult Predict(Student newStudent)
        {
            
            DataTable data = LoadDataFromDatabase();

            double[][] inputs = GetInputMatrix(data,
            "Nhập môn lập trình", "Cấu trúc dữ liệu và giải thuật", "Lập trình hướng đối tượng",
            "Công nghệ NET", "Cơ sở dữ liệu", "Hệ quản trị cơ sở dữ liệu",
            "Trí tuệ nhân tạo", "Mạng máy tính", "Hệ điều hành", "Kiến trúc máy tính");

            var (trainingLabelsDict, trainingLabelsInt) = GetTrainingLabels();

            var knn = TrainKnnModel(inputs, trainingLabelsInt, k: 15);

            List<(double[] Input, int Label, double Distance)> distances = new List<(double[], int, double)>();
            for (int i = 0; i < inputs.Length; i++)
            {
                double distance = Distance(new double[] { newStudent.GradeNhapMonLapTrinh, newStudent.GradeCauTrucDuLieu,newStudent.GradeLapTrinhHuongDoiTuong,newStudent.GradeCongNgheNET,newStudent.GradeCoSoDuLieu,newStudent.GradeHeQuanTriCoSoDuLieu,newStudent.GradeTriTueNhanTao,newStudent.GradeMangMayTinh,newStudent.GradeHeDieuHanh,newStudent.GradeKienTrucMayTinh}, inputs[i]);
                distances.Add((inputs[i], trainingLabelsInt[i], distance));
            }

            distances.Sort((x, y) => x.Distance.CompareTo(y.Distance));

            int kNeighbors = 15;
            var kNearestNeighbors = distances.Take(kNeighbors);

            // Use the modified PrintPredictedLabels method
            var (predictedLabel, secondaryLabel) = DecideLabels(kNearestNeighbors);
            

            if (predictedLabel == 1)
            {
                newStudent.PredictedDepartment = "Công Nghệ Phần Mềm";
            }
            else if (predictedLabel == 2)
            {
                newStudent.PredictedDepartment = "Hệ Thống Thông Tin";
            }
            else if (predictedLabel == 3)
            {
                newStudent.PredictedDepartment = "Khoa Học Phân Tích Dữ Liệu";
            }
            else if (predictedLabel == 4)
            {
                newStudent.PredictedDepartment = "Mạng Máy Tính";
            }
            if (secondaryLabel == 1)
            {
                newStudent.secondaryLabel = "Công Nghệ Phần Mềm";
            }
            else if (secondaryLabel == 2)
            {
                newStudent.secondaryLabel = "Hệ Thống Thông Tin";
            }
            else if (secondaryLabel == 3)
            {
                newStudent.secondaryLabel = "Khoa Học Phân Tích Dữ Liệu";
            }
            else if (secondaryLabel == 4)
            {
                newStudent.secondaryLabel = "Mạng Máy Tính";
            }

            return View("TraCuu", newStudent);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TrangChu()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChonCTDT(string SelectedCTDT)
        {
            
            if (SelectedCTDT == "CTDT12")
            {
                // Nếu chọn CTDT12, trả về view tương ứng
                return View("Index");
            }
            else if (SelectedCTDT == "CTDT13")
            {
                // Nếu chọn CTDT13, trả về view tương ứng
                return View("Index2");
            }
            else
            {
                // Trường hợp không xác định, có thể xử lý khác hoặc trả về view mặc định
                return View("Index");
            }
        }
    }
}