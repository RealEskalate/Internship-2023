import 'package:equatable/equatable.dart';

class Weather  extends Equatable{
  final String cityName;
  final double temperature;
  final double humidity;
  final String description;

   const Weather({
    required this.cityName,
    required this.temperature,
    required this.humidity,
    required this.description,
  }): super();
  
  @override
  List<Object> get props => [
        cityName,
        temperature,
        humidity,
        description,
      ];
}
