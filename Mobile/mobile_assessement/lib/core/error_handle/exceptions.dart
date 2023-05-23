class WeatherDataNotFoundException implements Exception {
  final String message;

  WeatherDataNotFoundException(this.message);
}