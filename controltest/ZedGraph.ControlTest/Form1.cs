
#if true

using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using ZedGraph;

namespace ZedGraph.ControlTest
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private PropertyGrid propertyGrid1;
		private ZedGraphControl zedGraphControl1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
			this.SuspendLayout();
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.propertyGrid1.Location = new System.Drawing.Point( 593, 12 );
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size( 259, 432 );
			this.propertyGrid1.TabIndex = 2;
			this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler( this.propertyGrid1_PropertyValueChanged );
			// 
			// zedGraphControl1
			// 
			this.zedGraphControl1.IsEnableHPan = true;
			this.zedGraphControl1.IsEnableVPan = true;
			this.zedGraphControl1.IsEnableZoom = true;
			this.zedGraphControl1.IsScrollY2 = false;
			this.zedGraphControl1.IsShowContextMenu = true;
			this.zedGraphControl1.IsShowHScrollBar = false;
			this.zedGraphControl1.IsShowPointValues = false;
			this.zedGraphControl1.IsShowVScrollBar = false;
			this.zedGraphControl1.IsZoomOnMouseCenter = false;
			this.zedGraphControl1.Location = new System.Drawing.Point( 12, 12 );
			this.zedGraphControl1.Name = "zedGraphControl1";
			this.zedGraphControl1.PanButtons = System.Windows.Forms.MouseButtons.Left;
			this.zedGraphControl1.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
			//this.zedGraphControl1.PanModifierKeys = ( (System.Windows.Forms.Keys)( ( System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None ) ) );
			this.zedGraphControl1.PanModifierKeys2 = System.Windows.Forms.Keys.None;
			this.zedGraphControl1.PointDateFormat = "g";
			this.zedGraphControl1.PointValueFormat = "G";
			this.zedGraphControl1.ScrollMaxX = 0;
			this.zedGraphControl1.ScrollMaxY = 0;
			this.zedGraphControl1.ScrollMaxY2 = 0;
			this.zedGraphControl1.ScrollMinX = 0;
			this.zedGraphControl1.ScrollMinY = 0;
			this.zedGraphControl1.ScrollMinY2 = 0;
			this.zedGraphControl1.Size = new System.Drawing.Size( 567, 432 );
			this.zedGraphControl1.TabIndex = 3;
			this.zedGraphControl1.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
			this.zedGraphControl1.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
			this.zedGraphControl1.ZoomModifierKeys = System.Windows.Forms.Keys.None;
			this.zedGraphControl1.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
			this.zedGraphControl1.ZoomStepFraction = 0.1;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size( 5, 13 );
			this.ClientSize = new System.Drawing.Size( 862, 461 );
			this.Controls.Add( this.zedGraphControl1 );
			this.Controls.Add( this.propertyGrid1 );
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler( this.Form1_Load );
			this.MouseDown += new System.Windows.Forms.MouseEventHandler( this.Form1_MouseDown );
			this.Resize += new System.EventHandler( this.Form1_Resize );
			this.KeyDown += new System.Windows.Forms.KeyEventHandler( this.Form1_KeyDown );
			this.ResumeLayout( false );

		}
