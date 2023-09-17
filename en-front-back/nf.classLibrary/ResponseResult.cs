using System;
using System.Data;
using System.Collections.Generic;
namespace nf.classLibrary
{
	public class RespondResult
	{
		public RespondResult()
		{
		}
        public bool success { get; set; }
        public string dataType { get; set; }
        public string errorMessage { get; set; }
        public string successMessage { get; set; }
        public List<Dictionary<string, object>> data { get; set; }
        public string dataModel { get; set; }
        public int total { get; set; }
        public string dataTable { get; set; }
        public String Json { get; set; }
    }
}

