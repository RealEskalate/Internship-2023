import 'package:equatable/equatable.dart';

class HomeDetail extends Equatable {
  final String city;
  final String description;
  final int temperature;
  final String date;
  // final int favourites;
  // final List<String> everyday;
  const HomeDetail({
    required this.city,
    required this.date,
    required this.description,
    required this.temperature,
    // required this.favourites,
    // required this.everyday,
  });
  @override
  List<Object?> get props => [city, date, description, temperature];
}
