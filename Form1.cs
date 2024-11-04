namespace DzSystemCodingPBars
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public async void StartFibonacciButton(object sender, EventArgs e)
        {
            Task t1 = Task.Run(() => StartFibonacci());
        }
        public async Task StartFibonacci()
        {
            await Task.Run(() =>
            {
                listBox1.Items.Clear();
                ulong range1 = 0;
                ulong range2 = 0;
                try
                {
                    range1 = ulong.Parse(textBox1.Text);
                    range2 = ulong.Parse(textBox2.Text);
                }
                catch { MessageBox.Show("Данные введены некорректно!");return; }
                ulong num1 = range1;
                ulong num2 = range1+1;
                ulong num3 =0;
                for (int i = (int)range1; i < (int)range2; i++)
                {
                    num3 = num1 + num2;
                    num1 = num2;
                    listBox1.Items.Add(num3);
                    num2 = num3;
                } 
                    

            });
        }
    }
}
