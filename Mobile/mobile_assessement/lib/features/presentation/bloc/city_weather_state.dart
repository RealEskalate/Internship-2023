part of 'city_weather_bloc.dart';

abstract class CityWeatherState extends Equatable {
  const CityWeatherState();

  @override
  List<Object> get props => [];
}

class CityWeatherInitial extends CityWeatherState {}

class Loadingstate extends CityWeatherState {}

// ignore: must_be_immutable
class LoadedState extends CityWeatherState {
  final String cityName;
  final double temperature;
  final double humidity;
  final String weatherDescription;

  const LoadedState(
      {required this.cityName,
      required this.humidity,
      required this.temperature,
      required this.weatherDescription});
}

class FailedState extends CityWeatherState {
  
}
