import 'package:equatable/equatable.dart';

class Weather extends Equatable {
  final String city;
  final double temperature;
  final double humidity;
  final String weatherDescription;

  Weather({
    required this.city,
    required this.temperature,
    required this.humidity,
    required this.weatherDescription,
  });

  @override
  List<Object?> get props => [city, temperature, humidity, weatherDescription];
}
