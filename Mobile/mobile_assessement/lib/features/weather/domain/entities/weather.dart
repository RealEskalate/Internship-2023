import 'package:equatable/equatable.dart';
import 'package:meta/meta.dart';

class Weather extends Equatable {
  final String city;
  final double temprature;
  final String description;
  final String favKey;

  Weather({
    required this.city,
    required this.temprature,
    required this.description,
    required this.favKey,
  });

  @override
  List<Object> get props => [city, temprature, description, favKey];
}

class SearchQuery {
  final String cityName;

  SearchQuery({required this.cityName});
}
