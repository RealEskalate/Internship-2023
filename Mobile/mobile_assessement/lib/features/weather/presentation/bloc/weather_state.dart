part of 'weather_bloc.dart';

abstract class WeatherState extends Equatable {
  const WeatherState();
  
  @override
  List<Object> get props => [];
}

class WeatherInitial extends WeatherState {}



class WeatherLoading extends WeatherState {}

class WeatherSuccess extends WeatherState {

  final TemperatureData  temperatureData ;

  WeatherSuccess({required this.temperatureData});

  @override
  List<Object> get props => [temperatureData];
}


class WeatherFailure extends WeatherState{

  WeatherFailure();

  @override
  List<Object> get props => [];
}