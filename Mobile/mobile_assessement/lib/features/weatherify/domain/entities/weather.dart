class Weather {
  final String cityName;
  final String date;
  final String weatherDesc;
  final String image;
  final String temperature;

  Weather(
      {required this.temperature,
      required this.cityName,
      required this.date,
      required this.weatherDesc,
      required this.image});
}
