using System.Collections.Generic;
using System.Linq;

namespace Algorithm.Composition
{
    public class HighPassSummingAggregator: IMeasurementFilter, IAggregationStrategy
    {
        public HighPassSummingAggregator(IEnumerable<Measurement> measurements)
        {
            _measurements = measurements;
        }
        

        public IEnumerable<Measurement> Filter(IEnumerable<Measurement> measurements)
        {
            return measurements.Where(m => m.X > 2 & m.Y > 2);
        }

        public Measurement Aggregate(IEnumerable<Measurement> measurements)
        {
            return new Measurement { X = measurements.Sum(m => m.X), Y = measurements.Sum(m => m.Y) };
        }

        public Measurement Aggregate()
        {
            var measurements = _measurements;
            measurements = Filter(measurements);            
            return Aggregate(measurements);
        }
        
        private readonly IEnumerable<Measurement> _measurements;
    }
}