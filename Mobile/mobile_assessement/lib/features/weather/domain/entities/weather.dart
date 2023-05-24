class Weather {
  final String averageTemp;
  final String minTemperature;
  final String maxTemperature;
  final String humidity;
  final String description;

  Weather({
    required this.minTemperature,
    required this.maxTemperature,
    required this.humidity,
    required this.description,
    required this.averageTemp,
  });
}
