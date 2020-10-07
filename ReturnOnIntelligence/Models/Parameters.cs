using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReturnOnIntelligence.Models
{
    public abstract class BaseParameters
    {
        protected BaseParameters()
        {
            Parameters = new Dictionary<string, object>();
        }

        protected readonly Dictionary<string, object> Parameters;

        public object this[string key]
        {
            get
            {
                object value;
                Parameters.TryGetValue(key, out value);

                return value;
            }
            set
            {
                if (value == null)
                    return;

                Parameters[key] = value;
            }
        }

        public static implicit operator string(BaseParameters parameters)
        {
            return parameters.ToString();
        }

        public virtual bool AreValid => Parameters.Count > 0;

        public override string ToString()
        {
            return string.Join("&", Parameters.Select(x => $"{x.Key}={x.Value}"));
        }
    }

    public class RequestParameters : BaseParameters
    {
        public RequestParameters()
        {
            PageSize  = 10;
            PageIndex = 1;

            Format = "xml";
        }

        public string Format
        {
            get
            {
                return this["format"]?.ToString();
            }
            set
            {
                this["format"] = value;
            }
        }

        public RequestParameters Paginate()
        {
            this["results_per_page"] = PageSize * PageIndex + 1;
            return this;
        }

        public int PageSize { get; }
        public int PageIndex { get; set; }

        public int NumOfElements => PageSize * PageIndex;

        public string Category
        {
            get
            {
                return this["category"]?.ToString();
            }
            set
            {
                this["category"] = value;
            }
        }

        public override bool AreValid => !string.IsNullOrWhiteSpace(Category);
    }
}