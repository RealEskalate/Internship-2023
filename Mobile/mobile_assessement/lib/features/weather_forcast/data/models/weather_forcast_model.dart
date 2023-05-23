
import 'package:mobile_assessement/features/weather_forcast/data/models/weather_model.dart';
import 'package:mobile_assessement/features/weather_forcast/domain/entities/weather_forcast.dart';

class WeatherForecastModel extends WeatherForecast {
  const WeatherForecastModel({required List<WeatherModel> forecast})
      : super(forecast: forecast);

  factory WeatherForecastModel.fromJson(Map<String, dynamic> json) {
    return WeatherForecastModel(
        forecast: (json['list'] as List)
            .map((e) => WeatherModel.fromJson(e))
            .toList());
  }

  Map<String, dynamic> toJson() {
    return {
      'list': (forecast as List<WeatherModel>).map((e) => e.toJson()).toList()
    };
  }
}