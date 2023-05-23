import 'package:equatable/equatable.dart';

class Weather  extends Equatable{
  final String cityName;
  final double maxtemperature;
  final double mintemperature;
  final List<String> next7DaysTemps;
  final String date;

   const Weather({
    required this.cityName,
    required this.mintemperature,
    required this.maxtemperature,
    required this.next7DaysTemps,
    required this.date,
    
  }): super();
  
  @override
  List<Object> get props => [
        cityName,
        mintemperature,
        maxtemperature,
        next7DaysTemps,
        date
      ];
}
