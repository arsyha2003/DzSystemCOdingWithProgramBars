namespace DzSystemCodingPBars
{
    public partial class Form1 : Form
    {
        private List<Task> progressTasks;
        private Dictionary<string, TimeSpan> progressInterval;
        private List<ProgressBar> progressBars;
        public Form1()
        {
            InitializeComponent();
            progressTasks = new List<Task>();
            progressInterval = new Dictionary<string, TimeSpan>();
            progressBar1.Name = "1";
            progressBar2.Name = "2";
            progressBar3.Name = "3";
            progressBar4.Name = "4";
            progressBar5.Name = "5";
            progressBars = new List<ProgressBar>()
            {
                progressBar1,
                progressBar2,
                progressBar3,
                progressBar4,
                progressBar5
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private async void StartProgressBarButton(object sender, EventArgs e)
        {
            int mesto = 1;
            foreach(var pb in progressBars)
            {
                var task = Task.Run(() => StarProgressBars(pb));
                progressTasks.Add(task);
            }
            await Task.WhenAll(progressTasks);
            foreach (var i in progressInterval.OrderBy(x=>x.Value).Select(x=>x))
            {
                listBox1.Items.Add($"|Место №{mesto} |Лошадь номер: {i.Key} | Время: {i.Value.Seconds} cекунд, {i.Value.Milliseconds} миллисекунд");
                mesto++;
            }
        }
        public void ShowLeaderboardButton(object sender, EventArgs e)
        {
            
        }
        private async Task StarProgressBars(ProgressBar progressBar)
        {
            await Task.Run(() =>
            {
                DateTime dateTime = DateTime.Now;
                int speed = new Random().Next(10, 100);
                Color randomColor = Color.FromArgb(new Random().Next(0,256), new Random().Next(0,256), new Random().Next(0,256));
                while (progressBar.Value < 100)
                {
                    progressBar.Value = Math.Min(progressBar.Value + new Random().Next(1, 10), 100);
                    progressBar.ForeColor = randomColor;
                    Thread.Sleep(speed);
                }
                TimeSpan sp = DateTime.Now - dateTime;
                progressInterval.Add(progressBar.Name, sp);
            });

        }
    }
}
