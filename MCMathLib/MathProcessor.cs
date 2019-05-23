using Common.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;


namespace MCMathLib
{
    public class MathProcessor : IMathProcessor
    {
        private readonly AppSettings _config;
        private readonly ILogger<MathProcessor> _logger;

        public MathProcessor(IOptions<AppSettings> config, ILogger<MathProcessor> logger)
        {
            _config = config.Value;
            _logger = logger;
        }

        double IMathProcessor.Calculate(double num1, double num2, string op)
        {
            double result = 0;

            switch (op)
            {
                case "Add":
                    _logger.LogInformation("Inside the Calculate/Add function");
                    result = (num1 + num2)*_config.Modifier;
                    break;
                case "Sub":
                    result = num1 - num2;
                    break;
                case "Mul":
                    result = num1 * num2;
                    break;
                case "Div":
                    result = num1 / num2;
                    break;
            }

            return result;

        }

    }

    public interface IMathProcessor
    {
        double Calculate(double num1, double num2, string op);
    }
}
