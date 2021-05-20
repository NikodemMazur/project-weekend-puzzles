using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ProjectWeekendPuzzles.Core.ApiServer
{
    /// <summary>
    /// Class for collecting api services. This collection is used later in endpoint mapping.
    /// </summary>
    public class ApiServiceCollection
    {
        private ImmutableList<Type> _types = ImmutableList.Create<Type>();

        public ApiServiceCollection AddApiService<T>() where T : class
        {
            _types = _types.Add(typeof(T));

            return this;
        }

        public IEnumerable<Type> ServiceTypes => _types;
    }
}
