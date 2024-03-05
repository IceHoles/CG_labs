using System.ComponentModel;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace CGraphix
{
    public partial class Form1 : Form
    {
        Bitmap image;
        ProgressForm progressForm;
        Stack<Bitmap> undoStack = new Stack<Bitmap>();
        Stack<Bitmap> undoundoStack = new Stack<Bitmap>();
        int[,] _structuringElement = new int[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files | *.png; *.jpg; *.bmp | All files (*.*) | *.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
                progressForm = new ProgressForm(image);
                progressForm.ImageProcessed += ProgressForm_ImageProcessed;
                undoStack.Clear();
                undoundoStack.Clear();
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|BMP Image|*.bmp";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveDialog.FileName;
                ImageFormat format = ImageFormat.Png;
                switch (saveDialog.FilterIndex)
                {
                    case 2:
                        format = ImageFormat.Jpeg;
                        break;
                    case 3:
                        format = ImageFormat.Bmp;
                        break;
                }
                pictureBox1.Image.Save(fileName, format);
            }
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (undoStack.Count > 0)
            {
                undoundoStack.Push(image);
                image = undoStack.Pop();
                pictureBox1.Image = image;
                pictureBox1.Refresh();
                progressForm.UpdateImage(image);
            }
        }

        private void ProgressForm_ImageProcessed(Bitmap processedImage)
        {
            undoundoStack.Clear();
            pictureBox1.Image = processedImage;
            image = processedImage;
            pictureBox1.Refresh();
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            InvertFilter filter = new InvertFilter();
            progressForm.backgroundWorker1.RunWorkerAsync(filter);
            progressForm.ShowDialog();
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            Filters filter = new BlurFilter();
            progressForm.backgroundWorker1.RunWorkerAsync(filter);
            progressForm.ShowDialog();
        }

        private void гауссаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            Filters filter = new GaussianFilter();
            progressForm.backgroundWorker1.RunWorkerAsync(filter);
            progressForm.ShowDialog();
        }

        private void чернобелыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            Filters filter = new GrayScaleFilter();
            progressForm.backgroundWorker1.RunWorkerAsync(filter);
            progressForm.ShowDialog();
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            Filters filter = new SepiaFilter();
            progressForm.backgroundWorker1.RunWorkerAsync(filter);
            progressForm.ShowDialog();
        }

        private void яркостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            Filters filter = new BrightnessFilter();
            progressForm.backgroundWorker1.RunWorkerAsync(filter);
            progressForm.ShowDialog();
        }

        private void собеляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            Filters filter = new SobelFilter();
            progressForm.backgroundWorker1.RunWorkerAsync(filter);
            progressForm.ShowDialog();
        }

        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            Filters filter = new SharpnessFilter();
            progressForm.backgroundWorker1.RunWorkerAsync(filter);
            progressForm.ShowDialog();
        }

        private void тиснениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            Filters filter1 = new GrayScaleFilter();
            progressForm.backgroundWorker1.RunWorkerAsync(filter1);
            progressForm.ShowDialog();
            Filters filter = new EmbossingFilter();
            progressForm.backgroundWorker1.RunWorkerAsync(filter);
            progressForm.ShowDialog();
        }

        private void сдвигToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            Filters filter = new ShiftFilter();
            progressForm.backgroundWorker1.RunWorkerAsync(filter);
            progressForm.ShowDialog();
        }

        private void поворотToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            Filters filter = new RotateFilter();
            progressForm.backgroundWorker1.RunWorkerAsync(filter);
            progressForm.ShowDialog();
        }

        private void волныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            Filters filter = new WaveFilter();
            progressForm.backgroundWorker1.RunWorkerAsync(filter);
            progressForm.ShowDialog();
        }

        private void стеклоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            Filters filter = new FrostedGlassFilter();
            progressForm.backgroundWorker1.RunWorkerAsync(filter);
            progressForm.ShowDialog();
        }

        private void motionBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            Filters filter = new MotionBlur();
            progressForm.backgroundWorker1.RunWorkerAsync(filter);
            progressForm.ShowDialog();
        }

        private void щарраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            Filters filter = new BoundariesFilterSharr();
            progressForm.backgroundWorker1.RunWorkerAsync(filter);
            progressForm.ShowDialog();
        }

        private void прюиттаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            Filters filter = new BoundariesFilterPruitt();
            progressForm.backgroundWorker1.RunWorkerAsync(filter);
            progressForm.ShowDialog();
        }

        private void резкость2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            Filters filter = new RoughnessFilter();
            progressForm.backgroundWorker1.RunWorkerAsync(filter);
            progressForm.ShowDialog();
        }

        private void autolevelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            AutolevelsFilter filter = new AutolevelsFilter();
            filter.FindColorLevels(image);
            progressForm.backgroundWorker1.RunWorkerAsync(filter);
            progressForm.ShowDialog();
        }

        private void линейнаяКоррекцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            LinearExpandFilter filter = new LinearExpandFilter();
            filter.FindLevels(image);
            progressForm.backgroundWorker1.RunWorkerAsync(filter);
            progressForm.ShowDialog();
        }

        private void серыйМирToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            GrayWorldFilter filter = new GrayWorldFilter();
            filter.FindAvgColorLevels(image);
            progressForm.backgroundWorker1.RunWorkerAsync(filter);
            progressForm.ShowDialog();
        }

        private void опорныйЦветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            ColorFilter filter = new ColorFilter();
            ColorDialog colorDialog = new ColorDialog();
            ColorDialog SourceColorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
                if (SourceColorDialog.ShowDialog() == DialogResult.OK)
                {
                    filter.SetColors(colorDialog.Color);
                    filter.SetSrcColors(SourceColorDialog.Color);
                }
            progressForm.backgroundWorker1.RunWorkerAsync(filter);
            progressForm.ShowDialog();
        }

        private void идеальныйОтражательToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            PerfectReflectionFilter filter = new PerfectReflectionFilter();
            filter.FindLevels(image);
            progressForm.backgroundWorker1.RunWorkerAsync(filter);
            progressForm.ShowDialog();
        }

        private void медианныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            Filters filter = new MedianFilter();
            progressForm.backgroundWorker1.RunWorkerAsync(filter);
            progressForm.ShowDialog();
        }

        private void topHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            MorphologicalOperations filter = new MorphologicalOperations();
            filter.SetStructuringElement(_structuringElement);
            progressForm.backgroundWorker2.RunWorkerAsync(new Tuple<Bitmap, ProgressForm.ProcessImageDelegate>(image, filter.TopHat));
            progressForm.ShowDialog();
        }

        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            MorphologicalOperations filter = new MorphologicalOperations();
            filter.SetStructuringElement(_structuringElement);
            progressForm.backgroundWorker2.RunWorkerAsync(new Tuple<Bitmap, ProgressForm.ProcessImageDelegate>(image, filter.Erosion));
            progressForm.ShowDialog();
        }

        private void dilationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            MorphologicalOperations filter = new MorphologicalOperations();
            filter.SetStructuringElement(_structuringElement);
            progressForm.backgroundWorker2.RunWorkerAsync(new Tuple<Bitmap, ProgressForm.ProcessImageDelegate>(image, filter.Dilation));
            progressForm.ShowDialog();
        }

        private void openingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            MorphologicalOperations filter = new MorphologicalOperations();
            filter.SetStructuringElement(_structuringElement);
            progressForm.backgroundWorker2.RunWorkerAsync(new Tuple<Bitmap, ProgressForm.ProcessImageDelegate>(image, filter.Opening));
            progressForm.ShowDialog();
        }

        private void closingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            MorphologicalOperations filter = new MorphologicalOperations();
            filter.SetStructuringElement(_structuringElement);
            progressForm.backgroundWorker2.RunWorkerAsync(new Tuple<Bitmap, ProgressForm.ProcessImageDelegate>(image, filter.Closing));
            progressForm.ShowDialog();
        }

        private void blackHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            MorphologicalOperations filter = new MorphologicalOperations();
            filter.SetStructuringElement(_structuringElement);
            progressForm.backgroundWorker2.RunWorkerAsync(new Tuple<Bitmap, ProgressForm.ProcessImageDelegate>(image, filter.BlackHat));
            progressForm.ShowDialog();
        }

        private void gradToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            MorphologicalOperations filter = new MorphologicalOperations();
            filter.SetStructuringElement(_structuringElement);
            progressForm.backgroundWorker2.RunWorkerAsync(new Tuple<Bitmap, ProgressForm.ProcessImageDelegate>(image, filter.Grad));
            progressForm.ShowDialog();
        }

        private void вернутьtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (undoundoStack.Count > 0)
            {
                undoStack.Push(image);
                image = undoundoStack.Pop();
                pictureBox1.Image = image;
                pictureBox1.Refresh();
                progressForm.UpdateImage(image);
            }
        }

        private void светящиесяКраяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            Filters filter1 = new MedianFilter();
            progressForm.backgroundWorker1.RunWorkerAsync(filter1);
            progressForm.ShowDialog();
            Filters filter = new GlowingEdgesFilter();
            progressForm.backgroundWorker1.RunWorkerAsync(filter);
            progressForm.ShowDialog();
        }

        private void структурныйЭлементToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form radiusForm = new Form();
            Label radiusLabel = new Label();
            radiusLabel.Text = "Введите радиус матрицы:";
            radiusLabel.AutoSize = true;
            radiusLabel.Location = new System.Drawing.Point(10, 10);
            NumericUpDown radiusInput = new NumericUpDown();
            radiusInput.Minimum = 1;
            radiusInput.Maximum = 10;
            radiusInput.Value = 1;
            radiusInput.Location = new System.Drawing.Point(10, 40);
            Button radiusButton = new Button();
            radiusButton.Text = "OK";
            radiusButton.DialogResult = DialogResult.OK;
            radiusButton.Location = new System.Drawing.Point(140, 35);
            radiusButton.Size = new System.Drawing.Size(80, 40);
            radiusForm.Controls.AddRange(new Control[] { radiusLabel, radiusInput, radiusButton });
            radiusForm.ClientSize = new System.Drawing.Size(230, 85);
            radiusForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            radiusForm.StartPosition = FormStartPosition.CenterScreen;
            radiusForm.ShowDialog();

            int radius = (int)radiusInput.Value;
            int size = 2 * radius + 1;

            // Окошко для ввода матрицы структурного элемента
            Form structuringElementForm = new Form();
            structuringElementForm.Text = "Введите матрицу структурного элемента";
            structuringElementForm.Size = new System.Drawing.Size(50 + 50 * size, 50 * size + 100);

            TextBox[,] textBoxes = new TextBox[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    textBoxes[i, j] = new TextBox();
                    textBoxes[i, j].Location = new System.Drawing.Point(25 + 50 * j, 25 + 50 * i);
                    textBoxes[i, j].Size = new System.Drawing.Size(30, 50);
                    structuringElementForm.Controls.Add(textBoxes[i, j]);
                }
            }

            Button okButton = new Button();
            okButton.Text = "OK";
            okButton.Size = new System.Drawing.Size(50, 30);
            okButton.DialogResult = DialogResult.OK;
            okButton.Location = new System.Drawing.Point(50 * size / 2 - 11, 20 + 50 * size);
            structuringElementForm.Controls.Add(okButton);
            structuringElementForm.AcceptButton = okButton;
            structuringElementForm.ShowDialog();

            int[,] _structuringElement = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    _structuringElement[i, j] = int.Parse(textBoxes[i, j].Text);
                }
            }
        }

        private void розовыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoStack.Push(new Bitmap(image));
            Filters filter = new PinkFilter();
            progressForm.backgroundWorker1.RunWorkerAsync(filter);
            progressForm.ShowDialog();
        }
    }

    public partial class ProgressForm : Form
    {
        private Bitmap image;
        public BackgroundWorker backgroundWorker1;
        public BackgroundWorker backgroundWorker2;
        private ProgressBar progressBar1;
        private Button btnCancel;
        public ProgressBar ProgressBar => progressBar1;
        public delegate void ImageProcessedEventHandler(Bitmap processedImage);
        public event ImageProcessedEventHandler ImageProcessed;

        public delegate Bitmap ProcessImageDelegate(Bitmap image, BackgroundWorker worker);

        public ProgressForm(Bitmap image)
        {
            InitializeComponent();
            this.image = image;
            btnCancel = new Button
            {
                Location = new System.Drawing.Point(430, 12),
                Size = new System.Drawing.Size(90, 46),
                Text = "Отмена",
                UseVisualStyleBackColor = true
            };
            btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.Controls.Add(btnCancel);
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if(backgroundWorker1.CancellationPending != true) { e.Result = newImage; }
        }

        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var args = (Tuple<Bitmap, ProcessImageDelegate>)e.Argument;
            Bitmap image = args.Item1;
            ProcessImageDelegate processImage = args.Item2;
            Bitmap newImage = processImage(image, backgroundWorker2);
            if (backgroundWorker2.CancellationPending != true) { e.Result = newImage; }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            this.Text = $"Выполнение... {e.ProgressPercentage}%";
        }

        private void backgroundWorker2_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            this.Text = $"Выполнение... {e.ProgressPercentage}%";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                Bitmap processedImage = (Bitmap)e.Result;
                ImageProcessed?.Invoke(processedImage);
                image  = processedImage;
                this.Close();
            }
            progressBar1.Value = 0;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                Bitmap processedImage = (Bitmap)e.Result;
                ImageProcessed?.Invoke(processedImage);
                image = processedImage;
                this.Close();
            }
            progressBar1.Value = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
        }

        public void UpdateImage(Bitmap newImage)
        {
            image = newImage;
        }

        private void InitializeComponent()
        {
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(300, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker2_ProgressChanged);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 46);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выполнение...";
            this.ResumeLayout(false);
        }
    }
}
