using System;

namespace WorkshopTool
{
    public class ProgressData : IProgress<float>
    {
        private float _Value = 0;
        public event Action<float> Progress = delegate { };

        public void Report(float value)
        {
            if (_Value >= value) return;

            _Value = value;
            Progress?.Invoke(_Value);

            Console.WriteLine(value);
        }

        public void Reset()
        {
            _Value = 0;
            Progress?.Invoke(_Value);
        }
    }
}
