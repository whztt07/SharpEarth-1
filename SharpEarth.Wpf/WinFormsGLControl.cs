using System.Windows.Forms;
using System.Windows.Forms.Integration;
using MethodTimer;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace SharpEarth.Wpf
{
  [Time]
  public class WinFormsGlControl : WindowsFormsHost
  {
    GLControl glControl;
    public WinFormsGlControl()
    {
      Initialized += OnInitialized;
    }

    protected override void Dispose(bool disposing)
    {
      Initialized -= OnInitialized;

      base.Dispose(disposing);
    }

    private void OnInitialized(object sender, System.EventArgs e)
    {
      var flags = GraphicsContextFlags.Default;
      glControl = new GLControl(new GraphicsMode(32, 24), 2, 0, flags);
      glControl.MakeCurrent();
      glControl.Paint += OnPaint;
      glControl.Dock = DockStyle.Fill;
      Child = glControl;
    }

    private void OnPaint(object sender, PaintEventArgs paintEventArgs)
    {
      GL.ClearColor(Color4.Salmon);
      GL.Clear(
          ClearBufferMask.ColorBufferBit |
          ClearBufferMask.DepthBufferBit |
          ClearBufferMask.StencilBufferBit);

      glControl.SwapBuffers();
    }
  }
}
