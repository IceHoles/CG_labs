namespace CGraphix
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            сохранитьToolStripMenuItem = new ToolStripMenuItem();
            файлToolStripMenuItem1 = new ToolStripMenuItem();
            фильтрыToolStripMenuItem = new ToolStripMenuItem();
            точечныеToolStripMenuItem = new ToolStripMenuItem();
            инверсияToolStripMenuItem = new ToolStripMenuItem();
            чернобелыйToolStripMenuItem = new ToolStripMenuItem();
            сепияToolStripMenuItem = new ToolStripMenuItem();
            яркостьToolStripMenuItem = new ToolStripMenuItem();
            сдвигToolStripMenuItem = new ToolStripMenuItem();
            поворотToolStripMenuItem = new ToolStripMenuItem();
            волныToolStripMenuItem = new ToolStripMenuItem();
            стеклоToolStripMenuItem = new ToolStripMenuItem();
            autolevelsToolStripMenuItem = new ToolStripMenuItem();
            линейнаяКоррекцияToolStripMenuItem = new ToolStripMenuItem();
            серыйМирToolStripMenuItem = new ToolStripMenuItem();
            опорныйЦветToolStripMenuItem = new ToolStripMenuItem();
            идеальныйОтражательToolStripMenuItem = new ToolStripMenuItem();
            медианныйToolStripMenuItem = new ToolStripMenuItem();
            розовыйToolStripMenuItem = new ToolStripMenuItem();
            матричныеToolStripMenuItem = new ToolStripMenuItem();
            размытиеToolStripMenuItem = new ToolStripMenuItem();
            гауссаToolStripMenuItem = new ToolStripMenuItem();
            резкостьToolStripMenuItem = new ToolStripMenuItem();
            резкость2ToolStripMenuItem = new ToolStripMenuItem();
            тиснениеToolStripMenuItem = new ToolStripMenuItem();
            motionBlurToolStripMenuItem = new ToolStripMenuItem();
            собеляToolStripMenuItem = new ToolStripMenuItem();
            щарраToolStripMenuItem = new ToolStripMenuItem();
            прюиттаToolStripMenuItem = new ToolStripMenuItem();
            светящиесяКраяToolStripMenuItem = new ToolStripMenuItem();
            морфологическиToolStripMenuItem = new ToolStripMenuItem();
            erosionToolStripMenuItem = new ToolStripMenuItem();
            dilationToolStripMenuItem = new ToolStripMenuItem();
            openingToolStripMenuItem = new ToolStripMenuItem();
            closingToolStripMenuItem = new ToolStripMenuItem();
            topHatToolStripMenuItem = new ToolStripMenuItem();
            blackHatToolStripMenuItem = new ToolStripMenuItem();
            gradToolStripMenuItem = new ToolStripMenuItem();
            структурныйЭлементToolStripMenuItem = new ToolStripMenuItem();
            отменитьToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Desktop;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1016, 497);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Black;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, фильтрыToolStripMenuItem, отменитьToolStripMenuItem, toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1016, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.BackColor = Color.Black;
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { открытьToolStripMenuItem, сохранитьToolStripMenuItem, файлToolStripMenuItem1 });
            файлToolStripMenuItem.ForeColor = Color.Silver;
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(59, 24);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.BackColor = SystemColors.Desktop;
            открытьToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.Size = new Size(166, 26);
            открытьToolStripMenuItem.Text = "Открыть";
            открытьToolStripMenuItem.Click += открытьToolStripMenuItem_Click;
            // 
            // сохранитьToolStripMenuItem
            // 
            сохранитьToolStripMenuItem.BackColor = SystemColors.Desktop;
            сохранитьToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            сохранитьToolStripMenuItem.Size = new Size(166, 26);
            сохранитьToolStripMenuItem.Text = "Сохранить";
            сохранитьToolStripMenuItem.Click += сохранитьToolStripMenuItem_Click;
            // 
            // файлToolStripMenuItem1
            // 
            файлToolStripMenuItem1.BackColor = SystemColors.Desktop;
            файлToolStripMenuItem1.ForeColor = SystemColors.ButtonHighlight;
            файлToolStripMenuItem1.Name = "файлToolStripMenuItem1";
            файлToolStripMenuItem1.Size = new Size(166, 26);
            файлToolStripMenuItem1.Text = "Файл";
            // 
            // фильтрыToolStripMenuItem
            // 
            фильтрыToolStripMenuItem.BackColor = Color.Black;
            фильтрыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { точечныеToolStripMenuItem, матричныеToolStripMenuItem, морфологическиToolStripMenuItem });
            фильтрыToolStripMenuItem.ForeColor = Color.Silver;
            фильтрыToolStripMenuItem.Name = "фильтрыToolStripMenuItem";
            фильтрыToolStripMenuItem.Size = new Size(85, 24);
            фильтрыToolStripMenuItem.Text = "Фильтры";
            // 
            // точечныеToolStripMenuItem
            // 
            точечныеToolStripMenuItem.BackColor = SystemColors.Desktop;
            точечныеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { инверсияToolStripMenuItem, чернобелыйToolStripMenuItem, сепияToolStripMenuItem, яркостьToolStripMenuItem, сдвигToolStripMenuItem, поворотToolStripMenuItem, волныToolStripMenuItem, стеклоToolStripMenuItem, autolevelsToolStripMenuItem, линейнаяКоррекцияToolStripMenuItem, серыйМирToolStripMenuItem, опорныйЦветToolStripMenuItem, идеальныйОтражательToolStripMenuItem, медианныйToolStripMenuItem, розовыйToolStripMenuItem });
            точечныеToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            точечныеToolStripMenuItem.Name = "точечныеToolStripMenuItem";
            точечныеToolStripMenuItem.Size = new Size(224, 26);
            точечныеToolStripMenuItem.Text = "Точечные";
            // 
            // инверсияToolStripMenuItem
            // 
            инверсияToolStripMenuItem.BackColor = SystemColors.Desktop;
            инверсияToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            инверсияToolStripMenuItem.Name = "инверсияToolStripMenuItem";
            инверсияToolStripMenuItem.Size = new Size(257, 26);
            инверсияToolStripMenuItem.Text = "Инверсия";
            инверсияToolStripMenuItem.Click += инверсияToolStripMenuItem_Click;
            // 
            // чернобелыйToolStripMenuItem
            // 
            чернобелыйToolStripMenuItem.BackColor = SystemColors.Desktop;
            чернобелыйToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            чернобелыйToolStripMenuItem.Name = "чернобелыйToolStripMenuItem";
            чернобелыйToolStripMenuItem.Size = new Size(257, 26);
            чернобелыйToolStripMenuItem.Text = "Черно-белый";
            чернобелыйToolStripMenuItem.Click += чернобелыйToolStripMenuItem_Click;
            // 
            // сепияToolStripMenuItem
            // 
            сепияToolStripMenuItem.BackColor = SystemColors.Desktop;
            сепияToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            сепияToolStripMenuItem.Name = "сепияToolStripMenuItem";
            сепияToolStripMenuItem.Size = new Size(257, 26);
            сепияToolStripMenuItem.Text = "Сепия";
            сепияToolStripMenuItem.Click += сепияToolStripMenuItem_Click;
            // 
            // яркостьToolStripMenuItem
            // 
            яркостьToolStripMenuItem.BackColor = SystemColors.Desktop;
            яркостьToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            яркостьToolStripMenuItem.Name = "яркостьToolStripMenuItem";
            яркостьToolStripMenuItem.Size = new Size(257, 26);
            яркостьToolStripMenuItem.Text = "Яркость";
            яркостьToolStripMenuItem.Click += яркостьToolStripMenuItem_Click;
            // 
            // сдвигToolStripMenuItem
            // 
            сдвигToolStripMenuItem.BackColor = SystemColors.Desktop;
            сдвигToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            сдвигToolStripMenuItem.Name = "сдвигToolStripMenuItem";
            сдвигToolStripMenuItem.Size = new Size(257, 26);
            сдвигToolStripMenuItem.Text = "Сдвиг";
            сдвигToolStripMenuItem.Click += сдвигToolStripMenuItem_Click;
            // 
            // поворотToolStripMenuItem
            // 
            поворотToolStripMenuItem.BackColor = SystemColors.Desktop;
            поворотToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            поворотToolStripMenuItem.Name = "поворотToolStripMenuItem";
            поворотToolStripMenuItem.Size = new Size(257, 26);
            поворотToolStripMenuItem.Text = "Поворот";
            поворотToolStripMenuItem.Click += поворотToolStripMenuItem_Click;
            // 
            // волныToolStripMenuItem
            // 
            волныToolStripMenuItem.BackColor = SystemColors.Desktop;
            волныToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            волныToolStripMenuItem.Name = "волныToolStripMenuItem";
            волныToolStripMenuItem.Size = new Size(257, 26);
            волныToolStripMenuItem.Text = "Волны";
            волныToolStripMenuItem.Click += волныToolStripMenuItem_Click;
            // 
            // стеклоToolStripMenuItem
            // 
            стеклоToolStripMenuItem.BackColor = SystemColors.Desktop;
            стеклоToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            стеклоToolStripMenuItem.Name = "стеклоToolStripMenuItem";
            стеклоToolStripMenuItem.Size = new Size(257, 26);
            стеклоToolStripMenuItem.Text = "Стекло";
            стеклоToolStripMenuItem.Click += стеклоToolStripMenuItem_Click;
            // 
            // autolevelsToolStripMenuItem
            // 
            autolevelsToolStripMenuItem.BackColor = SystemColors.Desktop;
            autolevelsToolStripMenuItem.ForeColor = SystemColors.ControlLight;
            autolevelsToolStripMenuItem.Name = "autolevelsToolStripMenuItem";
            autolevelsToolStripMenuItem.Size = new Size(257, 26);
            autolevelsToolStripMenuItem.Text = "Autolevels";
            autolevelsToolStripMenuItem.Click += autolevelsToolStripMenuItem_Click;
            // 
            // линейнаяКоррекцияToolStripMenuItem
            // 
            линейнаяКоррекцияToolStripMenuItem.BackColor = SystemColors.Desktop;
            линейнаяКоррекцияToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            линейнаяКоррекцияToolStripMenuItem.Name = "линейнаяКоррекцияToolStripMenuItem";
            линейнаяКоррекцияToolStripMenuItem.Size = new Size(257, 26);
            линейнаяКоррекцияToolStripMenuItem.Text = "Линейная коррекция";
            линейнаяКоррекцияToolStripMenuItem.Click += линейнаяКоррекцияToolStripMenuItem_Click;
            // 
            // серыйМирToolStripMenuItem
            // 
            серыйМирToolStripMenuItem.BackColor = SystemColors.Desktop;
            серыйМирToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            серыйМирToolStripMenuItem.Name = "серыйМирToolStripMenuItem";
            серыйМирToolStripMenuItem.Size = new Size(257, 26);
            серыйМирToolStripMenuItem.Text = "Серый мир";
            серыйМирToolStripMenuItem.Click += серыйМирToolStripMenuItem_Click;
            // 
            // опорныйЦветToolStripMenuItem
            // 
            опорныйЦветToolStripMenuItem.BackColor = SystemColors.Desktop;
            опорныйЦветToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            опорныйЦветToolStripMenuItem.Name = "опорныйЦветToolStripMenuItem";
            опорныйЦветToolStripMenuItem.Size = new Size(257, 26);
            опорныйЦветToolStripMenuItem.Text = "Опорный цвет";
            опорныйЦветToolStripMenuItem.Click += опорныйЦветToolStripMenuItem_Click;
            // 
            // идеальныйОтражательToolStripMenuItem
            // 
            идеальныйОтражательToolStripMenuItem.BackColor = SystemColors.Desktop;
            идеальныйОтражательToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            идеальныйОтражательToolStripMenuItem.Name = "идеальныйОтражательToolStripMenuItem";
            идеальныйОтражательToolStripMenuItem.Size = new Size(257, 26);
            идеальныйОтражательToolStripMenuItem.Text = "Идеальный отражатель";
            идеальныйОтражательToolStripMenuItem.Click += идеальныйОтражательToolStripMenuItem_Click;
            // 
            // медианныйToolStripMenuItem
            // 
            медианныйToolStripMenuItem.BackColor = SystemColors.Desktop;
            медианныйToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            медианныйToolStripMenuItem.Name = "медианныйToolStripMenuItem";
            медианныйToolStripMenuItem.Size = new Size(257, 26);
            медианныйToolStripMenuItem.Text = "Медианный";
            медианныйToolStripMenuItem.Click += медианныйToolStripMenuItem_Click;
            // 
            // розовыйToolStripMenuItem
            // 
            розовыйToolStripMenuItem.BackColor = SystemColors.Desktop;
            розовыйToolStripMenuItem.ForeColor = SystemColors.ControlLightLight;
            розовыйToolStripMenuItem.Name = "розовыйToolStripMenuItem";
            розовыйToolStripMenuItem.Size = new Size(257, 26);
            розовыйToolStripMenuItem.Text = "Розовый";
            розовыйToolStripMenuItem.Click += розовыйToolStripMenuItem_Click;
            // 
            // матричныеToolStripMenuItem
            // 
            матричныеToolStripMenuItem.BackColor = SystemColors.Desktop;
            матричныеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { размытиеToolStripMenuItem, гауссаToolStripMenuItem, резкостьToolStripMenuItem, резкость2ToolStripMenuItem, тиснениеToolStripMenuItem, motionBlurToolStripMenuItem, собеляToolStripMenuItem, щарраToolStripMenuItem, прюиттаToolStripMenuItem, светящиесяКраяToolStripMenuItem });
            матричныеToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            матричныеToolStripMenuItem.Name = "матричныеToolStripMenuItem";
            матричныеToolStripMenuItem.Size = new Size(224, 26);
            матричныеToolStripMenuItem.Text = "Матричные";
            // 
            // размытиеToolStripMenuItem
            // 
            размытиеToolStripMenuItem.BackColor = SystemColors.Desktop;
            размытиеToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            размытиеToolStripMenuItem.Name = "размытиеToolStripMenuItem";
            размытиеToolStripMenuItem.Size = new Size(211, 26);
            размытиеToolStripMenuItem.Text = "Размытие";
            размытиеToolStripMenuItem.Click += размытиеToolStripMenuItem_Click;
            // 
            // гауссаToolStripMenuItem
            // 
            гауссаToolStripMenuItem.BackColor = SystemColors.Desktop;
            гауссаToolStripMenuItem.ForeColor = SystemColors.HighlightText;
            гауссаToolStripMenuItem.Name = "гауссаToolStripMenuItem";
            гауссаToolStripMenuItem.Size = new Size(211, 26);
            гауссаToolStripMenuItem.Text = "Гаусса";
            гауссаToolStripMenuItem.Click += гауссаToolStripMenuItem_Click;
            // 
            // резкостьToolStripMenuItem
            // 
            резкостьToolStripMenuItem.BackColor = SystemColors.Desktop;
            резкостьToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            резкостьToolStripMenuItem.Name = "резкостьToolStripMenuItem";
            резкостьToolStripMenuItem.Size = new Size(211, 26);
            резкостьToolStripMenuItem.Text = "Резкость";
            резкостьToolStripMenuItem.Click += резкостьToolStripMenuItem_Click;
            // 
            // резкость2ToolStripMenuItem
            // 
            резкость2ToolStripMenuItem.BackColor = SystemColors.Desktop;
            резкость2ToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            резкость2ToolStripMenuItem.Name = "резкость2ToolStripMenuItem";
            резкость2ToolStripMenuItem.Size = new Size(211, 26);
            резкость2ToolStripMenuItem.Text = "Резкость 2";
            резкость2ToolStripMenuItem.Click += резкость2ToolStripMenuItem_Click;
            // 
            // тиснениеToolStripMenuItem
            // 
            тиснениеToolStripMenuItem.BackColor = SystemColors.Desktop;
            тиснениеToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            тиснениеToolStripMenuItem.Name = "тиснениеToolStripMenuItem";
            тиснениеToolStripMenuItem.Size = new Size(211, 26);
            тиснениеToolStripMenuItem.Text = "Тиснение";
            тиснениеToolStripMenuItem.Click += тиснениеToolStripMenuItem_Click;
            // 
            // motionBlurToolStripMenuItem
            // 
            motionBlurToolStripMenuItem.BackColor = SystemColors.Desktop;
            motionBlurToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            motionBlurToolStripMenuItem.Name = "motionBlurToolStripMenuItem";
            motionBlurToolStripMenuItem.Size = new Size(211, 26);
            motionBlurToolStripMenuItem.Text = "Motion Blur";
            motionBlurToolStripMenuItem.Click += motionBlurToolStripMenuItem_Click;
            // 
            // собеляToolStripMenuItem
            // 
            собеляToolStripMenuItem.BackColor = SystemColors.Desktop;
            собеляToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            собеляToolStripMenuItem.Name = "собеляToolStripMenuItem";
            собеляToolStripMenuItem.Size = new Size(211, 26);
            собеляToolStripMenuItem.Text = "Собеля";
            собеляToolStripMenuItem.Click += собеляToolStripMenuItem_Click;
            // 
            // щарраToolStripMenuItem
            // 
            щарраToolStripMenuItem.BackColor = SystemColors.Desktop;
            щарраToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            щарраToolStripMenuItem.Name = "щарраToolStripMenuItem";
            щарраToolStripMenuItem.Size = new Size(211, 26);
            щарраToolStripMenuItem.Text = "Щарра";
            щарраToolStripMenuItem.Click += щарраToolStripMenuItem_Click;
            // 
            // прюиттаToolStripMenuItem
            // 
            прюиттаToolStripMenuItem.BackColor = SystemColors.Desktop;
            прюиттаToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            прюиттаToolStripMenuItem.Name = "прюиттаToolStripMenuItem";
            прюиттаToolStripMenuItem.Size = new Size(211, 26);
            прюиттаToolStripMenuItem.Text = "Прюитта";
            прюиттаToolStripMenuItem.Click += прюиттаToolStripMenuItem_Click;
            // 
            // светящиесяКраяToolStripMenuItem
            // 
            светящиесяКраяToolStripMenuItem.BackColor = SystemColors.Desktop;
            светящиесяКраяToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            светящиесяКраяToolStripMenuItem.Name = "светящиесяКраяToolStripMenuItem";
            светящиесяКраяToolStripMenuItem.Size = new Size(211, 26);
            светящиесяКраяToolStripMenuItem.Text = "Светящиеся края";
            светящиесяКраяToolStripMenuItem.Click += светящиесяКраяToolStripMenuItem_Click;
            // 
            // морфологическиToolStripMenuItem
            // 
            морфологическиToolStripMenuItem.BackColor = SystemColors.Desktop;
            морфологическиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { erosionToolStripMenuItem, dilationToolStripMenuItem, openingToolStripMenuItem, closingToolStripMenuItem, topHatToolStripMenuItem, blackHatToolStripMenuItem, gradToolStripMenuItem, структурныйЭлементToolStripMenuItem });
            морфологическиToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            морфологическиToolStripMenuItem.Name = "морфологическиToolStripMenuItem";
            морфологическиToolStripMenuItem.Size = new Size(224, 26);
            морфологическиToolStripMenuItem.Text = "Морфологические";
            // 
            // erosionToolStripMenuItem
            // 
            erosionToolStripMenuItem.BackColor = SystemColors.Desktop;
            erosionToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            erosionToolStripMenuItem.Name = "erosionToolStripMenuItem";
            erosionToolStripMenuItem.Size = new Size(242, 26);
            erosionToolStripMenuItem.Text = "Erosion";
            erosionToolStripMenuItem.Click += erosionToolStripMenuItem_Click;
            // 
            // dilationToolStripMenuItem
            // 
            dilationToolStripMenuItem.BackColor = SystemColors.Desktop;
            dilationToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            dilationToolStripMenuItem.Name = "dilationToolStripMenuItem";
            dilationToolStripMenuItem.Size = new Size(242, 26);
            dilationToolStripMenuItem.Text = "Dilation";
            dilationToolStripMenuItem.Click += dilationToolStripMenuItem_Click;
            // 
            // openingToolStripMenuItem
            // 
            openingToolStripMenuItem.BackColor = SystemColors.Desktop;
            openingToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            openingToolStripMenuItem.Name = "openingToolStripMenuItem";
            openingToolStripMenuItem.Size = new Size(242, 26);
            openingToolStripMenuItem.Text = "Opening";
            openingToolStripMenuItem.Click += openingToolStripMenuItem_Click;
            // 
            // closingToolStripMenuItem
            // 
            closingToolStripMenuItem.BackColor = SystemColors.Desktop;
            closingToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            closingToolStripMenuItem.Name = "closingToolStripMenuItem";
            closingToolStripMenuItem.Size = new Size(242, 26);
            closingToolStripMenuItem.Text = "Closing";
            closingToolStripMenuItem.Click += closingToolStripMenuItem_Click;
            // 
            // topHatToolStripMenuItem
            // 
            topHatToolStripMenuItem.BackColor = SystemColors.Desktop;
            topHatToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            topHatToolStripMenuItem.Name = "topHatToolStripMenuItem";
            topHatToolStripMenuItem.Size = new Size(242, 26);
            topHatToolStripMenuItem.Text = "TopHat";
            topHatToolStripMenuItem.Click += topHatToolStripMenuItem_Click;
            // 
            // blackHatToolStripMenuItem
            // 
            blackHatToolStripMenuItem.BackColor = SystemColors.Desktop;
            blackHatToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            blackHatToolStripMenuItem.Name = "blackHatToolStripMenuItem";
            blackHatToolStripMenuItem.Size = new Size(242, 26);
            blackHatToolStripMenuItem.Text = "BlackHat";
            blackHatToolStripMenuItem.Click += blackHatToolStripMenuItem_Click;
            // 
            // gradToolStripMenuItem
            // 
            gradToolStripMenuItem.BackColor = SystemColors.Desktop;
            gradToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            gradToolStripMenuItem.Name = "gradToolStripMenuItem";
            gradToolStripMenuItem.Size = new Size(242, 26);
            gradToolStripMenuItem.Text = "Grad";
            gradToolStripMenuItem.Click += gradToolStripMenuItem_Click;
            // 
            // структурныйЭлементToolStripMenuItem
            // 
            структурныйЭлементToolStripMenuItem.BackColor = SystemColors.Desktop;
            структурныйЭлементToolStripMenuItem.ForeColor = SystemColors.ButtonHighlight;
            структурныйЭлементToolStripMenuItem.Name = "структурныйЭлементToolStripMenuItem";
            структурныйЭлементToolStripMenuItem.Size = new Size(242, 26);
            структурныйЭлементToolStripMenuItem.Text = "Структурный элемент";
            структурныйЭлементToolStripMenuItem.Click += структурныйЭлементToolStripMenuItem_Click;
            // 
            // отменитьToolStripMenuItem
            // 
            отменитьToolStripMenuItem.BackColor = Color.Black;
            отменитьToolStripMenuItem.ForeColor = Color.Silver;
            отменитьToolStripMenuItem.Name = "отменитьToolStripMenuItem";
            отменитьToolStripMenuItem.Size = new Size(91, 24);
            отменитьToolStripMenuItem.Text = "Отменить";
            отменитьToolStripMenuItem.Click += отменитьToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.BackColor = Color.Black;
            toolStripMenuItem1.ForeColor = Color.Silver;
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(79, 24);
            toolStripMenuItem1.Text = "Вернуть";
            toolStripMenuItem1.Click += вернутьtoolStripMenuItem1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(1016, 525);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            ForeColor = SystemColors.Desktop;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Лаба CG";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem сохранитьToolStripMenuItem;
        private ToolStripMenuItem фильтрыToolStripMenuItem;
        private ToolStripMenuItem точечныеToolStripMenuItem;
        private ToolStripMenuItem инверсияToolStripMenuItem;
        private ToolStripMenuItem матричныеToolStripMenuItem;
        private ToolStripMenuItem размытиеToolStripMenuItem;
        private ToolStripMenuItem гауссаToolStripMenuItem;
        private ToolStripMenuItem чернобелыйToolStripMenuItem;
        private ToolStripMenuItem сепияToolStripMenuItem;
        private ToolStripMenuItem яркостьToolStripMenuItem;
        private ToolStripMenuItem собеляToolStripMenuItem;
        private ToolStripMenuItem резкостьToolStripMenuItem;
        private ToolStripMenuItem тиснениеToolStripMenuItem;
        private ToolStripMenuItem сдвигToolStripMenuItem;
        private ToolStripMenuItem поворотToolStripMenuItem;
        private ToolStripMenuItem волныToolStripMenuItem;
        private ToolStripMenuItem стеклоToolStripMenuItem;
        private ToolStripMenuItem motionBlurToolStripMenuItem;
        private ToolStripMenuItem щарраToolStripMenuItem;
        private ToolStripMenuItem прюиттаToolStripMenuItem;
        private ToolStripMenuItem отменитьToolStripMenuItem;
        private ToolStripMenuItem резкость2ToolStripMenuItem;
        private ToolStripMenuItem autolevelsToolStripMenuItem;
        private ToolStripMenuItem линейнаяКоррекцияToolStripMenuItem;
        private ToolStripMenuItem серыйМирToolStripMenuItem;
        private ToolStripMenuItem опорныйЦветToolStripMenuItem;
        private ToolStripMenuItem идеальныйОтражательToolStripMenuItem;
        private ToolStripMenuItem морфологическиToolStripMenuItem;
        private ToolStripMenuItem topHatToolStripMenuItem;
        private ToolStripMenuItem медианныйToolStripMenuItem;
        private ToolStripMenuItem erosionToolStripMenuItem;
        private ToolStripMenuItem dilationToolStripMenuItem;
        private ToolStripMenuItem openingToolStripMenuItem;
        private ToolStripMenuItem closingToolStripMenuItem;
        private ToolStripMenuItem blackHatToolStripMenuItem;
        private ToolStripMenuItem gradToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem файлToolStripMenuItem1;
        private ToolStripMenuItem светящиесяКраяToolStripMenuItem;
        private ToolStripMenuItem структурныйЭлементToolStripMenuItem;
        private ToolStripMenuItem розовыйToolStripMenuItem;
    }
}
