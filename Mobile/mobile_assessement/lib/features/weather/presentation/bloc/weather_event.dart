part of 'weather_bloc.dart';

abstract class WeatherEvent extends Equatable {
  const WeatherEvent();

  @override
  List<Object> get props => [];
}

class SearchCityEvent extends WeatherEvent {
  final String query;
  SearchCityEvent(this.query);
}
