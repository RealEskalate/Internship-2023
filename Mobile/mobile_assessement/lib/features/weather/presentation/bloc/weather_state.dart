part of 'weather_bloc.dart';

abstract class WeatherState extends Equatable {
  const WeatherState();

  @override
  List<Object> get props => [];
}

class WeatherInitial extends WeatherState {}

class SearchLoadingState extends WeatherState {}

class SearchSuccessState extends WeatherState {
  final CityWeatherDetail detail;
  SearchSuccessState(this.detail);
}

class SearchFailureState extends WeatherState {}
