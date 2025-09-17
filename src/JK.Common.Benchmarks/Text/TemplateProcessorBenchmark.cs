using BenchmarkDotNet.Attributes;
using JK.Common.Text;
using System.Collections.Generic;
using System.Text;

namespace JK.Common.Benchmarks.Text;

[MemoryDiagnoser]
public class TemplateProcessorBenchmark
{
    private List<object> _objects;
    private TemplateProcessor _smallProcessor;
    private TemplateProcessor _largeProcessor;

    [GlobalSetup]
    public void Setup()
    {
        Person person = new() { Name = "John", Age = 30 };
        _objects = [person];

        // Small template
        var smallTemplate = "Hello, {{Person.Name}}! You are {{Person.Age}} years old.";
        _smallProcessor = new TemplateProcessor(smallTemplate)
        {
            Objects = _objects
        };

        // Large template
        var sb = new StringBuilder();
        for (var i = 0; i < 100; i++)
        {
            sb.Append($"Person {i}: {{{{Person.Name}}}}, Age: {{{{Person.Age}}}}\n");
        }
        var largeTemplate = sb.ToString();
        _largeProcessor = new TemplateProcessor(largeTemplate)
        {
            Objects = _objects
        };
    }

    [Benchmark]
    public string ProcessTemplate_Small() => _smallProcessor.ProcessTemplate();

    [Benchmark]
    public string ProcessTemplate_Large() => _largeProcessor.ProcessTemplate();

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
