part of 'city_weather_bloc.dart';

abstract class CityWeatherEvent extends Equatable {
  const CityWeatherEvent();

  @override
  List<Object> get props => [];
}

class GetStarted extends CityWeatherEvent {}

class SearchEvent extends CityWeatherEvent {
  String cityName;
  SearchEvent({required this.cityName});
}
