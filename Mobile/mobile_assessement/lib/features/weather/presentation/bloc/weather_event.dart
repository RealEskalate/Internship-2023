part of 'weather_bloc.dart';

abstract class WeatherEvent extends Equatable {
  @override
  List<Object?> get props => [];
}

class GetWeatherEvent extends WeatherEvent {
  final String cityName;

  GetWeatherEvent({required this.cityName});
}
