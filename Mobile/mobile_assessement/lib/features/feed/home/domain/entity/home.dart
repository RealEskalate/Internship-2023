import 'package:equatable/equatable.dart';

class Home extends Equatable {
  final String city;
  final String country;
  final int temperature;

  const Home({
    required this.country,
    required this.city,
    required this.temperature,
  });
  @override
  List<Object?> get props => [city, country,temperature];
}