#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run( new Form1() );
		}

		private void Form1_Load( object sender, System.EventArgs e )
		{
			GraphPane myPane = zedGraphControl1.GraphPane;

			myPane.Title = "Test Graph";
			double x, y1, y2;
			PointPairList list1 = new PointPairList();
			PointPairList list2 = new PointPairList();

			zedGraphControl1.ContextMenuBuilder += new ZedGraph.ZedGraphControl.ContextMenuBuilderEventHandler( MyContextMenuHandler );

			for( int i = 0; i < 18; i++ )
			{
				x = new XDate( 1995, i, i+5, i, i*2, i*3 );
				//x = (double) i;
				
				y1 = (Math.Sin( i / 9.0 * Math.PI ) + 1.1 ) * 1000.0;
				y2 = Math.Cos( i / 9.0 * Math.PI ) + 1.1;
				list1.Add(x, y1);
				list2.Add(x, y2);
			}

			LineItem myCurve = myPane.AddCurve("Sine", list1, Color.Red, SymbolType.Circle);
			LineItem myCurve2 = myPane.AddCurve("Cos", list2, Color.Blue, SymbolType.Circle);
			//myCurve2.IsY2Axis = true;
			
			myPane.YAxis.Type = AxisType.Log;
			//myPane.YAxis.IsReverse = true;
			//zedGraphControl6.IsShowPointValues = true;
			//zedGraphControl6.PointDateFormat = "hh:MM:ss";
			//zedGraphControl6.PointValueFormat = "f4";

			//double[] xx = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			//double[] yy = { 1, 2, 3, 4, 5, 4, 3, 2, 1, 2 };
			//double[] zz = { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 };
			//PointPairList list = new PointPairList( xx, yy, zz );

			//Color[] colors = { Color.Red, Color.Green, Color.Blue,
			//					Color.Yellow, Color.Orange };
			//Fill fill = new Fill( colors );
			//fill.Type = FillType.GradientByZ;
			//fill.RangeMin = 1;
			//fill.RangeMax = 5;

			//myPane.XAxis.ScaleFormat = "n1";
			//myPane.XAxis.ScaleMag = 0;
			//myPane.XAxis.Type = AxisType.Date;
			//myPane.YAxis.Max = 2499.9;
			//myPane.YAxis.IsScaleVisible = false;
			//myPane.YAxis.IsTic = false;
			//myPane.YAxis.IsMinorTic = false;


			//myPane.Y2Axis.IsVisible = true;
			//myPane.Y2Axis.IsInsideTic = false;
			//myPane.Y2Axis.IsMinorInsideTic = false;
			//myPane.Y2Axis.BaseTic = 500;
			//myPane.Y2Axis.Max = 2499.9;
			//myPane.Y2Axis.Cross = 34601;
			//myPane.Y2Axis.IsAxisSegmentVisible = false;
			//myPane.YAxis.Is

			zedGraphControl1.IsEnableVPan = false;
			zedGraphControl1.IsShowHScrollBar = true;
			zedGraphControl1.ScrollMinX = 33000;
			zedGraphControl1.ScrollMaxX = 37000;

			zedGraphControl1.IsShowVScrollBar = true;
			zedGraphControl1.ScrollMinY = -5000;
			zedGraphControl1.ScrollMaxY = 5000;

			zedGraphControl1.ScrollMinY2 = -2;
			zedGraphControl1.ScrollMaxY2 = 2;
			zedGraphControl1.IsScrollY2 = true; 

			zedGraphControl1.AxisChange();

			SetSize();
			
			propertyGrid1.SelectedObject = myPane;
		}

		private string MyPointValueHandler( object sender, GraphPane pane, CurveItem curve, int iPt )
		{
			PointPair pt = curve[iPt];
			return "This value is " + pt.Y.ToString() + " gallons";
		}

		private void MyContextMenuHandler( object sender, ContextMenu menu )
		{
			//MenuItem menuItem = menu.MenuItems..Find( "Set Scale to Default", false );

			
			foreach( MenuItem item in menu.MenuItems )
			{
				if ( item.Text == "Set Scale to Default" )
				{
					menu.MenuItems.Remove( item );
					break;
				}
			}
			

			//menu.MenuItems.RemoveByKey( "Set Scale to Default" );

			//menu.MenuItems.RemoveAt( 5 );

			/*
			MenuItem menuItem;
			int index = menu.MenuItems.Count;

			menuItem = new MenuItem();
			menuItem.Index = index++;
			menuItem.Text = "My New Item";
			menu.MenuItems.Add( menuItem );
			//menuItem.Click += new System.EventHandler( this.MenuClick_Copy );

			//menu.MenuItems.RemoveAt(2);
			 */
		}

		private void Form1_Resize(object sender, EventArgs e)
		{
			SetSize();
		}

		private void SetSize()
		{
			Size size = new Size( this.Size.Width - propertyGrid1.Width - zedGraphControl1.Left - 20,
									this.Size.Height - zedGraphControl1.Top - 40 );
			zedGraphControl1.Size = size;
			propertyGrid1.Left = this.Size.Width - 10 - propertyGrid1.Width;
			propertyGrid1.Height = Size.Height - 50;
		}

		PointF		startPt;
		double		startX, startY, startY2;
		bool		isDragPoint = false;
		CurveItem	dragCurve;
		int			dragIndex;
		PointPair	startPair;

		private void zedGraphControl1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if ( Control.ModifierKeys == Keys.Alt )
			{
				GraphPane myPane = zedGraphControl1.GraphPane;
				PointF mousePt = new PointF( e.X, e.Y );

				if ( myPane.FindNearestPoint( mousePt, out dragCurve, out dragIndex ) )
				{
					startPt = mousePt;
					startPair = dragCurve.Points[dragIndex];
					isDragPoint = true;
					myPane.ReverseTransform( mousePt, out startX, out startY, out startY2 );
				}
			}

			/*
			if ( myPane.YAxis.Type == AxisType.Linear )
				myPane.YAxis.Type = AxisType.Log;
			else
				myPane.YAxis.Type = AxisType.Linear;

			zedGraphControl4.AxisChange();
			Refresh();
			*/

			/*
			double rangeX = myPane.XAxis.Max - myPane.XAxis.Min;
			myPane.XAxis.Max -= rangeX/20.0;
			myPane.XAxis.Min += rangeX/20.0;
			double rangeY = myPane.YAxis.Max - myPane.YAxis.Min;
			myPane.YAxis.Max -= rangeY/20.0;
			myPane.YAxis.Min += rangeY/20.0;
			zedGraphControl4.AxisChange();
			zedGraphControl4.Refresh();
			//Invalidate();
			*/
		}

		private void zedGraphControl1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if ( isDragPoint )
			{
				// move the point
				double curX, curY, curY2;
				GraphPane myPane = zedGraphControl1.GraphPane;
				PointF mousePt = new PointF( e.X, e.Y );
				myPane.ReverseTransform( mousePt, out curX, out curY, out curY2 );
				PointPair newPt = new PointPair( startPair.X + curX - startX, startPair.Y + curY - startY );
				(dragCurve.Points as PointPairList)[dragIndex] = newPt;
				zedGraphControl1.Refresh();
			}
		}

		private void zedGraphControl1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if ( isDragPoint )
			{
				// finalize the move
				isDragPoint = false;
			}
		}

		private void Graph_PrintPage( object sender, PrintPageEventArgs e )
		{
			//clone the pane so the paneRect can be changed for printing
			//PaneBase printPane = (PaneBase) master.Clone();
			GraphPane printPane = (GraphPane) zedGraphControl1.GraphPane.Clone();
			printPane.PaneRect = new RectangleF( 50, 50, 400, 300 );

			//printPane.Legend.IsVisible = true;
			//printPane.PaneRect = new RectangleF( 50, 50, 300, 300 );
			//printPane.ReSize( e.Graphics, new RectangleF( 50, 50, 300, 300 ) );
				
			//e.Graphics.PageScale = 1.0F;
			//printPane.BaseDimension = 2.0F;
			printPane.Draw( e.Graphics );
		}

		private void DoPrint()
		{
			PrintDocument pd = new PrintDocument();
			//PrintPreviewDialog ppd = new PrintPreviewDialog();
			pd.PrintPage += new PrintPageEventHandler( Graph_PrintPage );
			//ppd.Document = pd;
			//ppd.Show();
			pd.Print();
		}

		private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
		}

		private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//MessageBox.Show( "Howdy" );
			//DoPrint();
		}

		private void propertyGrid1_PropertyValueChanged(object s, System.Windows.Forms.PropertyValueChangedEventArgs e)
		{
			Refresh();
		}

	}
}

