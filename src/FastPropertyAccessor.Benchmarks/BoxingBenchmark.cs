using BenchmarkDotNet.Attributes;

namespace FastPropertyAccessor.Benchmarks
{
    [MemoryDiagnoser]
    public class BoxingBenchmark
    {
        private PropertyAccessor _accessor;
        private Model _model;

        public BoxingBenchmark()
        {
            _model = new Model();
            _accessor = PropertyAccessor.Get(_model.GetType().GetProperty(nameof(Model.Value)));
        }

        [Benchmark]
        public void Boxing()
        {
            _accessor.SetValue(_model, 101);

        }

        [Benchmark]
        public void NoBoxing()
        {
            _accessor.SetInt32Value(_model, 101);
        }
    }
}