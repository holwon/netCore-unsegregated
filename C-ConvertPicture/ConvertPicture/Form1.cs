using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace ConvertPicture;

public partial class Form1 : MaterialForm
{
    private readonly MaterialSkinManager materialSkinManager;

    public Form1()
    {
        InitializeComponent();
        materialSkinManager = MaterialSkinManager.Instance;
        materialSkinManager.AddFormToManage(this);
        materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
        //materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }

    /// <summary>
    /// 打开图片
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnOpen_Click(object sender, EventArgs e)
    {
        //this.fileDialog.Filter = fileFilter;
        this.fileDialog.Multiselect = true;
        this.fileDialog.CheckFileExists = true;
        if (fileDialog.ShowDialog() == DialogResult.OK)
        {

            listView1.Items.Clear();
            imageList1.Images.Clear();


            string[] fileNames = this.fileDialog.FileNames;
            foreach (string fileName in fileNames)
            {
                Bitmap bmp = new Bitmap(fileName);
                //保存图片名称
                //bmp.Tag = Path.GetFileNameWithoutExtension(fileName);
                //PictureBox box = new PictureBox();
                //box.Image = bmp;
                //box.Width = 105;
                //box.Height = 150;
                //box.BorderStyle = BorderStyle.FixedSingle;
                //box.Padding = new Padding(2);

                imageList1.Images.Add(bmp);

                pictureBox1.Image = bmp;

            }
            //this.txtFile.Text = Path.GetDirectoryName(fileNames[0]);
            materialListView1.Refresh();
            listView1.Refresh();
        }
    }

}