#endif



#if false
using System; 
using ZedGraph; 
using System.Data; 
using System.Drawing; 
using System.Windows.Forms; 
using System.IO; 
using System.Globalization; 
using System.Collections; 
using System.Threading; 
//using ICApis; 
 
namespace ZedGraph.ControlTest
{ 
	/// <summary> 
	///  
	/// </summary> 
	public class Form1 : Form 
	{ 
		public const int Hour = 1;
		public const int Day = 2;
		public const int Week = 3;

		private PointPairList _pointPairList = new PointPairList(); 
		private Image _backImage; 
		private System.Windows.Forms.Panel optionsPanel; 
		private System.Windows.Forms.Panel diagramPanel; 
		private GraphPane _myPane = new GraphPane();  
		private RadioButton[] _accuracyButtons; 
		private int _accuracy = Form1.Day; 
 
		Fill _fill = new Fill(Color.FromArgb( 150, 255, 0, 0 ), Color.FromArgb( 150, 130, 255, 130 ), 
			Color.FromArgb( 150, 255, 0, 0 ) ); 
 
		Thread _showGraphThread; 
		private ZedGraph.ZedGraphControl zedGraphControl1; 
 
		public delegate void FinishShowDiagramThread(); 
		public FinishShowDiagramThread m_FinishShowDiagram; 
		private System.Windows.Forms.Panel topPanel; 
		private System.Windows.Forms.Panel buttomPanel; 
		private System.Windows.Forms.Panel sliderPanel; 
		private System.Windows.Forms.Label sliderLabel; 
		private System.Windows.Forms.TrackBar barWidthScaleSlider; 
		private System.Windows.Forms.Panel checkBoxPanel; 
		private System.Windows.Forms.CheckBox autoscaleBox; 
		private System.Windows.Forms.CheckBox showGrid; 
		private System.Windows.Forms.GroupBox accuracyGroup; 
		private System.Windows.Forms.RadioButton everyHour; 
		private System.Windows.Forms.RadioButton everyDay; 
		private System.Windows.Forms.RadioButton everyWeek; 
		private System.Windows.Forms.ProgressBar progressBar1;
		private ZedGraph.ZedGraphControl zedGraphControl2; 
 
