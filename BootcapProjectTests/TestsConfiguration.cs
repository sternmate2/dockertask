using System;
using System.IO;
using System.Text.Json;

namespace BootcampTest
{	
	public class TestsConfiguration
    {
		//bool? _testResults;
        public string FailTestResults { get; set; }

        public bool GetTestResults()
        {
            string jsonString = File.ReadAllText("Configurations/Tests.json");
            return Convert.ToBoolean(JsonSerializer.Deserialize<TestsConfiguration>(jsonString).FailTestResults.ToLower());
        }
    }	
}
