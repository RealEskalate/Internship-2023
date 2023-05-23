import 'package:equatable/equatable.dart';

class Weather extends Equatable {
  final String condition;
  final String conditionIcon;
  final double temperature;
  final double highTemperature;
  final double lowTemperature;
  final double windSpeed;
  final int humidity;
  final DateTime date;

  const Weather({
    required this.condition,
    required this.conditionIcon,
    required this.temperature,
    required this.highTemperature,
    required this.lowTemperature,
    required this.windSpeed,
    required this.humidity,
    required this.date,
  }) : super();

  @override
  List<Object> get props => [
        condition,
        conditionIcon,
        temperature,
        highTemperature,
        lowTemperature,
        windSpeed,
        humidity,
        date
      ];
}