		/// <summary> 
		/// This is an estimated value of the amount of data entries which will be added to the graph. 
		/// </summary> 
		private int _estimatedCount = 0; 
 
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run( new Form1() );
		}
 
		private void InitializeComponent() 
		{ 
			this.optionsPanel = new System.Windows.Forms.Panel();
			this.buttomPanel = new System.Windows.Forms.Panel();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.topPanel = new System.Windows.Forms.Panel();
			this.sliderPanel = new System.Windows.Forms.Panel();
			this.sliderLabel = new System.Windows.Forms.Label();
			this.barWidthScaleSlider = new System.Windows.Forms.TrackBar();
			this.checkBoxPanel = new System.Windows.Forms.Panel();
			this.autoscaleBox = new System.Windows.Forms.CheckBox();
			this.showGrid = new System.Windows.Forms.CheckBox();
			this.accuracyGroup = new System.Windows.Forms.GroupBox();
			this.everyHour = new System.Windows.Forms.RadioButton();
			this.everyDay = new System.Windows.Forms.RadioButton();
			this.everyWeek = new System.Windows.Forms.RadioButton();
			this.diagramPanel = new System.Windows.Forms.Panel();
			this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
			this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
			this.optionsPanel.SuspendLayout();
			this.buttomPanel.SuspendLayout();
			this.topPanel.SuspendLayout();
			this.sliderPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.barWidthScaleSlider)).BeginInit();
			this.checkBoxPanel.SuspendLayout();
			this.accuracyGroup.SuspendLayout();
			this.diagramPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// optionsPanel
			// 
			this.optionsPanel.Controls.Add(this.buttomPanel);
			this.optionsPanel.Controls.Add(this.topPanel);
			this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.optionsPanel.Location = new System.Drawing.Point(0, 550);
			this.optionsPanel.Name = "optionsPanel";
			this.optionsPanel.Size = new System.Drawing.Size(1016, 64);
			this.optionsPanel.TabIndex = 1;
			// 
			// buttomPanel
			// 
			this.buttomPanel.Controls.Add(this.progressBar1);
			this.buttomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttomPanel.Location = new System.Drawing.Point(0, 52);
			this.buttomPanel.Name = "buttomPanel";
			this.buttomPanel.Size = new System.Drawing.Size(1016, 12);
			this.buttomPanel.TabIndex = 10;
			// 
			// progressBar1
			// 
			this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.progressBar1.Location = new System.Drawing.Point(0, 0);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(1016, 12);
			this.progressBar1.Step = 1;
			this.progressBar1.TabIndex = 11;
			// 
			// topPanel
			// 
			this.topPanel.Controls.Add(this.sliderPanel);
			this.topPanel.Controls.Add(this.checkBoxPanel);
			this.topPanel.Controls.Add(this.accuracyGroup);
			this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.topPanel.Location = new System.Drawing.Point(0, 0);
			this.topPanel.Name = "topPanel";
			this.topPanel.Size = new System.Drawing.Size(1016, 40);
			this.topPanel.TabIndex = 9;
			// 
			// sliderPanel
			// 
			this.sliderPanel.Controls.Add(this.sliderLabel);
			this.sliderPanel.Controls.Add(this.barWidthScaleSlider);
			this.sliderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sliderPanel.Location = new System.Drawing.Point(72, 0);
			this.sliderPanel.Name = "sliderPanel";
			this.sliderPanel.Size = new System.Drawing.Size(656, 40);
			this.sliderPanel.TabIndex = 14;
			// 
			// sliderLabel
			// 
			this.sliderLabel.Dock = System.Windows.Forms.DockStyle.Right;
			this.sliderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sliderLabel.Location = new System.Drawing.Point(616, 0);
			this.sliderLabel.Name = "sliderLabel";
			this.sliderLabel.Size = new System.Drawing.Size(40, 40);
			this.sliderLabel.TabIndex = 9;
			this.sliderLabel.Text = "1";
			this.sliderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// barWidthScaleSlider
			// 
			this.barWidthScaleSlider.Dock = System.Windows.Forms.DockStyle.Fill;
			this.barWidthScaleSlider.Enabled = false;
			this.barWidthScaleSlider.Location = new System.Drawing.Point(0, 0);
			this.barWidthScaleSlider.Maximum = 500;
			this.barWidthScaleSlider.Minimum = 1;
			this.barWidthScaleSlider.Name = "barWidthScaleSlider";
			this.barWidthScaleSlider.Size = new System.Drawing.Size(656, 40);
			this.barWidthScaleSlider.TabIndex = 10;
			this.barWidthScaleSlider.Value = 1;
			// 
			// checkBoxPanel
			// 
			this.checkBoxPanel.Controls.Add(this.autoscaleBox);
			this.checkBoxPanel.Controls.Add(this.showGrid);
			this.checkBoxPanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.checkBoxPanel.Location = new System.Drawing.Point(0, 0);
			this.checkBoxPanel.Name = "checkBoxPanel";
			this.checkBoxPanel.Size = new System.Drawing.Size(72, 40);
			this.checkBoxPanel.TabIndex = 13;
			// 
			// autoscaleBox
			// 
			this.autoscaleBox.Checked = true;
			this.autoscaleBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.autoscaleBox.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.autoscaleBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.autoscaleBox.Location = new System.Drawing.Point(0, 24);
			this.autoscaleBox.Name = "autoscaleBox";
			this.autoscaleBox.Size = new System.Drawing.Size(72, 16);
			this.autoscaleBox.TabIndex = 12;
			this.autoscaleBox.Text = "Autoscale";
			this.autoscaleBox.CheckedChanged += new System.EventHandler(this.autoscaleBox_CheckedChanged);
			// 
			// showGrid
			// 
			this.showGrid.Checked = true;
			this.showGrid.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showGrid.Dock = System.Windows.Forms.DockStyle.Top;
			this.showGrid.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.showGrid.Location = new System.Drawing.Point(0, 0);
			this.showGrid.Name = "showGrid";
			this.showGrid.Size = new System.Drawing.Size(72, 16);
			this.showGrid.TabIndex = 11;
			this.showGrid.Text = "Show Grid";
			// 
			// accuracyGroup
			// 
			this.accuracyGroup.Controls.Add(this.everyHour);
			this.accuracyGroup.Controls.Add(this.everyDay);
			this.accuracyGroup.Controls.Add(this.everyWeek);
			this.accuracyGroup.Dock = System.Windows.Forms.DockStyle.Right;
			this.accuracyGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.accuracyGroup.Location = new System.Drawing.Point(728, 0);
			this.accuracyGroup.Name = "accuracyGroup";
			this.accuracyGroup.Size = new System.Drawing.Size(288, 40);
			this.accuracyGroup.TabIndex = 12;
			this.accuracyGroup.TabStop = false;
			this.accuracyGroup.Text = " Accuracy ";
			// 
			// everyHour
			// 
			this.everyHour.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.everyHour.Location = new System.Drawing.Point(8, 16);
			this.everyHour.Name = "everyHour";
			this.everyHour.Size = new System.Drawing.Size(80, 16);
			this.everyHour.TabIndex = 0;
			this.everyHour.Text = "Every Hour";
			this.everyHour.Click += new System.EventHandler(this.everyHour_Click);
			// 
			// everyDay
			// 
			this.everyDay.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.everyDay.Location = new System.Drawing.Point(96, 16);
			this.everyDay.Name = "everyDay";
			this.everyDay.Size = new System.Drawing.Size(80, 16);
			this.everyDay.TabIndex = 0;
			this.everyDay.Text = "Every Day";
			this.everyDay.Click += new System.EventHandler(this.everyDay_Click);
			// 
			// everyWeek
			// 
			this.everyWeek.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.everyWeek.Location = new System.Drawing.Point(184, 16);
			this.everyWeek.Name = "everyWeek";
			this.everyWeek.Size = new System.Drawing.Size(80, 16);
			this.everyWeek.TabIndex = 0;
			this.everyWeek.Text = "Every Week";
			this.everyWeek.Click += new System.EventHandler(this.everyWeek_Click);
			// 
			// diagramPanel
			// 
			this.diagramPanel.Controls.Add(this.zedGraphControl2);
			this.diagramPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.diagramPanel.Location = new System.Drawing.Point(0, 0);
			this.diagramPanel.Name = "diagramPanel";
			this.diagramPanel.Size = new System.Drawing.Size(1016, 550);
			this.diagramPanel.TabIndex = 2;
			// 
			// zedGraphControl1
			// 
			this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.zedGraphControl1.IsEnableHPan = true;
			this.zedGraphControl1.IsEnableVPan = true;
			this.zedGraphControl1.IsEnableZoom = true;
			this.zedGraphControl1.IsScrollY2 = false;
			this.zedGraphControl1.IsShowContextMenu = true;
			this.zedGraphControl1.IsShowHScrollBar = false;
			this.zedGraphControl1.IsShowPointValues = false;
			this.zedGraphControl1.IsShowVScrollBar = false;
			this.zedGraphControl1.IsZoomOnMouseCenter = false;
			this.zedGraphControl1.Location = new System.Drawing.Point(0, 0);
			this.zedGraphControl1.Name = "zedGraphControl1";
			this.zedGraphControl1.PanButtons = System.Windows.Forms.MouseButtons.Left;
			this.zedGraphControl1.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
			this.zedGraphControl1.PanModifierKeys2 = System.Windows.Forms.Keys.None;
			this.zedGraphControl1.PointDateFormat = "g";
			this.zedGraphControl1.PointValueFormat = "G";
			this.zedGraphControl1.ScrollMaxX = 0;
			this.zedGraphControl1.ScrollMaxY = 0;
			this.zedGraphControl1.ScrollMaxY2 = 0;
			this.zedGraphControl1.ScrollMinX = 0;
			this.zedGraphControl1.ScrollMinY = 0;
			this.zedGraphControl1.ScrollMinY2 = 0;
			this.zedGraphControl1.Size = new System.Drawing.Size(1016, 550);
			this.zedGraphControl1.TabIndex = 1;
			this.zedGraphControl1.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
			this.zedGraphControl1.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
			this.zedGraphControl1.ZoomModifierKeys = System.Windows.Forms.Keys.None;
			this.zedGraphControl1.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
			this.zedGraphControl1.ZoomStepFraction = 0.1;
			// 
			// zedGraphControl2
			// 
			this.zedGraphControl2.IsEnableHPan = true;
			this.zedGraphControl2.IsEnableVPan = true;
			this.zedGraphControl2.IsEnableZoom = true;
			this.zedGraphControl2.IsScrollY2 = false;
			this.zedGraphControl2.IsShowContextMenu = true;
			this.zedGraphControl2.IsShowHScrollBar = false;
			this.zedGraphControl2.IsShowPointValues = false;
			this.zedGraphControl2.IsShowVScrollBar = false;
			this.zedGraphControl2.IsZoomOnMouseCenter = false;
			this.zedGraphControl2.Location = new System.Drawing.Point(8, 8);
			this.zedGraphControl2.Name = "zedGraphControl2";
			this.zedGraphControl2.PanButtons = System.Windows.Forms.MouseButtons.Left;
			this.zedGraphControl2.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
			this.zedGraphControl2.PanModifierKeys2 = System.Windows.Forms.Keys.None;
			this.zedGraphControl2.PointDateFormat = "g";
			this.zedGraphControl2.PointValueFormat = "G";
			this.zedGraphControl2.ScrollMaxX = 0;
			this.zedGraphControl2.ScrollMaxY = 0;
			this.zedGraphControl2.ScrollMaxY2 = 0;
			this.zedGraphControl2.ScrollMinX = 0;
			this.zedGraphControl2.ScrollMinY = 0;
			this.zedGraphControl2.ScrollMinY2 = 0;
			this.zedGraphControl2.Size = new System.Drawing.Size(904, 432);
			this.zedGraphControl2.TabIndex = 0;
			this.zedGraphControl2.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
			this.zedGraphControl2.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
			this.zedGraphControl2.ZoomModifierKeys = System.Windows.Forms.Keys.None;
			this.zedGraphControl2.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
			this.zedGraphControl2.ZoomStepFraction = 0.1;
			// 
			// DiagramDialogRandom
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1016, 614);
			this.Controls.Add(this.diagramPanel);
			this.Controls.Add(this.optionsPanel);
			this.Name = "DiagramDialogRandom";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.DiagramDialog_Closing);
			this.optionsPanel.ResumeLayout(false);
			this.buttomPanel.ResumeLayout(false);
			this.topPanel.ResumeLayout(false);
			this.sliderPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.barWidthScaleSlider)).EndInit();
			this.checkBoxPanel.ResumeLayout(false);
			this.accuracyGroup.ResumeLayout(false);
			this.diagramPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		} 
 
		public Form1() //Device d_) 
		{ 
			_backImage = Bitmap.FromFile("background.gif"); 
 
			m_FinishShowDiagram = new FinishShowDiagramThread(this.finishShowDiagramThread); 
 
			InitializeComponent(); 
 
 
			this.initGraph(-1);//-1 because we use the default ClusterScaleWidth here 
			this.Show(); 
 
			_showGraphThread = new Thread(new ThreadStart(this.showDiagram)); 
			_showGraphThread.Start(); 
			this.WindowState = FormWindowState.Maximized; 
		} 
 
 
		private void initGraph(double clusterScaleWidth_) 
		{ 
			_myPane = new GraphPane(); 
			if (clusterScaleWidth_ > 0) 
			{ 
				_myPane.ClusterScaleWidth = clusterScaleWidth_; 
			} 
			_myPane.PaneRect = new RectangleF(0,0,zedGraphControl1.Size.Width,zedGraphControl1.Size.Height); 
			_myPane.YAxis.Title = "#Errors"; 
 
			// Fill the pane background with the image 
			try 
			{ 
				TextureBrush texBrush = new TextureBrush(_backImage); 
				_myPane.PaneFill = new Fill( texBrush ); 
			} 
			catch(Exception e_) 
			{ 
				Console.WriteLine("INFOCENTER: Useless exception was caught."); 
				//sometimes we get here an Exception that the _backImage is already in use, 
				//but it simply works, when catching it... 
			} 
 
			_myPane.AxisFill.IsVisible = false;//turn off the axis background fill 
			_myPane.XAxis.IsShowGrid = showGrid.Checked;//defined by the checkBox "showGrid" 
			_myPane.YAxis.IsShowGrid = showGrid.Checked; 
			_myPane.Legend.IsVisible = false;//hide the legend 
			_myPane.XAxis.Type = AxisType.Date; 
			zedGraphControl1.GraphPane = _myPane; 
		} 
 
		private void showDiagram() 
		{ 
			this.clearGraphData(); 
			this.updateGraph(); 
 
			int count = 0;//counts the while loop cycles for scaling the bar width 
			long errors = 0; 
			Random r = new Random(); 
			while (true) 
			{ 
				lock (r) { errors = r.Next(0,99999); }  
				_pointPairList.Add(new XDate( 
					new DateTime(count*(long)Math.Round(Math.Pow(10.0,7))*3600)),errors); 
				this.initGraph(_myPane.ClusterScaleWidth); 
				zedGraphControl1.GraphPane = _myPane; 
				BarItem myCurve = _myPane.AddBar( "ErrorOccurences", _pointPairList, Color.SteelBlue); 
				myCurve.Bar.Fill = _fill; 
				this.updateGraph(); 
				if (count >= 10000) break; 
 
				count++; 
 
				_myPane.ClusterScaleWidth = 10.0*(2.1 -_accuracy) / count;//scale the bar width 
			} 
			updateGraph(); 
			this.Invoke(this.m_FinishShowDiagram); 
		}//showDiagram 
 
		private void finishShowDiagramThread() 
		{ 
			MessageBox.Show("Drawing was finished successfully!"); 
		} 
 
 
		private void showGrid_CheckedChanged(object sender, System.EventArgs e) 
		{ 
			_myPane.XAxis.IsShowGrid = showGrid.Checked; 
			_myPane.YAxis.IsShowGrid = showGrid.Checked; 
			updateGraph(); 
		} 
 
		private void barWidthScaleSlider_Scroll(object sender, System.EventArgs e) 
		{ 
			double val = (double)barWidthScaleSlider.Value/100.0; 
			sliderLabel.Text = "" + Math.Round(val,2); 
			_myPane.ClusterScaleWidth = val; 
			updateGraph(); 
		} 
 
 
		private void clearGraphData() 
		{ 
			_pointPairList = new PointPairList(); 
			_myPane.GraphItemList.Clear(); 
			_myPane.CurveList.Clear(); 
		} 
 
 
		private void updateGraph()  
		{ 
			if (!this.IsDisposed) 
			{ 
				_myPane.AxisChange(this.CreateGraphics()); 
				zedGraphControl1.Refresh(); 
			}//if 
		} 
 
 
		private void DiagramDialog_Closing(object sender, System.ComponentModel.CancelEventArgs e) 
		{ 
			if ((_showGraphThread != null) && (_showGraphThread.IsAlive)) 
			{ 
				_showGraphThread.Abort(); 
			} 
		} 
 
 
		private void everyHour_Click(object sender, System.EventArgs e) 
		{ 
			try 
			{ 
				_accuracy = Form1.Hour; 
				this.accuracyGroup.Enabled = false; 
				_showGraphThread = new Thread(new ThreadStart(this.showDiagram)); 
				_showGraphThread.Start(); 
			} 
			catch(Exception e_) 
			{ 
				MessageBox.Show(e_.Message+"\n"+e_.StackTrace); 
			} 
		} 
 
		private void everyDay_Click(object sender, System.EventArgs e) 
		{ 
			_accuracy = Form1.Day; 
			this.accuracyGroup.Enabled = false; 
			_showGraphThread = new Thread(new ThreadStart(this.showDiagram)); 
			_showGraphThread.Start(); 
		} 
 
		private void everyWeek_Click(object sender, System.EventArgs e) 
		{ 
			_accuracy = Form1.Week; 
			this.accuracyGroup.Enabled = false; 
			_showGraphThread = new Thread(new ThreadStart(this.showDiagram)); 
			_showGraphThread.Start(); 
		} 
 
		private void autoscaleBox_CheckedChanged(object sender, System.EventArgs e) 
		{ 
			if (_showGraphThread.IsAlive) 
			{ 
				barWidthScaleSlider.Enabled = !autoscaleBox.Checked; 
			} 
			else 
			{ 
				barWidthScaleSlider.Enabled = true; 
				//because after drawing the user should be able to alter the scaling 
			} 
		} 
 
 
	} 
} 

#endif
