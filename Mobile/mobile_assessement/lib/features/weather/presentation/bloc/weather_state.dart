part of 'weather_bloc.dart';

abstract class WeatherState extends Equatable {
  const WeatherState();

  @override
  List<Object?> get pros => [];
}

class WeatherInitialState extends WeatherState {
  @override
  List<Object?> get props => [];
}

class WeatherLoadingState extends WeatherState {
  @override
  List<Object?> get props => [];
}

class WeatherSuccessState extends WeatherState {
  final Weather weather;

  const WeatherSuccessState({required this.weather});
  @override
  List<Object?> get props => [weather];
}

class WeatherFailureState extends WeatherState {
  final Failure error;

  const WeatherFailureState({required this.error});
  @override
  List<Object?> get props => [error];
}
