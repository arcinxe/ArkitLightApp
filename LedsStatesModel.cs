namespace ArktiLight
{
    public class LedsStatesModel
    {
        public class WhiteLed
        {
            public int brightness { get; set; }
            public int state { get; set; }
        }

        public class OrangeLed
        {
            public int brightness { get; set; }
            public int state { get; set; }
        }

        public class IndicatorLed
        {
            public int brightness { get; set; }
            public int state { get; set; }
        }

        public class Leds
        {
            public WhiteLed whiteLed { get; set; }
            public OrangeLed orangeLed { get; set; }
            public IndicatorLed indicatorLed { get; set; }
            public override string ToString()
            {
                return "White LED: " + System.Environment.NewLine + $"[state: {whiteLed.state}, brightness: {whiteLed.brightness}]" + System.Environment.NewLine +
                $"Orange LED: " + System.Environment.NewLine + $"[state: {orangeLed.state}, brightness: {orangeLed.brightness}]" + System.Environment.NewLine +
                $"Indicator LED: " + System.Environment.NewLine + $"[state: {indicatorLed.state}, brightness: {indicatorLed.brightness}]";
            }
        }
    }
}