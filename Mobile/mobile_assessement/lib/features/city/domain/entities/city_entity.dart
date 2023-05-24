import 'package:equatable/equatable.dart';
import 'weather_entity.dart';

class City extends Equatable {
  final String name;
  final List<Weather> weathers;
  const City({required this.name, required this.weathers});

  @override
  List<Object?> get props => [name, weathers];
}
