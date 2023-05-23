class WeatherData {
  final String city;
  final String observationTime;
  final double tempC;
  final double tempF;
  final int weatherCode;
  final String weatherIconUrl;
  final String weatherDesc;
  final double windspeedMiles;
  final double windspeedKmph;
  final int winddirDegree;
  final String winddir16Point;
  final double precipMM;
  final double precipInches;
  final double humidity;
  final double visibility;
  final double visibilityMiles;
  final double pressure;
  final double pressureInches;
  final double cloudcover;
  final double feelsLikeC;
  final double feelsLikeF;
  final int uvIndex;

  WeatherData({
    required this.city,
    required this.observationTime,
    required this.tempC,
    required this.tempF,
    required this.weatherCode,
    required this.weatherIconUrl,
    required this.weatherDesc,
    required this.windspeedMiles,
    required this.windspeedKmph,
    required this.winddirDegree,
    required this.winddir16Point,
    required this.precipMM,
    required this.precipInches,
    required this.humidity,
    required this.visibility,
    required this.visibilityMiles,
    required this.pressure,
    required this.pressureInches,
    required this.cloudcover,
    required this.feelsLikeC,
    required this.feelsLikeF,
    required this.uvIndex,
  });

  factory WeatherData.fromJson(Map<String, dynamic> json) {
    return WeatherData(
      city: json['data']['request'][0]['query'],
      observationTime: json['data']['current_condition'][0]['observation_time'],
      tempC: json['data']['current_condition'][0]['temp_C'],
      tempF: json['data']['current_condition'][0]['temp_F'],
      weatherCode: json['data']['current_condition'][0]['weatherCode'],
      weatherIconUrl: json['data']['current_condition'][0]['weatherIconUrl'][0]['value'],
      weatherDesc: json['data']['current_condition'][0]['weatherDesc'][0]['value'],
      windspeedMiles: json['data']['current_condition'][0]['windspeedMiles'],
      windspeedKmph: json['data']['current_condition'][0]['windspeedKmph'],
      winddirDegree: json['data']['current_condition'][0]['winddirDegree'],
      winddir16Point: json['data']['current_condition'][0]['winddir16Point'],
      precipMM: json['data']['current_condition'][0]['precipMM'],
      precipInches: json['data']['current_condition'][0]['precipInches'],
      humidity: json['data']['current_condition'][0]['humidity'],
      visibility: json['data']['current_condition'][0]['visibility'],
      visibilityMiles: json['data']['current_condition'][0]['visibilityMiles'],
      pressure: json['data']['current_condition'][0]['pressure'],
      pressureInches: json['data']['current_condition'][0]['pressureInches'],
      cloudcover: json['data']['current_condition'][0]['cloudcover'],
      feelsLikeC: json['data']['current_condition'][0]['FeelsLikeC'],
      feelsLikeF: json['data']['current_condition'][0]['FeelsLikeF'],
      uvIndex: json['data']['current_condition'][0]['uvIndex'],
    );
  }
}