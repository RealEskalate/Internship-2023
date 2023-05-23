part of 'weather_bloc.dart';

@immutable
abstract class WeatherState extends Equatable {
  WeatherState();
  @override
  List<Object> get props => [];

}

class WeatherInitial extends WeatherState {}
class WeatherLoading extends WeatherState {}
class WeatherLoaded extends WeatherState{
  final Weather weather;

  WeatherLoaded({required this.weather});

  @override
  List<Object> get props => [weather];  
}
class WeatherFailure extends WeatherState {
  final Failure error;

  WeatherFailure({required this.error});

  @override
  List<Object> get props => [error];
}
