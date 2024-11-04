namespace DzSystemCodingPBars
{
    public partial class Form1 : Form
    {
        public string dirPath = string.Empty;
        public string searchWord = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }
        public async void StartButton(object sender, EventArgs e)
        {
            try
            {
                dirPath = textBox1.Text;
                searchWord = textBox2.Text;
            }
            catch { MessageBox.Show("��� ����"); }
            Task t1 = Task.Run(() => SearchWordInFiles());
        }
        public async Task SearchWordInFiles()
        {
            await Task.Run(() =>
            {
                var files = Directory.EnumerateFiles(dirPath, "*.*", SearchOption.AllDirectories);
                var tasks = new List<Task>();
                foreach (var file in files)
                {
                    tasks.Add(ProcessFile(file));
                }
                Task.WhenAll(tasks);
            });
        }
        public async Task ProcessFile(string filePath)
        {
            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    string content = await reader.ReadToEndAsync();
                    if (content.Contains(searchWord, StringComparison.OrdinalIgnoreCase))
                    {
                        textBox3.Text = $"����� {searchWord} ������� � �����: {filePath}";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"������ ��� ��������� ����� {filePath}: {ex.Message}");
            }
        }
    }
}
