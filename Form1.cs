namespace DzSystemCodingPBars
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public async void CounterOfLettersButton(object sender,EventArgs e)
        {
            Task t1 = Task.Run(() => CounterOfLetters());
        }
        public async Task CounterOfLetters()
        {
            await Task.Run(() =>
            {
                OpenFileDialog fd = new OpenFileDialog();
                fd.ShowDialog();
                int count = 0;
                string filePath = fd.FileName;
                string lines;
                string userLetter = textBox1.Text;
                if (!filePath.ToLower().Contains(".txt")) { MessageBox.Show("Вы выбрали не текстовый файл!!");return; }
                using(FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using(StreamReader sr = new StreamReader(fs))
                    {
                        lines = sr.ReadToEnd();
                    }
                }
                string[] letters = lines.Split(new char[] { ' ', '.', ',', '!', '?' });//можно еще по другим знакам сплитить, я основные выписал
                foreach(string letter in letters)
                {
                    if(letter.Length>userLetter.Length)
                    {
                        if (letter.ToLower().Contains(userLetter.ToLower())) count++;
                    }
                    else
                    {
                        if (userLetter.ToLower().Contains(letter.ToLower())) count++;
                    }
                }
                textBox2.Text = $"Количество вхождений: {count}";
            });
        }
    }
}
