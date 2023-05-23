import 'package:equatable/equatable.dart';

class CityWeatherModel extends Equatable {
  final String cityName;
  final String oldestDate;
  final double avgTempc;
  final double currentTempc;
  final String weatherDescription;
  final String iconUrl;

  CityWeatherModel({
    required this.cityName,
    required this.oldestDate,
    required this.avgTempc,
    required this.currentTempc,
    required this.weatherDescription,
    required this.iconUrl,
  });

  @override
  List<Object?> get props => [
        cityName,
        oldestDate,
        avgTempc,
        currentTempc,
        weatherDescription,
        iconUrl,
      ];
}
