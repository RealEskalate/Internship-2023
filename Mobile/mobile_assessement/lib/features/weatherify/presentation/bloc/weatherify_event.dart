part of 'weatherify_bloc.dart';

abstract class WeatherifyEvent extends Equatable {
  final String cityName;
  const WeatherifyEvent({required this.cityName});

  @override
  List<Object> get props => [];
}

class SearchWeatherEvent extends WeatherifyEvent {
  final String cityName;

  const SearchWeatherEvent({required this.cityName})
      : super(cityName: cityName);

  @override
  List<Object> get props => [cityName];
}
