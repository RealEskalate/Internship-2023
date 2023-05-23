import 'package:equatable/equatable.dart';
import 'package:mobile_assessement/core/errors/failures.dart';
import 'package:mobile_assessement/features/weather_forcast/domain/entities/weather_forcast.dart';
import 'package:mobile_assessement/features/weather_forcast/domain/entities/weather.dart';

abstract class WeatherState extends Equatable {
 const WeatherState();

 @override
 List<Object> get props => [];
}

class WeatherInitial extends WeatherState {}

class WeatherLoading extends WeatherState {}

class WeatherLoaded extends WeatherState {
 final Weather? weather;
 final WeatherForecast? forecast;

 const WeatherLoaded(this.weather, this.forecast);

 @override
 List<Object> get props => [weather ?? Object(), forecast ?? Object()];
}

class WeatherError extends WeatherState {
 final Failure failure;

 const WeatherError(this.failure);

 @override
 List<Object> get props => [failure];
}
