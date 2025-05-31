namespace valsesv._Project.Scripts.UI.Options
{
    public class OptionsWindow : UiPanel
    {
        protected override void Start()
        {
            base.Start();
            InitSliders();
        }

        private void InitSliders()
        {
            var sliders = GetComponentsInChildren<OptionsSlider>();

            foreach (var slider in sliders)
            {
                slider.Init();
            }
        }
    }
}