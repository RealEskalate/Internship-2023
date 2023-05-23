part of 'weather_bloc.dart';

@immutable
abstract class WeatherEvent extends Equatable {
  const WeatherEvent();
   @override
  List<Object> get props => [];
}



class SearchEvent extends WeatherEvent {
  final String query;

  const SearchEvent(this.query);
}
