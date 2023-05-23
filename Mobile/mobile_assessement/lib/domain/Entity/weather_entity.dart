import 'package:equatable/equatable.dart';

class WeatherEntity extends Equatable {
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

  WeatherEntity({
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
  
  @override
  // TODO: implement props
  List<Object?> get props => [
     city,
observationTime,
tempC,
tempF,
weatherCode,
weatherIconUrl,
weatherDesc,
windspeedMiles,
windspeedKmph,
winddirDegree,
winddir16Point,
precipMM,
precipInches,
humidity,
visibility,
visibilityMiles,
pressure,
pressureInches,
cloudcover,
feelsLikeC,
feelsLikeF,
uvIndex,
  
  ];
}