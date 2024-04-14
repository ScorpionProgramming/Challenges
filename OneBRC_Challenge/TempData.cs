using System.Text;

namespace OneBRC_Challenge {
    public class TempData {
        public float low { get; set; }
        public float mean { get; set; }
        public float high { get; set; }

        public TempData(float low, float mean, float high) {
            this.low = low;
            this.mean = mean;
            this.high = high;
        }

        public TempData(float value) {
            this.low = value;
            this.mean = value;
            this.high = value;
        }

        public string ToString( ) {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.low.ToString("0.0")).Append(";");
            sb.Append(this.mean.ToString("0.0")).Append(";");
            sb.Append(this.high.ToString("0.0")).Append(";");
            return sb.ToString();
        }
    }
}
