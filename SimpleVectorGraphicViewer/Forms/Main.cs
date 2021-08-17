using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleVectorGraphicViewer.Serialization;
using SimpleVectorGraphicViewer.Serialization.Serializers;
using SimpleVectorGraphicViewer.Utils.Wrappers;

namespace SimpleVectorGraphicViewer
{
    public partial class Form1 : Form
    {
        internal static Form1 Instance; 
        
        public Form1()
        {
            InitializeComponent();
            Instance = this;

            // Avoid excessive single-threaded redraw
            ResizeBegin += (_,__) => SuspendLayout();
            ResizeEnd += (_,__) => ResumeLayout();
            Shown += Form1_Shown;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            MessageBoxEx.Show(this, "You can use mouse wheel scrolling to zoom in/out.", "Tooltip");
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Close();
            Environment.Exit(0);
        }

        private void showPresetShapesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            plot1.ShowPresetShapes();
        }

        private async void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog.Filter = "Data files (*.json;*.xml;*.yml)|*.json;*.xml;*.yml";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the path of specified file
                var filePath = openFileDialog.FileName;


                ISerializer serializer;
                switch (Path.GetExtension(filePath))
                {
                    case ".json":
                        {
                            serializer = new JsonSerializer();
                            break;
                        }

                    case ".xml":
                        {
                            serializer = new XmlSerializer();
                            break;
                        }

                    case ".yml":
                        {
                            serializer = new YmlSerializer();
                            break;
                        }

                    default: throw new Exception("Unsupported serializer");
                }

                await Task.Run(() =>
                {
                    // Read the contents of the file into a stream
                    using var reader = new StreamReader(openFileDialog.OpenFile());
                    var primitives = Serialization.Parsers.Parser.ParseData(serializer, reader.ReadToEnd());

                    try
                    {
                        plot1.RWL.AcquireWriterLock(100);
                        plot1.Primitives = primitives;
                    }
                    finally
                    {
                        plot1.RWL.ReleaseWriterLock();
                    }

                    this.UIThread(() => plot1.Invalidate());
                });
            }
        }

        private void clearGraphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            plot1.Primitives.Clear();
            plot1.Invalidate();
        }

        private void scaleWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scaleWindowToolStripMenuItem.Checked = !scaleWindowToolStripMenuItem.Checked;
        }

        private void resetViewzoomLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            plot1.ResetView();
            plot1.Invalidate();
        }
    }
}
