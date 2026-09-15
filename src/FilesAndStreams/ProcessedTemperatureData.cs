namespace FilesAndStreams;

/// <summary>
/// Represents the processed temperature data.
/// </summary>
internal class ProcessedTemperatureData
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProcessedTemperatureData"/> class.
    /// </summary>
    /// <param name="minimum">Minimum temperature recorded.</param>
    /// <param name="maximum">Maximum temperature recorded</param>
    /// <param name="average">Average temperature recorded</param>
    public ProcessedTemperatureData(double minimum, double maximum, double average)
    {
        this.MinimumTemperature = minimum;
        this.MaximumTemperature = maximum;
        this.AverageTemperature = average;
    }

    /// <summary>
    /// Gets or sets the minimum temperature
    /// </summary>
    /// <value>Represents the minimum temperature recorded.</value>
    public double MinimumTemperature { get; set; }

    /// <summary>
    /// Gets or sets the maximum temperature
    /// </summary>
    /// <value>Represents the maximum temperature recorded.</value>
    public double MaximumTemperature { get; set; }

    /// <summary>
    /// Gets or sets the average temperature
    /// </summary>
    /// <value>Represents the average temperature recorded.</value>
    public double AverageTemperature { get; set; }
}