import 'package:equatable/equatable.dart';

abstract class WeatherEvent extends Equatable {
 const WeatherEvent();

 @override
 List<Object> get props => [];
}

class GetCurrentWeatherEvent extends WeatherEvent {
 final String city;

 const GetCurrentWeatherEvent(this.city);

 @override
 List<Object> get props => [city];
}

class GetWeatherForecastEvent extends WeatherEvent {
 final String city;

 const GetWeatherForecastEvent(this.city);

 @override
 List<Object> get props => [city];
}
