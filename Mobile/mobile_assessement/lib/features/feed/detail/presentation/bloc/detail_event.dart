part of 'detail_bloc.dart';

abstract class DetailEvent extends Equatable {
  const DetailEvent();

  @override
  List<Object> get props => [];
}
class GetWeatherEvent extends DetailEvent {
  String city;
  GetWeatherEvent({required this.city});

  @override
  List<Object> get props => [city];
}


