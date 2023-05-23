part of 'weather_bloc.dart';

abstract class WeatherEvent extends Equatable {
  const WeatherEvent();

  @override
  List<Object> get props => [];
}
class GetWeatherEvent extends WeatherEvent {
  final String city;

  const GetWeatherEvent({required this.city});

  @override
  List<Object> get props => [city];
}