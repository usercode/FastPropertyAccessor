using BenchmarkDotNet.Attributes;
using System.Reflection;

namespace FastPropertyAccessor.Benchmarks
{
    [MemoryDiagnoser]
    public class DirectAccessBenchmark
    {
        private PropertyAccessor _accessor;
        private TypeAccessor _typeAccessor;
        private PropertyInfo _propertyInfo;
        private Action<Model> _delegateCall;
        private Model _model;
        private FastMember.TypeAccessor _fastMember;

        public DirectAccessBenchmark()
        {
            _model = new Model();
            _typeAccessor = TypeAccessor.Get(_model.GetType());
            _propertyInfo = _model.GetType().GetProperty(nameof(Model.Value))!;
            _accessor = PropertyAccessor.Get(_propertyInfo);
            _delegateCall = x => x.Value = 101;
            _fastMember = FastMember.TypeAccessor.Create(_model.GetType());

        }

        [Benchmark(Baseline = true)]
        public void UseDirectCall()
        {
            _model.Value = 101;
        }

        [Benchmark]
        public void UseDelegateCall()
        {
            _delegateCall(_model);
        }

        [Benchmark]
        public void UsePropertyAccessorWithBoxing()
        {
            _accessor.SetValue(_model, 101);
        }

        [Benchmark]
        public void UsePropertyAccessor()
        {
            _accessor.SetInt32Value(_model, 101);
        }

        [Benchmark]
        public void UseTypeAccessor()
        {
            _typeAccessor[_model, nameof(Model.Value)] = 101;
        }

        [Benchmark]
        public void UseFastMember()
        {
            _fastMember[_model, nameof(Model.Value)] = 101;
        }

        [Benchmark]
        public void UseReflection()
        {
            _propertyInfo.SetValue(_model, 101);
        }
    }
}