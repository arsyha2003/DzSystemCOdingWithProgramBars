using System;

namespace DzSystemCodingPBars
{
    public partial class Form1 : Form
    {
        List<ProgressBar> progressBarList;
        public Form1()
        {
            InitializeComponent();
            progressBarList = new List<ProgressBar>();

        }
        private void StartProgressBarButton(object sender, EventArgs e)
        {
            try
            {
                int count = int.Parse(textBox1.Text);
                for (int i = 0; i < count; i++)
                {
                    ProgressBar progressBar = new ProgressBar
                    {
                        Location = new Point(10, 50 + i * 30),
                        Size = new Size(350, 20)
                    };
                    this.Controls.Add(progressBar);
                    progressBarList.Add(progressBar);
                    Task.Run(() => StarProgressBars(progressBar));
                }

            }
            catch { }
        
        }
        private void Form1_Load(object sender, EventArgs e){ }
        private async Task StarProgressBars(ProgressBar progressBar)
        {
            await Task.Run(() =>
            {
                int speed = new Random().Next(10, 100);
                Color randomColor = Color.FromArgb(new Random().Next(256), new Random().Next(256), new Random().Next(256));
                while (progressBar.Value < 100)
                {
                    progressBar.Value = Math.Min(progressBar.Value + new Random().Next(1, 10),100);
                    progressBar.ForeColor = randomColor;
                    Thread.Sleep(speed);
                }
            });
        }
    }
}
