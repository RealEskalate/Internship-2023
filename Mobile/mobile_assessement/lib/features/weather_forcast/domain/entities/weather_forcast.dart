import 'package:equatable/equatable.dart';
import 'package:mobile_assessement/features/weather_forcast/domain/entities/weather.dart';

class WeatherForecast extends Equatable {
  final List<Weather> forecast;

  const WeatherForecast({
    required this.forecast,
  }) : super();

  @override
  List<Object> get props => [forecast];
}
