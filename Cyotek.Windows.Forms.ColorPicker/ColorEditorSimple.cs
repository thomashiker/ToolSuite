using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms
{
  // Cyotek Color Picker controls library
  // Copyright © 2013-2017 Cyotek Ltd.
  // http://cyotek.com/blog/tag/colorpicker

  // Licensed under the MIT License. See license.txt for the full text.

  // If you use this code in your applications, donations or attribution are welcome

  /// <summary>
  /// Represents a control that allows the editing of a color in a variety of ways.
  /// </summary>
  [DefaultProperty("Color")]
  [DefaultEvent("ColorChanged")]
  public partial class ColorEditorSimple : UserControl, IColorEditor
  {
    #region Constants

    private static readonly object _eventColorChanged = new object();

    private static readonly object _eventOrientationChanged = new object();

    private static readonly object _eventShowAlphaChannelChanged = new object();

    private static readonly object _eventShowColorSpaceLabelsChanged = new object();

    private const int _minimumBarWidth = 30;

    #endregion

    #region Fields

    private Color _color;

    private Orientation _orientation;

    private bool _showColorSpaceLabels;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="ColorEditor"/> class.
    /// </summary>
    public ColorEditorSimple()
    {
      this.InitializeComponent();

      _color = Color.Black;
      _orientation = Orientation.Vertical;
      //this.Size = new Size(200, 260);
      _showColorSpaceLabels = true;
    }

    #endregion

    #region Events

    [Category("Property Changed")]
    public event EventHandler OrientationChanged
    {
      add { this.Events.AddHandler(_eventOrientationChanged, value); }
      remove { this.Events.RemoveHandler(_eventOrientationChanged, value); }
    }

    [Category("Property Changed")]
    public event EventHandler ShowAlphaChannelChanged
    {
      add { this.Events.AddHandler(_eventShowAlphaChannelChanged, value); }
      remove { this.Events.RemoveHandler(_eventShowAlphaChannelChanged, value); }
    }

    /// <summary>
    /// Occurs when the ShowColorSpaceLabels property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ShowColorSpaceLabelsChanged
    {
      add { this.Events.AddHandler(_eventShowColorSpaceLabelsChanged, value); }
      remove { this.Events.RemoveHandler(_eventShowColorSpaceLabelsChanged, value); }
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the orientation of the editor.
    /// </summary>
    /// <value>The orientation.</value>
    [Category("Appearance")]
    [DefaultValue(typeof(Orientation), "Vertical")]
    public virtual Orientation Orientation
    {
      get { return _orientation; }
      set
      {
        if (this.Orientation != value)
        {
          _orientation = value;

          this.OnOrientationChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(true)]
    public bool ShowColorSpaceLabels
    {
      get { return _showColorSpaceLabels; }
      set
      {
        if (_showColorSpaceLabels != value)
        {
          _showColorSpaceLabels = value;

          this.OnShowColorSpaceLabelsChanged(EventArgs.Empty);
        }
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether input changes should be processed.
    /// </summary>
    /// <value><c>true</c> if input changes should be processed; otherwise, <c>false</c>.</value>
    protected bool LockUpdates { get; set; }

    #endregion

    #region Methods

    /// <summary>
    /// Raises the <see cref="ColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorChanged(EventArgs e)
    {
      EventHandler handler;

      this.UpdateFields(false);
            
      handler = (EventHandler)this.Events[_eventColorChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.DockChanged" /> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnDockChanged(EventArgs e)
    {
      base.OnDockChanged(e);
    }

    protected override void OnFontChanged(EventArgs e)
    {
      base.OnFontChanged(e);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.UserControl.Load" /> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
    }

    /// <summary>
    /// Raises the <see cref="OrientationChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnOrientationChanged(EventArgs e)
    {
      EventHandler handler;

      handler = (EventHandler)this.Events[_eventOrientationChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.PaddingChanged" /> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnPaddingChanged(EventArgs e)
    {
      base.OnPaddingChanged(e);
    }

    /// <summary>
    /// Raises the <see cref="E:Resize" /> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
    }

    /// <summary>
    /// Raises the <see cref="ShowAlphaChannelChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnShowAlphaChannelChanged(EventArgs e)
    {
      EventHandler handler;

      handler = (EventHandler)this.Events[_eventShowAlphaChannelChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ShowColorSpaceLabelsChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnShowColorSpaceLabelsChanged(EventArgs e)
    {
      EventHandler handler;

      handler = (EventHandler)this.Events[_eventShowColorSpaceLabelsChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Updates the editing field values.
    /// </summary>
    /// <param name="userAction">if set to <c>true</c> the update is due to user interaction.</param>
    protected virtual void UpdateFields(bool userAction)
    {
      if (!this.LockUpdates)
      {
        try
        {
          this.LockUpdates = true;

          // RGB
          if (!(userAction && rValueLabel.Focused))
          {
            rValueLabel.Text = this.Color.R.ToString();
          }
          if (!(userAction && gValueLabel.Focused))
          {
            gValueLabel.Text = this.Color.G.ToString();
          }
          if (!(userAction && bValueLabel.Focused))
          {
            bValueLabel.Text = this.Color.B.ToString();
          }
          rColorBar.Value = this.Color.R;
          rColorBar.Color = this.Color;
          gColorBar.Value = this.Color.G;
          gColorBar.Color = this.Color;
          bColorBar.Value = this.Color.B;
          bColorBar.Color = this.Color;
        }
        finally
        {
          this.LockUpdates = false;
        }
      }
    }

    private string AddSpaces(string text)
    {
      string result;

      //http://stackoverflow.com/a/272929/148962

      if (!string.IsNullOrEmpty(text))
      {
        StringBuilder newText;

        newText = new StringBuilder(text.Length * 2);
        newText.Append(text[0]);
        for (int i = 1; i < text.Length; i++)
        {
          if (char.IsUpper(text[i]) && text[i - 1] != ' ')
          {
            newText.Append(' ');
          }
          newText.Append(text[i]);
        }

        result = newText.ToString();
      }
      else
      {
        result = null;
      }

      return result;
    }

    private void SetBarStates(bool visible)
    {
      rColorBar.Visible = visible;
      gColorBar.Visible = visible;
      bColorBar.Visible = visible;
    }

    /// <summary>
    /// Change handler for editing components.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private void ValueChangedHandler(object sender, EventArgs e)
    {
      if (!this.LockUpdates)
      {
        bool useRgb;
        bool useNamed;

        useRgb = false;

        this.LockUpdates = true;

        if (sender == rColorBar || sender == gColorBar || sender == bColorBar)
        {
          rValueLabel.Text = rColorBar.Value.ToString();
          gValueLabel.Text = gColorBar.Value.ToString();
          bValueLabel.Text = bColorBar.Value.ToString();

          useRgb = true;
        }

        if (useRgb)
        {
          Color color;

          color = Color.FromArgb((int)rColorBar.Value, (int)gColorBar.Value, (int)bColorBar.Value);

          this.Color = color;
        }

        this.LockUpdates = false;
        this.UpdateFields(true);
      }
    }

    #endregion

    #region IColorEditor Interface

    [Category("Property Changed")]
    public event EventHandler ColorChanged
    {
      add { this.Events.AddHandler(_eventColorChanged, value); }
      remove { this.Events.RemoveHandler(_eventColorChanged, value); }
    }

    /// <summary>
    /// Gets or sets the component color.
    /// </summary>
    /// <value>The component color.</value>
    [Category("Appearance")]
    [DefaultValue(typeof(Color), "0, 0, 0")]
    public virtual Color Color
    {
      get { return _color; }
      set
      {
        /*
         * If the color isn't solid, and ShowAlphaChannel is false
         * remove the alpha channel. Not sure if this is the best
         * place to do it, but it is a blanket fix for now
         */
        if (value.A != 255)
        {
          value = Color.FromArgb(255, value);
        }

        if (_color != value)
        {
          _color = value;

          if (!this.LockUpdates)
          {
            this.LockUpdates = true;
            this.LockUpdates = false;
            this.UpdateFields(false);
          }
          else
          {
            this.OnColorChanged(EventArgs.Empty);
          }
        }
      }
    }

    #endregion
  }
}
