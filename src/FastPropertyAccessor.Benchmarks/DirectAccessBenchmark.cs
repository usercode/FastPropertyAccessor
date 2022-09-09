using BenchmarkDotNet.Attributes;
using FastMember;
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
        private Member _fastMemberProperty;

        public DirectAccessBenchmark()
        {
            _model = new Model();
            _typeAccessor = TypeAccessor.Get(_model.GetType());
            _propertyInfo = _model.GetType().GetProperty(nameof(Model.Value))!;
            _accessor = PropertyAccessor.Get(_propertyInfo);
            _delegateCall = x => x.Value = 101;
            _fastMember = FastMember.TypeAccessor.Create(_model.GetType());
        }

        [Benchmark(Baseline = true, Description = "DirectCall")]
        public void UseDirectCall()
        {
            _model.Value = 101;
        }

        [Benchmark(Description = "DelegateCall")]
        public void UseDelegateCall()
        {
            _delegateCall(_model);
        }

        [Benchmark(Description = "PropertyAccessorNoBoxing")]
        public void UsePropertyAccessorNoBoxing()
        {
            _accessor.SetInt32Value(_model, 101);
        }

        [Benchmark(Description = "PropertyAccessor")]
        public void UsePropertyAccessorBoxing()
        {
            _accessor.SetValue(_model, 101);
        }

        [Benchmark(Description = "TypeAccessor")]
        public void UseTypeAccessor()
        {
            _typeAccessor[_model, nameof(Model.Value)] = 101;
        }

        [Benchmark(Description = "FastMemberTypeAccessor")]
        public void UseFastMember()
        {
            _fastMember[_model, nameof(Model.Value)] = 101;
        }

        [Benchmark(Description = "Reflection")]
        public void UseReflection()
        {
            _propertyInfo.SetValue(_model, 101);
        }
    }
}