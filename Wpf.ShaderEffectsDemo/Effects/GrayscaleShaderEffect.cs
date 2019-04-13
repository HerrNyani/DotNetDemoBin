using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace DotNetDemoBin.Wpf.ShaderEffectsDemo.Effects
{
    /// <summary>
    /// Applies a grayscale effect on the supplied Brush.
    /// </summary>
    public class GrayscaleShaderEffect :
        ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty(nameof(Input), typeof(GrayscaleShaderEffect), 0);

        public static readonly DependencyProperty DesaturationFactorProperty = DependencyProperty.Register(
            nameof(DesaturationFactor), typeof(double), typeof(GrayscaleShaderEffect),
            new UIPropertyMetadata(0.0, PixelShaderConstantCallback(0), CoerceDesaturationFactor));

        private static readonly PixelShader DefaultGrayscalePixelShader = new PixelShader
        {
            UriSource = new System.Uri("pack://application:,,,/Resources/ShaderEffects/Grayscale.fxc")
        };

        public GrayscaleShaderEffect()
        {
            // Assign the PixelShader to the base.PixelShader property.
            base.PixelShader = DefaultGrayscalePixelShader;

            // Update shader values
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(DesaturationFactorProperty);
        }

        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        /// <summary>
        /// Defines how saturated the result should be. 0.0 = Grayscale, 1.0 = Full color.
        /// </summary>
        public double DesaturationFactor
        {
            get { return (double)GetValue(DesaturationFactorProperty); }
            set { SetValue(DesaturationFactorProperty, value); }
        }

        private static object CoerceDesaturationFactor(DependencyObject dependencyObj, object value)
        {
            GrayscaleShaderEffect effect = (GrayscaleShaderEffect)dependencyObj;
            double newFactor = (double)value;

            if (newFactor < 0.0 || newFactor > 1.0)
            {
                return effect.DesaturationFactor;
            }

            return newFactor;
        }
    }
}
