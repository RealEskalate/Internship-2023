import 'package:equatable/equatable.dart';

class CityWeather extends Equatable {
  final String cityName;
  final String oldestDate;
  final double avgTempc;

  const CityWeather({
    required this.cityName,
    required this.oldestDate,
    required this.avgTempc,
  });

  @override
  List<Object?> get props => [cityName, oldestDate, avgTempc];
}
